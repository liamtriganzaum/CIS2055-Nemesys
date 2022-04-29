using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

namespace CIS2055___Nemesys.Models.Documents
{
    public class Investigation : Document
    {

        private string DateOfAction { get; set; }

        private string Desc { get; set; }
        private string Investigator_Email { get; set; }
        private Status _status;

        public Investigation()
        {
            Random = new Random();
            // generate IRN
            Generate_RN();
        }
        
    }
}