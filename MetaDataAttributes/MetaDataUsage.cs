using System;

namespace MetaDataAttributes
{
    public class MetaDataUsage
    {
        //Proxy for global test hooks
        public MetaDataUsage()
        {
            var metaData = new MetaData();
            metaData.GetMetaData<MetaDataUsage>();
        }
        //Proxy for [Test]
        [MetaData(Application = Application.ApplicationOne, Feature = Feature.NewApplication, Owner = Owner.PlatformOne, Implemented = true)]
        public void MetaDataUsage_TestMetaData()
        {
            Console.WriteLine("Running the test...");
        }
    }
}