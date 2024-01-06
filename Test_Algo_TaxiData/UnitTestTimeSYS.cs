using Algo_TaxiData;

namespace Test_Algo_TaxiData
{
    [TestClass]
    public class UnitTestTimeSYS
    {
        [TestMethod]
        public void TestCreateFromBJStr()
        {
            TimeSYS timeSYSBJStr = TimeSYS.CreateFromBJStr("20170706123247");
            TimeSYS timeSYSBJ = TimeSYS.CreateFromBJ(2017,7,6,12,32,47);
            Assert.AreEqual(timeSYSBJStr.funMJD(), timeSYSBJ.funMJD());
        }
    }
}