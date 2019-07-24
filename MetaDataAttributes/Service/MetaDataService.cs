using MetaDataAttributes.Modal;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace MetaDataAttributes.Service
{
    public class MetaDataService
    {
        public static DBResponse DataResponse()
        {
            string halfpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(@"\bin\Debug", "");
            string path = Path.Combine(halfpath, @"Data\DatabaseResponse.json");            
            using (StreamReader reads = new StreamReader(path))
            {
                var json = reads.ReadToEnd();
                var items = JsonConvert.DeserializeObject<DBResponse>(json);
                return items;
            }
        }
    }
}
