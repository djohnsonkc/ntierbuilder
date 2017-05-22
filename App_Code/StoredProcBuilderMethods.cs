using System;
using System.Collections;
using System.Text;
using System.Web;

namespace NTierBuilder.Domain
{
	/// <summary>
	/// Summary description for StoredProc.
	/// </summary>
	public class StoredProcBuilderMethods
	{

		public StoredProcBuilderMethods()
		{
		}

		public string GetAddProcedure(Project project)
		{

			TableColumn col;
			int ctr = 0;
			int rowCtr = project.Table.Columns.Count;

			StringBuilder sb = new StringBuilder();

            //sb.Append("----------- START ADD PROCEDURE --------------<br />");
            sb.Append("CREATE PROCEDURE " + project.Table.ProcAdd.Name);
			sb.Append("<br />");
			sb.Append("<br />");

            string pkType = "int"; //use to output ID value
			
			for(int i=0; i < project.Table.Columns.Count; i++)
			{
                col = (TableColumn)project.Table.Columns[i];

				if(col.Stat != "1")
				{
					sb.Append("@" + col.Name.ToLower());
					sb.Append(" " + col.Type);
					sb.Append(getSize(col.Type, col.Length));
					//if(ctr < rowCtr)
						sb.Append(",");
					sb.Append("<br />");
				}
                else
                    pkType = col.Type; //set output ID value

			}

			sb.Append("@ID " + pkType + " OUTPUT"); //int or bigint 

			sb.Append("<br />");
			sb.Append("<br />");

			sb.Append("AS");
			
			sb.Append("<br />");
			sb.Append("<br />");

			sb.Append("INSERT INTO " + project.TableName);
			sb.Append("<br />");
			sb.Append("(");

			for(int i=0; i < project.Table.Columns.Count; i++)
			{
                col = (TableColumn)project.Table.Columns[i];
                ctr++;
				if(col.Stat != "1")
				{
					sb.Append(col.Name.ToLower());
					if(ctr < rowCtr)
						sb.Append(",");
				}
			}

			sb.Append(")");
			
			sb.Append("<br />");
			sb.Append("<br />");

			sb.Append("VALUES(");

			ctr = 0;
			for(int i=0; i < project.Table.Columns.Count; i++)
			{
				col = (TableColumn)project.Table.Columns[i];

				ctr++;
				if(col.Stat != "1")
				{
					sb.Append("@" +  col.Name.ToLower());
					if(ctr < rowCtr)
						sb.Append(",");
				}
			}

			
			sb.Append(")");

			sb.Append("<br />");
			sb.Append("<br />");

			sb.Append("SET @ID = @@IDENTITY");
			sb.Append("<br />");
			sb.Append("<br />");
			sb.Append("GO");
			sb.Append("<br />");
			sb.Append("<br />");

			return sb.ToString();
		}

		public string GetUpdateProcedure(Project project)
		{
			int ctr = 0;
			int rowCtr = project.Table.Columns.Count;
			string primaryKey = "";
			TableColumn col;

			StringBuilder sb = new StringBuilder();

            //sb.Append("----------- START UPDATE PROCEDURE --------------<br />");
			sb.Append("CREATE PROCEDURE " + project.Table.ProcUpdate.Name);
			sb.Append("<br />");
			sb.Append("<br />");

			rowCtr = project.Table.Columns.Count;

			//incase no auto-num on first column
			col = (TableColumn)project.Table.Columns[0];
			primaryKey = col.Name;

			ctr = 0;
			for(int i=0; i < project.Table.Columns.Count; i++)
			{
				col = (TableColumn)project.Table.Columns[i];

				ctr++;

				if(col.Stat == "1")
					primaryKey = col.Name;

				sb.Append("@" +  col.Name.ToLower());
				sb.Append(" " + col.Type);
				sb.Append(getSize(col.Type, col.Length));
				if(ctr < rowCtr)
					sb.Append(",");
				sb.Append("<br />");
			}

			sb.Append("<br />");

			sb.Append("AS");
			
			sb.Append("<br />");
			sb.Append("<br />");

			sb.Append("UPDATE " + project.TableName);
			sb.Append("<br />");
			sb.Append("SET");
			sb.Append("<br />");

			ctr = 0;
			for(int i=0; i < project.Table.Columns.Count; i++)
			{
                col = (TableColumn)project.Table.Columns[i];

				ctr++;
				if(col.Stat != "1")
				{
					sb.Append(col.Name + " = @" +  col.Name.ToLower());
					if(ctr < rowCtr)
						sb.Append(",");
					sb.Append("<br />");
				}
			}
	
			sb.Append("<br />");

			sb.Append("WHERE " + primaryKey + " = @" +  primaryKey.ToLower());

			sb.Append("<br />");
			sb.Append("<br />");
			sb.Append("GO");
			sb.Append("<br />");
			sb.Append("<br />");

			return sb.ToString();
		}

