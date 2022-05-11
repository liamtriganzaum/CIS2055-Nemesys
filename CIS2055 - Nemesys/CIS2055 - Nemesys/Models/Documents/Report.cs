using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CIS2055___Nemesys.Models.Documents
{
    public class Report
    {
        // todo put these constants outisde of the class scope 
        public const int RAND_MIN = 0;
        public const int RAND_MAX = 10;
        
        // report reference number
        [Key]
        public int RRN { get; set; }
        public DateTime DateAndTimeOfReport { get; set; }
        
        public string Title { get; set; }
        public string Location { get; set; }
        
        public HazardType _hazardType;
        
        public string Desc { get; set; }
        public  string Reporter_Email { get; set; }
        public  Status _status;

        public int upvotes { get; set; }

        // General List of reports (RRN):
        public static List<string> General_RRN;  

        public Random Random;

        public Report()
        {
            this.DateAndTimeOfReport = DateTime.Now;
        }
    }
}