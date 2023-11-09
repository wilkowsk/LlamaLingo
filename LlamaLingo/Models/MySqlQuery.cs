using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SyncfusionBlazorAppDemo.Pages
{
    public class MySqlQuery
    {
        public static List<int> getData()
        {
            List<int> output = new List<int>();
   //         try
   //         {

   //             using (SqlConnection connection = new SqlConnection("Data Source=.;Server=localhost\\TESTSERVER101023;Initial Catalog=spidertest;Trusted_Connection=Yes;"))

			//	{
   //                 String sql = "SELECT [test]\r\n      ,[test2]\r\n      ,[test3]\r\n  FROM [dbo].[testtable]\r\n  WHERE ID=1";

   //                 using (SqlCommand command = new SqlCommand(sql, connection))
   //                 {
   //                     connection.Open();
   //                     using (SqlDataReader reader = command.ExecuteReader())
   //                     {
   //                         while (reader.Read())
   //                         {
   //                             output.Add(reader.GetInt32(0));
			//					output.Add(reader.GetInt32(1));
			//					output.Add(reader.GetInt32(2));
			//				}
   //                     }
   //                 }
			//	}
			//} catch (Exception ex)
   //         {
   //             Debug.WriteLine(ex.ToString());
   //         }
            Random rng = new Random();
            while (output.Count < 3)
            {
                output.Add(rng.Next(10));
            }
            return output;
        }
    }
}
