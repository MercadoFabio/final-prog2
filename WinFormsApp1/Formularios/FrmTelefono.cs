using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.AccecoDatos.Implentaciones;
using WinFormsApp1.Entidades;
using WinFormsApp1.Servicios;

namespace WinFormsApp1
{
    public partial class FrmTelefono : Form
    {
        private telefono oTelefono;
        private GestorTelefono gestor;

        public FrmTelefono()
        {
            InitializeComponent();
            oTelefono = new telefono();
            gestor = new GestorTelefono(new DaoFactory());

        }



        private void FrmTelefono_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CargarLista();
            habilitarCampos(false);


        }
        public void habilitarCampos(bool habilitacion)
        {
            txtCodigo.Enabled = habilitacion;
            txtNombre.Enabled = habilitacion;
            txtPrecio.Enabled = habilitacion;
            btnEditar.Enabled = !habilitacion;
            lstTelefonos.Enabled = habilitacion;
            cboMarca.Enabled = habilitacion;
            btnNuevo.Enabled = !habilitacion;
            btnSalir.Enabled = !habilitacion;
            btnBorrar.Enabled = !habilitacion;
            btnGrabar.Enabled = false;
            btnAceptar.Enabled = false;

        }
        private void CargarLista()
        {
            DataTable dt = new DataTable();

            dt = gestor.CargarListaTelefonos();
            lstTelefonos.DataSource = dt;
            lstTelefonos.DisplayMember = "Lista";


        }

        private void CargarCombo()
        {

            DataTable dt = new DataTable();

            dt = gestor.CargarComboMarca();
            cboMarca.DataSource = dt;
            cboMarca.DisplayMember = "NombreMarca";
            cboMarca.ValueMember = "IdMarca";

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Estas seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarCampos(false);

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarCampos(true);
            btnGrabar.Enabled = true;
        }

        public void validarCampos()
        {

            try
            {
                if (txtNombre.Text == "" || txtCodigo.Text == "" || txtPrecio.Text == "")
                {
                    MessageBox.Show("Cargue todos los campos por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cboMarca.SelectedIndex == -1)
                {
                    MessageBox.Show("Cargue un marca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                int codigo = Convert.ToInt32(txtCodigo.Text);
                double precio = Convert.ToDouble(txtPrecio.Text);



            }
            catch (Exception ex)
            {
                MessageBox.Show("Cargue los campos codigo y precio con valores numericos por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            validarCampos();
            try
            {

                oTelefono.codigo = Convert.ToInt32(txtCodigo.Text);
                oTelefono.nombre = txtNombre.Text;
                oTelefono.marca = Convert.ToInt32(cboMarca.SelectedValue);
                oTelefono.precio = Convert.ToDouble(txtPrecio.Text);

                if (gestor.GrabarTelefono(oTelefono))
                {
                    MessageBox.Show("Telefono grabado con éxito", "Éxito");
                    CargarLista();
                }
                else
                {

                    MessageBox.Show("Error al grabar telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception ex)
            {

            }

            limpiarCampos();


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarCampos(true);
            btnAceptar.Enabled = true;

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            txtCodigo.Enabled = true;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            btnEditar.Enabled = false;
            lstTelefonos.Enabled = true;
            cboMarca.Enabled = false;
            btnNuevo.Enabled = false;
            btnSalir.Enabled = true;
            btnBorrar.Enabled = true;
            btnGrabar.Enabled = false;
            try
            {

                oTelefono.codigo = Convert.ToInt32(txtCodigo.Text);
                if (gestor.EliminarTelefono(oTelefono.codigo))
                {
                    DialogResult dialogResult = MessageBox.Show("Desea borrar este telefono", "borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show("Telefono eliminado con éxito", "Éxito");
                        CargarLista();
                    }
                    else
                    {

                        MessageBox.Show("Error al eliminar  telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {

                return;
            }
            limpiarCampos();

        }






        private void btnAceptar_Click(object sender, EventArgs e)
        {

            validarCampos();
            try
            {
                oTelefono.codigo = Convert.ToInt32(txtCodigo.Text);
                oTelefono.nombre = txtNombre.Text;
                oTelefono.marca = Convert.ToInt32(cboMarca.SelectedValue);
                oTelefono.precio = Convert.ToDouble(txtPrecio.Text);

                if (gestor.EditarTelefono(oTelefono))
                {
                    MessageBox.Show("Telefono editado con éxito", "Éxito");
                    CargarLista();
                }
                else
                {

                    MessageBox.Show("Error al editado telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception )
            {

                return;

            }

            limpiarCampos();
            CargarLista();
           
        }

    }


}