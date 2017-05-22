<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Start.aspx.cs" Inherits="Start" Title="NTierBuilder - Start" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">

			<h1><img src="images/start.gif" width="32" height="32"> Start - As easy as cut &amp; paste!</h1>
			<asp:Label id="LabelMessage" runat="server" ForeColor="Red" Font-Bold="True" Visible="False"></asp:Label>
			<br />
			To get started, run the following query&nbsp;in Query Analyzer (change table 
			name) to create the&nbsp;input needed by N-Tier Builder. After running the 
			query, paste the query results below and click on "Continue to Setup" to build 
			your layers.
			<br />
			<br />
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="90%" border="0">
				<TR>
					<TD style="WIDTH: 314px" bgColor="#e6e6e6" vAlign="top"><FONT size="1"> DECLARE 
							@TableName varchar(50)<br />
							SET @TableName = '&lt;Enter Name Here&gt;'<br />
							<br />
							select
							<br />
							c.name + ',' As ColumnName,
							<br />
							st.name + ',' As TypeName,
							<br />
							IsNull(CAST(c.Prec as varchar(5)), '4000') + ',' As Length, 
							<br />
							c.ColStat
							<br />
							<br />
							from syscolumns c,
							<br />
							sysobjects o,
							<br />
							systypes st
							<br />
							<br />
							where
							<br />
							c.id = o.id AND
							<br />
							c.xtype = st.xtype AND
							<br />
							o.Name = @TableName AND<br />
							NOT st.Name = 'sysname'<br />
							<br />
							order by o.name, c.colorder</FONT>
					</TD>
					<TD style="WIDTH: 26px" vAlign="top"></TD>
					<TD vAlign="top">
						<SPAN class="style1"><FONT color="#000000"><FONT size="4"><FONT size="2">Query Analyzer Output:</FONT>
									<br />
								</FONT>
								<br />
								<FONT size="1">Here's a sample of what the data returned by Query Analyzer should 
									look like. Copy the results to your clipboard by right-clicking a cell of the 
									query results and clicking "Select All". Right-click again and select "Copy".</FONT>
							</FONT>
							<br />
							<br />
							<img src="images/query_results.gif" width="291" height="138">&nbsp;<SPAN class="style1"><FONT color="#000000"><FONT size="4"><FONT size="2"></FONT></FONT></FONT></SPAN>
						</SPAN>
					</TD>
				</TR>
			</TABLE>
			<br />
			<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="700" border="0">
				<TR>
					<TD valign="top" style="WIDTH: 689px"><FONT size="4">Paste Query Results Below:
							</FONT><br />
						<asp:textbox id="txtColumns" runat="server" Width="90%" TextMode="MultiLine"
							ForeColor="Blue" Rows="12" CssClass="input" Height="144px"></asp:textbox></TD>
					<TD vAlign="top"></TD>
				</TR>
			</TABLE>
			<br />
			After copying your query results to the clipboard, click the button below. On 
			the next page, you can paste the query output as input for N-Tier Builder.<br />
			<br />
			<br />
			<p>
			<asp:Button id="btnStart" runat="server" Text="Continue to Setup >>>" onclick="btnStart_Click"></asp:Button><br />
			</p>
			<br />

</asp:Content>

