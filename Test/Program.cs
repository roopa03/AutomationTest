using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //set system property to initialize FireFoxDriver object
            //System.Environment.SetEnvironmentVariable("Webdriver.gecko.driver", "geckodriver.exe");

            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://automationpractice.com";

            //Running test 1, 2 and 3
            Test123(driver);
            
            //Running test 4 and 5
            Test45(driver);
        }

        static void Test123(IWebDriver driver)
        {
            //TEST case 1 and 2
            //Searching for 'Printed Summer Dress' should return N results
            //Each product on the search results page should contain: Name, Image and Price

            var searchBox = driver.FindElement(By.Id("search_query_top"));
            searchBox.SendKeys("Printed Summer Dress");

            var searchButton = driver.FindElement(By.Name("submit_search"));
            searchButton.Click();

            //Test case 3
            //A product page should contain: Name, Condition and Description
            //Clicking 1st image

            var image = driver.FindElement(By.XPath("html/body/div/div[2]/div/div[3]/div[2]/ul/li[1]/div/div[1]/div/a[1]/img"));
            image.Click();

        }



        static void Test45(IWebDriver driver)
        {
            //Test Case 4 - Contact us page
            // A message can be sent successfully when the following fields are populated: Subject Heading, Email address and Message

            //driver4.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            var contact = driver.FindElement(By.Id("contact-link"));
            contact.Click();

            var contactDropdown = driver.FindElement(By.Id("id_contact"));
            var CustomerService = contactDropdown.FindElements(By.TagName("option"))[2];
            CustomerService.Click();

            var email = driver.FindElement(By.Id("email"));
            email.SendKeys("abc@gmail.com");

            var message = driver.FindElement(By.Id("message"));
            message.SendKeys("I am happy with the service");

            //Test Case 5 - 
            //Once a message has been sent successfully, a confirmation alert should appear with the text: "Your message has been successfully sent to our team."

            var submitMessage = driver.FindElement(By.Id("submitMessage"));
            submitMessage.Click();




        }
    }
}
