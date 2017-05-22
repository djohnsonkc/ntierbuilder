using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Drawing;

/******************* Menu Item ********************/
public class MenuItem
{
    public string Text, Description, NavigateUrl, Roles;
    public bool Enabled;
    public MenuItem(string tabText, string description, string tabNavigateUrl, string roles, bool enabled)
    {
        this.Text = tabText;
        this.Description = description;
        this.NavigateUrl = tabNavigateUrl;
        this.Roles = roles;
        this.Enabled = enabled;
    }

}
/****************** Collection of Menu Items **********/
public class Menu
{
    public List<MenuItem> Items = new List<MenuItem>();
    public Menu()
    {
    }
    public void AddItem(string tabText, string roles)
    {
        MenuItem item = new MenuItem(tabText, tabText, "", roles, true);
        Items.Add(item);
    }
    public void AddItem(string tabText, string description, string roles)
    {
        bool allowed = true;
        
        //if no roles specified, allow tab access
        //if (roles == "" || UserSession.UserInAtLeastOneRole(roles))
        //     allowed = true;

        MenuItem item = new MenuItem(tabText, description, "", roles, allowed);
        Items.Add(item);
    }
    /*
    public void AddItem(string tabText, string description, string roles, bool enabled)
    {
        MenuItem item = new MenuItem(tabText, description, "", roles, enabled);
        Items.Add(item);
    }
    */
}

public partial class TabMenuControl : System.Web.UI.UserControl
{

    #region Properties 

    public Menu Menu = new Menu();

    private Int64 object_id = 0;
    private int selected_tab_index = 0;
    private string selected_tab_text;
    private bool show_description;
    private string tab_font_size = "10";

    public Int64 ObjectID
    {
        set { object_id = value; }
        get { return object_id; }
    }
    public int SelectedTabIndex
    {
        set { selected_tab_index = value; }
        get { return selected_tab_index; }
    }
    public string SelectedTabText
    {
        set { selected_tab_text = value; }
        get { return selected_tab_text; }
    }
    public bool ShowDescripton
    {
        set { show_description = value; }
        get { return show_description; }
    }
    public string TabFontSize
    {
        set { tab_font_size = value; }
        get { return tab_font_size; }
    }

    #endregion


    //Bubble Event To Parent Page
    public event EventHandler BubbleEvent;
    protected void OnBubbleEvent(EventArgs e)
    {
        if (BubbleEvent != null)
        {
            BubbleEvent(this, e);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        loadTabStrip();

        if (!IsPostBack)
        {
            int tab_ndx = int.Parse(QueryString.Value("tab", "0"));
            DefaultTab(tab_ndx);

            MultiView mv = (MultiView)Parent.FindControl("MultiView1");
            if (mv != null)
                mv.ActiveViewIndex = tab_ndx;

        }

        if (this.show_description)
            Panel1.Visible = true;

    }

    public string GetFontSize()
    {
        return "8px;";
    }

    public void DefaultTab(int index)
    {
        int ctr = 0;

        //find the description for this tab item
        MenuItem item = (MenuItem)this.Menu.Items[index];
        litDescription.Text = item.Description;
        
        foreach (LinkButton lb in plcHolder.Controls)
        {
            if (ctr == index)
            {
                lb.CssClass = "selected";               
                return;
            }
            ctr++;
        }
    }


    private void loadTabStrip()
    {
        this.selected_tab_index = 0;
        int ndx = 0;
        foreach(MenuItem item in this.Menu.Items)
        {
            LinkButton linkButton = new LinkButton();
            linkButton.Text = item.Text; 
            linkButton.CommandArgument = ndx.ToString();  //store for #id
            linkButton.ToolTip = item.Text;
            linkButton.PostBackUrl = item.NavigateUrl;
            linkButton.CausesValidation = false;

            //if adding new object, default to Tab1 and disable other tabs
            if (item.Enabled == false || (ndx > 0 && this.object_id == 0))
            {
                linkButton.Enabled = false;
            }

            linkButton.Click += new System.EventHandler(AlphaTabClick);

            plcHolder.Controls.Add(linkButton);

            ndx++;
        }
    }

    private void AlphaTabClick(object sender, System.EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;

        this.selected_tab_index = int.Parse(lb.CommandArgument);
        this.selected_tab_text = lb.Text;

        resetAlphaTabs();

        lb.CssClass = "selected"; 

        //find the description for this tab item
        foreach (MenuItem item in this.Menu.Items)
        {
            if (item.Text == lb.Text)
                litDescription.Text = item.Description;
        }

        //Bubble Event To Parent Page
        OnBubbleEvent(e);

    }



    private void resetAlphaTabs()
    {
        //reset back color for all tabs
        LinkButton lb;
        for (int i = 0; i < plcHolder.Controls.Count; i++)
        {
            lb = (LinkButton)plcHolder.Controls[i];
            lb.CssClass = "default";
        }


    }




}
