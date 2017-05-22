<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sorter.aspx.cs" Inherits="Sorter" Title="NTierBuilder - Custom Sorter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">

<h1>
    Sorting Object Collections for a Generic List</h1>

<p>
    Below, are examples of how you can sort a generic List&lt;&gt; collection.<br />
<br />
This is an example of sorting by Customer.Name ASC.<br /><br />
<pre>
List&lt;Customer&gt; collection = new List&lt;Customer&gt;();
collection.Sort(delegate(Customer c1, Customer c2)
{
    return c1.Name.CompareTo(c2.Name);
});
</pre>
</p>

<p>
This is an example of sorting by <strong>MULTIPLE</strong> properties. The collection below will sort the collection by 
Customer.NumberOfLocations DESC, then by Customer.Name ASC.<br /><br />
<pre>
List&lt;Customer&gt; collection = new List&lt;Customer&gt;();
collection.Sort(delegate(Customer c1, Customer c2)
{
    return c2.NumberOfLocations.CompareTo(c1.NumberOfLocations) + 
        c1.Name.CompareTo(c2.Name);
});
</pre>
</p>


<h1>
    Finding an Object in a Generic List</h1>

<pre>
List&lt;Customer&gt; collection = new List&lt;Customer&gt;();
Customer obj = collection.Find(delegate(Customer p) { return p.CustomerID == 3; });
</pre>

<h1>
    Finding ALL Matching Objects in a Generic List</h1>

<pre>
List&lt;Customer&gt; collection = new List&lt;Customer&gt;();
List&lt;Customer&gt; matches = collection.FindAll(delegate(Customer p) { return p.State == "KS"; });
</pre>

<br />






</asp:Content>

