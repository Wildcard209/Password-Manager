using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Password_Manager.SaveData
{
    class MainSaver
    {
        public void Saver(PasswordData passwordData)
        {
            string fileName = "PasswordData.json";
            string jsonString = JsonSerializer.Serialize(passwordData.PasswordDataList);
            File.WriteAllText(fileName, jsonString);

            Console.WriteLine(File.ReadAllText(fileName));
        }

        public List<Password> Loader()
        {
            string fileName = "PasswordData.json";
            List<Password> passwords = new List<Password>();
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                passwords = JsonSerializer.Deserialize<List<Password>>(jsonString);
            }

            return passwords;
        }
    }
}
