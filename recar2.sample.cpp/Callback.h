#pragma once

using namespace Recar2;

// Uses in callback function
struct RecarSolutionStruct
{
	// State passed by registration callback
	void* State;
	// Event identificator
	__int64 EventId;
	// Camera identificator
	int CameraId;
	// Plate number
	wchar_t* Number;
	// Plate number type
	wchar_t* NumberType;
	// Timestamp best frame with plate number
	time_t TimeStamp;
	// Plate number direction on frame
	int MovementDirection;
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

