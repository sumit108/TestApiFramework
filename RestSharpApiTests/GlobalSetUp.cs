using NUnit.Framework;
using RestSharpApiTests.Helpers;
using RestSharpApiTests.PropertyClass;
using System.Linq;

namespace RestSharpApiTests
{
   public class GlobalSetUp
    {
        public static ExcelProperties _TestData { get; set; }
        public static string _TestClassName { get; set; }
        public static string _TestCaseName { get; set; }

        [SetUp]
        public void SetupPre()
        {
            _TestCaseName = TestContext.CurrentContext.Test.Name;
            _TestClassName = TestContext.CurrentContext.Test.ClassName.Split('.').Last();

            var excelUtil = new ExcelUtil();
            var dt = excelUtil.ExcelRead();

            var testData = excelUtil.GetExcelDataRelativeToTc(dt);
            _TestData = testData;
            if (!testData.RunFlag)
                Assert.Ignore("Ignored the test case as run falg is set to " + testData.RunFlag + " in Test data");
        }
    }
}
