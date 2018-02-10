#include "stdafx.h"
#include "afxdialogex.h"
#include "recar2.sample.h"

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
