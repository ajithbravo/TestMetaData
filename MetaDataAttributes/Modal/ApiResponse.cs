using System.Collections.Generic;

namespace MetaDataAttributes.Modal
{   
    public class ApiResponse
    {
        public string PlatFormName { get; set; }
        public string AppName { get; set; }
        public string FeatureName { get; set; }

        public string PlatFomId { get; set; }

        public string AppId { get; set; }

        public string FeatureId { get; set; }

        public string TestName { get; set; }
    }

    public class DBResponse
    {
        public List<ApiResponse> DataBaseResponse { get; set; }
    }
}
