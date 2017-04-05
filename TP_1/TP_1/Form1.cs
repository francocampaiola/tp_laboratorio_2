using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_1
{
    public partial class Form1 : Form
    {
        public Numero num1;
        public Numero num2;
        public string operador;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.num1 = new Numero(double.Parse(txtNumero1.Text));
            this.num2 = new Numero(double.Parse(txtNumero2.Text));

            this.operador = cmbOperador.Text;

            double re = Calculadora.Operar(num1, num2, operador);

            if (num2.cantidad == 0 && operador == "/")
            {
                MessageBox.Show("No está disponible la división por 0", "Atención", MessageBoxButtons.OK);          
                txtNumero1.Text = "";
                txtNumero2.Text = "";
                lblResultado.Text = "";
                cmbOperador.Text = "";
            }

            lblResultado.Text = re.ToString();
            lblResultado.Show();

            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.num1 = new Numero();
            this.num2 = new Numero();
            this.operador = "";

            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
           
            Calculadora.Limpiar(num1, num2, operador);
        }
    }
}
