using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PointOfSell
{
    public class DB
    {


        public static int LoginState;
        public static int DetailCustomerId;
        public static int CustomerId;
        public static int ContrcatIdd;
        public static int _UserID;
        public static int _FormloginId;
        ////error//// public string st = @"Data Source=DESKTOP-1L06L5P,1433;Initial Catalog=NewAArmayData;User ID=islam; Password=123456;";
         public string st = @"Data Source=DESKTOP-5B4LUT6;Initial Catalog=PointOfSale;Persist Security Info=True;User ID=Goava;Password=01426;";
        //public string st = @"Data Source=DESKTOP-0D70RQ3;Initial Catalog=FinalWesalTest;Integrated Security=True";
        //  public string st = @"Data Source=USER-PC\SQL2014;Initial Catalog=CustomerData;Integrated Security=True";
       // public string st = System.IO.File.ReadAllText(@"DBConnection.txt");


        public void InsertData(string Sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = st;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = Sql;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                con.Close();
            }
            finally
            {


            }
        }


        public string ReternFromString(string x)
        {
            if (string.IsNullOrEmpty(x))
            {
                return "0";
            }
            else
            {

                return x;
            }


         
        }


        public void UserName(int UserID)
        {
            _UserID = UserID;


        }
        public int UserId()
        {
            return _UserID;


        }






        public void FormId(int fromId)
        {
            _FormloginId = fromId;


        }
        public int FormLoginState()
        {
            return _FormloginId;
        }
        public decimal ReturnDecimal(DataTable x)
        {
            decimal y = 0;
            try
            {


                if (string.IsNullOrEmpty(x.Rows[0][0].ToString()))
                {

                    y = 0;

                }
                else
                {

                    y = Convert.ToDecimal(x.Rows[0][0]);


                }
                return y;
            }
            catch
            {

                return y;
            }

        }



        public string ReturnString(DataTable x)
        {
            string y = "0";
            try
            {
                if (string.IsNullOrEmpty(x.Rows[0][0].ToString()))
                {

                    y = "0";

                }
                else
                {

                    y = x.Rows[0][0].ToString();


                }
                return y;

            }
            catch
            {
                return y;

            }


        }
        public DataTable GetData(string Sql)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = st;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = Sql;
            DataTable dtt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            try
            {
                db.Fill(dtt);
            }
            catch
            {

            }

            return dtt;
        }





    }
}
