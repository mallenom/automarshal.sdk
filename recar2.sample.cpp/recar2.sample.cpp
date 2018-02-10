#include "stdafx.h"
#include "atlcom.h"

#include "recar2.sample.h"
#include "MainForm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

CComModule _Module;
extern __declspec(selectany) CAtlModule* _pAtlModule = &_Module;

using namespace Recar2;

const UINT SINK_ID = 234231341;
const UINT DISP_ID = 0x60020000;

#define RECAR2_SDK_VER_MAJOR 2
#define RECAR2_SDK_VER_MINOR 32

// {3BF28819-4854-46FE-85C8-813425514952}
DEFINE_GUID(CLSID_VideoCoreEventsSink,
	0x3bf28819, 0x4854, 0x46fe, 0x85, 0xc8, 0x81, 0x34, 0x25, 0x51, 0x49, 0x52);

// Class helper for invoked event of recognized plate
class ATL_NO_VTABLE VideoCoreEventsSink :
	public CComObjectRootEx<CComMultiThreadModel>,
	public CComCoClass<VideoCoreEventsSink, &CLSID_VideoCoreEventsSink>,
	public IDispatchImpl<_IVideoCoreEvents, &__uuidof(_IVideoCoreEvents), &GUID_NULL>,
	public IDispEventImpl<SINK_ID, VideoCoreEventsSink, &__uuidof(_IVideoCoreEvents), &__uuidof(__recar2_com), RECAR2_SDK_VER_MAJOR, RECAR2_SDK_VER_MINOR>
{
public:
	BEGIN_COM_MAP(VideoCoreEventsSink)
		COM_INTERFACE_ENTRY(IDispatch)
		COM_INTERFACE_ENTRY(_IVideoCoreEvents)
	END_COM_MAP()

	BEGIN_SINK_MAP(VideoCoreEventsSink)
		SINK_ENTRY_EX(SINK_ID, __uuidof(_IVideoCoreEvents), DISP_ID, OnEvent)
	END_SINK_MAP()

public:
	HRESULT __stdcall OnEvent(struct IRecarSolution* solution) const
	{
		Form->NumberRecognized(solution);
		return S_OK;
	}

	MainForm* Form;
};

BEGIN_MESSAGE_MAP(SampleApp, CWinApp)
END_MESSAGE_MAP()

SampleApp theApp;

SampleApp::SampleApp()
{
	m_dwRestartManagerSupportFlags = AFX_RESTART_MANAGER_SUPPORT_RESTART;
}

void SampleApp::OnEvent(struct IRecarSolution* solution) const
{
	static_cast<MainForm*>(m_pMainWnd)->NumberRecognized(solution);
}

BOOL SampleApp::InitInstance()
{
	CWinApp::InitInstance();

	AfxEnableControlContainer();

	const auto pShellManager = new CShellManager;
	CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerWindows));
	SetRegistryKey(_T("Local AppWizard-Generated Applications"));

	IVideoCorePtr core;
	VideoCoreEventsSink* pSinker;
	try
	{
		// Initialize COM/OLE
		CoInitialize(nullptr);

		// Create core instance
		core = IVideoCorePtr(_uuidof(VideoCoreCom));

		//auto callback = new NumberRecognizedHandler(&SampleApp::OnEvent);
		//core->SetNumberRecognizedCallback(callback);

		// Set videochannel count
		core->PutVideoProcessChannelCount(2);
		// Convert plate to caps Latin symbols
		core->PutConvertPlateToCapsLatin(true);

		// Subscribe event of recognized plate
		VideoCoreEventsSink::_CreatorClass::CreateInstance(nullptr, __uuidof(Recar2::_IVideoCoreEvents), reinterpret_cast<void**>(&pSinker));
		if(pSinker)
		{
			pSinker->DispEventAdvise(core);
		}
	}
	catch(_com_error& exc)
	{
		::MessageBoxW(nullptr, exc.ErrorMessage(), L"Initialize core fail.", MB_OK);
		core->Dispose();
		return FALSE;
		printf("_com_error:\nError       : %08lX\nErrorMessage: %ls\nDescription : %ls\nSource      : %ls\n", exc.Error(),
			static_cast<LPCTSTR>(_bstr_t(exc.ErrorMessage())), static_cast<LPCTSTR>(_bstr_t(exc.Description())), static_cast<LPCTSTR>(_bstr_t(exc.Source())));
	}

	MainForm dlg(core);
	m_pMainWnd = &dlg;
	pSinker->Form = &dlg;
	auto nResponse = dlg.DoModal();

	if(pShellManager != nullptr)
	{
		delete pShellManager;
	}

	// Unsubscribe event of recognized plate
	pSinker->DispEventUnadvise(core);
	// Destroy core
	core->Dispose();
	// Uninitialize COM
	CoUninitialize();

	return FALSE;
}
