using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbOperacion.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperacion.Text = "+";
            lblResultado.Text = "0";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador = Calculadora.ValidarOperador(cmbOperacion.Text);
            Numero num1 = new Numero(txtNumero1.Text);
            Numero num2 = new Numero(txtNumero2.Text);

            lblResultado.Text = Calculadora.Operar(num1, num2, operador).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbOperacion.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperacion.Text = "+";
        }
    }
}
