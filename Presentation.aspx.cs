using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class Presentation : System.Web.UI.Page
{

    #region Logic for This Page

    NTierBuilder.Domain.Project proj;

    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Session["Project"] == null)
        //    Session["Project"] = NTierBuilder.Domain.Project.BuildSampleProject();

        //add event handler for menu and it's items
        TabMenuControl1.BubbleEvent += new EventHandler(tabChanged);
        TabMenuControl1.Menu.AddItem("Object Properties", "Object Properties", "");
        TabMenuControl1.Menu.AddItem("List Form", "List Form Layout and Code Behind", "");
        TabMenuControl1.Menu.AddItem("Edit Form", "Edit Form Layout and Code Behind", "");
        TabMenuControl1.Menu.AddItem("View Form", "View Form Layout and Code Behind", "");
        TabMenuControl1.Menu.AddItem("CSS", "CSS Attributes", "");
        TabMenuControl1.Menu.AddItem("GridView Pagination", "GridView Pagination", "");
        TabMenuControl1.ObjectID = 1;


        this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);


        if (Session["Project"] == null)
        {
            proj = new NTierBuilder.Domain.Project();
            proj.Name_Space = "";
        }
        else
        {
            proj = (NTierBuilder.Domain.Project)Session["Project"];
        }

        if (!IsPostBack)
        {
            txtFormClassPreface.Text = NTierBuilder.Domain.Utils.GetCookie("FormClassPreface");

            if (proj.Name_Space == "")
            {
                btnCreateWebForm.Enabled = false;
                DataGrid1.Visible = false;
                LabelMessage.Visible = true;
            }
            else
            {
                LabelMessage.Visible = false;
                btnCreateWebForm.Enabled = true;
                DataGrid1.Visible = true;
                bindGrid(proj.Table);
            }
        }
        else
        {
            //if ddlFormObjectType AutoPostBack occurs
            rebuildTable();
            refreshGrid(proj.Table);

            Session["Project"] = proj;

        }
    }


    //event handler for TabMenuControl events
    private void tabChanged(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = TabMenuControl1.SelectedTabIndex;
    }

    protected void btnCreateWebForm_Click(object sender, System.EventArgs e)
    {
        buildAll();
    }

    private void buildAll()
    {
        proj.FormClassPreface = txtFormClassPreface.Text;
        NTierBuilder.Domain.Utils.SetCookie("FormClassPreface", txtFormClassPreface.Text);

        if (cbEditableGridView.Checked)
            proj.EditableGridView = true;
        else
            proj.EditableGridView = false;

        buildEditHTML(proj);
        buildEditCode(proj);

        buildViewHTML(proj);
        buildViewCode(proj);

        buildListHTML(proj);
        buildListCode(proj);
    }

    private void bindGrid(NTierBuilder.Domain.Table table)
    {
        DataGrid1.DataSource = table.Columns;
        DataGrid1.DataBind();

        refreshGrid(table);
        Session["Project"] = proj;

    }

    private void refreshGrid(NTierBuilder.Domain.Table table)
    {

        DropDownList ddlFormObjectType = new DropDownList();
        TextBox txtBoundListObject = new TextBox();
        TextBox txtDataValueField = new TextBox();
        TextBox txtDataTextField = new TextBox();
        TextBox txtListValues = new TextBox();
        CheckBox cbRequiredField = new CheckBox();
        Panel PanelDropDownListSettings = new Panel();
        string type = "";
        string primaryKey = "";

        //loop through items and pre-set some attributes
        for (int i = 0; i < DataGrid1.Items.Count; i++)
        {
            primaryKey = DataGrid1.Items[i].Cells[3].Text;
            type = DataGrid1.Items[i].Cells[1].Text;
            ddlFormObjectType = (DropDownList)DataGrid1.Items[i].Cells[4].FindControl("ddlFormObjectType");

            PanelDropDownListSettings = (Panel)DataGrid1.Items[i].Cells[4].FindControl("PanelDropDownListSettings");
            txtBoundListObject = (TextBox)DataGrid1.Items[i].Cells[4].FindControl("txtBoundListObject");
            txtDataValueField = (TextBox)DataGrid1.Items[i].Cells[4].FindControl("txtDataValueField");
            txtDataTextField = (TextBox)DataGrid1.Items[i].Cells[4].FindControl("txtDataTextField");
            txtListValues = (TextBox)DataGrid1.Items[i].Cells[4].FindControl("txtListValues");
            cbRequiredField = (CheckBox)DataGrid1.Items[i].Cells[5].FindControl("cbRequiredField");

            
            NTierBuilder.Domain.TableColumn col = (NTierBuilder.Domain.TableColumn)table.Columns[i];

            //update project
            if(txtListValues != null)
                col.ListValues = txtListValues.Text;

            //update project
            col.IsRequiredField = cbRequiredField.Checked;
            col.Bound_List_Object = txtBoundListObject.Text;
            col.Data_Text_Field = txtDataTextField.Text;
            col.Data_Value_Field = txtDataValueField.Text;

            for (int k = 0; k < ddlFormObjectType.Items.Count; k++)
            {
                if (ddlFormObjectType.Items[k].Value == col.Form_Object_Type)
                    ddlFormObjectType.SelectedIndex = k;
            }


            //if bit field, then default to checkbox
            if (type == "bit")
            {
                for (int k = 0; k < ddlFormObjectType.Items.Count; k++)
                {
                    if (ddlFormObjectType.Items[k].Value == "CheckBox")
                        ddlFormObjectType.SelectedIndex = k;
                }
            }


            //if primary Key field, then default to Label since usually system-assigned
            if (primaryKey == "1") 
            {
                for (int k = 0; k < ddlFormObjectType.Items.Count; k++)
                {
                    if (ddlFormObjectType.Items[k].Value == "Label")
                        ddlFormObjectType.SelectedIndex = k;
                }
            }

            if (ddlFormObjectType.SelectedItem.Value == "DropDownList")
            {
                PanelDropDownListSettings.Visible = true;
            }
            else
            {
                PanelDropDownListSettings.Visible = false;
            }
        }


    }


    private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
    {

    }

    public void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        // be sure to add these commands to private void InitializeComponent()
        // this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
        // this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

        // ignore header and footer items
        if ((e.Item.ItemType == ListItemType.Header) || (e.Item.ItemType == ListItemType.Footer))
            return;
        // add client-side script to last column
        //LinkButton btnDel = (LinkButton)e.Item.Cells[9].Controls[0];
        //btnDel.Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this entry?')");

    }



    private NTierBuilder.Domain.Table rebuildTable()
    {
        string colName;
        DropDownList ddlFormObjectType;
        //TextBox txtBoundListObject;

        proj = (NTierBuilder.Domain.Project)Session["Project"];

        //loop through items and pre-set some attributes
        for (int i = 0; i < DataGrid1.Items.Count; i++)
        {
            colName = DataGrid1.Items[i].Cells[0].Text;
            ddlFormObjectType = (DropDownList)DataGrid1.Items[i].Cells[4].FindControl("ddlFormObjectType");

            //test object
            //txtBoundListObject = (TextBox)DataGrid1.Items[i].Cells[4].FindControl("Textbox1");

            foreach (NTierBuilder.Domain.TableColumn col in proj.Table.Columns)
            {

                if (col.Name == colName)
                {
                    col.Form_Object_Type = ddlFormObjectType.SelectedItem.Value;

                    if (col.Form_Object_Type == "TextBox")
                        col.Form_Object_Prefix = "txt";
                    else if (col.Form_Object_Type == "CheckBox")
                        col.Form_Object_Prefix = "cb";
                    else if (col.Form_Object_Type == "DropDownList")
                        col.Form_Object_Prefix = "ddl";
                    else
                        col.Form_Object_Prefix = "txt";

                }

            }

        }

        return proj.Table;

    }


    #endregion


    #region Edit Form and Code Builder Section


    private void buildEditHTML(NTierBuilder.Domain.Project proj)
    {
        NTierBuilder.Domain.FormBuilderMethods da = new NTierBuilder.Domain.FormBuilderMethods();
        string htmlString = da.GetEditFormHtml(proj, Server.MapPath("\\templates\\WebForms"));
        
        htmlString = Server.HtmlEncode(htmlString.ToString());
        htmlString = htmlString.Replace("\r\n", "<br />");

        lblFormHTML.Text = htmlString;
    }

    private void buildEditCode(NTierBuilder.Domain.Project proj)
    {
        NTierBuilder.Domain.FormBuilderMethods da = new NTierBuilder.Domain.FormBuilderMethods();
        lblFormHTMLCode.Text = da.GetEditFormCode(proj, Server.MapPath("\\templates\\WebForms")).Replace("\r\n", "<br />");
    }


    #endregion


    #region View Form and Code Builder Section


    private void buildViewHTML(NTierBuilder.Domain.Project proj)
    {

        NTierBuilder.Domain.FormBuilderMethods da = new NTierBuilder.Domain.FormBuilderMethods();
        string htmlString = da.GetViewFormHtml(proj, Server.MapPath("\\templates\\WebForms"));

        htmlString = Server.HtmlEncode(htmlString.ToString());
        htmlString = htmlString.Replace("\r\n", "<br />");

        lblFormViewHTML.Text = htmlString;


    }

    private void buildViewCode(NTierBuilder.Domain.Project proj)
    {
        NTierBuilder.Domain.FormBuilderMethods da = new NTierBuilder.Domain.FormBuilderMethods();
        lblFormViewHTMLCode.Text = da.GetViewFormCode(proj, Server.MapPath("\\templates\\WebForms")).Replace("\r\n", "<br />");
    }

    #endregion


    #region List Form and Code Builder Section


    private void buildListHTML(NTierBuilder.Domain.Project proj)
    {
        NTierBuilder.Domain.FormBuilderMethods da = new NTierBuilder.Domain.FormBuilderMethods();
        string htmlString = da.GetListFormHtml(proj, Server.MapPath("\\templates\\WebForms"));

        htmlString = Server.HtmlEncode(htmlString.ToString());
        htmlString = htmlString.Replace("\r\n", "<br />");
        lblFormListHTML.Text = htmlString;

    }


    private void buildListCode(NTierBuilder.Domain.Project proj)
    {
        NTierBuilder.Domain.FormBuilderMethods da = new NTierBuilder.Domain.FormBuilderMethods();
        lblFormListHTMLCode.Text = da.GetListFormCode(proj, Server.MapPath("\\templates\\WebForms")).Replace("\r\n", "<br />");
    }

    #endregion


    protected void cbEditableGridView_CheckedChanged(object sender, EventArgs e)
    {
        buildAll();
    }
}
