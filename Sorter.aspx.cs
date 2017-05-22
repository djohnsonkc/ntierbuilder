using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Sorter : System.Web.UI.Page
{

    NTierBuilder.Domain.Project proj;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Project"] == null)
        //    Session["Project"] = NTierBuilder.Domain.Project.BuildSampleProject();

        if (Session["Project"] == null)
        {
            proj = new NTierBuilder.Domain.Project();
            proj.Name_Space = "";
        }
        else
        {
            proj = (NTierBuilder.Domain.Project)Session["Project"];
        }

     }





}
