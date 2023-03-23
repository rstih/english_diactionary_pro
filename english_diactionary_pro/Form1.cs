using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace english_diactionary_pro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eng_dic.en_word_list' table. You can move, or remove it, as needed.
            this.en_word_listTableAdapter.Fill(this.eng_dic.en_word_list);
            this.comboBox1.SelectedIndex = 0;
            try
            {
                this.progress_panel1.Visible = true;
                this.progress_panel1.Refresh();
                this.en_word_listTableAdapter.FillBy_word(this.eng_dic.en_word_list, "a%");
                this.progress_panel1.Visible = false;
            }
            catch (Exception ex)
            {
                this.progress_panel1.Visible = false;
                MessageBox.Show("Error" + ex.Message);
            }

        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            // CODE FOR ERROR; BLANKSPACE, TRIM METHOD USED FOR THIS ERROR
            string w;
            w = this.search_box.Text;
            w = w.Trim();
            
            if(w == "")
            {
                MessageBox.Show("Please Enter your word to search");
                return;
            }
            
            this.progress_panel1.Visible = true;
            this.progress_panel1.Refresh();

            try
            {
                

                if(this.comboBox1.SelectedIndex == 0)
                {
                    this.en_word_listTableAdapter.FillBy_word(this.eng_dic.en_word_list, this.search_box.Text);
                }
                if (this.comboBox1.SelectedIndex == 1)
                {
                    this.en_word_listTableAdapter.FillBy_like_myword(this.eng_dic.en_word_list,
                                                                     this.search_box.Text); 
                }
                if (this.comboBox1.SelectedIndex == 2)
                {
                    this.en_word_listTableAdapter.FillBy_like_myword(this.eng_dic.en_word_list,
                                                                     "%" + this.search_box.Text);
                }
                if (this.comboBox1.SelectedIndex == 3)
                {
                    this.en_word_listTableAdapter.FillBy_like_myword(this.eng_dic.en_word_list,
                                                                    "%" + this.search_box.Text + "%");
                }
            }
            catch (Exception ex)
            {
                this.progress_panel1.Visible = false;
                MessageBox.Show("Error" + ex.Message);
            }
            this.progress_panel1.Visible = false;
        }

       
    }
}
