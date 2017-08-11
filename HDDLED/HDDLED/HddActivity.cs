using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// This application is designed to show Hard Drive activity, as many modern machines/laptops no longer show this informaton this litte app brings back that ability.
/// Built by Carl Hamilton, inspired from the work of Barnacules.
/// The application takes little resources and can be used at startup. I use this application personally.
/// Keep an eye on the source available at https://github.com/carlhamilton/CSharpApplications/tree/master/HDDLED/HDDLED I will be adding new features and tracking data as my experience progresses.
/// contact me at info@chtsi.uk if you have any questions and/or suggestions.
/// </summary>

namespace HDDActivity
{
    static class HddActivity
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new invisibleForm());
        }
    }
}
