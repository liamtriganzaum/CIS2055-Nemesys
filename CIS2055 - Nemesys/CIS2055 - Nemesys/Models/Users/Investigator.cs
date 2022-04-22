using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CIS2055___Nemesys.Models.Users
{
    public class Investigator : User
    {
        public List<string> IRN;

        public void AddIRN(string irn)
        {
            IRN.Add(irn);
        }

        public void RemoveIRN(string irn) {
        
            IRN.Remove(irn);
        }
    }
}