using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CountyElectionFunc
{
    public static class ElectionDataFileHandler
    {
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
    }
}