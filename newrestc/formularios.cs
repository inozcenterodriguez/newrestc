using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using ADODB;
using MySql.Data.MySqlClient;



namespace newrestc
{
    /// <summary>
    ///  CLASE QUE MANEJA TODAS LAS OPERACIONES CON FORMULARIOS
    /// </summary>
    class CONTROLDEFORMULARIOS
    {
        #region campos
        Control C = new Control();

        #endregion



        public CONTROLDEFORMULARIOS()
        { 
        

        }


        /// <summary>
        /// Método que guarda en una tabla todos los datos en los textbox de un formulario
        /// </summary>
        /// <param name="formulario"></param>
        /// <param name="tabla"></param>
       public  void guardarsegunformulario(Form formulario, string tabla)
        {
            MySqlCommand fcomando = new MySqlCommand() ;
            string campos = "";
            string datos = "";
            DataSet datax = new DataSet();
            int veces;
            Type tipo;
            MySqlConnection cnnlocal = new sobrebasededatos().CNN;
            bool sbol;
 
            


            // recorre todos los textbox de un formulario e introduce los datos y nombres de los campos 
            // en variables para construir la instruccion insert
            MySqlDataAdapter adaptador = new MySqlDataAdapter("select * from " +  tabla , cnnlocal);
            adaptador.Fill(datax);

           for ( veces  = 0; veces < datax.Tables[0].Columns.Count;   veces += 1)

            {
                

                foreach (Control C in formulario.Controls)
                {
                    if ( C is TextBox  &  C.Name == datax.Tables[0].Columns[veces].ColumnName )
                    {
                    sbol = (C.Name == datax.Tables[0].Columns[veces].ColumnName);    
                    //MessageBox.Show(" indice:(" + veces + ") " +  C.Name + "---" + datax.Tables[0].Columns[veces].ColumnName);
                      

                        tipo = datax.Tables[0].Columns[veces].DataType;//asigna el tipo de dato de la columna a una variable

                        //compara la variable de tipo Type con el tipo de dato de la columna en al base de datos
                        if ( tipo == System.Type.GetType("System.String") || tipo == System.Type.GetType("System.DateTime"))
                        // agrega el campo y los datos a las variables con  comillas simples en los casos string y fecha
                        {
                        campos +=   C.Name + ",";
                        datos += " '" + C.Text + "',";
                        //MessageBox.Show("insert to " + tabla + " (" + campos + ") values (" + datos + ")");
                        }
                         
                        else
                        // agrega el campo y los datos a las variables para construir la consulta en los otros casos
                        {campos += C.Name + " ,";
                        datos += C.Text + " ,";
                        //MessageBox.Show("no string -- insert to " + tabla + " (" + campos + ") values (" + datos + ")");
                        }


                    }

                    



                }


            }


           campos = campos.Substring(0, campos.Length - 1);
           datos = datos.Substring(0, datos.Length - 1);
            fcomando.CommandText = ("insert into " + tabla + " (" + campos + ") values (" + datos + ")" );
            fcomando.Connection = cnnlocal;
             fcomando.ExecuteNonQuery(); 


  












            #region propiedades
            #endregion


        }


       public void modificarsegunformulario(Form formulario, string tabla,string condicion)
       {
           MySqlCommand fcomando = new MySqlCommand();
           string campos = "";
           string datos = "";
           DataSet datax = new DataSet();
           int veces;
           Type tipo;
           MySqlConnection cnnlocal = new sobrebasededatos().CNN;
           bool sbol;




           // recorre todos los textbox de un formulario e introduce los datos y nombres de los campos 
           // en variables para construir la instruccion insert
           MySqlDataAdapter adaptador = new MySqlDataAdapter("select * from " + tabla, cnnlocal);
           adaptador.Fill(datax);

           for (veces = 0; veces < datax.Tables[0].Columns.Count; veces += 1)
           {


               foreach (Control C in formulario.Controls)
               {
                   if (C is TextBox & C.Name == datax.Tables[0].Columns[veces].ColumnName)
                   {
                       sbol = (C.Name == datax.Tables[0].Columns[veces].ColumnName);
                       //MessageBox.Show(" indice:(" + veces + ") " +  C.Name + "---" + datax.Tables[0].Columns[veces].ColumnName);


                       tipo = datax.Tables[0].Columns[veces].DataType;//asigna el tipo de dato de la columna a una variable

                       //compara la variable de tipo Type con el tipo de dato de la columna en al base de datos
                       if (tipo == System.Type.GetType("System.String") || tipo == System.Type.GetType("System.DateTime"))
                       // agrega el campo y los datos a las variables con  comillas simples en los casos string y fecha
                       {
                           campos += C.Name + " = '" + C.Text + "',";
                           
                           //MessageBox.Show("insert to " + tabla + " (" + campos + ") values (" + datos + ")");
                       }

                       else
                       // agrega el campo y los datos a las variables para construir la consulta en los otros casos
                       {
                           campos += C.Name + " = " + C.Text + ",";
                           
                           //MessageBox.Show("no string -- insert to " + tabla + " (" + campos + ") values (" + datos + ")");
                       }


                   }





               }


           }


           campos = campos.Substring(0, campos.Length - 1);
           fcomando.CommandText = ("update   " + tabla + " (" + campos + ") where (" + condicion + ")");
           fcomando.Connection = cnnlocal;
           fcomando.ExecuteNonQuery();















           #region propiedades
           #endregion


       }

      


       
    }

    
   public  class MENU_X
 {
        Control PX = new Control ();





        public MENU_X () 
      { }



      public  void activarpanel( Form  Xform, Panel Xpanel)
      { 

          foreach (Control PX in Xform.Controls)
          {
              if (PX is Panel)
              {
                  PX.Visible = false;
              }
          }
          foreach (Control PX in Xform.Controls)
          {
              if (Xpanel.Name == PX.Name & PX is Panel)
              {
                  PX.Visible = true;
              }

          }
      }



   




    }
  

}
