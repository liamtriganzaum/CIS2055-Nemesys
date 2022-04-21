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

        private string IRN { get; set; } // investigation reference number
        private string DateOfAction { get; set; }

        private string Desc { get; set; }
        private string Investigator_Email { get; set; }
        private Status _status;

        public static List<string> General_IRN;

        public Random Random;

        public Investigation()
        {
            Random = new Random();
            // generate IRN
            Generate_IRN();
        }


        private void Generate_IRN()
        {
            int RandomNumber = Random.Next(RAND_MIN, RAND_MAX);
            while (General_IRN.Contains(RandomNumber.ToString()))
            {
                RandomNumber = Random.Next(RAND_MIN, RAND_MAX);
            }
        }
    }
}