using global::System.Collections.Generic;
using global::Microsoft.AspNetCore.Components;
using LlamaLingo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LlamaLingo.Pages
{
    public partial class Page_Noun
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
        private List<Pype> pypes = new List<Pype>(); // Declare a private list of Pype objects
        private List<Noun> nouns = new List<Noun>(); // Declare a private list of Noun objects
        private List<Noun> nounsDelete = new List<Noun>(); // Declare a private list of Noun objects
        private Noun currentNoun = new Noun();
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

        private int _selectedNoun = 1; // user filter selection
        public int selectedNoun
        {
            get
            {
                return _selectedNoun;
            }

            set
            {
                if (_selectedNoun != value)
                {
                    _selectedNoun = value;
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
            Noun target = nouns.Find(x => x.NounId == selectedNoun);
            currentNoun.NounLabel = target.NounLabel;
            currentNoun.NounDescription = target.NounDescription;
            currentNoun.NounType = target.NounType;
            currentNoun.NounStatus = target.NounStatus;
            currentNoun.UrlIdPk = target.UrlIdPk;
        }

        //*******************************************************************************
        //**************************** Stored Procedure *********************************
        //****************************    NOUN CRUD     *********************************
        //*******************************************************************************
        private void Read()
        {
            string spName = "dbo.CRUD_Noun";
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
            nouns.Clear();
            while (reader.Read())
            {
                nouns.Add(new Noun { NounId = reader.GetInt32(0), NounLabel = reader.GetString(1), NounDescription = reader.GetString(2), NounType = reader.GetString(3), NounStatus = reader.GetString(4), PodIdFk = reader.GetInt32(5), UrlIdPk = reader.GetInt32(6) });
            }
        }

        //*******************************************************************************
        //****************************    NOUN CRUD     *********************************
        //*******************************************************************************
        private void Create()
        {
            string spName = "dbo.CRUD_Noun";
            SqlConnection connection = new SqlConnection(sqlServerconnectionString);
            SqlCommand cmd = new SqlCommand(spName, connection);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@label";
            param1.Value = currentNoun.NounLabel;
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@desc";
            param2.Value = currentNoun.NounDescription;
            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@type";
            param3.Value = currentNoun.NounType;
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
            currentNoun = new Noun();
        }

        //*******************************************************************************
        //*********************************** CHANGE NOUN *******************************
        //*******************************************************************************
        private void Change()
        {
            string spName = "dbo.CRUD_Noun";
            SqlConnection connection = new SqlConnection(sqlServerconnectionString);
            SqlCommand cmd = new SqlCommand(spName, connection);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@label";
            param1.Value = currentNoun.NounLabel;
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@desc";
            param2.Value = currentNoun.NounDescription;
            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@id";
            param3.Value = selectedNoun;
            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@PROC_action";
            param4.Value = "Update";
            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@pod";
            param5.Value = pod;
            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "@status";
            param6.Value = currentNoun.NounStatus;
            SqlParameter param7 = new SqlParameter();
            param7.ParameterName = "@url_id_pk";
            param7.Value = currentNoun.UrlIdPk;
            SqlParameter param8 = new SqlParameter();
            param8.ParameterName = "@type";
            param8.Value = currentNoun.NounType;
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
            currentNoun = new Noun();
        }

        //*******************************************************************************
        //*************************** DELETE NOUN if status=D ***************************
        //*******************************************************************************
        private void Delete()
        {
            string spName = "dbo.CRUD_Noun";
            SqlConnection connection = new SqlConnection(sqlServerconnectionString);
            SqlCommand cmd = new SqlCommand(spName, connection);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@id";
            param1.Value = currentNoun.NounId;
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

        //*******************************************************************************
        //**************************** Stored Procedure *********************************
        //*******************************************************************************
        private void DeleteRead()
        {
            string spName = "dbo.NounDeleteRead";
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
            nounsDelete.Clear();
            while (reader.Read())
            {
                nounsDelete.Add(new Noun { NounId = reader.GetInt32(0), NounLabel = reader.GetString(1), NounDescription = reader.GetString(2), NounType = reader.GetString(3), NounStatus = reader.GetString(4), PodIdFk = reader.GetInt32(5), UrlIdPk = reader.GetInt32(6) });
            }
        }

        //*******************************************************************************
        //**************************** Stored Procedure *********************************
        //****************************    PYPE TYPE     *********************************
        //*******************************************************************************
        private void PypeRead()
        {
            string spName = "dbo.sp_Pype_Type_Locked";
            SqlConnection connection = new SqlConnection(sqlServerconnectionString);
            SqlCommand cmd = new SqlCommand(spName, connection);
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@PROC_Input_Filter";
            param1.Value = "NOUN";
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

        //********************** Override the OnInitialized method ********************
        //********************** ReRead lists when necessary ********************
        protected override void OnInitialized()
        {
            Read();
            PypeRead();
            DeleteRead();
        }
    }
}