using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
 
namespace Develop02
{

    class JournalHelper
    {

        public static void SaveFile(Journal Diary, string name_file)
        {
            string json = JsonSerializer.Serialize(Diary);
            File.WriteAllText(name_file, json);
        }


        public static Journal LoadFile(string file_name)
        {
            if (!File.Exists(file_name))
            {
                return new Journal();
            }
            string json = File.ReadAllText(file_name);
            return JsonSerializer.Deserialize<Journal>(json);
        }
    }
}