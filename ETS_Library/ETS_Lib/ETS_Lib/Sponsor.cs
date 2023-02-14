using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Lib
{
    class Sponsor : Person
    {
        string sponsorID;
        double totalPrizeValue;

        public Sponsor(string firstname, string lastname, string sponsorId, double totalPrizeValue) : base(firstname, lastname)
        {
            this.sponsorID = sponsorId;
            this.totalPrizeValue = totalPrizeValue;
        }

        public string SponsorID
        {
            get { return sponsorID; }
            set { sponsorID = value; }
        }

        public double TotalPrizeValue
        {
            get { return totalPrizeValue; }
            set { totalPrizeValue = value; }
        }

        public string getID()
        {
            return sponsorID;
        }

        public void addValue(int amount, double value)
        {
            totalPrizeValue += (amount * value);
        }

        public void reduceValue(int amount, double value)
        {
            TotalPrizeValue -= (amount * value);
        }

        public override string toString()
        {
            return base.toString() + "," + SponsorID + "," + TotalPrizeValue;
        }
    }
}
