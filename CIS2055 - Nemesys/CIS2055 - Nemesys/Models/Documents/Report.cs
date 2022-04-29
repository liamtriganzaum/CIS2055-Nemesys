using System;

namespace CIS2055___Nemesys.Models.Documents
{
    public class Report : Document
    {
        private string DateAndTimeOfReport { get; set; }

        private string Location { get; set; }
        private HazardType _hazardType;
        private string Desc { get; set; }
        private string Reporter_Email { get; set; }
        private Status _status;

        private int upvotes { get; set; }

        public Report(string location,
                      HazardType h_type,
                      string description,
                      string email,
                      Status status)
        {
            Random = new Random();
            // generate RRN
            this.RN = Generate_RN();
            this.DateAndTimeOfReport = DateTime.Now.ToString();

            this.Location = location;
            this._hazardType = h_type;
            this.Desc = description;
            this.Reporter_Email = email;
            this._status = status;
        }

        
    }
}