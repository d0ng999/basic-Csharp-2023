using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf03_property
{
    public partial class frmMain : Form
    {
        Random rnd = new Random();

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
            {
                CboFontFamily.SelectedIndex = 275; // 디폴트는 나눔고딕으로 고정;
            }

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
            TxtResult.Font = new Font((string)CboFontFamily.SelectedItem,
                (float)fontSize, style);

            
        }
        private void ChangeIndent()
        {
            if (RdoNormal.Checked)// 라디오 버튼 추가 이벤트
            {
                TxtResult.Text = TxtResult.Text.Trim();
            }
            else if (RdoIndent.Checked)
            {
                TxtResult.Text = "     " + TxtResult.Text;
            }
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

        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PgbDummy.Value = TrbDummy.Value;
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modal Form",
                Width = 300,
                Height = 200,
                Left = 10,
                Top = 20,
                BackColor = Color.Aqua
            };
            frm.ShowDialog(); // 모달방식으로 자식창을 띄운다.
            // 모달이란 자식창이 켜지면 부모창은 건드릴 수 없음
        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modaless Form",
                Width = 300,
                Height = 200,
                StartPosition = FormStartPosition.CenterScreen,
                // 모달리스는 CenterParents가 안 먹힌다.
                BackColor = Color.GreenYellow
            };
            frm.Show(); // 모달리스 방식으로 자식창 띄운다.
            // 모달리스는 건들 수 있음
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(TxtResult.Text); // 기본적으로 메시지 박스는 모달형식

            // MessageBox.Show(TxtResult.Text, caption : "메시지 창과 메시지 방패");
            // 캡션 사용

            // MessageBox.Show(TxtResult.Text, "메시지 창과 메시지 방패",
            //                 MessageBoxButtons.YesNoCancel); 
            // 버튼 추가 방식

            //MessageBox.Show(TxtResult.Text, "메시지 창과 메시지 방패",
            //                MessageBoxButtons.AbortRetryIgnore,
            //                MessageBoxIcon.Error);
            // 또 다른 형식 , 총 23가지방법이 있다. 여기까지는 알기!!!

            MessageBox.Show(TxtResult.Text, "메시지 창과 메시지 방패",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                             MessageBoxDefaultButton.Button2);
            // MessageBoxDefaultButton : 창이 켜지자 마자 기본적으로 선택되어 있는 버튼

            //MessageBox.Show(TxtResult.Text, "메시지 창과 메시지 방패",
            //                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
            //                 MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            // MessageBoxOptions.RightAlign -- 메시지 창 내용이 오른쪽으로 정렬
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rnd.Next(45).ToString());
            // 숫자를 그냥 넣을 수는 없어서
            // 숫자를 스트링으로 바꿔줘야 한다.
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if (TrvDummy.SelectedNode != null)
            {
                TrvDummy.SelectedNode.Nodes.Add(rnd.Next(50,100).ToString());
                TrvDummy.SelectedNode.Expand();
                // 트리노트 하위것들을 펼쳐주는 것
                // 이거의 반대는 Collapse
                TreeToList();
            }
        }

        void TreeToList()
        {
            LsvDummy.Items.Clear();
            // 리스트 뷰, 트리뷰에 있는 모든 아이템을 초기화
            foreach (TreeNode item in TrvDummy.Nodes)
            {
                TreeToList(item);
            }
        }

        private void TreeToList(TreeNode item)
        {
            LsvDummy.Items.Add(
                new ListViewItem(new[]{ item.Text, item.FullPath.ToString() }));
            foreach (TreeNode node in item.Nodes)
            {
                TreeToList(node); // 재귀호출
            }
        }

        private void RdoNormal_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIndent();
        }

  

        private void RdoIndent_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIndent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            PcbDummy.Image = Bitmap.FromFile("cat.png");
        }

        private void PcbDummy_Click(object sender, EventArgs e)
        {
            if (PcbDummy.SizeMode == PictureBoxSizeMode.Zoom)
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
