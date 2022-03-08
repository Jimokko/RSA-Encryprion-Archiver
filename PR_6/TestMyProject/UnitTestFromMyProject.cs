using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR_6;

namespace TestMyProject
{
    [TestClass]
    public class UnitTestFromMyProject
    {
        [TestMethod]
        public void TestCheckingForSimplicityMethodFromEncryptRSA()
        {
            int simpleNumber = 103;
            bool expectedResult = true;

            bool actualResult = EncryptRSA.CheckingForSimplicity(simpleNumber);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
