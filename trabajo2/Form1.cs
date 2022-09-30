using System.Text.RegularExpressions;

namespace trabajo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ErrorProvider errorProvider1=new ErrorProvider();
        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            var textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Tag = "No puede ser vacio";
                
                errorProvider1.SetError(textBox, (string)textBox.Tag);
                e.Cancel = true;
            }
            else
            {
               if (textBox.Text=="0")
                {
                errorProvider1.SetError(textBox, "NO puedes iniciar con 0");
                    e.Cancel = true;
                }
                    
                        }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex exp = new Regex(@"^[0-9]*$");
            if (exp.IsMatch(e.KeyChar.ToString()) || e.KeyChar == (char)Keys.Back

                || e.KeyChar == (char)Keys.Delete)
            {
            }
            else
            {
                textBox1.Tag = "Solo se aceptan numeros";
               // errorProvider1.SetError(textBox1, "solo numeros");
                e.Handled = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          try
          {

            //variable que contiene el numero que se está probando
            int n = 2;
            //variable que contiene el total de numeros primos encontrados
            int total = 1;
            int nt=int.Parse(textBox1.Text);
            //iterar mientras el total de numeros primos no se mayor a 100
            while (total <= nt)
            {

                //variable que indica si un numero es primo o no
                Boolean esPrimo = true;

                //se divide el numero (n) entre todos los numeros anterios a el
                //si el modulo de la division es 0 significa que el numero no es primo
                //y se marca la variable esPrimo = false y se termina el ciclo for
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        esPrimo = false;
                        break;
                    }

                }

                //si despues de ejecutar el ciclo for la variable esPrimo sigue
                //teniendo un valor true entonces se imprime el numero y se incrementa
                // el contador de numeros encontrados total++
                if (esPrimo)
                {
                    listBox1.Items.Add(total.ToString()+" = "+n.ToString());
                    total++;
                }
                //se incrementa para evaluar el siguiente número
                n++;
            }
            }
            catch (Exception)
            {
                MessageBox.Show("No se permite decimales");
                
            }


        }
    }
}