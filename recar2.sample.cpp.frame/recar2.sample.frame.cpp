// recar2.sample.cpp.frame.cpp : Defines the entry point for the console application.
#include "stdafx.h"

#include <windows.h>
#include <io.h>
#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <comutil.h>

using namespace std;

#import "recar2.com.tlb" rename_namespace("Recar2")
using namespace Recar2;

#define _O_U16TEXT  0x20000
#define RGB_TO_Y8(r, g, b) ((byte)(((r * 4915) + (g * 9667) + (b * 1802)) >> 14));

byte* _imageData;
int _imageFormat;
int _imageWidth;
int _imageHeight;
int _imageStride;

byte* ConvertPalette(RGBQUAD* palette, int paletteSize)
{
	byte* buffer = NULL;
	for(int i = 0; i < paletteSize; ++i)
	{
		byte color;
		if(palette[i].rgbBlue == palette[i].rgbRed && palette[i].rgbRed == palette[i].rgbGreen)
		{
			color = palette[i].rgbBlue;
		}
		else
		{
			color = RGB_TO_Y8(palette[i].rgbRed, palette[i].rgbGreen, palette[i].rgbBlue);
		}
		if(color != i && buffer == NULL)
		{
			buffer = new byte[paletteSize];
			for(int j = 0; j < i; ++j)
			{
				buffer[j] = j;
			}
		}
		if(buffer != NULL)
		{
			buffer[i] = color;
		}

	}
	return buffer;
}

// Load and convert image
void LoadImage(LPCTSTR filename)
{
	CImage image;
	image.Load(filename);
	byte* data = static_cast<byte*>(image.GetBits());
	int width = image.GetWidth();
	int height = image.GetHeight();
	int pitch = image.GetPitch();

	_imageData = new byte[height * width];
	byte* targetPtr = _imageData;
	if(image.IsIndexed())
	{
		const int paletteSize = image.GetMaxColorTableEntries();
		RGBQUAD* originalPalette = new RGBQUAD[paletteSize];
		image.GetColorTable(0, paletteSize, originalPalette);
		byte* palette = ConvertPalette(originalPalette, paletteSize);

		if(palette)
		{
			byte* line = data;
			byte* eoi = data + pitch * height;
			while(line != eoi)
			{
				byte* pix = line;
				byte* eol = line + width;
				while(pix != eol)
				{
					*targetPtr++ = palette[*pix++];
				}
				line += pitch;
			}
		}
		else
		{
			byte* line = data;
			byte* eoi = data + pitch * height;
			while(line != eoi)
			{
				byte* pix = line;
				byte* eol = line + width;
				while(pix != eol)
				{
					*targetPtr++ = *pix++;
				}
				line += pitch;
			}
		}
		if(palette)
		{
			delete[] palette;
		}
	}
	else
	{
		byte* line = data;
		byte* eoi = data + pitch * height;
		while(line != eoi)
		{
			byte* pix = line;
			byte* eol = line + width * 3;
			while(pix != eol)
			{
				byte r = *pix++;
				byte g = *pix++;
				byte b = *pix++;
				*targetPtr++ = RGB_TO_Y8(r, g, b);
			}
			line += pitch;
		}
	}
	_imageFormat = 0;
	_imageWidth = width;
	_imageHeight = height;
	_imageStride = width;
}

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

HRESULT static __stdcall OnEventNumberRecognition(RecarSolutionStruct* solution)
{
	struct tm timeinfo;
	localtime_s(&timeinfo, &solution->TimeStamp);
	wchar_t buff[20];
	wcsftime(buff, 20, L"%H:%M:%S", &timeinfo);
	wprintf(L"Camera: %i, event id: %lld, '%ls' (%ls), %s, movement: %i, state: %p.\n",
		solution->CameraId, solution->EventId, solution->Number, solution->NumberType, buff, solution->MovementDirection,
		reinterpret_cast<void*>(solution->State));
	return S_OK;
}

int main()
{
	_setmode(_fileno(stdout), _O_U16TEXT);

	try
	{
		wprintf(L"Initializing core...\n");
		// Initialize COM/OLE
		CoInitialize(NULL);
		// Create core instance
		IVideoCorePtr core = IVideoCorePtr(_uuidof(VideoCoreCom));
		// Set videochannel count
		core->PutVideoProcessChannelCount(1);
		// Convert plate to caps Latin symbols
		core->PutConvertPlateToCapsLatin(true);
		// Register callback for recognized number
		core->RegisterNumberRecognizedCallback(reinterpret_cast<__int64>(OnEventNumberRecognition), reinterpret_cast<__int64>(new int()));
		// Hide video forms
		core->SetVideoFormsVisible(false);
		// Initialize core
		const int channelNum = 0;
		core->Initialize();
		core->LoadSettings();
		core->SetVideoSource(channelNum);

		core->SetSettingValue(L"Kernel.VideoChannel0", L"MotionDetectMethod", 0); // Disable motion detected
		//core->SetSettingValue(L"Kernel.VideoChannel0", L"Plate1Width", 0.10f); // Plate min width (default 0.07)
		//core->SetSettingValue(L"Kernel.VideoChannel0", L"Plate1Height", 0.03f); // Plate min height (default 0.031)
//		core->SetSettingValue(L"Kernel.VideoChannel0", L"Plate2Width", 0.20f); // Plate max width (default 0.17)
		//core->SetSettingValue(L"Kernel.VideoChannel0", L"Plate2Height", 0.07f); // Plate max height (default 0.075)
//		core->SetSettingValue(L"Kernel.VideoChannel0", L"DecisionKeepTimeout", 0); // Disable bloсking duplicate
//		core->SetSettingValue(L"Kernel.VideoChannel0.DecisionAlg", L"MinDecisionFrames", 1); // Min frames for decision

		LoadImage(L"data\\O969HA35.bmp"); // Plate size: 0.20 x 0.075
		//LoadImage(L"data\\vlcsnap-2016-02-19-16h47m25s745.png"); // Plate size: 0.17 x 0.05
		//LoadImage(L"data\\vlcsnap-2016-02-19-17h00m50s868.png"); // Plate size: 0.10 x 0.04
		
		core->Start();
		wprintf(L"Recognition started.\n");
		while(!_kbhit())
		{
			core->DispatchVideoFrame(0L, _imageFormat, reinterpret_cast<__int64>(_imageData), _imageStride, _imageWidth, _imageHeight);
			Sleep(200);
		}

		core->Stop();
		core->SaveSettings();
		wprintf(L"Recognition stopped.\n");
		// Destroy core
		core->Dispose();
		// Uninitialize COM
		CoUninitialize();
	}
	catch(_com_error& er) 
	{
		wprintf(L"_com_error:\nError       : %08lX\nErrorMessage: %ls\nDescription : %ls\nSource      : %ls\n", er.Error(),
			static_cast<LPCTSTR>(_bstr_t(er.ErrorMessage())), static_cast<LPCTSTR>(_bstr_t(er.Description())), static_cast<LPCTSTR>(_bstr_t(er.Source())));
	}

	return 0;
}
