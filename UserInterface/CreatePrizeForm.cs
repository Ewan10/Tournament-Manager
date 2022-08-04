using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class CreatePrizeForm : Form 
    {
        public CreatePrizeForm() 
        {
            InitializeComponent();
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Prize prize = new Prize(
                    placeNumberValue.Text,
                    placeNumberValue.Text,
                    prizeAmountValue.Text,
                    prizePercentageValue.Text);
            
            foreach(IDataConnection connection : Configuration.Connections)
            {
                
            }
            }
        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool isPlaceNumberValid = int.TryParse(placeNumberValue.Text, out placeNumber);

            if(!isPlaceNumberValid)
            {
                output = false;
            }

            if(placeNumber < 1)
            {
                output = false;
            }

            if(placeNumberValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool isPrizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool isPrizePercentageValid = double.TryParse(prizePercentageValue.Text, out prizePercentage);

            if(isPrizeAmountValid == false || isPrizePercentageValid == false)
            {
                output = false;
            }

            if(prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }

            if(prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }
    }
}