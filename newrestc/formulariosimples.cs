using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace newrestc
{
    static class ClaseFormulariosSimples
    {

        

          public static bool   solonumeros ( KeyPressEventArgs codigo )
        {
            return char.IsNumber(codigo.KeyChar);

            
             
          }

          public static bool sololetras(KeyPressEventArgs codigo)
          {

              return char.IsLetterOrDigit   (codigo.KeyChar);
               
          }

          

    }
}
