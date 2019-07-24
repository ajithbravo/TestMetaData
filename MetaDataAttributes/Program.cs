namespace MetaDataAttributes
{
    internal class Program
    {
        //Proxy for test run
        public static void Main()
        {
            var test = new MetaDataUsage();
            test.MetaDataUsage_TestMetaData();
            test.MetaDataUsage_TestMetaData2();
            test.MetaDataUsage_TestMetaData3();
            test.MetaDataUsage_TestMetaData4();
            test.MetaDataUsage_TestMetaData5();
            test.RunAfterTest();
        }
    }
}