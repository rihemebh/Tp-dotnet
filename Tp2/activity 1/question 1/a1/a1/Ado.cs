using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace a1
{
    class Ado
    {
        public SqlDataAdapter da { get; set; }
        public SqlDataReader dr { get; set; }
        public  SqlConnection conn { get; set; }
      
        public DataSet ds { get; set; }
        public  Ado(string str)
        {
           
          
                try
                {
                    conn = new SqlConnection(str);
                    conn.Open();
                }
                catch (Exception ex)
                {
                    if (conn != null)
                        conn.Close();
                    Console.WriteLine("connexion failed : " + ex);

                }
            
           

        }
        public void connectedMode()
        {
           
            SqlCommand cmd = null;
            try
            {   //adding data 
              //  cmd = new SqlCommand("insert into students values ('Flen Fouleni ', '01/11/1999' , '14357110')",conn);
               //  cmd.ExecuteNonQuery();
                //finding data 
                //cmd = new SqlCommand("Select * from students where Id = '1003'", conn);
                cmd = new SqlCommand("Select * from students", conn);

                //preparing dataAdapter for disconnected mode 
                da = new SqlDataAdapter(cmd);


                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(dr["Id"] + ",  " + dr["fullName"] + ",  " + dr["birthday"] + ",  " + dr["CIN"]);
                
               }
                dr.Close();
               
                Console.WriteLine("\n********** Updating data **********\n");
          

                cmd = new SqlCommand("update students set fullName = 'mariem brahem' where Id = 1004",conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("Select * from students", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(dr["Id"] + ",  " + dr["fullName"] + ",  " + dr["birthday"] + ",  " + dr["CIN"]);
                }
                dr.Close();
               
                Console.WriteLine("\n********** removing data **********\n");
                Console.WriteLine();
                cmd = new SqlCommand("delete from students  where Id = '1007'",conn);
                cmd.ExecuteNonQuery();

                
                cmd = new SqlCommand("Select * from students", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(dr["Id"] + ",  " + dr["fullName"] + ",  " + dr["birthday"] + ",  " + dr["CIN"]);
                }
                dr.Close();
                
                Console.WriteLine("********** Stored Procedures ********** ");

                cmd = new SqlCommand("spGetStudents", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr["Id"] + ",  " + dr["fullName"] + ",  " + dr["birthday"] + ",  " + dr["CIN"]);
                }
                dr.Close();
                Console.WriteLine("********** Stored Procedures with parameter ********** ");
              

                SqlCommand cmd1 = new SqlCommand()
                {
                    CommandText = "getStudentsByName",
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter param1 = new SqlParameter
                {
                    ParameterName = "@name", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                    Value = "mariem%",
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };
                //add the parameter to the SqlCommand object
                cmd1.Parameters.Add(param1);
               
                dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine( "name : "+dr["fullName"] + "\nCIN : "  + dr["CIN"]);
                }

                dr.Close();
               

               
                //closing connection 
                conn.Close();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong : " + ex);
            }



        }

        public void diconnectedMode()
        {
            SqlCommand cmd = new SqlCommand("Select * from students", conn);
            //preparing dataAdapter for disconnected mode 
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            Console.WriteLine();
            Console.WriteLine("we have " + ds.Tables[0].Rows.Count + " rows in our dataset");
            Console.WriteLine();


            foreach (DataRow row in ds.Tables[0].Rows)
            {
                foreach (DataColumn column in ds.Tables[0].Columns)
                    Console.WriteLine(column + " : "+ row[column]);

                Console.WriteLine();
            }

           



        }
       
    }
}
