using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace CountyElectionFunc
{


    public static class ElectionDataFileHandler
    {
        public static void SaveToFile(ElectionData data)
        {            
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SaveToFile($"c:\\temp\\electiondata_{timestamp}.json", data);
        }
        
        public static void SaveToFile(string filePath, ElectionData data)
        {
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }

        public static ElectionData LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Election data file not found.", filePath);

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<ElectionData>(json);
        }

        public static ElectionData LoadFromEmbeddedFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "CountyElectionFunc.Basedata.electiondata.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new FileNotFoundException("Embedded electiondata.json not found.");

                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    return JsonSerializer.Deserialize<ElectionData>(json);
                }
            }
        }
    }
}