using System;
using System.Collections.Generic;

namespace CIS2055___Nemesys.Models.Documents
{
    public class Document
    {
        public static List<string> General_RN;
        
        // todo put these constants outisde of the class scope 
        public const int RAND_MIN = 0;
        public const int RAND_MAX = 10;
        
        public Random Random;
        
        // reference number
        protected string RN { get; set; }
        
        protected string Generate_RN()
        {
            int RandomNumber = Random.Next(RAND_MIN, RAND_MAX);
            while (General_RN.Contains(RandomNumber.ToString()))
            {
                RandomNumber = Random.Next(RAND_MIN, RAND_MAX);
            }
            return RandomNumber.ToString();
        }
    }
}