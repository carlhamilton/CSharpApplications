using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalculator
{
    /// <summary>
    /// Holds information about a single calculator operation
    /// </summary>
    public class Operation
    {
        #region Public Properties
        /// <summary>
        /// Left side of operation
        /// </summary>
        public string LeftSide { get; set; }

        /// <summary>
        /// The right side of the operation
        /// </summary>
        public string RightSide { get; set; }

        /// <summary>
        /// The type of operation to perform
        /// </summary>
        public OperationType OperationType { get; set; }

        /// <summary>
        /// /Inner operation to be performed before the operation
        /// </summary>
        public OperationType InnerOperation { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Operation()
        {
            // Create an empty string instead of having null
            this.LeftSide = string.Empty;
            this.RightSide = string.Empty;
        }
        #endregion

    }
}
