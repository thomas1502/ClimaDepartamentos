using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClimaDepartamentos
{
    public partial class Form1 : Form
    {
        List<Clima> climas = new List<Clima>();
        List<Departamento> departamentos = new List<Departamento>();
        public Form1()
        {
            InitializeComponent();
        }
        // Funciones propias
        private void GuardarTemperatura()
        {
            FileStream stream = new FileStream("Temperaturas.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var p in climas)
            {
                writer.WriteLine(p.Codigo);
                writer.WriteLine(p.Temperatura);
                writer.WriteLine(p.FechaMedicion);
            }

            writer.Close();
        }
        private void LeerDepartamentos()
        {
            if (File.Exists("Departamentos.txt"))
            {
                FileStream stream = new FileStream("Departamentos.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Departamento vehiculoTemp = new Departamento();
                    vehiculoTemp.Codigo = reader.ReadLine();
                    vehiculoTemp.Nombre = reader.ReadLine();

                    departamentos.Add(vehiculoTemp);
                }
                reader.Close();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Clima climaTemp = new Clima();

            climaTemp.Codigo = cmbDepartamento.SelectedValue.ToString();
            climaTemp.Temperatura = Convert.ToInt32(txtTemperatura.Text);
            climaTemp.FechaMedicion = mcFecha.SelectionStart;

            climas.Add(climaTemp);

            GuardarTemperatura();
            //Limpiar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerDepartamentos();
            // Cargar las placas al ComboBox
            cmbDepartamento.ValueMember = "Nombre";
            cmbDepartamento.DataSource = null;
            cmbDepartamento.DataSource = departamentos;
        }
    }
}
