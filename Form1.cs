using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problema1_3_Banco_Nico_V1
{
    public partial class Form1 : Form
    {
        ConexionBD cnn;
        public Form1()
        {
            InitializeComponent();
            cnn = new ConexionBD();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCombo();
            MostarCampos(false);
            txtCodigo.Enabled = false;
            CargarLista();
            LimpiarCampos();
            btnEditar.Enabled = false;  
          
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtDNI.Text = String.Empty;
            cboTipoCuenta.SelectedIndex = -1;
            txtCBU.Text = String.Empty;
            txtSaldo.Text = String.Empty;
            dtpUltimoMovimiento.Value = DateTime.Now;
        }

        private void MostarCampos(bool v)
        {
            txtApellido.Enabled = v;
            txtNombre.Enabled = v;
            txtDNI.Enabled = v;
            cboTipoCuenta.Enabled = v;
            txtCBU.Enabled = v;
            txtSaldo.Enabled = v;
            dtpUltimoMovimiento.Enabled = v;


        }

        private void CargarLista()
        {
            
            DataTable tabla1 = cnn.ConsultaBD("SP_LstClientes");
            lstClientes.Items.Clear();


            

            foreach (DataRow fila in tabla1.Rows)
            {
                Cliente c = new Cliente();
                c.Codigo = Convert.ToInt32(fila["COD_CLIENTE"]);
                c.Apellido = fila["APELLIDO"].ToString();
                c.Nombre = fila["NOMBRE"].ToString();
                c.Dni = Convert.ToInt32(fila["DNI"]);  
                
                lstClientes.Items.Add(c);
            }

        }

        private void CargarCombo()
        {
            DataTable tabla = cnn.ConsultaBD("SP_TipoCuenta");

            cboTipoCuenta.DataSource = tabla;
            cboTipoCuenta.ValueMember = "COD_TIPO_CUENTA";
            cboTipoCuenta.DisplayMember = "NOMBRE";
            cboTipoCuenta.SelectedValue = -1;
            cboTipoCuenta.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro desea salir del formulario?","SALIR",MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            MostarCampos(true);
            txtNombre.Focus();
            btnEditar.Enabled = false;

        }

        private void lstClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarCampos();
            MostarCampos(false);

            if (lstClientes.SelectedIndex !=-1)
            {
                Cliente cliente = lstClientes.SelectedItem as Cliente;

                txtCodigo.Text = Convert.ToString(cliente.Codigo);
                txtNombre.Text = cliente.Nombre.ToString();
                txtApellido.Text = cliente.Apellido.ToString();
                txtDNI.Text = cliente.Dni.ToString();
                btnEditar.Enabled = true;
            }
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostarCampos(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {

            }
        }

        private bool ValidarCampos()
        {
            bool aux = true;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un Nombre","Error!");
                aux = false;
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar un Apellido", "Error!");
                aux = false;
            }
            if (string.IsNullOrEmpty(txtDNI.Text))
            {
                MessageBox.Show("Debe ingresar un DNI", "Error!");
                aux = false;
            }


            return aux;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
