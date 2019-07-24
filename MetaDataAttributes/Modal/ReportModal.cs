using System.Collections.Generic;

namespace MetaDataAttributes.Modal
{
    //To concatenate all the json file and create a report
    public class ReportModal
    {
        public List<TestReport>  TestReport { get; set; }
    }

    public class TestReport
    {
        public string PlatformName { get; set; }
        public string PlatformId { get; set; }
        public string AppName { get; set; }
        public string AppId { get; set; }
        public string FeatureName { get; set; }
        public string FeatureId { get; set; }
        public List<Test> Test { get; set; }
    }

    public class Test
    {
        public string TestName { get; set; }
        public string TestResult { get; set; }
        public string TestImplemented { get; set; }
        
    }
}
