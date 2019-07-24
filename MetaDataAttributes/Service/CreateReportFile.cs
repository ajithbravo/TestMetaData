using MetaDataAttributes.Modal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MetaDataAttributes.Service
{
    public class CreateReportFile
    {
        public static void CreateReport()
        {
            string halfpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(@"\bin\Debug", "");
            string path = Path.Combine(halfpath, @"Report");            
            DirectoryInfo dir = new DirectoryInfo(path);
            List<SingleReport> sing = new List<SingleReport>();
            foreach (var files in dir.GetFiles("*.json"))
            {
                using (FileStream file = new FileStream(files.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    // deserialize JSON directly from a file
                    using (StreamReader filer = new StreamReader(file))
                    {
                        var json = filer.ReadToEnd();
                        var items = JsonConvert.DeserializeObject<SingleReport>(json);
                        sing.Add(items);

                    }
                }

            }
            var filename = Path.Combine(halfpath, @"Report\SingleReport.json");            
            if (!File.Exists(filename))
            {   // serialize JSON to a string and then write string to a file
                File.WriteAllText(filename, JsonConvert.SerializeObject(sing, Formatting.Indented));
            }
            else
            {
                Console.Write("File Already exist");                
            }
        }

        public static void UpdateReport(string testname, string outCome)
        {
            try
            {
                string halfpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(@"\bin\Debug", "");
                string path = Path.Combine(halfpath, @"Report");
               // DirectoryInfo dir = new DirectoryInfo(@"D:\PracticeC\TestMetaData1\MetaDataAttributes\Report");
                DirectoryInfo dir = new DirectoryInfo(path);
                var filename = string.Format("{0}.json", testname);

                foreach (var files in dir.GetFiles(filename))
                {
                    // deserialize JSON directly from a file
                    using (FileStream file = new FileStream(files.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        //using (StreamReader srfile = File.OpenText(files.FullName))
                        using (StreamReader srfile = new StreamReader(file))
                        {
                            var json = srfile.ReadToEnd();
                            JObject rss = JObject.Parse(json);
                            rss["TestOutCome"] = outCome;

                            string output = Newtonsoft.Json.JsonConvert.SerializeObject(rss, Newtonsoft.Json.Formatting.Indented);
                            // File.Create(files.FullName).Dispose();
                            //File.WriteAllText(json, output);

                            File.WriteAllText(json, output);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }
        }


        public static void UpdateReport1(string testname, string outCome)
        {
            var jsonfile = @"D:\PracticeC\TestMetaData1\MetaDataAttributes\Report\{0}.json";
            var filepath = string.Format(jsonfile, testname);
            string json = File.ReadAllText(filepath).ToString();
            try
            {
                var jObject = JObject.Parse(json);
                jObject["TestOutCome"] = outCome;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filepath, output);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Error : " + ex.Message.ToString());
            }
        }


    }
}
