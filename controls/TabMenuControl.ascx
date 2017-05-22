<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TabMenuControl.ascx.cs" Inherits="TabMenuControl" %>

<style type="text/css"> 

.tabStrip {
    /*border-bottom: 4px solid #b9b9b9;*/
    padding-right: 10px; /*extends bottom border */
}

.directoryLinks {
    /*padding-bottom:-5px;*/
}

.directoryLinks a {
    font-family:Verdana, Tahoma, Arial, Helvetica, sans-serif;
    font-size:<%= TabFontSize %>px;
    font-weight: bold;
    text-decoration:none;
    border:1px solid #b9b9b9;
    padding:7px 7px;
    margin: 0 2px 0 0;
    background-color:#e9e9e9;
    color:#5B5B5B;
}

.directoryLinks a:hover {
    text-decoration:none;
    background-color:#95B3DE;
    /*color:#95B3DE;*/
    padding-top: 10px;
    /*font-size:12px;*/
}

.currentDescription {
    background-color:#15487C;
    color:#ffffff;
    padding:5px 0 5px 10px;
    font-size:12px;
    font-weight:bold;
}

/* referenced in code-behind */
.directoryLinks .selected {
    background-color:#b9b9b9;
    color:#15487C;
    font-weight:bold;
}
.directoryLinks .default {
    background-color:#e9e9e9;
    color:#15487C;
}


</style>

<table cellpadding="3" cellspacing="0">
    <tr>
        <td class="directoryLinks" style="padding:9px 4px 4px 0;border-bottom:1px solid #b9b9b9;">
            <asp:PlaceHolder ID="plcHolder" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
</table>

<asp:Panel ID="Panel1" runat="server" Visible="False">
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td class="currentDescription">
            <asp:Literal ID="litDescription" runat="server">Main</asp:Literal></td>
    </tr>
</table>
</asp:Panel>

