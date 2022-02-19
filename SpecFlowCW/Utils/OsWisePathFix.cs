using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowCW.Utils
{
    public class OsWisePathFix
    {
        public void setGlobalSetting()
        {
            //OperatingSystem operatingSystem = new OperatingSystem();
            //string os =  operatingSystem.Platform.Should
            //System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(osPlatform.Windows);

            Settings.Default.extentReportPath = "~/../../../../Reports/";
            Settings.Default.jsonReportPath = "~/../../../../Reports/results.json";
        }
    }
}
