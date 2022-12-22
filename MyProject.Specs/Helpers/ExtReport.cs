using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HistoricalEngland.Specs.Helpers
{
   
    class ExtReport
    {
        private static string reportPath;
        public static string day_dt;

        //Returns htmlreporter for use in Extent report

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static AventStack.ExtentReports.Reporter.ExtentHtmlReporter getReport()
        {
            DateTime dt = DateTime.Now;
            day_dt = dt.ToString("dd_MM_yy_HH_mm_ss");
            reportPath = (ProjectPath.getProjectPath() + "Reports\\" + day_dt + "\\TestRunReport.html");
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.ReportName = "Historic England Automation testing report";
            return htmlReporter;
        }
    }
}
