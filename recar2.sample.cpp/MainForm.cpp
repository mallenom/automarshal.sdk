#include "stdafx.h"
#include "afxdialogex.h"
#include "recar2.sample.h"

#include <tuple>
#include <vector>

#include "MainForm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

using namespace std;

using namespace Recar2;

// Uses in callback function
struct RecarSolutionStruct
{
	// State passed by registration callback
	__int64 State;
	// Event identificator
	__int64 EventId;
	// Camera identificator
	__int32 CameraId;
	// Plate number
	wchar_t* Number;
	// Plate number type
	wchar_t* NumberType;
	// Timestamp best frame with plate number
	time_t TimeStamp;
	// Plate number direction on frame
	__int32 MovementDirection;
};

MainForm::MainForm(IVideoCorePtr core, CWnd* pParent /*=NULL*/)
	: CDialogEx(MainForm::IDD, pParent)
{
	_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	_core = core;
}

void MainForm::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_STATIC_COUNT, _txtCount);
}

BEGIN_MESSAGE_MAP(MainForm, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON_INIT_CORE, &MainForm::OnBnClickedButtonInitCore)
	ON_BN_CLICKED(IDC_BUTTON_DEINIT_CORE, &MainForm::OnBnClickedButtonDeinitCore)
	ON_BN_CLICKED(IDC_BUTTON_SETUP, &MainForm::OnBnClickedButtonSetup)
	ON_BN_CLICKED(IDC_BUTTON_ALG_SETUP1, &MainForm::OnBnClickedButtonAlgSetup1)
	ON_BN_CLICKED(IDC_BUTTON_ALG_SETUP2, &MainForm::OnBnClickedButtonAlgSetup2)
	ON_BN_CLICKED(IDC_BUTTON_START, &MainForm::OnBnClickedButtonStart)
	ON_BN_CLICKED(IDC_BUTTON_STOP, &MainForm::OnBnClickedButtonStop)
	ON_CBN_SELCHANGE(IDC_CMB_PARAM_NAME, &MainForm::OnCbnSelchangeCmbParamName)
	ON_BN_CLICKED(IDC_BTN_SET_PARAM_VALUE, &MainForm::OnBnClickedBtnSetParamValue)
END_MESSAGE_MAP()

BOOL MainForm::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	SetIcon(_hIcon, TRUE);
	SetIcon(_hIcon, FALSE);

	auto list = static_cast<CListCtrl*>(GetDlgItem(IDC_LIST_NUMBERS));
	list->InsertColumn(0, L"Id", 0, 40);
	list->InsertColumn(1, L"Plate", 0, 70);
	list->InsertColumn(2, L"Camera", 0, 60);
	list->InsertColumn(3, L"Timestamp", 0, 120);
	list->InsertColumn(4, L"Direction", 0, 70);
	list->InsertColumn(5, L"Remark", 0, 150);
	list->InsertColumn(6, L"File", 0, 150);

	return TRUE;
}

void MainForm::UpdateGrid(IRecarSolution* solution)
{
	auto list = static_cast<CListCtrl*>(GetDlgItem(IDC_LIST_NUMBERS));
	int num = list->GetItemCount();
	_bstr_t number = solution->GetNumber();
	int index = list->InsertItem(num, number);
	wchar_t str[128];
	::_ltow_s(solution->GetEventId(), str, 10);
	list->SetItemText(index, 0, str);
	list->SetItemText(index, 1, number);
	::_ltow_s(solution->GetCameraId(), str, 10);
	list->SetItemText(index, 2, str);
	auto timestamp = COleDateTime(solution->TimeStamp);
	list->SetItemText(index, 3, timestamp.Format(L"%d.%m.%Y %H:%M:%S"));
	switch(solution->GetMovementDirection())
	{
	case 0: list->SetItemText(index, 4, L"Undefined"); break;
	case 1: list->SetItemText(index, 4, L"Bottom up"); break;
	case 2: list->SetItemText(index, 4, L"Up down"); break;
	}
	list->SetItemText(index, 5, L"Event raised");
	_bstr_t filename = solution->GetImageFileName();
	list->SetItemText(index, 6, filename);

	::SysFreeString(number);
	::SysFreeString(filename);
}

