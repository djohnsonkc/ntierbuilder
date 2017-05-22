<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Data.aspx.cs" ValidateRequest="False" Inherits="Data" Title="NTierBuilder - Data Access Layer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">

			<h1><img src="images/data.gif" width="32" height="32"> Data Access Layer (Stored Procedures & Data Adapter)
			Stored Procedures</h1>			
			<p>
			View <a href="samples/StoredProcedures.sql.txt" target="_blank">sample stored procedures</a>
			<br />
			<br />
			Below are the stored procedures that will be used to Insert, Delete, Update, 
			and Retrieve data from your database. You can modify the Retrieval procedure to 
			support multiple retrieval parameters.<br />
			
	
			To add these procedures to your database, open Query Analyzer, paste the 
			content below and click on the "Run" menu option.<br />
			<br />
			<asp:textbox id="txtSQLScript" runat="server" Rows="25" TextMode="MultiLine" 
				Width="700px" Height="232px" CssClass="input" ForeColor="Blue">To view the Data Access Layer, please open &quot;Start&quot; and paste in the required query output and provide the requested information on the 'Setup' page.</asp:textbox><br />

	</p>
	
	<p>	
	<br />
	<FONT size="4">Grant Execute Statements (for the procs named above)</font>
	
				<asp:textbox id="txtGrantExecuteSQL" runat="server" Rows="5" TextMode="MultiLine" 
				Width="700px" Height="75px" CssClass="input" ForeColor="Blue"></asp:textbox><br />
	
	</p>
    
    <p>
    
    <br />
    
    <FONT size="4">Data Adapter</font>
    <br />
    <br />
    Below is the C# code for the classes that will provide the data adapter for your domain
    object. Please note below that a base class is used to create a more simple
    implementation for multiple adapter classes. The base class contains most of the
    logic for accessing your database and acts as a type of facade for your other data
    adapters. Your various adapter classes should all inherit from this base class.
    <br />
    <br />
    You should include these in a separate data project/assembly (e.g. Sales.Data).<br />
    <br />
    Base Adapter (used by all of your adapter objects)<br />
    <br />
    <asp:TextBox ID="txtBaseAdapter" runat="server" CssClass="input" 
        ForeColor="Blue" Height="150px" Rows="25" TextMode="MultiLine" Width="700px">To view the Data Access Layer, please open &quot;Start&quot; and paste in the required query output and provide the requested information on the 'Setup' page.</asp:TextBox><br />
    <br />
    Data Adapter for this object (inherits BaseAdapter).<br /><br />
    <asp:TextBox ID="txtDataAdapter" runat="server" CssClass="input" ForeColor="Blue"
        Height="150px" Rows="25" TextMode="MultiLine" Width="700px">To view the Data Access Layer, please open &quot;Start&quot; and paste in the required query output and provide the requested information on the 'Setup' page.</asp:TextBox><br />
			<br />
			<asp:Button id="btnContinue" runat="server" Text="Continue to Presentation Layer >>>" onclick="btnContinue_Click"></asp:Button>
			<br />
			<br />
			<br />
    </p>

</asp:Content>

