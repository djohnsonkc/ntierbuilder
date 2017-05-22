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
using NTierBuilder.Domain;

public partial class Start : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //get columns from Cookie if exist
            if (NTierBuilder.Domain.Utils.GetCookie("QueryInput") != "")
            {
                NTierBuilder.Domain.Project proj = NTierBuilder.Domain.Project.BuildProjectFromCookies();
                txtColumns.Text = proj.QueryInput.Replace("_", ""); //remove _ bug
            }
        }


    }

    protected void btnStart_Click(object sender, System.EventArgs e)
    {
        LabelMessage.Visible = false;

        if (txtColumns.Text == "")
        {
            LabelMessage.Visible = true;
            LabelMessage.Text = "<br /><font color='red'>Please paste in your query results before continuing to Setup.</font></br>";
            return;
        }
        else
        {

            //create project
            NTierBuilder.Domain.Project proj = new NTierBuilder.Domain.Project();
            proj.QueryInput = txtColumns.Text;
            proj.Table.LoadTable(proj.QueryInput);
            Session["Project"] = proj;

            NTierBuilder.Domain.Utils.SetCookie("QueryInput", txtColumns.Text);


            Response.Redirect("setup.aspx");
        }
    }



}
