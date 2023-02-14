using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Lib
{
    class Donor : Person
    {
        string donorID;
        string address;
        string phone;
        char cardType;
        string cardNumber;
        string cardExpiry;

        public Donor(string firstname, string lastname, string donorID, string address, string phone, char cardType, string cardNumber, string cardExpiry) : base(firstname, lastname)
        {
            this.donorID = donorID;
            this.address = address;
            this.phone = phone;
            this.cardType = cardType;
            this.cardNumber = cardNumber;
            this.cardExpiry = cardExpiry;
        }

        public string DonorID
        {
            get { return donorID; }
            set { donorID = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public char CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        public string CardExpiry
        {
            get { return cardExpiry; }
            set { cardExpiry = value; }
        }

        public string getID()
        {
            return donorID;
        }

        public override string toString()
        {
            return base.toString() + "," + DonorID + "," + Address + "," + Phone + "," + CardType + "," + CardNumber + "," + CardExpiry;
        }
    }
}
