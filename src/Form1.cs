using System;
using System.Windows.Forms;

namespace UltraCtrlAltF4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ContextMenu cm;
            MenuItem miCurr;
            int iIndex = 0;


            
            cm = new ContextMenu();

            
            miCurr = new MenuItem();
            miCurr.Index = iIndex++;
            miCurr.Text = "&Exit";
            miCurr.Click += new System.EventHandler(Action1Click);
            cm.MenuItems.Add(miCurr);

            notifyIcon1.Icon = Properties.Resources.ultraaltf4;
            notifyIcon1.Text = "UltraCtrlAltF4 by SnGmng";
            notifyIcon1.Visible = true;
            notifyIcon1.ContextMenu = cm;

            Application.Run();
        }

        private void Action1Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
