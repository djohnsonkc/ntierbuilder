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

public partial class Business : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

       // if (Session["Project"] == null)
       //     Session["Project"] = NTierBuilder.Domain.Project.BuildSampleProject();

        NTierBuilder.Domain.Project  proj = (NTierBuilder.Domain.Project)Session["Project"];

        if (proj != null)
        {
            if (proj.Name_Space == "" || proj.TableName == "" || proj.ClassName == "" || proj.ConnectionString == "")
            {
            }
            else
            {
                LabelBusinessLayerClassName.Text = proj.ClassName + ".cs";

                NTierBuilder.Domain.ClassBuilderMethods classObj = new NTierBuilder.Domain.ClassBuilderMethods();

                //display object class
                string strClass = classObj.GetClass(proj);
                txtNetCode.Text = strClass;

                txtNetCode.Text = sb.ToString() + txtNetCode.Text.Replace("<br />", "\r\n");

            }
        }

    }

    protected void btnContinue_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("data.aspx");
    }
}
