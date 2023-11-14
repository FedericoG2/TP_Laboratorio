using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Laboratorio
{
    public partial class Form1 : Form
    {
       //Valores constantes, marcas y origen

        const string P = "Peugeot";
        const string F = "Fiat";
        const string R = "Renault";

        const string N = "Nacional";
        const string I = "Importado";

        

        //Variables para guardar datos de la interfaz

        int numRepuesto;
        string marca;
        string origen;
        string descripcion;
        float precio;

        
        //Variables para guardar los valores de los filtros seleccionados

        string marcaFiltro;
        string origenFiltro;




        //Estructura

        public struct REPUESTO
        {
            public int numero;
            public string marca;
            public string origen;
            public string descripcion;
            public float precio;
        }

        //Arreglo

        REPUESTO[] repuestos;

    

        //Posicion en el arreglo
        public int posicion = 0;

       


        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            //Carga combo marca
            cmbMarca.Items.Add(P);
            cmbMarca.Items.Add(F);
            cmbMarca.Items.Add(R);

            //Seleccionado el primero
            cmbMarca.SelectedIndex = 0;

            //Inicializo el arreglo en 10 elementos
            repuestos = new REPUESTO[10];

            
          

           //Carga combo marca pero del sector donde se aplican los filtros
            cmbMarcaConsulta.Items.Add(P);
            cmbMarcaConsulta.Items.Add(F);
            cmbMarcaConsulta.Items.Add(R);

            

           
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Evento Registrar :

            //  1.Almaceno en variables los datos de la interfaz.

            //  2.Guardo los datos en el arreglo de estructuras. 

            //  3.Limpio la interfaz.


            //Numero de respuesto
            numRepuesto = int.Parse(txtNumRepuesto.Text);

            //Marca
            marca = cmbMarca.SelectedItem.ToString();

            //Origen
            if (optNacional.Checked) {
                origen = N;
            } else
            {
                origen = I;
            }

            //Descripcion
            descripcion = txtDescripcion.Text;

            //Precio
            precio = float.Parse(txtPrecio.Text);




            //Guardo los datos en el arreglo

            repuestos[posicion].numero = numRepuesto;
            repuestos[posicion].marca = marca;
            repuestos[posicion].origen = origen;
            repuestos[posicion].descripcion = descripcion;
            repuestos[posicion].precio = precio;
            posicion++;


            

            
            
            //Limpiar interfaz
            txtNumRepuesto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";

            
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {


            // Evento donde se consulta los repuestos aplicando filtros por marca y por origen.

            // Los filtros deben estar combinados,hay 3 casos

            // 1.Repuestos solo por Marca
            // 2.Respuestos solo por Origen
            // 3.Repuestos por marca y origen


            //Limpio primero la grilla sino se van acumulando una atras de otra

            dataGrid.Rows.Clear();

            //Se almacena la marca seleccionada en el filtro

            marcaFiltro = cmbMarcaConsulta.SelectedItem.ToString();

            //Se almacena el origen seleccionado en el filtro

            if (optNacionalConsulta.Checked)
            {

                origenFiltro = N;
            }
            else
            {

                origenFiltro = I;
            }



            // --> Respuestos por marca y origen

            // 1.Si tengo valores en marcaFiltro y origenFiltro es porque fueron seleccionados
            // 2.Itero sobre repuestos 
            // 3.Por cada elemento de repuestos pregunto si cumple con las dos condiciones
            // 4.Muestro en la grilla los elementos que cumplen con las dos condiciones

            if (marcaFiltro != null && origenFiltro != null )
            {
                for ( int i = 0; i < posicion; i++)
                {
                    if (repuestos[i].marca == marcaFiltro && repuestos[i].origen == origenFiltro)
                    {

                        dataGrid.Rows.Add(
          repuestos[i].numero.ToString(),
          repuestos[i].marca,
          repuestos[i].origen,
          repuestos[i].descripcion,
          repuestos[i].precio.ToString()

          );
                    }
                }
            }









        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Evento donde se consultan todos los repuestos registrados

            //Limpio primero la grilla

            dataGrid.Rows.Clear();


            //Itero sobre el arreglo de repuestos con la posicion como limite. 

            for (int i = 0; i < posicion; i++)
            {
                dataGrid.Rows.Add(
           repuestos[i].numero.ToString(),
           repuestos[i].marca,
           repuestos[i].origen,
           repuestos[i].descripcion,
           repuestos[i].precio.ToString()

           );
            }
        }
    }
}
