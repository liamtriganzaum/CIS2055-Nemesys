using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CIS2055___Nemesys.Models.Users
{
    public class Investigator : User
    {
        public List<string> IRN;

        public void AddRRN(string irn)
        {
            IRN.Add(irn);
        }

        public void RemoveRRN(string irn)
        {
            IRN.Remove(irn);
        }
    }
}