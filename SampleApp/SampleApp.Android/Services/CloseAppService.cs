using System;
using Services;

namespace SampleApp.Droid.Services
{
    public class CloseAppService : ICloseApp
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}
