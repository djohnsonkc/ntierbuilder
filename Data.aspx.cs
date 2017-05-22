using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using NTierBuilder.Domain;

public partial class Data : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Project"] == null)
        //    Session["Project"] = NTierBuilder.Domain.Project.BuildSampleProject();

        NTierBuilder.Domain.Project proj = (NTierBuilder.Domain.Project)Session["Project"];

        if (proj != null)
        {
            if (proj.Name_Space == "" || proj.TableName == "" || proj.ClassName == "" || proj.ConnectionString == "")
            {
            }
            else
            {

                NTierBuilder.Domain.StoredProcBuilderMethods proc = new NTierBuilder.Domain.StoredProcBuilderMethods();

                string addSQL = proc.GetAddProcedure(proj);
                string updateSQL = proc.GetUpdateProcedure(proj);
                string deleteSQL = proc.GetDeleteProcedure(proj);
                string fetchSQL = proc.GetRetrieveProcedure(proj);

                proj.Table.ProcAdd.Sql = addSQL;
                proj.Table.ProcDelete.Sql = deleteSQL;
                proj.Table.ProcRetrieve.Sql = fetchSQL;
                proj.Table.ProcUpdate.Sql = updateSQL;

                txtGrantExecuteSQL.Text += "grant execute on [" + proj.Table.ProcAdd.Name + "] to [" + proj.LoginName + "]\r\n";
                txtGrantExecuteSQL.Text += "grant execute on [" + proj.Table.ProcDelete.Name + "] to [" + proj.LoginName + "]\r\n";
                txtGrantExecuteSQL.Text += "grant execute on [" + proj.Table.ProcRetrieve.Name + "] to [" + proj.LoginName + "]\r\n";
                txtGrantExecuteSQL.Text += "grant execute on [" + proj.Table.ProcUpdate.Name + "] to [" + proj.LoginName + "]\r\n";


                NTierBuilder.Domain.TableColumn col = new NTierBuilder.Domain.TableColumn();
                for (int i = 0; i < proj.Table.Columns.Count; i++)
                {
                    col = (TableColumn)proj.Table.Columns[i];
                    if (col.Stat == "1")
                        proj.Table.IdColumnName = col.Name;
                }


                //update project
                Session["Project"] = proj;


                //create install script
                StringBuilder sb = new StringBuilder();


                sb.Append(addSQL);
                sb.Append("<br />");

                sb.Append(deleteSQL);
                sb.Append("<br />");

                sb.Append(updateSQL);
                sb.Append("<br />");

                sb.Append(fetchSQL);
                sb.Append("<br />");

                txtSQLScript.Text = sb.ToString();
                txtSQLScript.Text = txtSQLScript.Text.Replace("<br />", "\r\n");

                //get Data Adapter
                NTierBuilder.Domain.DataAdapterBuilderMethods da = new NTierBuilder.Domain.DataAdapterBuilderMethods();

                txtBaseAdapter.Text = da.GetBaseAdapterClass(proj, Server.MapPath("\\templates\\DataAdapter\\BaseAdapter.txt"));
                txtDataAdapter.Text = da.GetAdapterClass(proj, Server.MapPath("\\templates\\DataAdapter\\Adapter.txt"));


            }
        }

    }

    protected void btnContinue_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("presentation.aspx");
    }
}
