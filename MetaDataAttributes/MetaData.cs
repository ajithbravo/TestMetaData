using System;
using System.IO;
using System.Linq;
using System.Reflection;
using MetaDataAttributes.Helper;
using MetaDataAttributes.Service;
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
        NewApplication,
        NewQuote
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

        public string TestName { get; set; }

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
            catch (Exception e)
            {
                Console.WriteLine("An exception occurred: {0}", e.Message);
            }
        }

        public void GetAttributeValues(Type T)
        {
            MetaData att;
            MemberInfo[] MyMemberInfo = T.GetMethods();
            // Loop through all methods in this class that are in the
            // MyMemberInfo array.
            for (int i = 0; i < MyMemberInfo.Length; i++)
            {
                att = (MetaData)Attribute.GetCustomAttribute(MyMemberInfo[i], typeof(MetaData));

                if (att == null)
                {
                    Console.WriteLine("No attribute in member function {0}.\n", MyMemberInfo[i].ToString());
                }
                else
                {
                    var responses = MetaDataService.DataResponse(); // values to be fetched from the databasse
                    var newlist = responses.DataBaseResponse.Where(x => x.AppName == att.Application.ToString()).FirstOrDefault();
                    newlist.TestName = MyMemberInfo[i].Name;
                    //path
                    string halfpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(@"\bin\Debug", "");                    
                    var filename = Path.Combine(halfpath, string.Format(@"Report\{0}.json", MyMemberInfo[i].Name)); ;
                    if (!File.Exists(filename))
                    {
                        // serialize JSON to a string and then write string to a file
                        File.WriteAllText(filename, JsonConvert.SerializeObject(newlist, Formatting.Indented));
                    }
                    else
                    {
                        File.WriteAllText(filename, JsonConvert.SerializeObject(newlist, Formatting.Indented));
                        // File.WriteAllText(MetaDataHelper.GetNextFileName(filename), JsonConvert.SerializeObject(newlist));
                    }
                }
            }
        }        
    }
}