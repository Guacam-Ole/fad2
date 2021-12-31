using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fadAuto
{
    public partial class About : MetroForm
    {
        public About()
        {
            InitializeComponent();
        }

      

        private void butOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
