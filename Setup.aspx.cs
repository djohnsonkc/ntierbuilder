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

public partial class Setup : System.Web.UI.Page
{

    NTierBuilder.Domain.Project proj;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            txtNamespace.Text = NTierBuilder.Domain.Utils.GetCookie("Namespace");
            txtDataLayerNamespace.Text = NTierBuilder.Domain.Utils.GetCookie("Data_Layer_Namespace");
            txtClassName.Text = NTierBuilder.Domain.Utils.GetCookie("ClassName");
            txtTableName.Text = NTierBuilder.Domain.Utils.GetCookie("TableName");
            txtProcAdd.Text = NTierBuilder.Domain.Utils.GetCookie("ProcAdd");
            txtProcDelete.Text = NTierBuilder.Domain.Utils.GetCookie("ProcDelete");
            txtProcRetrieve.Text = NTierBuilder.Domain.Utils.GetCookie("ProcRetrieve");
            txtProcUpdate.Text = NTierBuilder.Domain.Utils.GetCookie("ProcUpdate");
            txtConnectionName.Text = NTierBuilder.Domain.Utils.GetCookie("ConnectionString");
            txtProcLoginName.Text = NTierBuilder.Domain.Utils.GetCookie("LoginName"); 

            if (Session["Project"] == null)
            {
                btnCreate.Enabled = false;
                LabelMessage.Text = "<br /><font color='red'><b>Please return to 'Start' to paste in your query output.</b></font><br />";
            }
            else
            {
                proj = (NTierBuilder.Domain.Project)Session["Project"];
                //txtNamespace.Text = proj.Name_Space;
                //txtDataLayerNamespace.Text = proj.Data_Layer_Name_Space;
                //txtClassName.Text = proj.ClassName;
                //txtTableName.Text = proj.TableName;
                //txtProcAdd.Text = proj.Table.ProcAdd.Name;
                //txtProcDelete.Text = proj.Table.ProcDelete.Name;
                //txtProcRetrieve.Text = proj.Table.ProcRetrieve.Name;
                //txtProcUpdate.Text = proj.Table.ProcUpdate.Name;
                //txtConnectionName.Text = proj.ConnectionString;

                btnCreate.Enabled = true;
            }

        }
    }


    protected void btnCreate_Click(object sender, System.EventArgs e)
    {
        LabelMessage.Text = "";

        if (txtNamespace.Text == "" || txtTableName.Text == "" || txtClassName.Text == "")
        {
            LabelMessage.Text = "<font color='red'>Please provide the following information:<ul><li>Namespace, Table Name, and Class Name</li></ul></font>";

            return;
        }

        //add to project created on start.aspx
        proj = (NTierBuilder.Domain.Project)Session["Project"];
        proj.Name_Space = txtNamespace.Text;
        proj.Data_Layer_Name_Space = txtDataLayerNamespace.Text;
        proj.TableName = txtTableName.Text;
        proj.ClassName = txtClassName.Text;
        proj.ConnectionString = txtConnectionName.Text;
        //proj.QueryInput = set on Start page
        proj.Table = new NTierBuilder.Domain.Table();
        proj.Table.LoadTable(proj.QueryInput);
        proj.Table.ProcAdd.Name = txtProcAdd.Text;
        proj.Table.ProcDelete.Name = txtProcDelete.Text;
        proj.Table.ProcRetrieve.Name = txtProcRetrieve.Text;
        proj.Table.ProcUpdate.Name = txtProcUpdate.Text;
        proj.LoginName = txtProcLoginName.Text;

        Session["Project"] = proj;

        //set cookies
        NTierBuilder.Domain.Utils.SetCookie("Namespace", txtNamespace.Text);
        NTierBuilder.Domain.Utils.SetCookie("Data_Layer_Namespace", txtDataLayerNamespace.Text);
        NTierBuilder.Domain.Utils.SetCookie("TableName", txtTableName.Text);
        NTierBuilder.Domain.Utils.SetCookie("ClassName", txtClassName.Text);
        NTierBuilder.Domain.Utils.SetCookie("ProcAdd", txtProcAdd.Text);
        NTierBuilder.Domain.Utils.SetCookie("ProcDelete", txtProcDelete.Text);
        NTierBuilder.Domain.Utils.SetCookie("ProcUpdate", txtProcUpdate.Text);
        NTierBuilder.Domain.Utils.SetCookie("ProcRetrieve", txtProcRetrieve.Text);
        NTierBuilder.Domain.Utils.SetCookie("ConnectionString", txtConnectionName.Text);
        NTierBuilder.Domain.Utils.SetCookie("LoginName", txtProcLoginName.Text);


        Response.Redirect("business.aspx");

    }




    protected void btnCreateStoredProcNames_Click(object sender, EventArgs e)
    {
        if (txtClassName.Text == "")
        {
            LabelMessage.Text = "<font color='red'>Please provide the following information:<ul><li>Please specify a Class name</li></ul></font>";
            return;
        }
        //txtProcAdd.Text = "p_" + txtTableName.Text.ToLower() + "_insert";
        //txtProcDelete.Text = "p_" + txtTableName.Text.ToLower() + "_delete";
        //txtProcUpdate.Text = "p_" + txtTableName.Text.ToLower() + "_update";
        //txtProcRetrieve.Text = "p_" + txtTableName.Text.ToLower() + "_select";


        txtProcAdd.Text = txtTableName.Text + "Insert";
        txtProcDelete.Text = txtTableName.Text + "Delete";
        txtProcUpdate.Text = txtTableName.Text + "Update";
        txtProcRetrieve.Text = txtTableName.Text + "Select";


    }
}
