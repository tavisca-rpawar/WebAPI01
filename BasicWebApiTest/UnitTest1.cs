using System;
using Xunit;

namespace BasicWebApiTest
{
    public class UnitTest1
    {
        [Fact]
        public void BasicGreet()
        {
            WebApplication1.Controllers.GreetingController gc = new WebApplication1.Controllers.GreetingController();
            string greet = gc.Get().Value;
            string expected = "No input";
            Assert.Equal(expected, greet);
        }

        [Fact]
        public void HelloGreet()
        {
            WebApplication1.Controllers.GreetingController gc = new WebApplication1.Controllers.GreetingController();
            string greet = gc.Get("Hello", "Rupika").Value;
            string expected = "Hi Rupika";
            Assert.Equal(expected, greet);
        }
    }
}
