using System;
using System.Collections.Generic;
using System.Text;

namespace NTierBuilder.Domain
{
    public class FormBuilderMethods
    {

        #region List Form 

        public string GetListFormHtml(Project project, string template_path)
        {
            StringBuilder sb = new StringBuilder();
            string template = "";
            string row_template = ""; 
            string row_html = "";

            if (project.EditableGridView)
            {
                template = Utils.LoadTemplate(template_path + "\\List.aspx.editable.txt"); 
                row_template = Utils.LoadTemplate(template_path + "\\List.aspx.tr.editable.txt");
            }
            else
            {
                template = Utils.LoadTemplate(template_path + "\\List.aspx.txt");
                row_template = Utils.LoadTemplate(template_path + "\\List.aspx.tr.txt");
            }

            template = template.Replace("[DOMAIN_OBJECT_NAMESPACE]", project.Name_Space);
            template = template.Replace("[DOMAIN_OBJECT_NAME]", project.ClassName);
            template = template.Replace("[DOMAIN_OBJECT_ID_NAME]", project.Table.IdColumnName);
            template = template.Replace("[PROC_RETRIEVE]", project.Table.ProcRetrieve.Name);
            template = template.Replace("[ADAPTER_CONNECTION_STRING]", project.ConnectionString);

            foreach (TableColumn col in project.Table.Columns)
            {
                row_html = row_template.Replace("[DOMAIN_OBJECT_PROPERTY_NAME]", col.Name);
                sb.Append(row_html + "\r\n");
            }

            template = template.Replace("[LIST_FORM_OBJECT_ROWS]", sb.ToString());

            return template;

        }

        public string GetListFormCode(Project project, string template_path)
        {
            string template = "";

            if (project.EditableGridView)
            {
                template = Utils.LoadTemplate(template_path + "\\List.cs.editable.txt");
            }
            else
            {
                template = Utils.LoadTemplate(template_path + "\\List.cs.txt");
            }

            template = template.Replace("<", "&lt;").Replace(">", "&gt;");

            TableColumn tc = (TableColumn)project.Table.Columns[0];

            if (tc.Type.ToLower() == "bigint")
                template = template.Replace("[PKType]", "Int64");
            else
                template = template.Replace("[PKType]", "int");


            template = template.Replace("[DOMAIN_OBJECT_ID_NAME]", project.Table.IdColumnName);
            template = template.Replace("[DOMAIN_OBJECT_NAMESPACE]", project.Name_Space);
            template = template.Replace("[ADAPTER_CLASS_NAMESPACE]", project.Data_Layer_Name_Space);
            template = template.Replace("[DOMAIN_OBJECT_NAME]", project.ClassName);
            template = template.Replace("[PROC_RETRIEVE]", project.Table.ProcRetrieve.Name);
            template = template.Replace("[FORM_CLASS_PREFACE]", project.FormClassPreface);


            return template;

        }


        #endregion


        #region View Form

        public string GetViewFormHtml(Project project, string template_path)
        {
            StringBuilder sb = new StringBuilder();
            string template = Utils.LoadTemplate(template_path + "\\View.aspx.txt");
            string row_template = Utils.LoadTemplate(template_path + "\\View.aspx.tr.txt");
            string row_html = "";

            template = template.Replace("[DOMAIN_OBJECT_NAME]", project.ClassName);

            foreach (TableColumn col in project.Table.Columns)
            {
                row_html = row_template;
                row_html = row_html.Replace("[DOMAIN_OBJECT_PROPERTY_NAME]", col.Name);
                row_html = row_html.Replace("[OBJECT_PROPERTY_FORM_ELEMENT]", "<asp:Label id=\"lbl" + col.Name + "\" runat=\"server\"></asp:Label>");
                sb.Append(row_html + "\r\n");
            }

            template = template.Replace("[VIEW_FORM_OBJECT_ROWS]", sb.ToString());

            return template;

        }

        public string GetViewFormCode(Project project, string template_path)
        {
            StringBuilder sb = new StringBuilder();
            string template = Utils.LoadTemplate(template_path + "\\View.cs.txt");

            template = template.Replace("[DOMAIN_OBJECT_NAMESPACE]", project.Name_Space);
            template = template.Replace("[ADAPTER_CLASS_NAMESPACE]", project.Data_Layer_Name_Space);
            template = template.Replace("[DOMAIN_OBJECT_NAME]", project.ClassName);
            template = template.Replace("[DOMAIN_OBJECT_ID_NAME]", project.Table.IdColumnName);
            template = template.Replace("[FORM_CLASS_PREFACE]", project.FormClassPreface);

            foreach (TableColumn col in project.Table.Columns)
            {
                sb.Append("lbl" + col.Name + ".Text = obj." + col.Name + ".ToString();\r\n");
            }

            template = template.Replace("[LOAD_FORM_VALUES]", sb.ToString());


            return template;

        }

