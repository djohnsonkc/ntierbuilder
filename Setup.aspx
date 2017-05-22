<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="Setup.aspx.cs" Inherits="Setup" Title="NTierBuilder - Setup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">

			<h1><img src="images/setup.gif" width="32" height="32"> Setup -&nbsp;5 
				easy steps and you're done!</h1> 
			<asp:label id="LabelMessage" runat="server"></asp:label><br />
			Enter the settings requested below. These will be used when generating your 
			object classes, SQL Server stored procedures, and Web Form elements.<br />
    &nbsp;<br />
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" bgColor="#336699" border="0">
				<TR>
					<TD><STRONG><FONT color="white">STEP #1. Enter Namespaces</FONT></STRONG></TD>
				</TR>
			</TABLE>
            <p>
            <strong>Domain Namespace:</strong></p>
            <p>
			Tip: Use a high-level singular name such as Sales.Domain, Inventory.Domain, etc. 
			The assembly for your Business Layer should exist in a separate project in 
			Visual Studio.NET from your Presentation Layer. The Business Layer assembly can 
			be included as a Reference in the project for the Presentation Layer.<br />
			<asp:textbox id="txtNamespace" runat="server" Width="248px">Sales.Domain</asp:textbox>&nbsp;(e.g. Sales.Domain)</p>
            <p>
            <strong>Data Namespace:</strong><br />
            <br />
            Enter the name of your data access layer namespace (e.g. Sales.Data)<br />
            <asp:TextBox ID="txtDataLayerNamespace" runat="server" Width="248px">Sales.Data</asp:TextBox><br />
			</p>
			<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" bgColor="#336699" border="0">
				<TR>
					<TD><STRONG><FONT color="white">STEP #2. Enter a Table Name</FONT></STRONG>
					</TD>
				</TR>
			</TABLE>
			<p>
			This will be used to build the Data Access Layer components.</p>
			<p>
			<asp:textbox id="txtTableName" runat="server" Width="248px">Customers</asp:textbox>&nbsp;(e.g. 
				Customers)
			</p>
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" bgColor="#336699" border="0">
				<TR>
					<TD><STRONG><FONT color="white">STEP #3. Enter a Class Name</FONT></STRONG></TD>
				</TR>
			</TABLE>
			<p>Use singular name to 
				represent a single object in your table - e.g. use "Customer" for the 
				"Customers" table
			</p>
			<p>
			<asp:textbox id="txtClassName" runat="server" Width="248px">Customer</asp:textbox>&nbsp;(e.g. 
			Customer)
			</p>
			<br />
			<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" bgColor="#336699" border="0">
				<TR>
					<TD><STRONG><FONT color="white">STEP #4.&nbsp;Enter a Connection String Name</FONT></STRONG>&nbsp;</TD>
				</TR>
			</TABLE>
			<p>
			This will be used in the Business Layer to allow connection to the Data Access Layer 
			This should be added to your Web.Config or Machine.Config file in the &lt;connectionStrings&gt;
               section. Below is an example.</p>
                <p>
                &lt;configuration&gt;<br />
                &lt;connectionStrings&gt;<br />
                &nbsp; &nbsp;&nbsp; &lt;add name="Sales" <br />
                &nbsp; &nbsp;&nbsp; connectionString="server=localhost;database=Sales;user
                id=web_user;password=web_user;"/&gt; <br />
                &lt;/connectionStrings&gt;
				</p>
				<p>
				Connection String Name (e.g. Sales)<br />
				<asp:TextBox id="txtConnectionName" runat="server" Width="248px">Sales</asp:TextBox>
				</p>
				<br />
				<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" bgColor="#336699" border="0">
					<TR>
						<TD><STRONG><FONT color="white">STEP #5.&nbsp;Stored Procedure Naming Convention</FONT></STRONG>&nbsp;</TD>
					</TR>
				</TABLE>
				For the Data Access Layer, please indicate the names for your Stored Procedures. This 
				a huge&nbsp;subject of debate that differs in almost every IT environment. To 
				pre-pend the Stored Procedures with "usp_", "p_" or "sproc_", enter it below. 
				Remember, it's not recommended to pre-pend a procedure name with "sp_" as this 
				prefix is used by the SQL Server "master" database.<br />
				<br />
                Enter Stored Procedure Names Below:<br />
                <table>
                    <tr>
                        <td style="width: 67px">
                            Insert:</td>
                        <td style="width: 434px">
                            <asp:TextBox ID="txtProcAdd" runat="server">p_customer_insert</asp:TextBox>
                            <asp:Button ID="btnCreateStoredProcNames" runat="server" Font-Size="Smaller" OnClick="btnCreateStoredProcNames_Click"
                                Text="Create Stored Proc Names" /></td>
                    </tr>
                    <tr>
                        <td style="width: 67px; height: 18px">
                            Delete:</td>
                        <td style="width: 434px; height: 18px">
                            <asp:TextBox ID="txtProcDelete" runat="server">p_customer_delete</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 67px; height: 23px">
                            Select:</td>
                        <td style="width: 434px; height: 23px">
                            <asp:TextBox ID="txtProcRetrieve" runat="server">p_customer_select</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 67px">
                            Update:</td>
                        <td style="width: 434px">
                            <asp:TextBox ID="txtProcUpdate" runat="server">p_customer_update</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 67px">
                        </td>
                        <td style="width: 434px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 67px">
                            Grant Access To:</td>
                        <td style="width: 434px">
                            <asp:TextBox ID="txtProcLoginName" runat="server">web_user</asp:TextBox></td>
                    </tr>
                </table>
                <br />
				<br />
				Click the button below to generate the layers.
				<p>				
				<asp:button id="btnCreate" runat="server" Text="Create N-Tier Layers Now" onclick="btnCreate_Click"></asp:button><br />
		        </p>

</asp:Content>