void MainForm::UpdateGrid(RecarSolutionStruct* solution)
{
	//_bstr_t filename;
	auto list = static_cast<CListCtrl*>(GetDlgItem(IDC_LIST_NUMBERS));
	int num = list->GetItemCount();
	_bstr_t number = solution->Number;
	int index = list->InsertItem(num, number);
	wchar_t str[128];
	::_ltow_s(solution->EventId, str, 10);
	list->SetItemText(index, 0, str);
	list->SetItemText(index, 1, number);
	::_ltow_s(solution->CameraId, str, 10);
	list->SetItemText(index, 2, str);
	auto timestamp = COleDateTime(solution->TimeStamp);
	list->SetItemText(index, 3, timestamp.Format(L"%d.%m.%Y %H:%M:%S"));
	switch (solution->MovementDirection)
	{
	case 0: list->SetItemText(index, 4, L"Undefined"); break;
	case 1: list->SetItemText(index, 4, L"Bottom up"); break;
	case 2: list->SetItemText(index, 4, L"Up down"); break;
	}
	list->SetItemText(index, 5, L"Callback");

	::SysFreeString(number);
	//::SysFreeString(filename);
}


// Invoked when plate recognized
void MainForm::NumberRecognized(struct IRecarSolution* solution)
{
	IRecarSolution* p;
	if(SUCCEEDED(solution->QueryInterface<IRecarSolution>(&p)) && p != nullptr)
	{
		UpdateGrid(p);

		++_count;
		wchar_t str1[20];
		::swprintf_s(str1, L"Count: %i", _count);
		//_txtCount.SetWindowTextW( L"Count: " + ::_itow(_count, str1, 10));
		_txtCount.SetWindowTextW(str1);

		// Save current image to file
		//p->SaveImageToFile(L"1.bmp");
		//p->SaveImageToFile(L"1.jpeg");

		p->Release();
	}
}

HRESULT static __stdcall OnEventNumberRecognition(RecarSolutionStruct* solution)
{
	auto form = reinterpret_cast<MainForm*>(solution->State);
	form->UpdateGrid(solution);
	return S_OK;
}

void MainForm::OnSysCommand(UINT nID, LPARAM lParam)
{
	CDialogEx::OnSysCommand(nID, lParam);
}

