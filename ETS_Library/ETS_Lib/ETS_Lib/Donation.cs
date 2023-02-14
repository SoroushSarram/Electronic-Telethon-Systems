using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Lib
{
    class Donation
    {
        string donationID;
        string donationDate;
        string donorID;
        double donationAmount;
        string prizeID;

        public Donation(string donationID, string donationDate, string donorID, double donationAmount, string prizeID)
        {
            this.donationID = donationID;
            this.donationDate = donationDate;
            this.donorID = donorID;
            this.donationAmount = donationAmount;
            this.prizeID = prizeID;
        }

        public string DonationID
        {
            get { return donationID; }
            set { donationID = value; }
        }

        public string DonationDate
        {
            get { return donationDate; }
            set { donationDate = value; }
        }

        public string DonorID
        {
            get { return donorID; }
            set { donorID = value; }
        }

        public double DonationAmount
        {
            get { return donationAmount; }
            set { donationAmount = value; }
        }

        public string PrizeID
        {
            get { return prizeID; }
            set { prizeID = value; }
        }

        public string getID()
        {
            return donationID;
        }

        public string toString()
        {
            return DonationID + "," + DonationDate + "," + DonorID + "," + DonationAmount + "," + PrizeID;
        }
    }
}
