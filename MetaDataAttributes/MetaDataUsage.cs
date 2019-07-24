using MetaDataAttributes.Service;
using System;

namespace MetaDataAttributes
{
    public class MetaDataUsage
    {
        //Proxy for global test hooks
        public MetaDataUsage()
        {
            //var metaData = new MetaData();
            // metaData.GetMetaData<MetaDataUsage>();         

        }
        //Proxy for [Test]
        // [MetaData(Application = Application.ApplicationOne, Feature = Feature.NewApplication, Owner = Owner.PlatformOne, Implemented = true, TestName = "MetaDataUsage_TestMetaData")]
        [MetaData(Application = Application.ApplicationOne)]
        public void MetaDataUsage_TestMetaData()
        {
            Console.WriteLine("Running the test...");
        }

        //[MetaData(Application = Application.ApplicationOne, Feature = Feature.NewApplication, Owner = Owner.PlatformOne, Implemented = true)]
        [MetaData(Application = Application.ApplicationOne)]
        public void MetaDataUsage_TestMetaData2()
        {
            Console.WriteLine("Running the test2...");
        }

        //[MetaData(Application = Application.ApplicationTwo, Feature = Feature.NewQuote, Owner = Owner.PlatformTwo, Implemented = true)]
        [MetaData(Application = Application.ApplicationTwo)]

        public void MetaDataUsage_TestMetaData3()
        {
            Console.WriteLine("Running the test3...");
        }

        // [MetaData(Application = Application.ApplicationTwo, Feature = Feature.NewQuote, Owner = Owner.PlatformTwo, Implemented = true)]
        [MetaData(Application = Application.ApplicationTwo)]
        public void MetaDataUsage_TestMetaData4()
        {
            Console.WriteLine("Running the test4...");
        }

        // [MetaData(Application = Application.ApplicationOne, Feature = Feature.NewApplication, Owner = Owner.PlatformOne, Implemented = true)]
        [MetaData(Application = Application.ApplicationOne)]
        public void MetaDataUsage_TestMetaData5()
        {
            Console.WriteLine("Running the test5...");
        }

        public void RunAfterTest()
        {
            var metaData = new MetaData();
            metaData.GetAttributeValues(typeof(MetaDataUsage));
            //will be called from the after running all test
            CreateReportFile.CreateReport();
        }
    }
}