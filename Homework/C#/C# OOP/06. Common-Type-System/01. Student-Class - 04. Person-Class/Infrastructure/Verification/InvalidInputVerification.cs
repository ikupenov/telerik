namespace StudentClass.Infrastructure.Verification
{
    using Exception;
    using System.Collections.Generic;

    public static class InvalidInputVerification
    {
        private static List<string> usedSSNumbers;

        static InvalidInputVerification()
        {
            usedSSNumbers = new List<string>();
        }

        public static void VerifyName(string name)
        {
            if (name.Length <= 2)
            {
                throw new InvalidNameException("Name cannot contain less than 3 letters");
            }
            else if (name.Length > 10)
            {
                throw new InvalidNameException("Name cannot contain more than 10 letters");
            }

            foreach (var symb in name)
            {
                if (!char.IsLetter(symb))
                {
                    throw new InvalidNameException("Name cannot contain digits or symbols");
                }
            }
        }

        public static void VerifySSN(string SSN)
        {
            if (SSN.Length != 9)
            {
                throw new InvalidSSNException("The social security number has to contain 9 digits");
            }

            foreach (var symb in SSN)
            {
                if (!char.IsDigit(symb))
                {
                    throw new InvalidSSNException("The social security number cannot contain letters or symbols");
                }
            }

            if (usedSSNumbers.IndexOf(SSN) >= 0)
            {
                throw new InvalidSSNException("The social security number is already taken");
            }

            usedSSNumbers.Add(SSN);
        }

        public static void VerifyPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 10)
            {
                throw new InvalidPhoneNumberException("Phone number cannot contain more or less than 10 digits!");
            }

            foreach (var symb in phoneNumber)
            {
                if (!char.IsDigit(symb))
                {
                    throw new InvalidPhoneNumberException("Phone number cannot contain letters or symbols!");
                }
            }
        }

        public static void VerifyEmailAddress(string emailAddress)
        {
            if (emailAddress.Length < 8)
            {
                throw new InvalidEmailAddressException("Invalid Email Address");
            }

            if (!emailAddress.Contains("@"))
            {
                throw new InvalidEmailAddressException("Invalid Email Address");
            }
        }
    }
}