void MainForm::OnPaint()
{
	if(IsIconic())
	{
		CPaintDC dc(this);
		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;
		dc.DrawIcon(x, y, _hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

HCURSOR MainForm::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(_hIcon);
}

void MainForm::OnBnClickedButtonInitCore()
{
	try
	{
		// Initialize core
		_core->Initialize();
		// Load settings from configure file
		_core->LoadSettings();

		// Show/hide video forms
		_core->SetVideoFormsVisible(true);

		_core->RegisterNumberRecognizedCallback(reinterpret_cast<__int64>(OnEventNumberRecognition), reinterpret_cast<__int64>(this));

		// Settings set sample
		//_core->SetSettingValue(L"Kernel.VideoChannel0.ProcessUnit", L"DecisionTimeout", 100);
		//_core->SetSettingValue(L"Kernel.VideoChannel0.ProcessUnit", L"DecisionKeepTimeout", 0); // Disable bloсking duplicate
		
		// Set plate sizes
		//_core->SetSettingValue(L"Kernel.VideoChannel0.ProcessUnit", L"Plate1Width", 0.178f); // Plate min width (default 0.07)
		//_core->SetSettingValue(L"Kernel.VideoChannel0.ProcessUnit", L"Plate1Height", 0.056f); // Plate min height (default 0.031)
		//_core->SetSettingValue(L"Kernel.VideoChannel0.ProcessUnit", L"Plate2Width", 0.189f); // Plate max width (default 0.17)
		//_core->SetSettingValue(L"Kernel.VideoChannel0.ProcessUnit", L"Plate2Height", 0.059f); // Plate max height (default 0.031)

		UpdateSettings();
		UpdateControls(TRUE);
	}
	catch(const _com_error& exc)
	{
		::MessageBoxW(GetSafeHwnd(), exc.Description(), L"Initialize core fail.", MB_OK);
		_core->Dispose();
	}
}

// Update setting for UI
void MainForm::UpdateSettings()
{
	auto sections = _core->GetSettingSections();
	long lBound, uBound;
	::SafeArrayGetLBound(sections, 1, &lBound);
	::SafeArrayGetUBound(sections, 1, &uBound);
	BSTR* raw;
	::SafeArrayAccessData(sections, reinterpret_cast<void **>(&raw));
	auto cmb = static_cast<CComboBox*>(GetDlgItem(IDC_CMB_PARAM_NAME));
	for(int i = lBound; i <= uBound; ++i)
	{
		auto section = _bstr_t(raw[i]);
		long lBoundN, uBoundN;
		auto names = _core->GetSettingNames(section);
		::SafeArrayGetLBound(names, 1, &lBoundN);
		::SafeArrayGetUBound(names, 1, &uBoundN);
		BSTR* rawN;
		::SafeArrayAccessData(names, reinterpret_cast<void**>(&rawN));
		for(int j = lBoundN; j <= uBoundN; ++j)
		{
			auto name = _bstr_t(rawN[j]);
			int index = cmb->AddString(section + L":" + name);
			_settings.push_back(Setting(index, section, name));
		}
	}
}

void MainForm::OnBnClickedButtonDeinitCore()
{
	_core->Dispose();

	auto cmb = static_cast<CComboBox*>(GetDlgItem(IDC_CMB_PARAM_NAME));
	cmb->Clear();
	_settings.clear();
	UpdateControls(FALSE);
}

void MainForm::OnBnClickedButtonSetup()
{
	_core->ShowSetupForm();
	_core->SaveSettings();
}

void MainForm::OnBnClickedButtonAlgSetup1()
{
	_core->ShowAlgSetupForm(0);
	_core->SaveSettings();
}

void MainForm::OnBnClickedButtonAlgSetup2()
{
	_core->ShowAlgSetupForm(1);
	_core->SaveSettings();
}

void MainForm::OnBnClickedButtonStart()
{
	_count = 0;
	auto list = static_cast<CListCtrl*>(GetDlgItem(IDC_LIST_NUMBERS));
	list->DeleteAllItems();

	_core->Start();
}

void MainForm::OnBnClickedButtonStop()
{
	_core->Stop();
}

void MainForm::UpdateControls(BOOL isInitialized)
{
	GetDlgItem(IDC_BUTTON_INIT_CORE)->EnableWindow(!isInitialized);
	GetDlgItem(IDC_BUTTON_DEINIT_CORE)->EnableWindow(isInitialized);
	GetDlgItem(IDC_BUTTON_SETUP)->EnableWindow(isInitialized);
	GetDlgItem(IDC_BUTTON_ALG_SETUP1)->EnableWindow(isInitialized);
	GetDlgItem(IDC_BUTTON_ALG_SETUP2)->EnableWindow(isInitialized);
	GetDlgItem(IDC_BUTTON_START)->EnableWindow(isInitialized);
	GetDlgItem(IDC_BUTTON_STOP)->EnableWindow(isInitialized);
	GetDlgItem(IDC_CMB_PARAM_NAME)->EnableWindow(isInitialized);
	GetDlgItem(IDC_TXT_PARAM_VALUE)->EnableWindow(isInitialized);
	GetDlgItem(IDC_BTN_SET_PARAM_VALUE)->EnableWindow(isInitialized);
}

void MainForm::OnCbnSelchangeCmbParamName()
{
	auto cmb = static_cast<CComboBox*>(GetDlgItem(IDC_CMB_PARAM_NAME));
	int index = cmb->GetCurSel();
	if(index == CB_ERR) return;

	for(auto it = _settings.begin(); it != _settings.end(); ++it)
	{
		auto ix = std::get<0>(*it);
		if(ix == index)
		{
			auto section = std::get<1>(*it);
			auto name = std::get<2>(*it);
			auto description = _core->GetSettingDescription(section, name);
			auto txtDescription = static_cast<CStatic*>(GetDlgItem(IDC_TXT_SETTING_DESCRIPTION));
			txtDescription->SetWindowTextW(description);
			auto val = _core->GetSettingValue(section, name);
			auto txtValue = static_cast<CEdit*>(GetDlgItem(IDC_TXT_PARAM_VALUE));
			txtValue->SetWindowTextW(_bstr_t(val));
			break;
		}
	}
}

void MainForm::OnBnClickedBtnSetParamValue()
{
	auto cmb = static_cast<CComboBox*>(GetDlgItem(IDC_CMB_PARAM_NAME));
	int index = cmb->GetCurSel();
	if(index == CB_ERR) return;

	for(auto it = _settings.begin(); it != _settings.end(); ++it)
	{
		auto ix = std::get<0>(*it);
		if(ix == index)
		{
			auto txtValue = static_cast<CEdit*>(GetDlgItem(IDC_TXT_PARAM_VALUE));
			auto v = new wchar_t[128];
			txtValue->GetWindowTextW(v, 128);
			auto val = ::_wtoi(v);
			SetSettingValue(*it, val);
			break;
		}
	}
}

void MainForm::SetSettingValue(Setting setting, int value)
{
	try
	{
		auto section = std::get<1>(setting);
		auto name = std::get<2>(setting);
		_core->SetSettingValue(section, name, value);
		_core->SaveSettings();
	}
	catch(const exception& exc)
	{
		::MessageBoxW(GetSafeHwnd(), reinterpret_cast<LPCWSTR>(exc.what()), L"Set settings fail.", MB_OK);
	}
	catch(const _com_error& exc)
	{
		::MessageBoxW(GetSafeHwnd(), exc.ErrorMessage(), L"Set settings fail.", MB_OK);
	}
}
