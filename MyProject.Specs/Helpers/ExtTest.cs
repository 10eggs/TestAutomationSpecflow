using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace HistoricalEngland.Specs.Helpers
{
    class ExtTest
    {
        public static ThreadLocal<ExtentTest> extentTestThreadSafe = new ThreadLocal<ExtentTest>();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest getTest()
        {
            return extentTestThreadSafe.Value;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void setTest(ExtentTest tst)
        {
            extentTestThreadSafe.Value = tst;
        }
    }
}
