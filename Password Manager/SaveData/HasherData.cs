using System;
using System.Collections.Generic;
using System.Text;

namespace Password_Manager.SaveData
{
    class HasherData
    {
        public List<Hasher> HasherDataList = new List<Hasher>();

        public void AddPassword(string Name, byte[] Salt, int Iterations)
        {
            Hasher haser = new Hasher
            {
                Name = Name,
                Salt = Salt,
                Iterations = Iterations
            };

            HasherDataList.Add(haser);
        }
    }
    public class Hasher
    {
        public string Name { get; set; }
        public byte[] Salt { get; set; }
        public int Iterations { get; set; }
    }
}
