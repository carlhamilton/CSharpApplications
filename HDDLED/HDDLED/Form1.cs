using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Management.Instrumentation;
using System.Collections.Specialized;
using System.Threading;

/// <summary>
/// This application is designed to show Hard Drive activity, as many modern machines/laptops no longer show this informaton this litte app brings back that ability.
/// Built by Carl Hamilton, inspired from the work of Barnacules.
/// The application takes little resources and can be used at startup. I use this application personally.
/// Keep an eye on the source available at https://github.com/carlhamilton/CSharpApplications/tree/master/HDDLED/HDDLED I will be adding new features and tracking data as my experience progresses.
/// contact me at info@chtsi.uk if you have any questions and/or suggestions.
/// </summary>

namespace HDDActivity
{
    public partial class invisibleForm : Form
    {
        NotifyIcon hddLedIcon;
        Icon activeIcon;
        Icon idleIcon;
        Thread hddActivity;

        #region Form Data
        public invisibleForm()
        {
            InitializeComponent();
            //Load icon files into objects
            activeIcon = new Icon("HDD_Busy.ico");
            idleIcon = new Icon("HDD_Idle.ico");
            //Create the notify icons and assign idle icon and set it to visible
            hddLedIcon = new NotifyIcon();
            hddLedIcon.Icon = idleIcon;
            hddLedIcon.Visible = true;
            #region Context Menu Creation and use
            //Create all context menu items and add to tray icons
            MenuItem progNameMenuItem = new MenuItem("HDD Actibity V1 beta by ChtsiUK");
            MenuItem quitMenuItem = new MenuItem("Quit");
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(progNameMenuItem);
            contextMenu.MenuItems.Add(quitMenuItem);
        
            hddLedIcon.ContextMenu = contextMenu;

            //wire up the quit button
            quitMenuItem.Click += QuitMenuItem_Click;
            #endregion  
            //Hide the form as it is unused as notification tray application
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            //Start thread to pull HDD activity

            hddActivity = new Thread(new ThreadStart(HddActivityThread));
            hddActivity.Start();
        }

        /// <summary>
        /// Close the application and end the process threads associated with the application
        /// without closing the threads the application would crash as the UI would close without the thread processses.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            hddActivity.Abort();
            hddLedIcon.Dispose();
            this.Close();
        }
        #endregion

        #region Threads
        /// <summary>
        /// This is the thread that pulls the hdd activity
        /// </summary>
        public void HddActivityThread()
        {
            //Accesses the class that provides I/O data so we can detect activity
            ManagementClass driveDataClass = new ManagementClass("win32_PerfFormattedData_PerfDisk_PhysicalDisk");
            try
            {
                

                //Main loop for hdd activity
                while (true)
                {
                    //connect to drive performance instance
                    ManagementObjectCollection driveDataClassCollection = driveDataClass.GetInstances();
                    foreach( ManagementObject obj in driveDataClassCollection)
                    {
                        //only connect to total instance ignore the indiividual
                        if( obj["Name"].ToString() == "_Total")
                        {
                            if( Convert.ToUInt64(obj["DiskBytesPerSec"]) > 0 )
                            {
                                hddLedIcon.Icon = activeIcon;
                                //show busy icon
                            }
                            else
                            {
                                hddLedIcon.Icon = idleIcon;
                                //Show idle icon
                            }
                        }
                    }
                    //We add a sleep to the thread to prevent CPU overuse, by adding this sleep we dramatically reduce CPU usage
                    Thread.Sleep(100);

                }

            }catch( ThreadAbortException tbe)
            {
                //Thread was aborted
                driveDataClass.Dispose();
            }
        }

        #endregion
    

        private void Form1_Load(object sender, EventArgs e)
        {
            //No use for this function as the form is never used but we need this here due to the nature of our application.
        }
    }

}

