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
            TimeSYS timeSYSBJ = TimeSYS.CreateFromBJ(2017, 7, 6, 12, 32, 47);
            Assert.AreEqual(timeSYSBJStr.funMJD(), timeSYSBJ.funMJD());

            timeSYSBJStr = TimeSYS.CreateFromBJStr("20071026093000");
            timeSYSBJ = TimeSYS.CreateFromBJ(2007, 10, 26, 09, 30, 00);
            Assert.AreEqual(timeSYSBJStr.funMJD(), timeSYSBJ.funMJD());
        }

        [TestMethod]
        public void TestfunMJD()
        {
            TimeSYS timeSYSBJStr = TimeSYS.CreateFromBJStr("20071026093000");
            Assert.AreEqual(timeSYSBJStr.funMJD(), 54399.0625, 1e-10);
        }

        //[TestMethod]
        //public void TestToString()
        //{
        //    CalResult calResult = new CalResult(01, 57940.19005242, 57940.19067423, 82.317423, 290.872423);
        //    Assert.AreEqual(calResult.ToString(), "01, 57940.19005-57940.19067, 82.317, 290.872");
        //}

        [TestMethod]
        public void TestdeltaUTC()
        {
            TimeSYS timeSYSBJStr1 = TimeSYS.CreateFromBJStr("20071026093000");
            TimeSYS timeSYSBJStr2 = TimeSYS.CreateFromBJStr("20071026093001");
            double res = TimeSYS.deltaUTC(timeSYSBJStr1, timeSYSBJStr2);

            Assert.AreEqual(res, 1);
        }
    }
}