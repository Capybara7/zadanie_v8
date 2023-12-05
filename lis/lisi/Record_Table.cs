// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System.Windows.Forms;

namespace lisi
{
    public partial class Record_Table : Form
    {
        public Record_Table()
        {
            InitializeComponent();
        }

        private void KeyPresss(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == '-') || (e.KeyChar == '.'))
            {
                return;
            }
            e.Handled = true;
        }
    }
}
