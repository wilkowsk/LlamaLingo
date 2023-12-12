using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace LlamaLingo.Pages
{
    public class ColorManage
    {
        private static int currentID = 0;

        private static bool isConnected = false;
        private static SqlConnection conn = null;

        private static List<string> componentNames = new List<string>() { "Red Strength", "Green Strength", "Blue Strength" };
        public static List<int> getComponents()
        {
            connect();

            List<int> output;
            String sql = "SELECT redStr, grnStr, bluStr from dbo.ColorTest\n" +
                "WHERE id=" + currentID + ";";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) {
                        output = new List<int>
                        {
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                        };
                    } else
                    {
                        output = new List<int>
                        {
                            0, 0, 0
                        };
                    }
				}
            }
            return output;
        }

        public static bool setCurrentId(int id)
        {
            connect();

			String sql = "SELECT * from dbo.ColorTest\n" +
				"WHERE id=" + id + ";";
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
                        currentID = id;
                        return true;
					}
					else
					{
                        return false;
					}
				}
			}
        }

        public static int getCurrentId()
		{
			return currentID;
        }

        public static List<int> getIDs()
        {
            connect();

			List<int> output = new List<int>();
            String sql = "SELECT id from dbo.ColorTest";
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
                    {
                        output.Add(reader.GetInt32(0));
                    }
				}
			}
            return output;
		}



        public static List<string> getColors()
        {
			connect();

			List<string> output = new List<string>();
			String sql = "SELECT color from dbo.ColorTest";
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						output.Add(reader.GetString(0));
					}
				}
			}
			return output;
		}

        public static List<string> getComponentNames()
        {
            return componentNames;
        }

        public static string connect()
        {
            if (isConnected)
			{
				return "alreadyConnected";
			}

			SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "llamalingo.database.windows.net";
            stringBuilder.UserID = "LlamaLingoLogin";
            stringBuilder.Password = "UMDLlamaLingo4444";
            stringBuilder.InitialCatalog = "JayTest";

            conn = new SqlConnection(stringBuilder.ConnectionString);
			conn.Open();
            isConnected = true;
            return "qepithim";


		}
    }
}
