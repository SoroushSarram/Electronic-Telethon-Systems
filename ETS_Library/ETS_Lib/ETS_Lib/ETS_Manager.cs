using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Lib
{
    public class ETS_Manager
    {
        Donors myDonors = new Donors();
        Sponsors mySponsors = new Sponsors();
        Donations myDonations = new Donations();
        Prizes myPrizes = new Prizes();

        public string WriteDonations()
        {
            string allInfo = "";
            using (StreamReader sr = new StreamReader(@"C:\Users\Lenovo\Documents\Multi-tier Applications\ETS_Windows\Files\Donations.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();

                    strArray = str.Split(',');
                    Donation donation = new Donation(strArray[0], strArray[1], strArray[2], double.Parse(strArray[3]), strArray[4]);
                    myDonations.add(donation);
                }
            }
            foreach (Donation donation in myDonations)
            {
                allInfo += donation.toString();
                allInfo += Environment.NewLine;
            }
            return allInfo;
        }

        public void SaveDonors()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Lenovo\Documents\Multi-tier Applications\ETS_Windows\Files\Donors.txt"))
            {
                foreach (Donor donor in myDonors)
                {
                    sw.WriteLine(donor.toString());
                }
            }
        }

        public void SaveDonations()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Lenovo\Documents\Multi-tier Applications\ETS_Windows\Files\Donations.txt"))
            {
                foreach (Donation don in myDonations)
                {
                    sw.WriteLine(don.toString());
                }
            }
        }


        public string ListSponsors()
        {
            string allInfo = "";
            foreach (Sponsor sponsor in mySponsors)
            {
                allInfo += sponsor.toString();
                allInfo += Environment.NewLine;
            }
            return allInfo;
        }

        public string ListDonors()
        {
            string allInfo = "";
            foreach (Donor donor in myDonors)
            {
                allInfo += donor.toString();
                allInfo += Environment.NewLine;
            }
            return allInfo;
        }

        public string ListPrizes()
        {
            string allInfo = "";
            foreach (Prize prize in myPrizes)
            {
                allInfo += prize.toString();
                allInfo += Environment.NewLine;
            }
            return allInfo;
        }

        public string ListDonations()
        {
            string allInfo = "";
            foreach (Donation don in myDonations)
            {
                allInfo += don.toString();
                allInfo += Environment.NewLine;
            }
            return allInfo;
        }

        public string ListQualifiedPrizes(double amount)
        {
            string allInfo = "";
            foreach (Prize prize in myPrizes)
            {
                if (prize.DonationLimit < amount)
                {
                    allInfo += prize.toString();
                    allInfo += Environment.NewLine;
                }
            }
            return allInfo;
        }


        public double SponsorTotalPrize(string SID)
        {
            double totalValue = 0;
            foreach (Prize prize in myPrizes)
            {
                if (prize.SponsorID == SID)
                    totalValue += prize.Value * prize.CurrentAvailable;
            }
            return totalValue;
        }

        public bool MinimumLimitChecker(string PID, double donAmount)
        {
            bool flag = true;
            foreach (Prize prize in myPrizes)
            {
                if (prize.getPrizeID() == PID)
                {
                    if (donAmount < prize.DonationLimit)
                    {
                        flag = false;
                    }
                }
            }
            return flag;
        }

        public double fetchValueFromPrizeID(string PID)
        {
            double val = 0;
            foreach (Prize prize in myPrizes)
            {
                if (prize.getPrizeID() == PID)
                {
                    val = prize.Value;
                }
            }
            return val;
        }

        public string fetchSponsorIdFromPrizeID(string PID)
        {
            string SID = "";
            foreach (Prize prize in myPrizes)
            {
                if (prize.getPrizeID() == PID)
                {
                    SID = prize.SponsorID;
                }
            }
            return SID;
        }

        public void PrizeReducer(string PID, int amount)
        {
            foreach (Prize prize in myPrizes)
            {
                if (prize.getPrizeID() == PID)
                {
                    prize.decrease(amount);
                }
            }
            foreach (Sponsor sponsor in mySponsors)
            {
                if (sponsor.getID() == fetchSponsorIdFromPrizeID(PID))
                {
                    sponsor.TotalPrizeValue -= (amount * fetchValueFromPrizeID(PID));
                }
            }
        }

        public bool isPrizeNegative(string PID, int amount)
        {
            bool flag = false;
            foreach (Prize prize in myPrizes)
            {
                if (prize.getPrizeID() == PID)
                {
                    if (prize.CurrentAvailable - amount < 0)
                    {
                        return true;
                    }                    
                }
            }
            return flag;
        }
        
        public void PrizeValueAdderToSponsor(string SID, int amount, double value)
        {
            foreach(Sponsor sponsor in mySponsors)
            {
                if (sponsor.getID() == SID)
                {
                    sponsor.addValue(amount, value);
                }
            }
        }


        public bool donationVerifier(string DonationID)
        {
            bool flag = false;
            foreach (Donation don in myDonations)
            {
                if (don.getID() == DonationID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool prizeVerifier(string PID)
        {
            bool flag = false;
            foreach (Prize prize in myPrizes)
            {
                if (prize.getPrizeID() == PID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool sponsorVerifier(string SID)
        {
            bool flag = false;
            foreach (Sponsor sponsor in mySponsors)
            {
                if (sponsor.getID() == SID)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool donorVerifier(string donorID)
        {
            bool flag = false;
            foreach (Donor donor in myDonors)
            {
                if (donor.getID() == donorID)
                {
                    flag = true;
                }                
            }
            return flag;
        }


        public string searchSponsor(string SID)
        {
            string allInfo = "";
            if (sponsorVerifier(SID) == true)
            {
                allInfo = ListSponsors();
            }
            else
            {
                allInfo = "Sponsor " + SID + " not found!";
            }
            return allInfo;
        }

        public string searchPrize(string PID)
        {
            string allInfo = "";
            if (prizeVerifier(PID) == true)
            {
                allInfo = ListPrizes();
            }
            else
            {
                allInfo = "Prize " + PID + " not found!";
            }
            return allInfo;
        }

        public string searchDonor(string DID)
        {
            string allInfo = "";
            if (donorVerifier(DID) == true)
            {
                allInfo = ListDonors();
            }
            else
            {
                allInfo = " Donor " + DID + " not found!";
            }
            return allInfo;
        }

        public string searchDonation(string donID)
        {
            string allInfo = "";
            if (donationVerifier(donID) == true)
            {
                allInfo = ListDonations();
            }
            else
            {
                allInfo = " Donation " + donID + " not found!";
            }
            return donID;
        }


        public string AddDonor(string firstname, string lastname, string donorID, string address, string phone, char cardType, string cardNumber, string cardExpiry)
        {
            string message = "";
            if (donorID.Length < 4)
            {
                message = "Error! Donor ID must be exactly 4 characters";
            }
            else
            {
                if (donorVerifier(donorID) == true)
                {
                    message = "Error! There is another donor with this ID";
                }
                else
                {
                    if (cardNumber.Length != 16)
                    {
                        message = "Error! the card number must be exactly 16 characters";
                    }
                    else
                    {
                        Donor donor = new Donor(firstname, lastname, donorID, address, phone, cardType, cardNumber, cardExpiry);
                        myDonors.add(donor);
                        message = "Donor added successfully!";
                    }
                }
            }
            return message;
        }

        public string AddSponsor(string firstname, string lastname, string sponsorId)
        {
            string message = " ";
            if (sponsorId.Length < 4)
            {
                message = "Error! Sponsor ID must be exactly 4 characters"; 
            }
            else if (sponsorVerifier(sponsorId) == true)
            {
                message = "Error! there's already one sponsor with this ID";
            }
            else
            {
                double totalPrizeValue = SponsorTotalPrize(sponsorId);
                Sponsor sponsor = new Sponsor(firstname, lastname, sponsorId, totalPrizeValue);
                mySponsors.add(sponsor);
                message = "Sponsor added successfully!";
            }
            return message;
        }

        public string AddPrize(string prizeID, string description, double value, int amount, double donationLimit, string sponsorID)
        {
            string message = " ";
            if (prizeID.Length < 4)
            {
                message = "Error! Prize ID should be exactly 4 characters";
            }
            else if (prizeVerifier(prizeID) == true)
            {
                message = "Error! there's already a prize with this ID";
            }
            else if (sponsorVerifier(sponsorID) == false)
            {
                message = "Error! there's no sponsor with this ID";
            }
            else if (value > 299.99)
            {
                message = "Error! the maximum price shouldn't be more that $299.99";
            }
            else if (amount > 999)
            {
                message = "Error! the amount shouldn't be more than 999";
            }
            else
            {
                int currAvailable = amount;
                PrizeValueAdderToSponsor(sponsorID, amount, value);
                Prize prize = new Prize(prizeID, description, value, donationLimit, amount, currAvailable, sponsorID);
                myPrizes.add(prize);
                message = "Prize added successfully!";
            }
            return message;
        }

        public string AddDonation(string donationID, string donorID, string donationDate, double donationAmount, string prizeID, int prizeAmount)
        {
            string message = " ";
            if (donationID.Length < 4)
            {
                message = "Error! Donation ID should be exactly 4 charachters";
            }
            else if (donationVerifier(donationID) == true)
            {
                message = "Error! there's already one donation with this ID";
            }
            else if (donorID.Length < 4)
            {
                message = "Error! Donor ID should be exactly 4 charachters";
            }
            else if (donorVerifier(donorID) == false)
            {
                message = "Error! there's no donor with this ID";
            }
            else if (donationAmount < 5 || donationAmount > 999999.99)
            {
                message = "Error! donation amount should be between $5 and $999999.99";
            }
            else if (prizeID.Length < 4)
            {
                message = "Error! Prize ID should be exactly 4 charachters";
            }
            else if (prizeVerifier(prizeID) == false)
            {
                message = "Error! there's no prize with this ID";
            }
            else if (isPrizeNegative(prizeID, prizeAmount) == true)
            {
                message = "Error! there are not enough prize available";
            }
            else if (MinimumLimitChecker(prizeID, donationAmount) == false)
            {
                message = "Error! this prize's minimum donation limit is more that the donation amount";
            }
            else
            {
                PrizeReducer(prizeID, prizeAmount);
                Donation donation = new Donation(donationID, donationDate, donorID, donationAmount, prizeID);
                myDonations.add(donation);
                message = "Donation added successfully!";
            }
            return message;
        }
    }
}
