using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class SchoolData
    {
        public long money;
        public long fame;
        public string name;
        public List<string> facilities = new List<string>();
    }
}
