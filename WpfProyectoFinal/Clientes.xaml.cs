using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        ElectroparEntities datos;
        public Clientes()
        {
            InitializeComponent();
            datos = new ElectroparEntities();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                dtgClientes.ItemsSource = datos.Cliente.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgClientes.SelectedItem != null)
            {
                Cliente d = (Cliente)dtgClientes.SelectedItem;

                txtId.Text = d.CodCliente.ToString();
                txtNumDocumento.Text = d.NroDocumento.ToString();
                txtRazonSocial.Text = d.NombreRazonSocial;
                txtTelefono.Text = d.Telefono.ToString();
                txtEmail.Text = d.Email.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Text = string.Empty;
            txtNumDocumento.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.NroDocumento = txtNumDocumento.Text;
            cliente.NombreRazonSocial = txtRazonSocial.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Email = txtEmail.Text;
            datos.Cliente.Add(cliente);
            datos.SaveChanges();
            CargarDatos();
            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgClientes.SelectedItem != null)
            {
                Cliente d = (Cliente)dtgClientes.SelectedItem;
                d.NroDocumento = txtNumDocumento.Text;
                d.NombreRazonSocial = txtRazonSocial.Text;
                d.Telefono = txtTelefono.Text;
                d.Email = txtEmail.Text;
                datos.Entry(d).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();
                CargarDatos();
            }
            else
                MessageBox.Show("Seleccione un Cliente para la modificación");
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgClientes.SelectedItem != null)
            {
                Cliente d = (Cliente)dtgClientes.SelectedItem;
                d.NroDocumento = txtNumDocumento.Text;
                d.NombreRazonSocial = txtRazonSocial.Text;
                d.Telefono = txtTelefono.Text;
                d.Email = txtEmail.Text;
                datos.Entry(d).State = System.Data.Entity.EntityState.Deleted;
                datos.SaveChanges();
                CargarDatos();
            }
            else
                MessageBox.Show("Seleccione un Dispositivo para la modificación");
            LimpiarCampos();
        }

        private bool validar()
        {
            if (txtNumDocumento.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una Número de Documento");
                txtNumDocumento.Focus();
                return false;
            }
            if (txtRazonSocial.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una Razon Social");
                txtRazonSocial.Focus();
                return false;
            }
            if (txtTelefono.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Telefono");
                txtTelefono.Focus();
                return false;
            }
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Email");
                txtEmail.Focus();
                return false;
            }
            return true;
        }
    }
}
