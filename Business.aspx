<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Business.aspx.cs" Inherits="Business" Title="NTierBuilder - Domain Objects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
			<h1><img src="/images/business.gif" width="32" height="32"> Business/Domain Layer (Custom Object Classes)</h1> 
			View <a href="/samples/Customer.cs.txt" target="_blank">
				sample object class</a>&nbsp;
			<p>
			Below is the .NET object Class that will be used by your data and presentation layers.
    This object class contains constructors, 
			private &amp; public properties and methods&nbsp;which can contain 
			your&nbsp;business rules.<br />
			<br />
			Note: When the C# code is pasted into your Visual Studio class file, the text 
			will be properly indented an aligned.<br />
			<br />
			In Visual Studioi.NET, create a new C# class with a file name of
			<asp:Label id="LabelBusinessLayerClassName" runat="server" Font-Bold="True"></asp:Label>&nbsp;and 
			paste the following content into it.<br />
			<asp:textbox id="txtNetCode" runat="server" Rows="25" TextMode="MultiLine" 
				Width="100%" CssClass="input" ForeColor="Blue">To view the Data Access Layer, please open &quot;Start&quot; and paste in the required query output and provide the requested information on the 'Setup' page.</asp:textbox><br />
			<br />
			<br />
			<asp:Button id="btnContinue" runat="server" Text="Continue to Data Access Layer  >>>" onclick="btnContinue_Click"></asp:Button>

			</p>

</asp:Content>

