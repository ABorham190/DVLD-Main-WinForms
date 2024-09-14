using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace DVLDdataAccessLayer
{
    public static class clsUsersDataLayer
    {
        static public int AddNewUser (int PersonID,string UserName,
            string Password,bool IsActive)
        {
            int InsertedID = -1;
            string Querey = @"Insert into Users (PersonID,UserName,
                          Password,IsActive) values 
                          (@PersonID,@UserName,@Password,@IsActive);
                           select Scope_identity();";
            SqlConnection Connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand Command=new SqlCommand(Querey,Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if(Result!=null&&int.TryParse(Result.ToString(),out int ID))
                {
                    InsertedID = ID;
                }

                
            }catch (Exception ex)
            {
                InsertedID=-1;
            }finally { Connection.Close(); }
            return InsertedID;
        }
        static public DataTable GetUsersList()
        {
            DataTable dt = new DataTable();
            string Querey = @"select UserID,Users.PersonID,
                          FirstName+' '+SecondName+' '+ThirdName+' '+LastName as FullName , 
                          UserName,
                          IsActive from Users inner join People 
                          on Users.PersonID=People.PersonID;";
            SqlConnection Connection=new SqlConnection(Settings.ConnectionString); ;
            SqlCommand Command=new SqlCommand( Querey,Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
                
            }catch(Exception ex)
            {

            }finally
            {
                Connection.Close();
            }
            return dt;
        }
        static public bool DeleteUser(int UserID)
        {
            int NumberOfAffectedRows = 0;
            string Querey = "Delete from Users where UserID=@UserID";
            SqlConnection Connection=new SqlConnection(Settings.ConnectionString);
            SqlCommand Command = new SqlCommand(Querey, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                Connection.Open();
                NumberOfAffectedRows = Command.ExecuteNonQuery();

            }catch (Exception ex)
            {
                NumberOfAffectedRows=0;
            }finally
            {
                Connection.Close();
            }
            return NumberOfAffectedRows > 0;
        }
        static public bool FindUserByUserID(int UserID,ref int PersonID,
            ref string UserName,ref string Password,ref bool IsActive)
        {
            bool IsFound = false;
            string Querey = @"select * from Users where UserID=@UserID";
            SqlConnection Connection=new SqlConnection(Settings.ConnectionString);
            SqlCommand Command= new SqlCommand( Querey, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound= true;
                    PersonID = (int)Reader["PersonID"];
                    Password = (string)Reader["Password"];
                    UserName = (string)Reader["UserName"];
                    IsActive = (bool)Reader["IsActive"];
                }

            }catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }
        static public bool FindUserByUserNameAndPassword(ref int UserID, ref int PersonID,
             string UserName, string Password, ref bool IsActive)
        {
            bool IsFound = false;
            string Querey = @"select * from Users where UserName=@UserName
                             and Password=@Password";
            SqlConnection Connection = new SqlConnection(Settings.ConnectionString);
            SqlCommand Command = new SqlCommand(Querey, Connection);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)Reader["PersonID"];
                    UserID = (int)Reader["UserID"];
                    IsActive = (bool)Reader["IsActive"];
                }

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        static public bool UpdateUserIsActive(int UserID,bool IsActive,
            string UserName,string Password)
        {
            int NumberOfAffectedRows = 0;
            string Querey = @"Update Users set IsActive=@IsActive,
                             UserName=@UserName,Password=@Password
                              where UserID=@UserID;";
            SqlConnection Connection=new SqlConnection(Settings.ConnectionString);
            SqlCommand Command= new SqlCommand(Querey, Connection);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                Connection.Open();
                NumberOfAffectedRows = Command.ExecuteNonQuery();

            }catch (Exception ex)
            {
                NumberOfAffectedRows = 0;
            }
            finally
            {
                Connection.Close() ;
            }

            return NumberOfAffectedRows > 0;

        }

        static public bool GetUserNameByUserID(int UserID,ref string UserName)
        {
            bool IsFound = false;
            string Querey = @"select Users.UserName from Users where 
                             UserID=@UserID;";
            SqlConnection connection=new SqlConnection(Settings.ConnectionString);
            SqlCommand Command= new SqlCommand( Querey, connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    UserName = (string)Reader["UserName"];
                }
                Reader.Close();
            }catch(Exception ex)
            {
                IsFound = false;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        
    }
}
