using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalculator
{
    /// <summary>
    /// Type of operation the calculator can perform
    /// </summary>
    public enum OperationType //enum is a number
    {
        Add, //adds two values together
        Minus, //takes one value from another
        Divide, //divides one number by another
        Multiply //multiplies two numbers together
    }
}
