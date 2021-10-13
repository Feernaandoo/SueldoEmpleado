using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SueldoEmpleado
{
    public partial class frmSueldo : Form
    {
        public frmSueldo()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando los valores del formulario
            string nombre = txtEmpleado.Text;
            string categoria = cboCategoria.Text;
            int horas = int.Parse(txtHoras.Text);

            //Capturando los montos obtenidos desde la clase
            double costo = Empleado.asignaCostoHora(categoria);
            double bruto = Empleado.calculaBruto(horas, costo);
            double descuento = Empleado.calculaDescuento(bruto);
            double neto = Empleado.calculaNeto(bruto, descuento);

            //Imprimiendo los resultados
            ListViewItem fila = new ListViewItem(nombre);
            fila.SubItems.Add(categoria); 
            fila.SubItems.Add(horas.ToString());
            fila.SubItems.Add(costo.ToString("C"));
            fila.SubItems.Add(bruto.ToString("C"));
            fila.SubItems.Add(descuento.ToString("C")); 
            fila.SubItems.Add(neto.ToString("C"));
            lvPago.Items.Add(fila);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta seguro de salir ? ", "Salir",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (r == DialogResult.Yes)
                this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox) c.Text = "";
            }
            cboCategoria.SelectedIndex = -1;
            txtEmpleado.Focus();
        }
    }   
}
