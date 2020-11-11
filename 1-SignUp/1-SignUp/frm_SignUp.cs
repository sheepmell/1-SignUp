using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartLinli.DatabaseDevelopement;

namespace _1_SignUp
{
    public partial class frm_SignUp : Form
    {
        public frm_SignUp()
        {
            InitializeComponent();
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            if (this.txt_Password.Text=="")
            {
                MessageBox.Show("请输入密码！");
                return;
            }
            string commandText =
                $@"INSERT tb_Student (No,Password)
                   VALUES('{this.txt_No.Text}','{this.txt_Password.Text}');";
            SqlHelper sqlHelper = new SqlHelper();
            int rowAffected = sqlHelper.QuickSubmit(commandText);

            if (rowAffected==1)
            {
                MessageBox.Show("注册成功！");
            }
            else
            {
                MessageBox.Show("该用户已存在！注册失败！");
            }

            txt_No.Text = "";
            txt_Password.Text = "";
        }

        private void frm_SignUp_Load(object sender, EventArgs e)
        {
                btn_SignUp.Enabled = false;
        }

        private void txt_No_TextChanged(object sender, EventArgs e)
        {
            this.btn_SignUp.Enabled = this.txt_No.Text != "";
        }
    }
}
