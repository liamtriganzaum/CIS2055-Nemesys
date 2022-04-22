using System;
using System.Collections.Generic;

namespace CIS2055___Nemesys.Models.Documents
{
    public class Report
    {
        // todo put these constants outisde of the class scope 
        public const int RAND_MIN = 0;
        public const int RAND_MAX = 10;
        
        // report reference number
        private string RRN { get; set; }
        private string DateAndTimeOfReport { get; set; }

        private string Location { get; set; }
        private HazardType _hazardType;
        private string Desc { get; set; }
        private string Reporter_Email { get; set; }
        private Status _status;

        private int upvotes { get; set; }

        public static List<string> General_RRN;

        public Random Random;

        public Report()
        {
            Random = new Random();
            // generate RRN
            Generate_RRN();
        }


        private string Generate_RRN()
        {
            int RandomNumber = Random.Next(RAND_MIN, RAND_MAX);
            while (General_RRN.Contains(RandomNumber.ToString()))
            {
                RandomNumber = Random.Next(RAND_MIN, RAND_MAX);
            }
            return RandomNumber.ToString();
        }
    }
}