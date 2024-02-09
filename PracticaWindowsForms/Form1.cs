using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PracticaWindowsForms
{
    public partial class Form1 : Form
    {
        Color colorBorde = Color.FromArgb(130, 149, 99);
        public Form1()
        {
            InitializeComponent();
            ModificarBotones();

        }

        private void ModificarBotones()
       {
                btnAceptar.FlatAppearance.BorderColor = colorBorde;
                btnAceptar.FlatAppearance.BorderSize = 2;
                btnCancelar.FlatAppearance.BorderColor = colorBorde;
                btnCancelar.FlatAppearance.BorderSize = 2;
       }


        private void ComprobarCampos()
        {

            List<TextBox> camposAComprobar = this.camposObligatorios();
            
            foreach (TextBox campo in camposAComprobar)
            {
                if (string.IsNullOrEmpty(campo.Text))
                {
                    campo.BackColor = Color.Red;
                }
            }

        }

        private List<TextBox> camposObligatorios()
        {
            List<TextBox> listadoDeCampos = new List<TextBox>();

            listadoDeCampos.Add(txtApellido);
            listadoDeCampos.Add(txtEdad);
            listadoDeCampos.Add(txtDireccion);
            listadoDeCampos.Add(txtNombre);

            return listadoDeCampos;
        }

        private bool ValidarCamposCompletados()
        {
            return (!(string.IsNullOrEmpty(txtApellido.Text) ||
                string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtEdad.Text) ||
                string.IsNullOrEmpty(txtDireccion.Text)));
        }
      
        private void btnAceptar_Click(object sender, EventArgs e) { 

            this.ComprobarCampos();

            string apellido = txtApellido.Text;
            string nombre = txtNombre.Text;
            string edad = txtEdad.Text;
            string direccion = txtDireccion.Text;

            if (ValidarCamposCompletados()) 
            { // Cargo el resultado
            txtResultado.Text = "Apellido y Nombre: " + apellido + " " + nombre + 
                "\r\nEdad: " + edad + "\r\nDirección: " + direccion ;
            } else
            {
                txtResultado.Clear();
                MessageBox.Show("Hay campos incompletos");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            txtApellido.BackColor = SystemColors.Window;
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.BackColor = SystemColors.Window;
        }
        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            txtDireccion.BackColor = SystemColors.Window;
        }
        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            txtEdad.BackColor = SystemColors.Window;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;

        }
        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Compruebo que solo se ingresen datos númericos

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Compruebo que solo se ingresen datos alfabéticos
           
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;

        }


    }
}
