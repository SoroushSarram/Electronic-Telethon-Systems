using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Lib
{
    class Prize
    {
        string prizeID;
        string description;
        double value;
        double donationLimit;
        int originalAvailable;
        int currentAvailable;
        string sponsorID;

        public Prize(string prizeID, string description, double value, double donationLimit, int originalAvailable, int currentAvailable, string sponsorID)
        {
            this.prizeID = prizeID;
            this.description = description;
            this.value = value;
            this.donationLimit = donationLimit;
            this.originalAvailable = originalAvailable;
            this.currentAvailable = currentAvailable;
            this.sponsorID = sponsorID;
        }

        public string PrizeID
        {
            get { return prizeID; }
            set { prizeID = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Value
        {
            get { return value; }
            set { this.value = value;  }
        }

        public double DonationLimit
        {
            get { return donationLimit; }
            set { donationLimit = value; }
        }

        public int OriginalAvailable
        {
            get { return originalAvailable; }
            set { originalAvailable = value; }
        }

        public int CurrentAvailable
        {
            get { return currentAvailable; }
            set { currentAvailable = value; }
        }

        public string SponsorID
        {
            get { return sponsorID; }
            set { sponsorID = value; }
        }

        public string getPrizeID()
        {
            return prizeID;
        }

        public void decrease(int amount)
        {
            currentAvailable -= amount;
        }

        public string toString()
        {
            return PrizeID + "," + Description + "," + Value + "," + DonationLimit + "," + OriginalAvailable + "," + CurrentAvailable + "," + SponsorID;
        }
    }
}
