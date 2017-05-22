using System;
using System.Text;
using System.Web;

namespace NTierBuilder.Domain
{
	public class ClassBuilderMethods
	{

		public ClassBuilderMethods()
		{
		}

		public string GetClass(Project project)
		{

			StringBuilder sb = new StringBuilder();

            string primaryKeyProperCase = project.Table.IdColumnName; 
			string primaryKey = primaryKeyProperCase.ToLower();


			//add headers
			sb.Append("using System;");
            sb.Append("<br />");
            sb.Append("<br />");

			//start namespace
			sb.Append("namespace " + project.Name_Space);
			sb.Append("<br />");
			sb.Append("{");
			sb.Append("<br />");
			sb.Append("<br />");

			//start class def
			sb.Append("public class " + project.ClassName);
			sb.Append("<br />");
			sb.Append("{");
			sb.Append("<br />");
			sb.Append("<br />");

			//add Private and Public Properties
			sb.Append(getProperties(project));

			//add Constructors
			sb.Append(getConstructors(project.ClassName, primaryKey));
            
			//end Class def
			sb.Append("}");
			sb.Append("<br />");
			sb.Append("<br />");
			
			//end namespace
			sb.Append("}");
			sb.Append("<br />");
			sb.Append("<br />");			

			return sb.ToString();
		}


		private string getProperties(Project project)
		{
			
			int ctr = 0;
			TableColumn col;

			StringBuilder sb = new StringBuilder();            	

            //ctr = 0;
            //for(int i=0; i < project.Table.Columns.Count; i++)
            //{
            //    col = (TableColumn)project.Table.Columns[i];
            //    ctr++;

            //    sb.Append("private " + Utils.GetType(col.Type) + " " +  col.Name.ToLower() + ";");
            //    sb.Append("<br />");
            //}

            //sb.Append("<br />");

            //ctr = 0;
            //for(int i=0; i < project.Table.Columns.Count; i++)
            //{
            //    col = (TableColumn)project.Table.Columns[i];

            //    ctr++;
            //    sb.Append("public " + Utils.GetType(col.Type) + " " + col.PublicName);
            //    sb.Append("<br />");
            //    sb.Append("{");
            //    sb.Append("<br />");
            //    sb.Append("set { " +  col.Name.ToLower() + " = value; }");
            //    sb.Append("<br />");
            //    sb.Append("get { return " +  col.Name.ToLower() + "; }");
            //    sb.Append("<br />");
            //    sb.Append("}");
            //    sb.Append("<br />");
            //}

            ctr = 0;
            for (int i = 0; i < project.Table.Columns.Count; i++)
            {
                col = (TableColumn)project.Table.Columns[i];

                ctr++;
                sb.Append("public " + Utils.GetType(col.Type) + " " + col.PublicName + " { set; get; }");
                sb.Append("<br />");
            }


			sb.Append("<br />");

			return sb.ToString();
		}



		private string getConstructors(string className, string primaryKey)
		{
			StringBuilder sb = new StringBuilder();

			//default constructor
			sb.Append("public " + className + "()");
			sb.Append("<br />");
			sb.Append("{");
			sb.Append("<br />");
			sb.Append("}");
			sb.Append("<br />");
			sb.Append("<br />");

			return sb.ToString();
		}


        

	}
}
