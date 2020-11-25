using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieGuide;
using System.Data.OleDb;

namespace MovieGuideUnitTest
{
    [TestClass]
    public class DatabaseOperationsTests
    {

        [TestMethod]
        public void CreateNewLTEntry()
        {
            //Arrange
            DatabaseOperations database = new DatabaseOperations();
            OleDbCommand command;
            database.Connect();

            //Act
            database.CreateLTEntry("LT_ACTORS", "Test Testcioglu");
            OleDbConnection databaseConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\repos\MovieGuide\MovieGuide\bin\Debug\MovieGuideDb.accdb");
            databaseConnection.Open();
            command = new OleDbCommand("SELECT ID FROM LT_ACTORS WHERE CODE = 'Test Testcioglu'", databaseConnection);
            Assert.IsTrue(command.ExecuteReader().Read());
            databaseConnection.Close();


        }
    }
}
