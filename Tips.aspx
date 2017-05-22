<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tips.aspx.cs" Inherits="Tips" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">

<h1>Tips & Tricks</h1>

<p>
If comparing dates in Data Adapter, use the following logic:<br /><br />
<pre>
if (obj.DateReserved != (DateTime)SqlDateTime.Null && obj.DateReserved > DateTime.Parse("1/1/1900"))
    AddInputParameter("DateReserved", obj.DateReserved);
</pre>
</p>

<h2>Load Dataset</h2>
<p>
<pre>

string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Resort"].ConnectionString;

string strSQL = Template.Load("MemberSearch.sql");
strSQL = strSQL.Replace("[SEARCH_TEXT]", txtSearch.Text);

DataSet ds = new DataSet();
SqlConnection conn = new SqlConnection(connectionString);
SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
ds = new System.Data.DataSet();
da.Fill(ds, "Records");


foreach (DataRow row in ds.Tables["Records"].Rows)
{
    //if (row["Status"].ToString() == "P")
    //    pending_ctr++;
}

GridView1.DataSource = ds.Tables["Records"];
GridView1.DataBind();

</pre>

</p>


<h2>Load Reader</h2>
<p>
<pre>

string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
IDataReader reader = null;
SqlConnection conn;
SqlCommand cmd;

string strSQL = "Select * From Customer";

conn = new SqlConnection(connectionString);
cmd = new SqlCommand(strSQL, conn);
//cmd.Parameters.AddWithValue("@searchtext", txtSearch.Text);

cmd.CommandType = CommandType.Text;

conn.Open();
reader = cmd.ExecuteReader();

while (reader.Read())
{
    MyObj m = new MyObj()

    m.MemberID = (Int64)reader["MemberID"];
    m.FullName = reader["LastName"].ToString() + ", " + reader["FirstName"].ToString();

}

conn.Close();
cmd.Dispose();



</pre>

</p>

</asp:Content>

