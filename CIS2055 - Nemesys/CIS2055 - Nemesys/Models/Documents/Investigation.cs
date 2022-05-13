using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

namespace CIS2055___Nemesys.Models.Documents
{
    public class Investigation
    {
        // todo put these constants outisde of the class scope 
        public const int RAND_MIN = 0;
        public const int RAND_MAX = 10;

        [Key]
        public int IRN { get; set; } // investigation reference number
        public DateTime DateOfAction { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Investigator_Email { get; set; }
        public Status _status;

        public static List<string> General_IRN;

        public Random Random;

        public Investigation()
        {
            this.DateOfAction = DateTime.Now;
        }
    }
}