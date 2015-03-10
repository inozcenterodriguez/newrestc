using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace newrestc
{
    public partial class FormularioPrincipal : Form
    {
        CONTROLDEFORMULARIOS control1 = new CONTROLDEFORMULARIOS();
        private Button C = new Button();
        int x;

        public FormularioPrincipal()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PanelIngredientes.Parent = this;
            PanelProductos.Parent = this;
            PanelCombos.Parent = this;
            

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

       

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void PicMesas_Click(object sender, EventArgs e)
        {
             
        }

        private void PicMesas_MouseHover(object sender, EventArgs e)
        {
            MENU_X tempoMesas = new MENU_X();
            tempoMesas.activarpanel(this, PanelMesas );

        }

        private void PicIngredientes_MouseHover(object sender, EventArgs e)
        {
            MENU_X tempoIngredientes = new MENU_X();
            tempoIngredientes.activarpanel(this, PanelIngredientes);
            if (this.ingredientes_id.Text == "")
            {
                sobrebasededatos X1 = new sobrebasededatos();
                this.ingredientes_id.Text = X1.ultimomasuno("ingredientes", "ingredientes_id", "");
            }
        }

        private void PicIngredientes_Click(object sender, EventArgs e)
        {

        }

        private void PicProductos_MouseHover(object sender, EventArgs e)
        {
            MENU_X tempoProductos = new MENU_X();
            tempoProductos.activarpanel(this, PanelProductos);
            if (this.productos_id.Text == "")
            {
                sobrebasededatos X1 = new sobrebasededatos();
                this.productos_id.Text = X1.ultimomasuno ("productos", "productos_id", "");
            }
        }









        

        private void PicProductos_Click(object sender, EventArgs e)
        {

        }

        private void PicCombos_Click(object sender, EventArgs e)
        {

        }

        private void PicCombos_MouseHover(object sender, EventArgs e)
        {
            MENU_X tempoCombos = new MENU_X();
            tempoCombos.activarpanel(this, PanelCombos);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
          

        }

        private void FormularioPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void ingredientes_id_KeyDown(object sender, KeyEventArgs e)
        {
            
            


        }

        private void ingredientes_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void ingredientes_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ClaseFormulariosSimples.solonumeros(e);

        }

      

       

        

        
    }


    
}
