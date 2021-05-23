using System;
using System.Collections.Generic;
using System.Text;

namespace Password_Manager.SaveData
{
    public class Password
    {
        public string Name { get; set; }
        public byte[] Cipher { get; set; }
        public byte[] IV { get; set; }
    }

    public class PasswordData
    {
        public List<Password> PasswordDataList = new List<Password>();

        public void AddPassword(string Name, byte[] Chipher, byte[] IV)
        {
            Password password = new Password
            {
                Name = Name,
                Cipher = Chipher,
                IV = IV
            };

            PasswordDataList.Add(password);
        }
    }
}
