using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf03_property
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GbxMain.Text = "컨트롤 학습";
            var fonts = FontFamily.Families.ToList(); // 내 OS 폰트 이름 가져오기
            foreach (var font in fonts)
            {
                CboFontFamily.Items.Add(font.Name);
            }
            // 글자크기 최솟값, 최댓값 지정
            NudPontSize.Minimum = 5; // 폰트 사이즈 최소 5
            NudPontSize.Maximum = 50; // 폰트 사이즈 최대 50

            // 텍스트박스 초기화
            TxtResult.Text = "Hello, Winforms"; 

            NudPontSize.Value = 9; // 글자체 크기를 9로 지정
        }
        /// <summary>
        /// 글자 스타일, 크기, 글자체를 변경해주는 메소드
        /// </summary>
        private void ChangeFontStyle()
        {
            if (CboFontFamily.SelectedIndex < 0)
                return;

            FontStyle style = FontStyle.Regular; // 기본

            if (ChkBold.Checked == true)
            {
                style |= FontStyle.Bold; // Bit 연산 or
            }
            
            if (ChkItalic.Checked == true)
            {
                style |= FontStyle.Italic;
            }

            decimal fontSize = NudPontSize.Value;
            TxtResult.Font = new Font((string)CboFontFamily.SelectedItem, (float)fontSize);
        }

        private void CboFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void NudPontSize_ValueChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

    }
}
