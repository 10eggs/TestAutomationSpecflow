using HistoricalEngland.Specs.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace HistoricalEngland.Specs.StepDefinitions.BaseSteps
{
    [Binding]
    public class NavigationSteps
    {
        private readonly Navigation _navigation;
        public NavigationSteps(Navigation navigation)
        {
            _navigation = navigation;
        }
        [StepDefinition(@"Navigate to the ""(.*)"" page")]
        public void NavigateToThePage(string area)
        {
            try
            {
                _navigation.Navigate(area);

            }
            catch (UnhandledAlertException)
            {
                return;
            }
        }
    }
}
