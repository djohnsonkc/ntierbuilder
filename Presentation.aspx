<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Presentation.aspx.cs" Inherits="Presentation" Title="NTierBuilder - Presentation Layer"
    MaintainScrollPositionOnPostback="True" %>

<%@ Register Src="~/controls/TabMenuControl.ascx" TagName="TabMenuControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="Server">

<style type="text/css">

pre {background-color: #e9e9e9;}

</style>

    <h1>
        <img src="images/presentation.gif" width="32" height="32">
        Presentation Layer (.aspx pages and C# code-behind)
    </h1>
    <asp:Label ID="LabelMessage" runat="server" Font-Bold="True" Visible="False" ForeColor="Red"><br />To view the Presentation Layer, please open <a href="start.aspx">
					Start</a> to paste in your query output and provide the requested information on the 'Setup' page.<br /></asp:Label>
    <br />
    After specifying the Form Object types below, click the "Create Presentation Layer"
    button to create the HTML and C# code-behind for pages that will <strong><a href="samples/edit.jpg"
        target="_blank">Add</a>, <a href="samples/edit.jpg" target="_blank">Update</a>,
        <a href="samples/view.jpg" target="_blank">Delete</a>, <a href="samples/view.jpg"
            target="_blank">View</a>, and <a href="samples/list.jpg" target="_blank">List</a></strong>
    your data (click links for sample screen-shot).
    <br />
    <br />
    <uc1:TabMenuControl ID="TabMenuControl1" runat="server" ShowDescripton="True" TabFontSize="11" />
    <br />
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <br />
            <table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
                <tr>
                    <td>
                        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="3">
                            <AlternatingItemStyle BackColor="#E6E6E6"></AlternatingItemStyle>
                            <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="tableHeader" BackColor="#E6E6E6">
                            </HeaderStyle>
                            <Columns>
                                <asp:BoundColumn DataField="PublicName" HeaderText="Public Name"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Type" HeaderText="Type"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Length" HeaderText="Length"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Stat" HeaderText="Primary Key"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Form Object">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlFormObjectType" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="TextBox">TextBox</asp:ListItem>
                                            <asp:ListItem Value="TextBoxMultiLine">TextBox MultiLine</asp:ListItem>
                                            <asp:ListItem Value="DropDownList">DropDownList</asp:ListItem>
                                            <asp:ListItem Value="CheckBox">CheckBox</asp:ListItem>
                                            <asp:ListItem Value="Label">Label</asp:ListItem>
                                        </asp:DropDownList><br />
                                        <asp:Panel ID="PanelDropDownListSettings" runat="server">
                                            <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="1">
                                                <tr bgcolor="DarkGray">
                                                    <td colspan="2">
                                                        For DropDownList form objects, use the following settings to build the control and
                                                        business logic to populate and use the dropdown.</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Object Collection (e.g. SalesRepCollection):</td>
                                                    <td>
                                                        <asp:TextBox ID="txtBoundListObject" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Bound_List_Object") %>'>
                                                        </asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Data Text Field (e.g. SalesRepName):</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDataTextField" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Data_Text_Field") %>'>
                                                        </asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Data Value Field (e.g. SalesRepID):</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDataValueField" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Data_Value_Field") %>'>
                                                        </asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#ffff99">
                                                        Or, enter a hard-coded, comma-separated list of name/value pairs (e.g. High/1, Medium/2,
                                                        Low/3):</td>
                                                    <td bgcolor="#ffff99">
                                                        <asp:TextBox ID="txtListValues" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ListValues") %>'>
                                                        </asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Required?">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbRequiredField" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </td>
                </tr>
                <tr>
                    <td>
                        Note: If using a <strong>DropDownList </strong>form object, you can specifiy a user-defined&nbsp;object
                        collection (e.g. SalesRepCollection) that will be used for populating your DropDownList,
                        or you can enter a hard-coded, comma-separated list of values. If using an object
                        collection, you'll also need to specify the Data Text Field (e.g. SalesRepName)
                        and Data Value Field (e.g. SalesRepID) to be used by the DropDownList.<br />
                        
                        <br />
                        Partial Class Preface for Web Forms:
                        <br />
                        <asp:TextBox ID="txtFormClassPreface" runat="server" Width="256px"></asp:TextBox>
                        ( e.g. admin_customer_ )<br />
                        <br />
                        <asp:Button ID="btnCreateWebForm" runat="server" Text="Create Presentation Layer"
                            Enabled="False" OnClick="btnCreateWebForm_Click"></asp:Button>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
        </asp:View>
        <asp:View ID="View2" runat="server">
        

        
        <p style="padding: 4px 4px 4px 4px; border: solid 1px #cc6699;">

            Use the link below to download the GenericSorter class. This class is used for generic GridView sorting. Save this to your App_Code directory with a .cs extension (e.g. GenericSorter.cs).
            
            <br />    
			<a href='/templates/sorter/GenericSorter.txt' target='_blank'>Download GenericSorter class</a>
            <br />
            <br />

            Use the link below to download the GridViewPagination class. This class is used for adding pagination to your GridView.
            
            <br />    
			<a href='/templates/pagination/GridViewPagination.txt' target='_blank'>Download GridViewPagination class</a>
            <br />
            <br />
            
            Use the following images for your pagination links in the List.aspx page:
			<br />
			<img src='/images/pagination_first.gif' />&nbsp;<img src='/images/pagination_prev.gif' />&nbsp;<img src='/images/pagination_next.gif' />&nbsp;<img src='/images/pagination_last.gif' />
            <br />
			<a href='/artwork/pagination.png'>Click here to download pagination.png to edit your own buttons in Fireworks</a>&nbsp;(right-click & select Save Target As)
			<br />
			<br />


			Use the following images for your Edit and Delete links in the List.aspx page:
			<br />
			<img src='/images/edit.gif' />&nbsp;<img src='/images/delete.gif' />&nbsp;<img src='/images/update.gif' />&nbsp;<img src='/images/cancel.gif' />
			<br />
			<a href='/artwork/buttons.png'>Click here to download buttons.png to edit your own buttons in Fireworks</a>&nbsp;(right-click & select Save Target As)
			
        </p>
        
            <asp:CheckBox ID="cbEditableGridView" runat="server" AutoPostBack="True" OnCheckedChanged="cbEditableGridView_CheckedChanged"
                Text="Create an Editable GridView" /><br />
            <table>
                <tr>
                    <td>
                        <h2>List.aspx Form HTML (Paste this HTML in the Form section of your Web page):</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                    <pre>
                        <asp:Label ID="lblFormListHTML" runat="server" ForeColor="#0000C0">Click "Create Presentation Layer" to create this section</asp:Label>
                        </pre>
                        </td>
                    
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h2>List.aspx.cs Code Behind:</h2>
                    </td>
                </tr>
                <tr>
                    <td
                    <pre>
                        <asp:Label ID="lblFormListHTMLCode" runat="server" ForeColor="#0000C0">Click "Create Presentation Layer" to create this section</asp:Label>
                        </pre>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <table>
                <tr>
                    <td>
                        
                        <h2>Edit.aspx Form HTML (Paste this HTML in the Form section of your Web page):</h2></td>
                </tr>
                <tr>
                    <td>
                        <pre>
                        <asp:Label ID="lblFormHTML" runat="server" ForeColor="#0000C0">Click "Create Presentation Layer" to create this section</asp:Label>
                        </pre>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h2>Edit.aspx.cs Code Behind:</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                    <pre>
                        <asp:Label ID="lblFormHTMLCode" runat="server" ForeColor="#0000C0">Click "Create Presentation Layer" to create this section</asp:Label><asp:Label
                            ID="lblFormUpdateCode" runat="server" ForeColor="#0000C0" Font-Size="Smaller"></asp:Label>
                            </pre>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View4" runat="server">
            <table>
                <tr>
                    <td>
                        <h2>View.aspx Form HTML (Paste this HTML in the Form section of your Web page):</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                    <pre>
                        <asp:Label ID="lblFormViewHTML" runat="server" ForeColor="#0000C0">Click "Create Presentation Layer" to create this section</asp:Label>
                        </pre>
                        </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h2>View.aspx.cs Code Behind:</h2>
                    </td>
                </tr>
                <tr>
                    <td>
                    <pre>
                        <asp:Label ID="lblFormViewHTMLCode" runat="server" ForeColor="#0000C0">Click "Create Presentation Layer" to create this section</asp:Label>
                    </pre>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View5" runat="server">
            <p>
                Use the following classes in your css to create easy style control for your GridView
                list - including alternate row background shading.</p>
            <p>
                &lt;asp:GridView id="GridView1" runat="server" AutoGenerateColumns="False" CssClass="cTable"&gt;
                &lt;AlternatingRowStyle CssClass="cTableAltRow" /&gt;
            </p>
            <p>
            </p>
            <pre>/* Custom Table */
table.cTable {
    border:none;
    border-color: #eeeeee; /* Firefox - border:none doesn't work, so set color same as body */    
}
table.cTable th {
    border:none;
    background-color:#8f8f8f;
    padding:4px 4px 4px 4px;
    color:#eeeeee;  
    text-align:left; 
    vertical-align:top;            
}
table.cTable td {
    /*color:#675949;*/
    border: solid 1px #f4f4f4;
    text-align:left;
    vertical-align:top;
    overflow: auto; 
    padding:4px 4px 4px 4px;
}
.cTableAltRow td {
    background-color:#f8f8f8;
}

.cTableBgcCell{
    background-color:#ffffff;
    /*padding:2px 10px 3px 5px;*/
    vertical-align:top;
    border: solid 1px #ffffff;
}
</pre>
        </asp:View>
    </asp:MultiView>
</asp:Content>
