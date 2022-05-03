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
        private string rrn;
        public string RRN{ get; set; }
        private string DateAndTimeOfReport { get; set; }

        private string location;
        public string Location { get; set; }
        
        private HazardType _hazardType;
        
        private string desc;
        public string Desc { get; set; }
        private string Reporter_Email { get; set; }
        private Status _status;

        private int upvotes { get; set; }

        // General List of reports (RRN):
        public static List<string> General_RRN;  

        public Random Random;

        public Report(string location,
                      HazardType h_type,
                      string description,
                      string email,
                      Status status)
        {
            Random = new Random();
            General_RRN = new List<string>();
            // generate RRN
            this.RRN = Generate_RRN();
            this.DateAndTimeOfReport = DateTime.Now.ToString();

            this.Location = location;
            this._hazardType = h_type;
            this.Desc = description;
            this.Reporter_Email = email;
            this._status = status;
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