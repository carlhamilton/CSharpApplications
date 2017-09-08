using System;
using System.Linq;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class h : Form
    {
        #region Constructor
        public h()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        #region Clear Statements
        private void CEButton_Click(object sender, EventArgs e)
        {
            this.UserInputText.Text = string.Empty;
            FocusInputText();
        }

        private void CButton_Click(object sender, EventArgs e)
        {
            RemoveTextValue();

            FocusInputText();
        }
        #endregion



        private void Text_Click(object sender, EventArgs e)
        {

        }

        

        #region Operator Methods

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("*");
            FocusInputText();
        }

      

        private void MinusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("-");
            FocusInputText();
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("+");
            FocusInputText();
        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("/");
            FocusInputText();
        }
        #endregion


        #region Number Methods
        private void ZeroButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("0");
            FocusInputText();
            //);
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("1");
            FocusInputText();
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("2");
            FocusInputText();
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("3");
            FocusInputText();
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("4");
            FocusInputText();
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("5");
            FocusInputText();
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("6");
            FocusInputText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertTextValue("7");
            FocusInputText();
        }


        private void EightButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("8");
            FocusInputText();
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("9");
            FocusInputText();
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            InsertTextValue(".");
            FocusInputText();
        }
        #endregion

        #region Calculations

        private void EqualButton_Click(object sender, EventArgs e)
        {
            CalculateEquation();
            FocusInputText();
        }

        
        private void CalculateEquation()
        {
            
           //Add our ParseOperati
            this.CalculationResultText.Text = ParseOperation();

            FocusInputText();

        }

        /// <summary>
        /// Parses the users equation and calculates the result
        /// </summary>
        /// <returns></returns>

        private string ParseOperation()
        {
            #region Catch Exceptions to present user with the error
            try
            {
                /// Get the users equation input
                var input = this.UserInputText.Text;

                //Remove all spaces
                input = input.Replace(" ", "");

                //Creates a new top-level operation
                var operation = new Operation();
                var leftSide = true;


                //loop through each character of the input starting from left to right
                for (int i = 0; i <input.Length; i++)
                {
                    // TODO: Handle order priority
                    //Example 4 + 5 * 3
                    // It should calculate 5*3 first and then the 4 + the result (so 4 + 15)

                    var myString = "0123456789.";

                if (myString.Any(c => input[i] == c))
                    {
                        if (leftSide)
                            operation.Lefside = AddNumberPart(operation.Lefside, input[i]);
                    }
                }
                return string.Empty;

            }
            catch(Exception ex)
            {
                return $"Invalid equation. {ex.Message}";
            }
            #endregion

        }

        /// <summary>
        /// Attempts to add a new character to the current number, checking for valid characters as it goes
        /// </summary>
        /// <param name="currentNumber"></param>
        /// <param name="newCharacter">The new charater to append to the string </param>
        /// <returns></returns>
        private string AddNumberPart(string currentNumber, char newCharacter)
        {
            //Check if there is already a . in the number
            if (newCharacter == '.' && currentNumber.Contains('.'))
                throw new InvalidOperationException($"Number {currentNumber} already contains a . and another cannot be added");

            return currentNumber + newCharacter;
            
        }
        #endregion



        /// <summary>
        /// focuses user input text
        /// </summary>
        /// 

        #region Private Helpers
        private void FocusInputText()
        {
            this.UserInputText.Focus();
        }

        private void InsertTextValue(string value)
        {
            //remembers the selection start
            var selectionStart = this.UserInputText.SelectionStart;
            this.UserInputText.Text = this.UserInputText.Text.Insert(this.UserInputText.SelectionStart, value);
            //restore selection start
            this.UserInputText.SelectionStart = selectionStart + value.Length;

            //set selection to 0
            this.UserInputText.SelectionLength = 0;
        }

        private void RemoveTextValue()
        {
           

            //if we don't have a value to delete then return
            if (this.UserInputText.Text.Length < this.UserInputText.SelectionStart + 1)
                return;

            //remembers the selection start
            var selectionStart = this.UserInputText.SelectionStart;

            //Delete the character to the right of the selection
            this.UserInputText.Text = this.UserInputText.Text.Remove(this.UserInputText.SelectionStart, 1);

            //restore selection start
            this.UserInputText.SelectionStart = selectionStart;

            //set selection to 0
            this.UserInputText.SelectionLength = 0;
        }




        #endregion

        
    }
}
