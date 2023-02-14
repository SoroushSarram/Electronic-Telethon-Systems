using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETS_Lib;

namespace ETS_Windows
{
    public partial class ETSMain : Form
    {
        ETS_Manager telethonSystem = new ETS_Manager();
        public ETSMain()
        {
            InitializeComponent();
        }

        private void buttonAddSponsor_Click(object sender, EventArgs e)
        {
            string msg = telethonSystem.AddSponsor(textBoxfn.Text, textBoxln.Text, textBoxSponID.Text);
            MessageBox.Show(msg);
        }

        private void buttonViewSponsor_Click(object sender, EventArgs e)
        {
            richTextBoxSponsors.Clear();
            richTextBoxSponsors.AppendText(telethonSystem.ListSponsors());
        }

        private void buttonAddPrize_Click(object sender, EventArgs e)
        {
            string msg = telethonSystem.AddPrize(textBoxPrizeID.Text, textBoxDesc.Text, Convert.ToDouble(textBoxValue.Text), Convert.ToInt32(textBoxAmount.Text), Convert.ToDouble(textBoxDonLimit.Text), textBoxSponsorID.Text);
            MessageBox.Show(msg);
        }

        private void buttonViewPrize_Click(object sender, EventArgs e)
        {
            richTextBoxPrizes.Clear();
            richTextBoxPrizes.AppendText(telethonSystem.ListPrizes());
        }

        private void buttonAddDonor_Click(object sender, EventArgs e)
        {
            char cardType = 'V';
            if (radioButtonAmex.Checked == true)
            {
                cardType = 'A'; 
            }
            else if (radioButtonMc.Checked == true)
            {
                cardType = 'M';
            }
            else if (radioButtonVisa.Checked == true)
            {
                cardType = 'V';
            }
            string msg = telethonSystem.AddDonor(textBoxFirstName.Text, textBoxLastName.Text, textBoxDonorId.Text, textBoxAddress.Text, textBoxPhone.Text, cardType, textBoxCardNumber.Text, textBoxExpiry.Text);
            MessageBox.Show(msg);
        }

        private void buttonViewDonor_Click(object sender, EventArgs e)
        {
            richTextBoxDonors.Clear();
            richTextBoxDonors.AppendText(telethonSystem.ListDonors());
        }

        private void buttonAddDonation_Click(object sender, EventArgs e)
        {
            string msg = telethonSystem.AddDonation(textBoxDonationID.Text, textBoxDonorIdd.Text, textBoxDonDate.Text, Convert.ToDouble(textBoxDonAmount.Text), textBoxPID.Text, Convert.ToInt32(textBoxPrizeAmount.Text));
            MessageBox.Show(msg);
        }

        private void buttonViewDonation_Click(object sender, EventArgs e)
        {
            richTextBoxDonations.Clear();
            richTextBoxDonations.AppendText(telethonSystem.ListDonations());
        }

        private void buttonSaveDonor_Click(object sender, EventArgs e)
        {
            telethonSystem.SaveDonors();
            MessageBox.Show("Saved Successfully!");
        }

        private void buttonSaveDonations_Click(object sender, EventArgs e)
        {
            telethonSystem.SaveDonations();
            MessageBox.Show("Saved Successfully!");
        }

        private void buttonWriteDonations_Click(object sender, EventArgs e)
        {
            richTextBoxDonations.AppendText(telethonSystem.WriteDonations());
        }

        private void buttonClearSponsor_Click(object sender, EventArgs e)
        {
            textBoxfn.Clear();
            textBoxln.Clear();
            textBoxSponID.Clear();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonClearPrize_Click(object sender, EventArgs e)
        {
            textBoxPrizeID.Clear();
            textBoxSponsorID.Clear();
            textBoxDesc.Clear();
            textBoxValue.Clear();
            textBoxAmount.Clear();
            textBoxDonLimit.Clear();
        }

        private void buttonExit1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonClearDonor_Click(object sender, EventArgs e)
        {
            textBoxDonorId.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxAddress.Clear();
            textBoxPhone.Clear();
            textBoxCardNumber.Clear();
            textBoxExpiry.Clear();
        }

        private void buttonExit2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonClearDonation_Click(object sender, EventArgs e)
        {
            textBoxDonationID.Clear();
            textBoxDonorIdd.Clear();
            textBoxDonDate.Clear();
            textBoxDonAmount.Clear();
            textBoxPID.Clear();
            textBoxPrizeAmount.Clear();
        }

        private void buttonExit3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonQualifiedPrizes_Click(object sender, EventArgs e)
        {
            string msg = telethonSystem.ListQualifiedPrizes(Convert.ToDouble(textBoxDonAmount.Text));
            MessageBox.Show(msg, "Qualified Prizes");
        }

        private void buttonSearchPrize_Click(object sender, EventArgs e)
        {
            string info = telethonSystem.searchPrize(textBoxSearchPrize.Text);
            MessageBox.Show(info, "Result");
        }

        private void buttonSearchSponsor_Click(object sender, EventArgs e)
        {
            string info = telethonSystem.searchSponsor(textBoxSearchSponsor.Text);
            MessageBox.Show(info, "Result");
        }

        private void buttonSearchDonor_Click(object sender, EventArgs e)
        {
            string info = telethonSystem.searchDonor(textBoxSearchDonor.Text);
            MessageBox.Show(info, "Result");
        }

        private void buttonSearchDonation_Click(object sender, EventArgs e)
        {
            string info = telethonSystem.searchDonation(textBoxSearchDonation.Text);
            MessageBox.Show(info, "Result");
        }
    }
}
