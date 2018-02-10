#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"

#import "recar2.com.tlb" rename_namespace("Recar2")

using namespace Recar2;

class SampleApp : public CWinApp
{
public:
	SampleApp();

// Overrides
public:
	virtual BOOL InitInstance() override;

	void OnEvent(struct IRecarSolution* solution) const;

// Implementation
private:
	DECLARE_MESSAGE_MAP()
};

extern SampleApp theApp;