		public string GetDeleteProcedure(Project project)
		{
			string primaryKey = "";
			TableColumn col;

			StringBuilder sb = new StringBuilder();

            //sb.Append("----------- START DELETE PROCEDURE --------------<br />");
			sb.Append("CREATE PROCEDURE " + project.Table.ProcDelete.Name);
			sb.Append("<br />");
			sb.Append("<br />");

			//incase no auto-num on first column
			col = (TableColumn)project.Table.Columns[0];
			primaryKey = col.Name;
			
			for(int i=0; i < project.Table.Columns.Count; i++)
			{
                col = (TableColumn)project.Table.Columns[i];

				if(col.Stat == "1")
				{
					primaryKey = col.Name;
					sb.Append("@" +  col.Name.ToLower() + " " + col.Type);
				}
			}
			sb.Append("<br />");
			sb.Append("<br />");

			sb.Append("AS");
			
			sb.Append("<br />");
			sb.Append("<br />");

			sb.Append("DELETE FROM " + project.TableName);
			sb.Append("<br />");
            sb.Append("WHERE " + primaryKey + " = @" + primaryKey.ToLower());

			sb.Append("<br />");
			sb.Append("<br />");
			sb.Append("GO");
			sb.Append("<br />");
			sb.Append("<br />");

			return sb.ToString();
		}

		public string GetRetrieveProcedure(Project project)
		{
            int ctr = 0;
			int rowCtr = project.Table.Columns.Count;
			string primaryKey = "";
			string primaryKeyType = "";
			TableColumn col;
	
			StringBuilder sb = new StringBuilder();
			
			//incase no auto-num on first column
			col = (TableColumn)project.Table.Columns[0];
			primaryKey = col.Name;
			primaryKeyType = col.Type;


            //sb.Append("----------- START RETRIEVE PROCEDURE --------------<br />");
			sb.Append("CREATE PROCEDURE " + project.Table.ProcRetrieve.Name);
			sb.Append("<br />");
			sb.Append("<br />");

			for(int i=0; i < project.Table.Columns.Count; i++)
			{
                col = (TableColumn)project.Table.Columns[i];

				if(col.Stat == "1")
				{
					primaryKey = col.Name.ToLower();
					primaryKeyType = col.Type;
				}
			}
			sb.Append("@" +  primaryKey.ToLower() + " " + primaryKeyType + " = NULL");

			sb.Append("<br />");
			sb.Append("<br />");

			sb.Append("AS");
			
			sb.Append("<br />");
			sb.Append("<br />");
			
			sb.Append("SELECT");			
			
			sb.Append("<br />");
			sb.Append("<br />");

			
			ctr = 0;
			for(int i=0; i < project.Table.Columns.Count; i++)
			{
				col = (TableColumn)project.Table.Columns[i];

				if(col.Stat == "1")
					primaryKey = col.Name;

				ctr++;
				//if(col.Stat != "1")
				//{
					sb.Append(project.TableName.Substring(0,1).ToLower() + "." + col.Name.ToLower());
					if(ctr < rowCtr)
						sb.Append(",");
					sb.Append("<br />");
				//}
			}
			sb.Append("<br />");


			sb.Append("FROM " + project.TableName + " " + project.TableName.Substring(0,1).ToLower());
			sb.Append("<br />");
			sb.Append("WHERE ");
            sb.Append("( " + project.TableName.Substring(0, 1).ToLower() + "." + primaryKey.ToLower() + " = @" + primaryKey.ToLower() + " OR @" + primaryKey.ToLower() + " IS NULL)");

			sb.Append("<br />");
			sb.Append("<br />");
			sb.Append("GO");
			sb.Append("<br />");
			sb.Append("<br />");

			return sb.ToString();
		}

		private string getSize(string type, string size)
		{
			string returnValue = ""; 

			switch(type)
			{
				case "varchar":
					returnValue = "(" + size + ")";
					break;
				case "text":
					returnValue = "(" + size + ")";
					break;
				case "char":
					returnValue = "(" + size + ")";
					break;
				case "nvarchar":
					returnValue = "(" + size + ")";
					break;

			}

			return returnValue;
		}


	}
}
