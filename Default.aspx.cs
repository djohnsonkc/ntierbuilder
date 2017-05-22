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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //go ahead and load demo so that visitors can see the code
        //without having to do anything
        //if (Session["Project"] == null)
        //    Session["Project"] = NTierBuilder.Domain.Project.BuildSampleProject();

    }
}
