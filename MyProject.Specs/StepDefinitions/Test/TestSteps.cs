using HistoricalEngland.Specs.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.Test
{
    [Binding]
    public class TestSteps
    {
        private readonly Navigation _navigation;
        public TestSteps(Navigation navigation)
        {
            _navigation = navigation;
        }

    }
}
