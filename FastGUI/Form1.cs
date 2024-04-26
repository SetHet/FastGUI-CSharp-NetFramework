
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastGUI.Evaluations;


namespace FastGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fastGUI = new FastGUI.Modules.FastGUI();
        }

        FastGUI.Modules.FastGUI fastGUI;

        private void Form1_Load(object sender, EventArgs e)
        {
            fastGUI.Add(this.textBox1)
                .AddEvaluation(TextBoxEvaluations.NotEmpty);

            fastGUI.Add(this.textBox2)
                .AddEvaluation(TextBoxEvaluations.NotEmpty)
                .AddEvaluation(TextBoxEvaluations.MinEqual(-10))
                .AddEvaluation(TextBoxEvaluations.MaxEqual(50));

            fastGUI.Add(this.textBox3)
                .AddEvaluation(TextBoxEvaluations.NotEmpty)
                .AddEvaluation(TextBoxEvaluations.RegExp("^(\\d{1,3}(?:\\.\\d{3}){2}-[\\dkK])$"));

            fastGUI.Add(this.textBox4)
                .AddEvaluation(TextBoxEvaluations.IsFloat);
                
            fastGUI.Add(this.textBox5)
                .AddEvaluation(TextBoxEvaluations.FirstLetters("KFC"));

            fastGUI.Add(this.textBox6)
                .AddEvaluation(TextBoxEvaluations.LastLetters("KFC"));

            fastGUI.Add(this.textBox7)
                .AddEvaluation(TextBoxEvaluations.Contains("KFC"));

            fastGUI.Add(this.checkBox1).AddEvaluation(CheckBoxEvaluation.Required(this.textBox3, fastGUI));
            //fastGUI.Get(this.checkBox1).AddRequiredControl(this.textBox1);
            fastGUI.Add(this.radioButton1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool evaluation1 = fastGUI.Evaluate();
            bool evaluation2 = fastGUI.EvaluateRequiredOthers();

            MessageBox.Show($"Evaluate All: {evaluation1}\nEvaluate Required: {evaluation2}");
        }

        private void button_chechneedrut_Click(object sender, EventArgs e)
        {
            string text = "";

            if(this.checkBox1.Checked )
            {
                text = "Cheched: True\n";
            }
            else
            {
                text = "Cheched: False\n";
            }

            if (fastGUI.Get(this.checkBox1).Evaluate())
            {
                text += "Evaluacion rut: true";
            }
            else
            {
                text += "Evaluacion rut: false";
            }

            MessageBox.Show($"{text}\nEl rut: {fastGUI.Get(this.textBox3).Get.String()}");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Check KFC.......   => {fastGUI.Get(this.textBox5).Evaluate()}");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Check KFC.......   => {fastGUI.Get(this.textBox6).Evaluate()}");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Check KFC.......   => {fastGUI[this.textBox7].Evaluate()}");
        }
    }
}