        #endregion


        #region Edit Form

        public string GetEditFormHtml(Project project, string template_path)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbReq = new StringBuilder();

            string template = Utils.LoadTemplate(template_path + "\\Edit.aspx.txt");
            string row_template = Utils.LoadTemplate(template_path + "\\Edit.aspx.tr.txt");
            string required_field_template = Utils.LoadTemplate(template_path + "\\Edit.RequiredField.txt");
            string required_field_html = "";
            string row_html = "";

            template = template.Replace("[DOMAIN_OBJECT_NAME]", project.ClassName);

            foreach (TableColumn col in project.Table.Columns)
            {
                row_html = row_template;
                row_html = row_html.Replace("[DOMAIN_OBJECT_PROPERTY_NAME]", col.Name);
                row_html = row_html.Replace("[OBJECT_PROPERTY_FORM_ELEMENT]", GetFormObject(col));
                sb.Append(row_html + "\r\n");
            }
            template = template.Replace("[EDIT_FORM_OBJECT_ROWS]", sb.ToString());

            //set required field validator for required fields
            foreach (TableColumn col in project.Table.Columns)
            {
                if (col.IsRequiredField)
                {
                    required_field_html = required_field_template;
                    required_field_html = required_field_html.Replace("[DOMAIN_OBJECT_PROPERTY_NAME]", col.Name);
                    sbReq.Append(required_field_html + "\r\n");
                }
            }
            template = template.Replace("[REQUIRED_FIELD_VALIDATOR]", sbReq.ToString());


            return template;

        }

        public string GetEditFormCode(Project project, string template_path)
        {
            StringBuilder sb = new StringBuilder();
            string template = Utils.LoadTemplate(template_path + "\\Edit.cs.txt");
            string ddl_template = Utils.LoadTemplate(template_path + "\\DropDownList.txt");
            string ddl_html = "";

            template = template.Replace("[DOMAIN_OBJECT_NAMESPACE]", project.Name_Space);
            template = template.Replace("[ADAPTER_CLASS_NAMESPACE]", project.Data_Layer_Name_Space);
            template = template.Replace("[DOMAIN_OBJECT_NAME]", project.ClassName);
            template = template.Replace("[DOMAIN_OBJECT_ID_NAME]", project.Table.IdColumnName);
            template = template.Replace("[FORM_CLASS_PREFACE]", project.FormClassPreface);

            //load form values
            foreach (TableColumn col in project.Table.Columns)
            {
                sb.Append("\t   " + SetFormValueFromObject(col));
            }
            template = template.Replace("[LOAD_FORM_VALUES]", sb.ToString());

            //load object values
            sb.Remove(0, sb.Length);
            foreach (TableColumn col in project.Table.Columns)
            {
                if(!col.IsPrimaryKey)
                    sb.Append("\t   " + SetObjectValueFromForm(col));
            }
            template = template.Replace("[LOAD_OBJECT_VALUES]", sb.ToString());

            //load dropdowns with collection
            ddl_html = ddl_template;
            foreach (TableColumn col in project.Table.Columns)
            {
                if (col.Form_Object_Type == "DropDownList")
                {
                    //if bound list e.g. State
                    if (col.Bound_List_Object != "")
                    {
                        ddl_html = ddl_html.Replace("[DOMAIN_OBJECT_NAMESPACE]", project.Name_Space);
                        ddl_html = ddl_html.Replace("[ADAPTER_CLASS_NAMESPACE]", project.Data_Layer_Name_Space);
                        ddl_html = ddl_html.Replace("[DOMAIN_OBJECT_NAME]", col.Bound_List_Object);
                        ddl_html = ddl_html.Replace("[DOMAIN_OBJECT_DATA_VALUE_FIELD]", col.Data_Value_Field);
                        ddl_html = ddl_html.Replace("[DOMAIN_OBJECT_DATA_TEXT_FIELD]", col.Data_Text_Field);

                        template = template.Replace("//[LOAD_OBJECTS]", "load" + col.Bound_List_Object + "Collection();\r\n");
                        template = template.Replace("//[LOAD_OBJECT_METHODS]", ddl_html + "\r\n");
                    }
                    //if static list e.g. Active/A, Inactive/I
                    else
                    {
                        template = template.Replace("//[LOAD_OBJECTS]", "");
                        template = template.Replace("//[LOAD_OBJECT_METHODS]", "");
                    }
                }
            }


            return template;

        }


        #endregion



        #region Utilities

