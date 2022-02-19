using System.Runtime.InteropServices;

namespace SpecFlowCW.Utils
{
    public class OsWisePathFix
    {
        public void setGlobalSetting()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Settings.Default.extentReportPath = "~/../../../../Reports/";
                Settings.Default.jsonReportPath = "~/../../../../Reports/results.json";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {

            }
        }
    }
}
