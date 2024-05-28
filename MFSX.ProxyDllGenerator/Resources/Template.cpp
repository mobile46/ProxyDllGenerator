#define DEBUG 1

#include <windows.h>
#include <psapi.h>
#include "Logger.h"

#define FUNC(i) ((void(*)())mProcs[i])()

HINSTANCE mHinstDLL;
uintptr_t mProcs[#COUNT#];

const char* mImportNames[] = { #IMPORTS# };

void MFSX();

uintptr_t* RvaAddress(uintptr_t base, uintptr_t address)
{
	return (uintptr_t*)((char*)base + address);
}

void ReadBytes(const uintptr_t* address, uintptr_t& bytes, const size_t size)
{
	ReadProcessMemory(GetCurrentProcess(), address, &bytes, size, nullptr);
}

void WriteBytes(uintptr_t* address, const BYTE* bytes, const size_t size)
{
	WriteProcessMemory(GetCurrentProcess(), address, bytes, size, NULL);
}

void WaitModule(const char* moduleName, uintptr_t& handle)
{
	while ((handle = (uintptr_t)GetModuleHandle(moduleName)) == -1 || !handle) Sleep(10);
}

void WaitModuleUnpacked(const uintptr_t* address, uintptr_t bytes)
{
	while ((DWORD)*address != (DWORD)bytes) Sleep(10);
}

BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved)
{
	if (ul_reason_for_call == DLL_PROCESS_ATTACH)
	{
		INITLOGGER("#NAME#.log");

		DisableThreadLibraryCalls(hModule);

		char szPath[MAX_PATH];

		if (!GetSystemDirectory(szPath, MAX_PATH))
			return FALSE;

		strcat_s(szPath, sizeof(szPath), "\\#NAME#");

		mHinstDLL = LoadLibrary(szPath);

		if (!mHinstDLL)
			return FALSE;

		for (int i = 0; i < #COUNT#; i++)
			mProcs[i] = (uintptr_t)GetProcAddress(mHinstDLL, mImportNames[i]);

		CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)MFSX, NULL, 0, NULL);
	}
	else if (ul_reason_for_call == DLL_PROCESS_DETACH)
	{
		FreeLibrary(mHinstDLL);
		CLOSELOGGER();
	}
	return TRUE;
}

void MFSX()
{
	char fileName[MAX_PATH];
	GetModuleBaseName(GetCurrentProcess(), NULL, fileName, MAX_PATH);

	LOG("Hello, %s!", fileName);
}

#EXPORTS#
