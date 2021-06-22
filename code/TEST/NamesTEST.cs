using Microsoft.AspNetCore.Mvc;
using Service2.Controllers;
using Xunit;

namespace TEST
{
    public class NamesTEST
    {
        [Fact]
        public void Test1()
        {

            //Arrange
            var aliasGen = new NamesController();

            //act
            var returnValue = aliasGen.Get();

            //assert
            Assert.NotNull(returnValue);
            Assert.IsType<ActionResult<string>>(returnValue);


        }
    }
}