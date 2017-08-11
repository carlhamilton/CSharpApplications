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

namespace HDDActivity
{
    public partial class Form1 : Form
    {
        NotifyIcon hddLedIcon;
        Icon activeIcon;
        Icon idleIcon;
        Thread hddActivity;

        #region Form Data
        public Form1()
        {
            InitializeComponent();
            //Load icon files into objects
            activeIcon = new Icon("HDD_Busy.ico");
            idleIcon = new Icon("HDD_Idle.ico");
            //Create the notify icons and assign idle icon and set it to visible
            hddLedIcon = new NotifyIcon();
            hddLedIcon.Icon = idleIcon;
            hddLedIcon.Visible = true;

            //Create all context menu items and add to tray icons
            MenuItem progNameMenuItem = new MenuItem("HDD Actibity V1 beta by ChtsiUK");
            MenuItem quitMenuItem = new MenuItem("Quit");
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(progNameMenuItem);
            contextMenu.MenuItems.Add(quitMenuItem);


            hddLedIcon.ContextMenu = contextMenu;

            //wire up the quit button

            quitMenuItem.Click += QuitMenuItem_Click;
            
            //Hide the form as it is unused as notification tray application
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            //Start thread to pull HDD activity

            hddActivity = new Thread(new ThreadStart(HddActivityThread));
            hddActivity.Start();
        }

        /// <summary>
        /// Close the application and end the process threads associated with the application
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

        }
    }

}

