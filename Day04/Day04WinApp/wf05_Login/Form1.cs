using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf05_Login
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtID.Text == "abcd" && TxtPW.Text == "1234")
            {
                LblSuccess.Text ="로그인 성공";
            }
            else
            {
                LblSuccess.Text = "로그인 실패";
            }
        }
    }
}
