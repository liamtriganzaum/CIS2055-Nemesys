namespace CIS2055___Nemesys.Models.Users
{
    public class User
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // checks if the id is correct according to Maltese standards 
        public bool checkIdCorrect(string id)
        {
            //string into array of char
            char[] charArray = id.ToCharArray();
            bool result = true;

            //loop to check that the first 6 char are digits
            for (int i = 0; i <= 5; i++)
            {
                if (char.IsLetter(charArray[i]))
                {
                    result = false;
                    break;
                }
            }

            //to check that the last char is a letter
            if (char.IsDigit(id, 6))
            {
                result = false;
            }

            return result;
        }

        public bool isValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool checkIfword(string word)
        {
            //string into array of char
            char[] charArray = word.ToCharArray();
            bool result = true;

            //loop to check that the chars are letters
            foreach (char ch in word)
            {
                if (char.IsDigit(ch))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
        
        public bool checkIfnumber(string word)
        {
            bool result = true;
            //loop to check that the chars are digits
            foreach (char ch in word)
            {
                if (char.IsLetter(ch))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

    }
}