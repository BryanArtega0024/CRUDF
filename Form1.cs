using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            refreshPantalla();
            txtId.Enabled = false;
        }

        public void refreshPantalla()
        {
            dataGridView1.DataSource = PersonaDAL.PresentarRegistro();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Persona persona= new Persona();
            persona.nombre = txtNombre.Text;
            persona.edad = Convert.ToInt32(txtEdad.Text);
            persona.celular = txtCelular.Text;

            
            if (dataGridView1.SelectedRows.Count ==1) {  
            int id= Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                

                if (id != null)
                {

                    persona.id = id;
                    int result = PersonaDAL.ModificarPersona(persona);

                if (result > 0)
                {
                    MessageBox.Show("Exito al Modificar");
                }
                else
                {
                    MessageBox.Show("Error al Modificar");
                }

            }
            }
            else
            {
                
                int result = PersonaDAL.AgregarPersona(persona);

                if (result > 0)
                {
                    MessageBox.Show("Exito al Guardar");
                }
                else
                {
                    MessageBox.Show("Error al Guardar");
                }
            }
            refreshPantalla();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtId.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id"].Value);

            txtNombre.Text = Convert.ToString( dataGridView1.CurrentRow.Cells["nombre"].Value);
            txtEdad.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["edad"].Value);
            txtCelular.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["celular"].Value);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 1)

            { 
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);


            int resultado = PersonaDAL.EliminarPersona(id);

            if (resultado > 0)
            {
                MessageBox.Show("Eliminado con exito");
            }
            else {
                MessageBox.Show("Error al eliminar ");

            }
            }
            refreshPantalla();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNombre.Clear();
            txtEdad.Clear();
            txtCelular.Clear();
            dataGridView1.CurrentCell = null;

        }
    }
}
