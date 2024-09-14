using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DVLDdataAccessLayer
{
    internal class Settings
    {
        //static public string ConnectionString = "Server=.;Database=DVLD3;User Id=sa;" +
        //    "Password=111990;";

        static public string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        static public int GetCountryID(string CountryName)
        {
            int CountryID = 0;
           string Querey=@" select CountryID from Countries where
                           CountryName = @CountryName;";
            SqlConnection Connection=new SqlConnection(ConnectionString);
            SqlCommand Command = new SqlCommand(Querey, Connection);
            Command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();
                Object Result = Command.ExecuteScalar();
                if(Result!=null && int.TryParse(Result.ToString(),out int ID))
                {
                    CountryID = ID;
                }


            }catch (Exception ex)
            {
                CountryID=0;
            }
            finally
            {
                Connection.Close();
            }
            return CountryID;
        }
    }
}
