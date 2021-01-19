using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MovieGuide;
namespace MovieGuideUnitTest
{
    [TestClass]
    public class OMDbTests
    {
        [TestMethod]
        public void GetMovieInfo_ReturnNull()
        {
            //Act
            Movie result=OMDb.GetMovieInfo("wrfea");
            Assert.IsNotNull(result);
        }
        public void GetMovieInfo_ReturnNotNull()
        {
            //Act
            Movie result = OMDb.GetMovieInfo("Godfather");
            Assert.IsNotNull(result);
        }
    }
}
