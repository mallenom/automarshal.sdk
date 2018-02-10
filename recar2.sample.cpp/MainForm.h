#pragma once

#include <tuple>
#include <vector>
#include "afxwin.h"

using namespace Recar2;

typedef std::tuple <int, _bstr_t, _bstr_t> Setting;

struct RecarSolutionStruct;

// MainForm dialog
class MainForm : public CDialogEx
{
	// Construction
public:
	MainForm(IVideoCorePtr core, CWnd* pParent = nullptr); // standard constructor

	// Event handler
	void NumberRecognized(struct IRecarSolution* solution);

	void UpdateGrid(RecarSolutionStruct* solution);

	//HRESULT  static __stdcall OnEventNumberRecognition(RecarSolutionStruct* solution);

	// Dialog Data
	enum { IDD = IDD_RECAR2SAMPLECPP_DIALOG };

protected:
	void DoDataExchange(CDataExchange* pDX) override; // DDX/DDV support

	// Implementation
private:
	IVideoCorePtr _core;
	std::vector<Setting> _settings;
	int _count = 0;

protected:
	// Generated message map functions
	virtual BOOL OnInitDialog() override;
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
private:
	void UpdateControls(BOOL isInitialized);
	void UpdateGrid(IRecarSolution* solution);
	void UpdateSettings();
	void SetSettingValue(Setting setting, int value);

	private:
	HICON _hIcon;
	CStatic _txtCount;

public:
	afx_msg void OnBnClickedButtonInitCore();
	afx_msg void OnBnClickedButtonDeinitCore();
	afx_msg void OnBnClickedButtonSetup();
	afx_msg void OnBnClickedButtonAlgSetup1();
	afx_msg void OnBnClickedButtonAlgSetup2();
	afx_msg void OnBnClickedButtonStart();
	afx_msg void OnBnClickedButtonStop();
	afx_msg void OnCbnSelchangeCmbParamName();
	afx_msg void OnBnClickedBtnSetParamValue();

};
