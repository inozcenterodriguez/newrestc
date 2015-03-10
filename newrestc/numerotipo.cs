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
    public class numerotipo
    {
         
    
        numerotipo()
        {}

        public int esestring (Type eltipodedato)
        {
        
        if (eltipodedato  ==  System.Type.GetType("System.String") || eltipodedato  == System.Type.GetType("System.DateTime")  )   
            {
            return(1);
            }
        else     
            {
            return(0);
            }
        }



    }
}
