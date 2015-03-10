using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADODB;
using MySql.Data.MySqlClient;
using System.Data;    
using System.Windows.Forms;


namespace newrestc
{
 
    public class sobrebasededatos
    {



#region campos
        private DataSet DATA  ; //data set a usar 
        private MySqlCommand  comando   ; 
        private  string   sentenciasql;
        private   string basedata;
        private   string servidor;
        private   string usuario;
        public   bool   campoconectado = new bool();
        public MySqlDataReader reader1  ;
        private string numero;
        private int numero2;
        private     MySqlConnection  laconexion = new MySqlConnection();
#endregion

           



        public      sobrebasededatos ( )
        
        {
            //MessageBox.Show("Data Source=" + GLOBALES.Gservidor + ";Database= " + GLOBALES.Gbasededatos + ";User ID=" + GLOBALES.Gusuario + ";Password=" + GLOBALES.Gclave + ";"); 
            laconexion.ConnectionString = ("Data Source=" + GLOBALES.Gservidor + "; Database= " + GLOBALES.Gbasededatos + ";User ID=" + GLOBALES.Gusuario + ";Password=" + GLOBALES.Gclave + ";");
                
             
            laconexion.Open () ;
            



            if (laconexion.State == ConnectionState.Open)
            {

               // MessageBox.Show(" conectado");    

  
            }
            else
            {
                 
                //MessageBox.Show("No conectado");
            }

        }

#region propiedades


        public bool conexionenable
        {
            get { return campoconectado; }
        }

        public MySqlConnection  CNN
        {
            get { return laconexion; }
        }
       


#endregion





        public void ejecutarsql(string Csql  )
        {


            MySqlCommand metodocomando = new MySqlCommand();
            metodocomando.Connection=CNN;
            metodocomando.CommandText = Csql;
            metodocomando.ExecuteNonQuery();

                    
            
        
        }


        public bool existe(string tabla, string condicion)
        {


            MySqlCommand metodoexiste = new MySqlCommand();
            metodoexiste.Connection = CNN;
            metodoexiste.CommandText = "select count.* as campo1 from " + tabla + "  where  "  + condicion  ;
            metodoexiste.ExecuteNonQuery();
            reader1 = metodoexiste.ExecuteReader();

            return (reader1.HasRows);
 
        }



        public void eliminar( string tabla, string condicion)
        {
            MySqlCommand metodoeliminar = new MySqlCommand();
            metodoeliminar.Connection = CNN;
            metodoeliminar.CommandText = "Delete from " + tabla + " where (" + condicion + ")";
            metodoeliminar.ExecuteNonQuery();
        
        }

        public string ultimo(string tabla, string campo, string condicion)
        {
            MySqlCommand metodoultimo = new MySqlCommand();
            metodoultimo.Connection = CNN;
            if (condicion == "")
            { metodoultimo.CommandText = "Select    MAX(" + campo + ")as idx    from " + tabla ; }
            else
            { metodoultimo.CommandText = "Select  MAX(" + campo + ")as idx    from " + tabla + " where " + condicion  ; }
            metodoultimo.ExecuteNonQuery(); 
            reader1 = metodoultimo.ExecuteReader() ;
            if (reader1.Read() == true)
            {
                numero = reader1.GetValue(0).ToString(); 
                }
           return   numero   ;
        }


        // metodo que devuelve el ultimo valor mas 1
        

        public string ultimomasuno(string tabla, string campo, string condicion)
        {
            MySqlCommand metodoultimo = new MySqlCommand();//instancia un nuevo comando mysql
            metodoultimo.Connection = CNN;// asigna la conexion cnn
            if (condicion == "") //escoje entre si el campo tiene una condicion o simplemente 

            { metodoultimo.CommandText = "Select    MAX(" + campo + " + 1)as idx    from " + tabla; }//selecciona el valor maximo de un campo y le suma 1 valor
            else
            { metodoultimo.CommandText = "Select  MAX(" + campo + " + 1)as idx    from " + tabla + " where " + condicion; }
            metodoultimo.ExecuteNonQuery();
            reader1 = metodoultimo.ExecuteReader();
            if (reader1.Read() == true)//si hay filas
            {
                numero = reader1.GetValue(0).ToString() ;
                            }
            return numero;
        }



    }
}
