using System;
using System.Collections.Generic;

namespace CIS2055___Nemesys.Models.Documents
{
    public class Report
    {
        // todo put these constants outisde of the class scope 
        public const int RAND_MIN = 0;
        public const int RAND_MAX = 10;
        
        private string RRN { get; set; } // report reference number
        private string DateOfReport;
        private string TimeOfReport;

        private string Location;
        private HazardType _hazardType;
        private string Desc;
        private string Reporter_Email;
        private Status _status;

        private int upvotes;

        public static List<string> General_RRN;

        public Random Random;

        public Report()
        {
            Random = new Random();
            // generate RRN
            Generate_RRN();
        }


        private void Generate_RRN()
        {
            int RandomNumber = Random.Next(RAND_MIN, RAND_MAX);
            while (General_RRN.Contains(RandomNumber.ToString()))
            {
                RandomNumber = Random.Next(RAND_MIN, RAND_MAX);
            }
        }
    }
}