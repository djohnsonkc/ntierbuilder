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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //make submit button default when password changed
        txtPassword.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btnSubmit.ClientID + "').click();return false;}} else {return true}; ");

        btnSubmit.Attributes.Add("onclick", "javascript: document.getElementById('" + lblMessage.ClientID + "').innerText='Verifying credentials...';");


        //cause field to be selected (highlighted) when has focus
        txtEmail.Attributes.Add("onfocus", txtEmail.ClientID + ".select();");
        txtPassword.Attributes.Add("onfocus", txtPassword.ClientID + ".select();");


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string username = txtEmail.Text.ToLower();
        string pwd = txtPassword.Text.ToLower();

        if (FormsAuthentication.Authenticate(username, pwd))
        {
            FormsAuthentication.RedirectFromLoginPage(username, false);

            Response.Redirect("/Default.aspx");
        }
        else
        {
            lblMessage.Text = "You did not enter in the correct username or password";
        }

    }




}
