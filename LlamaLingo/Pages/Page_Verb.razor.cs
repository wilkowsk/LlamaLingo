using global::System.Collections.Generic;
using global::Microsoft.AspNetCore.Components;
using LlamaLingo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LlamaLingo.Pages
{
    public partial class Page_Verb
    {
        [Parameter]
        [SupplyParameterFromQuery]
        public int? pod { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public int? pid { get; set; }

        private readonly string sqlServerconnectionString = "Server=tcp:llamalingo.database.windows.net,1433;Initial Catalog=LlamaLingoDB;Persist Security Info=False;User ID=LlamaLingoLogin;Password=UMDLlamaLingo4444;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public bool showCreate = false;
        public bool showModify = false;
        public bool showDelete = false;
        public bool showList = false;
        public string table = "";
        public int DDCounter = 0;
        private List<Pype> pypes = new List<Pype>(); // Declare a private list of Pype objects
        private List<Verb> verbs = new List<Verb>(); // Declare a private list of Verb objects
        private List<Verb> verbsDelete = new List<Verb>(); // Declare a private list of Verb objects
        private Verb currentVerb = new Verb();
        private string _selectedFilter = "****"; // user filter selection
        public string selectedFilter
        {
            get
            {
                return _selectedFilter;
            }

            set
            {
                if (_selectedFilter != value)
                {
                    _selectedFilter = value;
                    Read();
                }
            }
        }

        private int _selectedVerb = 1; // user filter selection
        public int selectedVerb
        {
            get
            {
                return _selectedVerb;
            }

            set
            {
                if (_selectedVerb != value)
                {
                    _selectedVerb = value;
                    AutoFill();
                }
            }
        }

        private void ShowList()
        {
            if (showList == false)
            {
                showModify = false;
                showDelete = false;
                showList = true;
                showCreate = false;
            }
            else
            {
                showList = false;
            }
        }

        private void ShowCreate()
        {
            if (showCreate == false)
            {
                showModify = false;
                showDelete = false;
                showList = false;
                showCreate = true;
            }
            else
            {
                showCreate = false;
            }
        }

        private void ShowModify()
        {
            if (showModify == false)
            {
                showCreate = false;
                showDelete = false;
                showList = false;
                showModify = true;
            }
            else
            {
                showModify = false;
            }
        }

        private void ShowDelete()
        {
            if (showDelete == false)
            {
                showCreate = false;
                showModify = false;
                showList = false;
                showDelete = true;
            }
            else
            {
                showDelete = false;
            }
        }

        private void OnCreate()
        {
            Create();
            Read();
            DeleteRead();
        }

        private void OnChange()
        {
            Change();
            Read();
            DeleteRead();
        }

        private void OnDelete()
        {
            Delete();
            Read();
            DeleteRead();
        }

        private void AutoFill()
        {
            Verb target = verbs.Find(x => x.VerbId == selectedVerb);
            currentVerb.VerbLabel = target.VerbLabel;
            currentVerb.VerbDescription = target.VerbDescription;
            currentVerb.VerbType = target.VerbType;
            currentVerb.VerbStatus = target.VerbStatus;
            currentVerb.UrlIdPk = target.UrlIdPk;
        }

        private void Read()
        {
            string spName = "dbo.CRUD_Verb";
            SqlConnection connection = new SqlConnection(sqlServerconnectionString);
            SqlCommand cmd = new SqlCommand(spName, connection);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@PROC_filter";
            param1.Value = selectedFilter;
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@PROC_action";
            param2.Value = "Read";
            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@pod";
            param3.Value = pod;
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //execute the stored procedure
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            verbs.Clear();
            while (reader.Read())
            {
                verbs.Add(new Verb { VerbId = reader.GetInt32(0), VerbLabel = reader.GetString(1), VerbDescription = reader.GetString(2), VerbType = reader.GetString(3), VerbStatus = reader.GetString(4), PodIdFk = reader.GetInt32(5), UrlIdPk = reader.GetInt32(6) });
            }
        }

        private void Create()
        {
            string spName = "dbo.CRUD_Verb";
            SqlConnection connection = new SqlConnection(sqlServerconnectionString);
            SqlCommand cmd = new SqlCommand(spName, connection);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@label";
            param1.Value = currentVerb.VerbLabel;
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@desc";
            param2.Value = currentVerb.VerbDescription;
            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@type";
            param3.Value = currentVerb.VerbType;
            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@PROC_action";
            param4.Value = "Create";
            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@pod";
            param5.Value = pod;
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //execute the stored procedure
            cmd.ExecuteNonQuery();
            currentVerb = new Verb();
        }

        private void Change()
        {
            string spName = "dbo.CRUD_Verb";
            SqlConnection connection = new SqlConnection(sqlServerconnectionString);
            SqlCommand cmd = new SqlCommand(spName, connection);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@label";
            param1.Value = currentVerb.VerbLabel;
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@desc";
            param2.Value = currentVerb.VerbDescription;
            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@id";
            param3.Value = selectedVerb;
            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@PROC_action";
            param4.Value = "Update";
            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@pod";
            param5.Value = pod;
            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "@status";
            param6.Value = currentVerb.VerbStatus;
            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "@url_id_pk";
            param7.Value = currentVerb.UrlIdPk;
            SqlParameter param8 = new SqlParameter();
            param8.ParameterName = "@type";
            param8.Value = currentVerb.VerbType;
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //execute the stored procedure
            cmd.ExecuteNonQuery();
            currentVerb = new Verb();
        }

        private void Delete()
        {
            string spName = "dbo.CRUD_Verb";
            SqlConnection connection = new SqlConnection(sqlServerconnectionString);
            SqlCommand cmd = new SqlCommand(spName, connection);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@id";
            param1.Value = currentVerb.VerbId;
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@PROC_action";
            param2.Value = "Delete";
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //execute the stored procedure
            cmd.ExecuteNonQuery();
        }

        private void DeleteRead()
        {
            string spName = "dbo.VerbDeleteRead";
            SqlConnection connection = new SqlConnection(sqlServerconnectionString);
            SqlCommand cmd = new SqlCommand(spName, connection);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@PROC_filter";
            param1.Value = selectedFilter;
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@pod";
            param2.Value = pod;
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //execute the stored procedure
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            verbsDelete.Clear();
            while (reader.Read())
            {
                verbsDelete.Add(new Verb { VerbId = reader.GetInt32(0), VerbLabel = reader.GetString(1), VerbDescription = reader.GetString(2), VerbType = reader.GetString(3), VerbStatus = reader.GetString(4), PodIdFk = reader.GetInt32(5), UrlIdPk = reader.GetInt32(6) });
            }
        }

        private void PypeRead()
        {
            string spName = "dbo.sp_Pype_Type_Locked";
            SqlConnection connection = new SqlConnection(sqlServerconnectionString);
            SqlCommand cmd = new SqlCommand(spName, connection);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@PROC_Input_Filter";
            param1.Value = "VERB";
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@pod";
            param2.Value = pod;
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //execute the stored procedure
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                pypes.Add(new Pype { PypeId = reader.GetString(0), PypeType = reader.GetString(1), PypeLabel = reader.GetString(2), PypeStatus = reader.GetString(3), PypeDesc = reader.GetString(4), PypeLink = reader.GetString(5), });
            }
        }

        protected override void OnInitialized() // Override the OnInitialized method
        {
            Read();
            PypeRead();
            DeleteRead();
        }
    }
}