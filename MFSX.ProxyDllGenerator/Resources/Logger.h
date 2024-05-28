#pragma once
#if DEBUG
#include <stdio.h>

#define INITLOGGER(fileName) InitLogger(fileName)
#define CLOSELOGGER() CloseLogger()
#define LOG(fmt, ...) WriteLog("%X:%d:%s: " ##fmt, GetCurrentThreadId(), __LINE__, __FUNCTION__, __VA_ARGS__)
#define HEXDUMP(data, length) HexDump(data, length)

HANDLE mutex = NULL;
FILE* file = NULL;

inline void InitLogger(const char* fileName)
{
	mutex = CreateMutex(NULL, false, NULL);

	AllocConsole();

	FILE* temp;
	freopen_s(&temp, "CONIN$", "r", stdin);
	freopen_s(&temp, "CONOUT$", "w", stdout);
	freopen_s(&temp, "CONOUT$", "w", stderr);

	const HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	DWORD currMode;
	GetConsoleMode(handle, &currMode);
	SetConsoleMode(handle, currMode | ENABLE_VIRTUAL_TERMINAL_PROCESSING);

	SetConsoleOutputCP(CP_UTF8);

	fopen_s(&file, fileName, "a");
}

inline void CloseLogger()
{
	FreeConsole();
	if (mutex != NULL)
		CloseHandle(mutex);
	if (file != NULL)
		fclose(file);
}

inline __declspec(noinline) void WriteLog(const char* fmt, ...)
{
	WaitForSingleObject(mutex, INFINITE);

	va_list args;
	va_start(args, fmt);

	SYSTEMTIME time;
	GetLocalTime(&time);

	printf("[%04d-%02d-%02d %02d:%02d:%02d] ", time.wYear, time.wMonth, time.wDay, time.wHour, time.wMinute, time.wSecond);
	vprintf(fmt, args);
	printf("\n");

	if (file != NULL)
	{
		fprintf(file, "[%04d-%02d-%02d %02d:%02d:%02d] ", time.wYear, time.wMonth, time.wDay, time.wHour, time.wMinute, time.wSecond);
		vfprintf(file, fmt, args);
		fprintf(file, "\n");
		fflush(file);
	}

	va_end(args);

	ReleaseMutex(mutex);
}

inline __declspec(noinline) void HexDump(const char* data, size_t length)
{
	WaitForSingleObject(mutex, INFINITE);

	const unsigned rowSize = 16;
	char buffer[128];
	size_t bufferIndex = 0;

	for (size_t i = 0; i < length; i += rowSize)
	{
		bufferIndex += sprintf(buffer + bufferIndex, "0x%06X: ", (unsigned)i);
		size_t end = i + rowSize < length ? i + rowSize : length;

		for (size_t j = i; j < end; ++j)
		{
			bufferIndex += sprintf(buffer + bufferIndex, "%02X ", (unsigned char)data[j]);
		}
		for (size_t j = end; j < i + rowSize; ++j)
		{
			bufferIndex += sprintf(buffer + bufferIndex, "   ");
		}

		bufferIndex += sprintf(buffer + bufferIndex, " ");
		for (size_t j = i; j < end; ++j)
		{
			char c = data[j];
			bufferIndex += sprintf(buffer + bufferIndex, "%c", c >= 32 && c <= 126 ? c : '.');
		}

		if (i + rowSize >= length)
			sprintf(buffer + bufferIndex, "\n");

		WriteLog("%s", buffer);
		bufferIndex = 0;
	}

	ReleaseMutex(mutex);
}
#else
#define INITLOGGER()
#define CLOSELOGGER()
#define LOG(fmt, ...)
#define HEXDUMP(data, length)
#endif
