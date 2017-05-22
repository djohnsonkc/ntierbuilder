using System;
using System.Text;
using System.Web;
using System.IO;

namespace NTierBuilder.Domain
{
    public class DataAdapterBuilderMethods
    {

        public string GetBaseAdapterClass(Project project, string template_path)
        {
            string template = Utils.LoadTemplate(template_path);

            template = template.Replace("[ADAPTER_CLASS_NAMESPACE]", project.Data_Layer_Name_Space);
            template = template.Replace("[ADAPTER_CONNECTION_STRING]", project.ConnectionString);

            return template;

        }

        public string GetAdapterClass(Project project, string template_path)
        {

            string template = Utils.LoadTemplate(template_path);

            template = template.Replace("[DOMAIN_OBJECT_NAMESPACE]", project.Name_Space);
            template = template.Replace("[ADAPTER_CLASS_NAMESPACE]", project.Data_Layer_Name_Space);
            template = template.Replace("[ADAPTER_CLASS_NAME]", project.ClassName + "Adapter");
            template = template.Replace("[DOMAIN_OBJECT_NAME]", project.ClassName);
            template = template.Replace("[DOMAIN_OBJECT_ID_NAME]", project.Table.IdColumnName);
            template = template.Replace("[PROC_ADD]", project.Table.ProcAdd.Name);
            template = template.Replace("[PROC_DELETE]", project.Table.ProcDelete.Name);
            template = template.Replace("[PROC_UPDATE]", project.Table.ProcUpdate.Name);
            template = template.Replace("[PROC_RETRIEVE]", project.Table.ProcRetrieve.Name);

            template = template.Replace("[ADAPTER_PROPERTIES]", getPropertyList(project));
            template = template.Replace("[ADAPTER_PARAMETERS]", getParameterList(project));

            TableColumn tc = (TableColumn)project.Table.Columns[0];
            if (tc.Type == "int")
            {
                template = template.Replace("[PK_SIZE]", "32");
                template = template.Replace("[PK_TYPE]", "int");
            }
            else if (tc.Type == "bigint")
            {
                template = template.Replace("[PK_SIZE]", "64");
                template = template.Replace("[PK_TYPE]", "Int64");
            }

            return template;

        }

        private string getPropertyList(Project project)
        {
            TableColumn col;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < project.Table.Columns.Count; i++)
            {

                col = (TableColumn)project.Table.Columns[i];

                if (!col.IsPrimaryKey)
                {

                    if (i > 0)
                        sb.Append("		    ");

                    sb.Append("obj." + col.PublicName + " = ");

                    if (Utils.IsStringType(col.Type) == true)
                    {
                        if (col.Type.ToLower() == "char") //replace = "-"
                        {
                            sb.Append("GetChar(\"" + col.Name + "\", reader);");
                        }
                        else
                        {
                            sb.Append("GetString(\"" + col.Name + "\", reader);");
                        }
                    }
                    else
                    {
                        if (Utils.GetType(col.Type.ToLower()) == "int")
                        {
                            sb.Append("GetInt32(\"" + col.Name + "\", reader);");
                        }
                        else if (Utils.GetType(col.Type.ToLower()) == "bigint")
                        {
                            sb.Append("GetInt64(\"" + col.Name + "\", reader);");
                        }
                        else if (Utils.GetType(col.Type.ToLower()) == "short")
                        {
                            sb.Append("GetShort(\"" + col.Name + "\", reader);");
                        }
                        else if (Utils.GetType(col.Type.ToLower()) == "byte")
                        {
                            sb.Append("GetByte(\"" + col.Name + "\", reader);");
                        }
                        else if (Utils.GetType(col.Type.ToLower()) == "float")
                        {
                            sb.Append("GetFloat(\"" + col.Name + "\", reader);");
                        }
                        else if (Utils.GetType(col.Type.ToLower()) == "bool")
                        {
                            sb.Append("GetBoolean(\"" + col.Name + "\", reader);");
                        }
                        else
                        {
                            sb.Append("Get" + Utils.ProperCase(Utils.GetType(col.Type)) + "(\"" + col.Name + "\", reader);");
                        }
                    }


                    sb.Append("\r\n");
                }
            }

            return sb.ToString();
        }

        private string getParameterList(Project project)
        {
            TableColumn col;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < project.Table.Columns.Count; i++)
            {
                col = (TableColumn)project.Table.Columns[i];

                if (!col.IsPrimaryKey) 
                {
                    if (i > 0)
                        sb.Append("		    ");

                    sb.Append("AddInputParameter(\"" + col.Name + "\", obj." + col.PublicName + ");");
                    sb.Append("\r\n");
                }
            }

            return sb.ToString();
        }





    }



}
