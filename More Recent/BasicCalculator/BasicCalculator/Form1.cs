using System.Drawing.Text;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class BasicCalculator : Form
    {
        #region Constructor
        public BasicCalculator()
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
                for (int i = 0; i < input.Length; i++)
                {
                    // TODO: Handle order priority
                    //Example 4 + 5 * 3
                    // It should calculate 5*3 first and then the 4 + the result (so 4 + 15)

                    var numberRange = "0123456789.";

                    if (numberRange.Any(c => input[i] == c))
                    {
                        if (leftSide)
                            operation.LeftSide = AddNumberPart(operation.LeftSide, input[i]);
                        else operation.RightSide = AddNumberPart(operation.RightSide, input[i]);
                    }
                    // Check if the character is an operator ( + - * /)
                    else if ("+-*/".Any(c => input[i] == c))
                    {
                        // If we are on the righ side already, we now need to calculate our current operation
                        // we set the result to the left side of the next operation
                        if (!leftSide)
                        {
                            //Get operator type
                            var operatorType = GetOperationType(input[i]);

                            if (operation.RightSide.Length == 0)
                            {
                                // Check the operator is nit minus ( as it could be a negaive number
                                if (operatorType != OperationType.Minus)
                                    throw new InvalidOperationException($"Operator (+ * / or more than one -) specified without any right side number");

                                // if we got here the operator type is a minus and there is no left number currently, so add the minus to the number
                                operation.RightSide += input[i];
                            }
                            else
                            {
                                // 4 + 5 * as an example
                              
                                //Calculate previous equation and set the left side
                                operation.LeftSide = CalculateOperation(operation);

                                //set new operator 
                                operation.OperationType = operatorType;

                                //Clear the previous right number
                                operation.RightSide = string.Empty;


                            }
                        }
                        else
                        {
                            //Get operator type
                            var operatorType = GetOperationType(input[i]);
                            //Check if we have a left side number
                            if (operation.LeftSide.Length == 0)
                            {
                                // Check the operator is nit minus ( as it could be a negaive number
                                if (operatorType != OperationType.Minus)
                                    throw new InvalidOperationException($"Operator (+ * / or more than one -) specified without any left side number");

                                // if we got here the operator type is a minus and there is no left number currently, so add the minus to the number
                                operation.LeftSide += input[i];
                            }
                            else
                            {
                                // if we get here we have a left number and now an operator so we want to move to the right side

                                // set the operation type
                                operation.OperationType = operatorType;

                                //Move to the right side
                                leftSide = false;
                            }
                        }
                    }
                }

                // If we are done parsing, and there are no exceptions
                // calculate the current operation
                
                return CalculateOperation(operation);

            }
            catch(Exception ex)
            {
                return $"Invalid equation. {ex.Message}";
            }
            #endregion


            
        }

        /// <summary>
        /// Calculates an <see cref="Operation"/> and returns the result
        /// </summary>
        /// <param name="operation">The operation to calculate</param>

        private string CalculateOperation(Operation operation)
        {
            // Store number values of the string representation
            decimal left = 0;
            decimal right = 0;

            // Check if we have a valid left side number (not blank string) or if the number is invalid
            if (string.IsNullOrEmpty(operation.LeftSide) || !decimal.TryParse(operation.LeftSide, out left))
                throw new InvalidOperationException($"Left side of the operation was not a number. {operation.LeftSide}");
            // Check if we have a valid right side number (not blank string) or if the number is invalid
            if (string.IsNullOrEmpty(operation.RightSide) || !decimal.TryParse(operation.RightSide, out right))
                throw new InvalidOperationException($"Right side of the operation was not a number. {operation.RightSide}");

            try
            {
                switch (operation.OperationType)
                {
                    case OperationType.Add:
                        return (left + right).ToString();
                    case OperationType.Minus:
                        return (left - right).ToString();
                    case OperationType.Divide:
                        return (left / right).ToString();
                    case OperationType.Multiply:
                        return (left * right).ToString();
                    default:
                        throw new InvalidOperationException($"Unknown operator type when calculating operation {operation.OperationType}");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to calculate operation {operation.LeftSide} {operation.OperationType} {operation.RightSide}. {ex.Message}");
            }

            return string.Empty;
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
        /// Accepts a character and returns the known <see cref="OperationType"/>
        /// </summary>
        /// <param name="character">The character to parse</param>
        /// <returns></returns>
        private OperationType GetOperationType(char character)
        {
            switch (character)
            {
                case '+':
                    return OperationType.Add;
                case '-':
                    return OperationType.Minus;
                case '/':
                    return OperationType.Divide;
                case '*':
                    return OperationType.Multiply;
                default:
                    throw new InvalidOperationException($"Unknown operator type {character}");
            }
        }



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
