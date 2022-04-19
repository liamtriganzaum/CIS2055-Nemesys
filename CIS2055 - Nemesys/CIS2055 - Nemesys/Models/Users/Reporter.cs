using System;
using System.Collections.Generic;

//using System.Collections.Generic;

namespace CIS2055___Nemesys.Models.Users
{
    public class Reporter: User
    {
        public List<string> RRN;

        public void AddRRN(string rrn)
        {
            RRN.Add(rrn);
        }

        public void RemoveRRN(string rrn)
        {
            RRN.Remove(rrn);
        }
    }
}