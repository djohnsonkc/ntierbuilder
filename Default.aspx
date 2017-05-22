<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="NTierBuilder - Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
<h1>Welcome to N-Tier Builder for&nbsp;ASP.NET, C#, and Microsoft SQL Server</h1>

			<table width="100%" height="178" border="0" cellpadding="3" cellspacing="0">
				<tr>
					<td>
						N-Tier Builder is an object persistence code generator that uses an existing SQL Server table schema to 
						generate a domain object, data access layer and presentation layer for a specified table.  
						<br />
						<br />
						<br />
							
						<table height="147" border="0" cellpadding="4" cellspacing="0" style="width: 622px">
							<tr>
								<td valign="top" style="width: 516px">All from this simple input! ---&gt;<br />
										<br />
									(Sample of common "Customers" table)
                                </td>
								<td valign="top" style="width: 319px"><span class="style3">CustomerID, int, 4, 1<br />
										Name, varchar, 50, 0<br />
										Address, varchar, 50, 0<br />
										City, varchar, 50, 0<br />
										State, varchar, 50, 0<br />
										Zip, varchar, 50, 0<br />
										Active, bit, 1, 0<br />
										DateCreated, datetime, 8, 0</span></td>
                                <td valign="top" style="width: 225px">
                                    <a href="start.aspx"><img src="images/start.gif" width="32" height="32" border="0"></a><strong> Start Now!</strong></td>
							</tr>
						</table>
					</td>
				</tr>
                <tr>
                    <td valign="top">
                        <img src="images/business.gif" width="32" height="32" border="0">
						<strong>Domain Object<br />
                        </strong>
                        <br />
                        N-Tier Builder creates C# code for your <strong>object class</strong> (e.g. Customer.cs) with  
						a constructor and declares all of it's private properties as well as setters and 
						getters for it's public properties. 
						(<a href="/samples/Customer.cs.txt" target="_blank">see example</a>)
					</td>
                </tr>
                <tr>
                    <td valign="top">&nbsp;
                        </td>
                </tr>
                <tr>
                    <td valign="top">
                        <img src="images/data.gif" width="32" height="32" border="0">
						<strong> Data Access Layer</strong>
                        <br />
                        <br />
                        N-Tier Builder creates SQL Server <strong>stored procedures</strong> for 
						inserting, updating, deleting, and retrieving records in your database. 
						The connection to the Data Access Layer is controlled by your Web.config or Machine.config 
						connection setting. 
						(<a href="/samples/StoredProcedures.sql.txt" target="_blank">see example</a>)
						<br /><br />
						
						N-Tier Builder also creates <strong>"adapters"</strong> to load your data into your Domain Object. 
						(<a href="/samples/CustomerAdapter.cs.txt" target="_blank">see example</a>)<br /><br />
						
						N-Tier Builder provides a "base adapter" that all adapters can inherit from 
						and contain most of the actual code for accessing your database. 
						(<a href="/samples/BaseAdapter.txt" target="_blank">see example</a>)<br /><br />
						
					</td>
                </tr>
                
                <tr>
                    <td valign="top">
                        <img src="images/presentation.gif" width="32" height="32" border="0">
						<strong>Presentation Layer</strong>
                        <br />
                        <br />					
						N-Tier Builder creates ASP.NET Web Form <strong>HTML and C# code</strong> for viewing, 
						adding, editing, and removing objects/records via calls to objects in the 
						Data Access Layer. The code-behind for the Web Forms will instantiate objects 
						and call public methods from the Data Access Layer. <br />
						
						(see examples: 
						<a href="/samples/list.jpg" target="_blank">List.aspx</a>
						<a href="/samples/list.aspx.cs.txt" target="_blank">List.cs</a>
						<a href="/samples/view.jpg" target="_blank">View.aspx</a>
						<a href="/samples/view.aspx.cs.txt" target="_blank">View.cs</a>
						<a href="/samples/edit.jpg" target="_blank">Edit.aspx</a>
						<a href="/samples/edit.aspx.cs.txt" target="_blank">Edit.cs</a>						
						)
						</td>
                </tr>
			</table>


</asp:Content>

