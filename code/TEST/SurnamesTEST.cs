using Microsoft.AspNetCore.Mvc;
using Service3_Surnames.Controllers;
using Xunit;

namespace TEST
{
    public class SurnamesTEST
    {
        [Fact]
        public void Test2()
        {
            //Arrange
            var alias = new SurnamesController();

            //act
            var returnValue1 = alias.Get();

            //assert
            Assert.NotNull(returnValue1);
            Assert.IsType<ActionResult<string>>(returnValue1);
        }
    }
}
