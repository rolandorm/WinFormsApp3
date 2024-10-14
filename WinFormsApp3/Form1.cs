using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Los n�meros tienen que ser MAYOR que cero, NO VAC�OS");
                return;
            }

            int Semilla = Convert.ToInt32(textBox1.Text);
            int Maxiter = Convert.ToInt32(textBox2.Text);

            ClassCM generador = new ClassCM();
            List<List<int>> listaSalida = generador.AleatorioCuadradoMedio(Semilla, Maxiter);
            llenarGrid(listaSalida);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void llenarGrid(List<List<int>> listaDeListas)
        {
            // Limpiar el DataGridView antes de llenarlo
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Establecer un n�mero de columnas din�mico basado en el n�mero de listas
            int numeroDeColumnas = listaDeListas.Count;

            dataGridView1.Columns.Add("Aleatorio", "Aleatorio");
            dataGridView1.Columns.Add("Cuadrado", "Cuadrado");
            dataGridView1.Columns.Add("Centros", "Centros");
            dataGridView1.Columns.Add("Izquierdo", "Izquierdo");
            dataGridView1.Columns.Add("Derecho", "Derecho");





            // Determinar el n�mero m�ximo de filas basado en la lista m�s larga
            int numeroDeFilas = listaDeListas.Max(l => l.Count);

            // A�adir filas al DataGridView de forma transpuesta
            for (int i = 0; i < numeroDeFilas; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                // Rellenar cada fila con los valores correspondientes
                for (int j = 0; j < numeroDeColumnas; j++)
                {
                    if (i < listaDeListas[j].Count) // Verifica si hay un valor en la posici�n actual
                    {
                        row.Cells[j].Value = listaDeListas[j][i];
                    }
                    else
                    {
                        row.Cells[j].Value = ""; // Dejar la celda vac�a si no hay m�s elementos
                    }
                }
                dataGridView1.Rows.Add(row);
            }
        }

    }
}
