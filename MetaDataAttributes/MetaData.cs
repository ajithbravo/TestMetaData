using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MetaDataAttributes
{
    public enum Application
    {
        ApplicationOne,
        ApplicationTwo,
        Derp
    }

    public enum TestType
    {
        Gui,
        Api
    }

    public enum Feature
    {
        NewApplication
    }

    public enum Owner
    {
        PlatformOne,
        PlatformTwo
    }
    [AttributeUsage(AttributeTargets.All)]
    public class MetaData : Attribute
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Application Application { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Feature Feature { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Owner Owner { get; set; }
        public bool Implemented { get; set; }

        public void GetMetaData<T>() where T : class
        {
            try
            {
                var classType = typeof(T);
                var classMembers = classType.GetMembers();
                foreach (var member in classMembers)
                {
                    var metaDataAttributes = member.GetCustomAttributes(true);
                    if (metaDataAttributes.Length <= 0) continue;
                    foreach (var metaData in metaDataAttributes)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(metaData));
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("An exception occurred: {0}", e.Message);
            }
        }
    }
}