using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalEngland.Specs.POM
{
    class SortingAndPaginationPageObjects : BasePageObjects
    {
        //Sorting
        public By SortByLink = By.Id("results-order-preference");
        public By FirstResult = By.XPath("//div[@id='archive-search-results']//div/dl[3]/dd");
        public By FirstResultTitle = By.XPath("//div[@id='archive-search-results']//h3");
        public By ChangeResultTitle = By.XPath("//div[@id='archive-search-results']//h3[contains(text(),'Middlesex Guildhall')]");
    }
}
