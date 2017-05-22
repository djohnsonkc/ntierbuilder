using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Security.Cryptography;
using System.Text;

using System.Collections;
using System.Collections.Specialized;

/// <summary>
/// Summary description for QueryString
/// </summary>
public class QueryString
{

    //private string key = "!@#$%^&*";

    public QueryString()
    {
    }
    
    public static string Value(string parameter_name, string default_value)
    {
        string value = default_value;

        if (HttpContext.Current.Request.QueryString[parameter_name] != null)
        {
            if (HttpContext.Current.Request.QueryString[parameter_name] != "")
                value = HttpContext.Current.Request.QueryString[parameter_name].ToString();
        }
        return value;

    }


}