using System;

namespace Obligatorisk_Opgave_1_2.Models
{
    public class Trophy
    {
        private int _id;
        private string _competition;
        private int _year;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Competition
        {
            get => _competition;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Competition must be at least 3 characters long and cannot be null.");
                }
                _competition = value;
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value < 1970 || value > 2025)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Year must be between 1970 and 2025.");
                }
                _year = value;
            }
        }

        public override string ToString()
        {
            return $"Trophy: Id {Id}, Competition {Competition}, Year {Year}";
        }
    }
}