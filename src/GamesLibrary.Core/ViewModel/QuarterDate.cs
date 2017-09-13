using System;

namespace GamesLibrary.Client.Core.ViewModel
{
    /// <summary>
    /// Represents a quarter
    /// </summary>
    public class QuarterDate : IComparable<QuarterDate>
    {
        public QuarterDate(DateTime date)
        {
            var month = date.Month;
            Year = date.Year;

            if (month < 4)
            {
                Quarter = 1;
            }
            else if (month < 7)
            {
                Quarter = 2;
            }
            else if (month < 10)
            {
                Quarter = 3;
            }
            else
            {
                Quarter = 4;
            }
        }

        public int Year { get; set; }

        public short Quarter { get; set; }

        public int CompareTo(QuarterDate other)
        {
            if (this.Year != other.Year)
            {
                return this.Year.CompareTo(other.Year);
            }
            else
            {
                //same year then check quartual
                return this.Quarter.CompareTo(other.Quarter);
            }
        }

        public override bool Equals(object obj)
        {
            var other = (QuarterDate)obj;
            return Year.Equals(other.Year) && Quarter.Equals(other.Quarter);
        }

        public override int GetHashCode()
        {
            return Year.GetHashCode() + Quarter.GetHashCode();
        }

        public override string ToString()
        {
            return Year.ToString() + "/" + Quarter.ToString();
        }

        public string Name
        {
            get { return $"Q{Quarter} {Year}"; }
        }

        public string ShortName
        {
            get { return $"Q{Quarter} {Year}"; }
        }
    }
}