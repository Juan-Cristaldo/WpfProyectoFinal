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

namespace ClienteAPIRESTProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private async void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Cliente c = new Cliente();
            c.NroDocumento = txtNumDocumento.Text;
            c.NombreRazonSocial = txtRazonSocial.Text;
            c.Telefono = txtTelefono.Text;
            c.Email = txtEmail.Text;

            await Cliente.AgregarCliente(c);
            ObtenerDatos();
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (lstClientes.SelectedItem != null)
            {
                Cliente clienteSeleccionada = (Cliente)lstClientes.SelectedItem;
                clienteSeleccionada.NroDocumento = txtNumDocumento.Text;
                clienteSeleccionada.NombreRazonSocial = txtRazonSocial.Text;
                clienteSeleccionada.Telefono = txtTelefono.Text;
                clienteSeleccionada.Email = txtEmail.Text;
                await Cliente.ModificarCliente(clienteSeleccionada);
                ObtenerDatos();
            }
            else
                MessageBox.Show("Debe seleccionar primeramente el cliente a modificar ");
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lstClientes.SelectedItem != null)
            {
                Cliente clienteSeleccionada = (Cliente)lstClientes.SelectedItem;
                await Cliente.EliminarCliente(clienteSeleccionada);
                ObtenerDatos();
            }
            else
                MessageBox.Show("Debe seleccionar primeramente el cliente a eliminar ");
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtNumDocumento.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObtenerDatos();
        }

        private async void ObtenerDatos()
        {
            List<Cliente> lista = await Cliente.ObtenerTodos();
            lstClientes.ItemsSource = lista;
        }

        private void lstClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstClientes.SelectedItem != null)
            {
                Cliente clienteSeleccionada = (Cliente)lstClientes.SelectedItem;
                txtId.Text = clienteSeleccionada.CodCliente.ToString();
                txtNumDocumento.Text = clienteSeleccionada.NroDocumento;
                txtRazonSocial.Text = clienteSeleccionada.NombreRazonSocial;
                txtTelefono.Text = clienteSeleccionada.Telefono;
                txtEmail.Text = clienteSeleccionada.Email;
            }
        }
    }
}
