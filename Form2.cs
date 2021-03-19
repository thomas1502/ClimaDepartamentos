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
    public partial class Form2 : Form
    {
        List<Clima> climas = new List<Clima>();
        List<Departamento> departamentos = new List<Departamento>();
        List<Reporte> reportes = new List<Reporte>();
        // Funciones propias
        private void LeerDepartamentos()
        {
            if (File.Exists("Departamentos.txt"))
            {
                FileStream stream = new FileStream("Departamentos.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Departamento departamentoTemp = new Departamento();
                    departamentoTemp.Codigo = reader.ReadLine();
                    departamentoTemp.Nombre = reader.ReadLine();

                    departamentos.Add(departamentoTemp);
                }
                reader.Close();
            }
        }
        private void LeerClima()
        {
            if (File.Exists("Temperaturas.txt"))
            {
                FileStream stream = new FileStream("Temperaturas.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Clima climaTemp = new Clima();
                    climaTemp.Codigo = reader.ReadLine();
                    climaTemp.Temperatura = float.Parse(reader.ReadLine());
                    climaTemp.FechaMedicion = Convert.ToDateTime(reader.ReadLine());

                    climas.Add(climaTemp);
                }
                reader.Close();
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void btnDesplegar_Click(object sender, EventArgs e)
        {
            // DataGriedView1
            for(int x = 0; x < climas.Count; x++)
            {
                for(int y = 0; y < departamentos.Count;y++)
                {
                    if (climas[x].Codigo == departamentos[y].Codigo)
                    {
                        Reporte reporteTemp = new Reporte();

                        reporteTemp.Nombre = departamentos[y].Nombre;
                        reporteTemp.Temperatura = climas[x].Temperatura;

                        reportes.Add(reporteTemp);
                    }
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();

            // Data GriedView2
            reportes.OrderBy(p => p.Temperatura);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = reportes;
            dataGridView2.Refresh();

            // Promedio
            float promedio = 0;
            for(int x = 0; x < reportes.Count;x++)
            {
                promedio += reportes[x].Temperatura;
            }

            label2.Text = promedio.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LeerClima();
            LeerDepartamentos();
        }
    }
}
