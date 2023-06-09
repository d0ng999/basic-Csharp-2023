﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf04_fileCopy
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnFindSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(); // 모달 창
            if (result == DialogResult.OK)
            {
                TxtSource.Text = dialog.FileName;
            }
        }

        private void BtnFindTarget_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(); // 모달 창
            if (result == DialogResult.OK)
            {
                TxtSource.Text = dialog.FileName;
            }
        }

        // 일반적인 동기식 파일복사
        private void BtnSyncCopy_Click(object sender, EventArgs e)
        {
            long totalCopied = CopySync(TxtSource.Text, TxtTarget.Text);
        }

        // 비동기는 호출할때는 await 사용, 구현할때는 async 사용
        private long CopySync(string fromFile, string tofile)
        {
            BtnSyncCopy.Enabled = false; // 비동기버튼 일시 비활성화
            long totalCopied = 0;
            
            using (FileStream fromStream = new FileStream(fromFile, FileMode.Open))
            {// 원본 파일은 열고
                using (FileStream toStream = new FileStream(tofile, FileMode.Create))
                {// 타켓 파일은 생성
                    byte[] buffer = new byte[1024 * 1024]; // 1MByte 버퍼(파일생성의 공간을 만듦)
                    int nRead = 0;
                    while ((nRead = fromStream.Read(buffer, 0, buffer.Length)) != 0) 
                    { 
                        toStream.Write(buffer, 0, nRead);
                        totalCopied += nRead;

                        //프로그래스 바에 표시
                        PgbCopy.Value = (int)(((double)totalCopied / (double)fromStream.Length) * PgbCopy.Maximum);
                    }
                }
            }

            BtnSyncCopy.Enabled = true;
            return totalCopied;
        }
        // 비동기 호출할때는 awit사용, 구현할때는 async 사용
        private async Task<long> CopyAsync(string fromFile, string toFile)
        {
            BtnSyncCopy.Enabled = false; // 동기복사버튼 비활성화

            long totalCopied = 0;

            using (FileStream fromStream = new FileStream(fromFile, FileMode.Open))
            { //원본파일은 열고
                using (FileStream toStream = new FileStream(toFile, FileMode.Create))
                { // 타켓파일은 생성
                    byte[] buffer = new byte[1024 * 1024]; // 1MByte 버퍼
                    int nRead = 0;
                    while ((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead;

                        // 프로그래스바에 표시
                        PgbCopy.Value = (int)((double)totalCopied / (double)fromStream.Length) * PgbCopy.Maximum;

                    }
                }
            }
            BtnSyncCopy.Enabled = true;
            return totalCopied;

        }

        private async void BtnAsyncCopy_Click(object sender, EventArgs e)
        {
            long totalCopied = await CopyAsync(TxtSource.Text, TxtTarget.Text);

        }
    }
}
