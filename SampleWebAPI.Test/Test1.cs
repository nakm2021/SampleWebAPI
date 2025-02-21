namespace SampleWebAPI.Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testObj = new SampleData().MyList;

            var testHikaku = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                testHikaku.Add($"Item {i}");
            }
            CollectionAssert.AreEqual(testObj, testHikaku);
        }
    }
}
