#include <iostream>
#include <Windows.h>
#include <thread>

using namespace std;

int getWidth(const char * WindowName) {
	HWND hwnd = FindWindowA(0, WindowName);
	if (hwnd == NULL) return 0;

	RECT rekt;
	GetWindowRect(hwnd, &rekt);
	return rekt.right - rekt.left;
}

int getHeight(const char * WindowName) {
	HWND hwnd = FindWindowA(0, WindowName);
	if (hwnd == NULL) return 0;

	RECT rekt;
	GetWindowRect(hwnd, &rekt);
	return rekt.bottom - rekt.top;
}

bool isWindowRunning(const char * WindowName)
{
	HWND hwnd = FindWindowA(0, WindowName);
	return (hwnd != NULL);
}

void switchToWindow(const char * WindowName) {
	HWND hwnd = FindWindowA(0, WindowName);
	if (hwnd != NULL) SwitchToThisWindow(hwnd, true);
}

int main() {
	const char* WindowName = "Overwatch";

	float MouseSensitivity = 15.00f;
	bool HumanLikeMovements = true;
	int AimSpeed = 7;
	bool Headshots = false;
	bool Triggerbot = false;
	bool ShootAfterAiming = false;
	int ShootTime = 100;


	cout << "WindowName -> " << WindowName << endl;
	/*
	cout << "MouseSensitivity -> " << MouseSensitivity << endl;
	cout << "HumanLikeMovements -> " << HumanLikeMovements << endl;
	cout << "AimSpeed -> " << AimSpeed << endl;
	cout << "Headshots -> " << Headshots << endl;
	cout << "Triggerbot -> " << Triggerbot << endl;
	cout << "ShootAfterAiming -> " << ShootAfterAiming << endl;
	cout << "ShootTime -> " << ShootTime << endl;
	*/
	while (!isWindowRunning(WindowName))
	{
		cout << "... wait" << endl;
		Sleep(1000);
	}
	cout << endl << "Overwatch found!!!" << endl;

	cout << "===================================================" << endl;
	cout << "process width  -> " << getWidth(WindowName) << endl;
	cout << "process height -> " << getHeight(WindowName) << endl;
	cout << "===================================================" << endl;

	switchToWindow(WindowName);
	Sleep(1000);
	Beep(1000, 250);

	system("pause");
	return 0;
}
