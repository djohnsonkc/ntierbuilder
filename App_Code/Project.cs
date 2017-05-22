using System;
using System.Text;
using System.Web;

namespace NTierBuilder.Domain
{
	/// <summary>
	/// Summary description for Project.
	/// </summary>
	public class Project
	{

		private string name_space;
        private string data_layer_name_space;
        private string table_name;
		private string class_name;
		private string connection_string;
		private string query_input;
        private Table table = new Table();
        private string login_name;
        private string form_class_preface;
        private bool editable_gridview = false;

		public string Name_Space
		{
			set { name_space = value; }
			get { return name_space; }
		}
        public string Data_Layer_Name_Space
        {
            set { data_layer_name_space = value; }
            get { return data_layer_name_space; }
        }
        public string TableName
		{
			set { table_name = value; }
			get { return table_name; }
		}
        public string ClassName
		{
			set { class_name = value; }
			get { return class_name; }
		}
		public string ConnectionString
		{
			set { connection_string = value; }
			get { return connection_string; }
		}
		public string QueryInput
		{
			set { query_input = value; }
			get { return query_input; }
		}
        public Table Table
        {
            set { table = value; }
            get { return table; }
        }
        public string CodeToInstantiateObject
        {
            get { return Name_Space + "." + ClassName + " " + ClassName.ToLower() + " = new " + Name_Space + "." + ClassName + "();"; }
        }
        public string CodeToInstantiateAdapter
        {
            get { return Data_Layer_Name_Space + "." + ClassName + "Adapter adapter = new " + Data_Layer_Name_Space + "." + ClassName + "Adapter();"; }
        }

        public string LoginName
        {
            set { login_name = value; }
            get { return login_name; }
        }
        public string FormClassPreface
        {
            set { form_class_preface = value; }
            get { return form_class_preface; }
        }
        public bool EditableGridView
        {
            set { editable_gridview = value; }
            get { return editable_gridview; }
        }

		public Project()
		{
		}

               
		public static Project BuildSampleProject()
		{
            //string template = Utils.LoadTemplate(sample_columns_template);

            string demo_path = HttpContext.Current.Server.MapPath("\\templates\\DomainObject\\SampleColumns.txt");
            string template = NTierBuilder.Domain.Utils.LoadTemplate(demo_path);
 
			//create project
			Project proj = new Project();
			proj.Name_Space = "Sales.Domain"; //will be set in Setup
            proj.Data_Layer_Name_Space = "Sales.Data";
			proj.TableName = "Customers";
			proj.ClassName = "Customer";
			proj.ConnectionString = "Sales";
			proj.QueryInput = template;
            proj.Table = new NTierBuilder.Domain.Table();
            proj.Table.LoadTable(proj.QueryInput);
            proj.Table.ProcAdd.Name = "p_customer_insert";
            proj.Table.ProcDelete.Name = "p_customer_delete";
            proj.Table.ProcRetrieve.Name = "p_customer_select";
            proj.Table.ProcUpdate.Name = "p_customer_update";
            proj.LoginName = "web_user";

            //set cookies
            NTierBuilder.Domain.Utils.SetCookie("Namespace", proj.Name_Space);
            NTierBuilder.Domain.Utils.SetCookie("Data_Layer_Namespace", proj.Data_Layer_Name_Space);
            NTierBuilder.Domain.Utils.SetCookie("TableName", proj.TableName);
            NTierBuilder.Domain.Utils.SetCookie("ClassName", proj.ClassName);
            NTierBuilder.Domain.Utils.SetCookie("ProcAdd", proj.Table.ProcAdd.Name);
            NTierBuilder.Domain.Utils.SetCookie("ProcDelete", proj.Table.ProcDelete.Name);
            NTierBuilder.Domain.Utils.SetCookie("ProcUpdate", proj.Table.ProcUpdate.Name);
            NTierBuilder.Domain.Utils.SetCookie("ProcRetrieve", proj.Table.ProcRetrieve.Name);
            NTierBuilder.Domain.Utils.SetCookie("ConnectionString", proj.ConnectionString);
            NTierBuilder.Domain.Utils.SetCookie("LoginName", proj.LoginName);


            NTierBuilder.Domain.Utils.SetCookie("QueryInput", template);


            return proj;
		}

        public static Project BuildProjectFromCookies()
        {
            //create project
            Project proj = new Project();
            proj.Name_Space = Utils.GetCookie("Namespace");
            proj.Data_Layer_Name_Space = Utils.GetCookie("Data_Layer_Namespace");
            proj.TableName = Utils.GetCookie("TableName");
            proj.ClassName = Utils.GetCookie("ClassName");
            proj.ConnectionString = Utils.GetCookie("ConnectionString");
            proj.QueryInput = Utils.GetCookie("QueryInput").Replace("%0d%0a", "\r\n");
            proj.Table = new NTierBuilder.Domain.Table();
            proj.Table.LoadTable(proj.QueryInput);
            proj.Table.ProcAdd.Name = Utils.GetCookie("ProcAdd");
            proj.Table.ProcDelete.Name = Utils.GetCookie("ProcDelete");
            proj.Table.ProcRetrieve.Name = Utils.GetCookie("ProcRetrieve");
            proj.Table.ProcUpdate.Name = Utils.GetCookie("ProcUpdate");

            return proj;
        }


	}
}
