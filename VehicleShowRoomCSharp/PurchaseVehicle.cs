using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VehicleShowRoomCSharp
{
    
   
    public partial class PurchaseVehicle : Form
    {
        

        public PurchaseVehicle()
        {
           
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexander\Documents\Visual Studio 2012\Projects\VMS\VehicleShowRoomCSharp\bin\Debug\vehicle.mdf;Integrated Security=True");



        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            try
            {
                string str = " INSERT INTO purchase(c_id,c_name,mobile,email,t_addr,p_addr,v_id,v_name,type,comany) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text  + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox1.Text + "','" + textBox9.Text + "','" + textBox8.Text + "','" + textBox10.Text + "'); ";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                //-------------------------------------------//

                string str1 = "select max(Id) from purchase;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Selled Vehicle and customer's details saved successfully..");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";

                }
                
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string getCust = "select name,mobile,email,t_addr,p_addr from cust where id=" + Convert.ToInt32(textBox6.Text) + " ;";

                SqlCommand cmd = new SqlCommand(getCust, con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr.GetValue(0).ToString();
                    textBox3.Text = dr.GetValue(1).ToString();
                    textBox4.Text = dr.GetValue(2).ToString();
                    textBox5.Text = dr.GetValue(3).ToString();
                    textBox7.Text = dr.GetValue(4).ToString();  
                }
                else
                {
                    MessageBox.Show(" Sorry ,,This ID, " + textBox1.Text + " Customer is not Available.   ");
                    textBox1.Text = "";
                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string getveh = "select v_name,type,company from vehicle where id=" + Convert.ToInt32(textBox1.Text) + " ;";

                SqlCommand cmd = new SqlCommand(getveh, con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   
                   
                    textBox9.Text = dr.GetValue(0).ToString();
                    textBox8.Text = dr.GetValue(1).ToString();
                    textBox10.Text = dr.GetValue(2).ToString();

                }
                else
                {
                    MessageBox.Show(" Sorry ,,This ID, " + textBox1.Text + " Vehicle is not Available.   ");
                    textBox1.Text = "";
                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void PurchaseVehicle_Load(object sender, EventArgs e)
        {

        }
    }
}
