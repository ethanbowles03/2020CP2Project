﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuProgramEB
{
    public partial class mainScreen2Normal : Form
    {
        //private static bool state = false;
        public Form activeMiniForm = null;
        public Form activeChildForm = null;
        //private Form currentFormUp = null;
        //private Form currentFormDown = null;
        public mainScreen2Normal()
        {
            InitializeComponent();
            removeRefresh();
            customDesign();
        }

        private void customDesign()
        {
            panelMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            panelMenu.Visible = false;
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void openChildForm(Form child)
        {
            if (activeChildForm != null)
            {
                activeChildForm.Close();
            }
            activeChildForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(child);
            panelChildForm.Tag = child;
            child.BringToFront();
            child.Show();
        }

        public void openMiniForm(Form mini)
        {
            if (activeMiniForm != null)
            {
                activeMiniForm.Close();
            }
            activeMiniForm = mini;
            mini.TopLevel = false;
            mini.FormBorderStyle = FormBorderStyle.None;
            mini.Dock = DockStyle.Fill;
            panelMiniForm.Controls.Add(mini);
            panelMiniForm.Tag = mini;
            mini.BringToFront();
            mini.Show();
        }

        private void removeRefresh()
        {
            menuRefresh.Hide();
            logRefresh.Hide();
            if (activeChildForm != null)
            {
                activeChildForm.Close();
                
            }
            if (activeMiniForm != null)
            {
                activeMiniForm.Close();
            }
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            removeRefresh();
            hideSubMenu();
            openChildForm(new MenuForm());
            openMiniForm(new MenuButtonsStudent());
            menuRefresh.Show();
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            removeRefresh();
            hideSubMenu();
            openChildForm(new LogScreen());
            logRefresh.Show();
        }

        private void menuRefresh_Click(object sender, EventArgs e)
        {
            openChildForm(new MenuForm());
            openMiniForm(new MenuButtonsStudent());
        }

        private void logRefresh_Click(object sender, EventArgs e)
        {
            openChildForm(new LogScreen());
        }
    }
}
