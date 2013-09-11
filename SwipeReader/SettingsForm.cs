using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwipeReader
{
    public partial class SettingsForm : Form
    {
        public int Hour = 0;
        public int Minutes = 0;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void timeMaskedTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (timeMaskedTextBox.Text.Length < 5)
            {
                e.Cancel = true;
                return;
            }

            var time = timeMaskedTextBox.Text.Split(new char[] { ':' });

            int hour = 0;
            int minutes = 0;

            if(!int.TryParse(time[0], out hour) || !int.TryParse(time[1], out minutes))
            {
                e.Cancel=true;
                return;
            }
            
            if ((hour < 0 || hour > 23) || (minutes < 0 || minutes > 59))
            {
                e.Cancel = true;
                return;
            }

            Hour = hour;
            Minutes = minutes;
        }

    }
}
