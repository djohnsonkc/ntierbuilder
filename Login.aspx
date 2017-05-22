<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeFile="Login.aspx.cs" Inherits="Login" Title="Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">


<h1>Please enter your login information below.</h1>

<p>
    <br />
    Need a login? Contact info@inspiredeffect.com
    <br />

    <br />

                <strong>User Name:<br />
                </strong>
    <asp:TextBox ID="txtEmail" runat="server" Width="200px" CssClass="text"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
        Display="Dynamic" ErrorMessage="Email required"></asp:RequiredFieldValidator><br />
</p>
<p>
    <strong>Password:</strong><br />
    <asp:TextBox ID="txtPassword" runat="server" Width="200px" CssClass="text" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
        Display="Dynamic" ErrorMessage="Password required"></asp:RequiredFieldValidator><br />
    <br />
    <asp:Button CssClass="text" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Login" />
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" Font-Bold="False" ForeColor="Blue"></asp:Label></p>

    <br />

    <br />
    <p>

    </p>
</asp:Content>

