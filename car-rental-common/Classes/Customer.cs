using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental_common.Classes
{
    public class Customer
    {
        private string _sSN;
        public string SSN
        {
            get { return _sSN; }
            set
            {
                if (IsValidSSN(value))
                {
                    _sSN = value;
                }
                else
                {
                    throw new ArgumentException("Social security number must be in the format 123456.");
                }
            }
        }
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (IsValidName(value))
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentException("Names can only contain letters.");
                }
            }
        }

        public string LastName { get; set; }

        public Customer(string sSN, string firstName, string lastName)
        {
            SSN = sSN;
            FirstName = firstName;
            LastName = lastName;
        }

        private bool IsValidSSN(string sSN)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(sSN, @"^\d{6}$");
        }

        private bool IsValidName(string firstName)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(firstName, @"^[\p{L}]+$");
        }
    }
}