        public string GetFormObject(TableColumn column)
        {
            string formObjectName = "";
            string liVal = "", liText = "";

            if (column.Form_Object_Type == "DropDownList")
            {
                formObjectName = "<asp:DropDownList id='ddl" + column.Name + "' runat='server'>";

                if (column.ListValues != "")
                {
                    string[] listValues;
                    listValues = column.ListValues.Split(',');

                    for (int j = 0; j < listValues.Length; j++)
                    {
                        liVal = listValues[j].Trim();
                        liText = listValues[j].Trim();

                        //if name/value pair specified, then parse it
                        if (liVal.IndexOf("/") != -1)
                        {
                            string[] nameValuePair;
                            nameValuePair = liVal.Split('/');
                            liText = nameValuePair[0];
                            liVal = nameValuePair[1];

                        }

                        formObjectName += "<asp:ListItem Value=\"" + liVal + "\">" + liText + "</asp:ListItem>";
                    }
                }
                formObjectName += "</asp:DropDownList>";

            }
            else if (column.Form_Object_Type == "CheckBox")
                formObjectName = "<asp:CheckBox id='cb" + column.Name + "' runat='server'></asp:CheckBox>";
            else if (column.Form_Object_Type == "Label")
                formObjectName = "<asp:Label id='lbl" + column.Name + "' runat='server'></asp:Label>";
            else if (column.Form_Object_Type == "TextBoxMultiLine")
                formObjectName = "<asp:TextBox id='txt" + column.Name + "' runat='server' Rows=\"3\" TextMode=\"MultiLine\" Width=\"300px\" MaxLength=\"" + column.Length + "\"></asp:TextBox>";
            else
            {
                //if datetime (len 8) allow length for "MM/dd/yyyy hh:mm tt"
                if(column.Type.ToLower() == "datetime")
                    formObjectName = "<asp:TextBox id='txt" + column.Name + "' runat='server' MaxLength=\"20\"></asp:TextBox>";
                else
                    formObjectName = "<asp:TextBox id='txt" + column.Name + "' runat='server' MaxLength=\"" + column.Length + "\"></asp:TextBox>";
            }
            return formObjectName;

        }

        public string SetFormValueFromObject(TableColumn column)
        {
            string formObjectName = "";

            if (column.Form_Object_Type == "DropDownList")
            {
                formObjectName = "\r\n"; //select current value using code below
                formObjectName += "ddl" + column.Name + ".SelectedIndex = ddl" + column.Name + ".Items.IndexOf(ddl" + column.Name + ".Items.FindByValue(obj." + column.Name + ".ToString()));\r\n"; 
                formObjectName += "\r\n";
            }
            else if (column.Form_Object_Type == "CheckBox")
                formObjectName = "cb" + column.Name + ".Checked = obj." + column.Name + ";\r\n";
            else if (column.Form_Object_Type == "Label")
                formObjectName = "lbl" + column.Name + ".Text = obj." + column.Name + ".ToString();\r\n";
            else if (column.Form_Object_Type == "Text")
                formObjectName = "txt" + column.Name + ".Text = obj." + column.Name + ".ToString();\r\n";
            else
                formObjectName = "txt" + column.Name + ".Text = obj." + column.Name + ".ToString();\r\n";

            return formObjectName;

        }

        public string SetObjectValueFromForm(TableColumn column)
        {
            string formObjectName = "";

            if (column.Form_Object_Type == "DropDownList")
            {
                if(column.Type == "int")
                    formObjectName = "obj." + column.Name + " = int.Parse(ddl" + column.Name + ".SelectedItem.Value);\r\n";
                else if (column.Type == "bigint")
                    formObjectName = "obj." + column.Name + " = Int64.Parse(ddl" + column.Name + ".SelectedItem.Value);\r\n";
                else
                    formObjectName = "obj." + column.Name + " = ddl" + column.Name + ".SelectedItem.Value;\r\n";
            }
            else if (column.Form_Object_Type == "CheckBox")
                formObjectName = "obj." + column.Name + " = cb" + column.Name + ".Checked;\r\n";
            else if (column.Form_Object_Type == "Label")
            {
                if (column.Type == "datetime")
                    formObjectName = "obj." + column.Name + " = DateTime.Now;\r\n";
                else
                    formObjectName = "//obj." + column.Name + " = lbl" + column.Name + ".Text;\r\n";
            }
            else if (column.Form_Object_Type == "Text")
                formObjectName = "obj." + column.Name + " = txt" + column.Name + ".Text;\r\n";
            else
                formObjectName = "obj." + column.Name + " = txt" + column.Name + ".Text;\r\n";

            return formObjectName;

        }


        #endregion

    }
}
