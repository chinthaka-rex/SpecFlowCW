using System.Runtime.InteropServices;

namespace SpecFlowCW.Utils
{
    public class OsWisePathFix
    {
        public void setGlobalSetting()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WriteLine("This is windows");
                Settings.Default.extentReportPath = "~/../../../../Reports/";
                Settings.Default.jsonReportPath = "~/../../../../Reports/results.json";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                string text = File.ReadAllText("../Reports/c.txt");
                Console.WriteLine( text);

                Console.WriteLine("This is osx");
                //Settings.Default.extentReportPath = "/SpecFlowCW/SpecFlowCW/Reports/";
                //Settings.Default.jsonReportPath = "/SpecFlowCW/SpecFlowCW/Reports/results.json";
            }
        }
    }
}
