<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Distributor.Master" AutoEventWireup="true" CodeBehind="DistributorScreen.aspx.cs" Inherits="e_ration_card.Master.DistributorScreen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:15%;padding:1px 16px;height:100%;margin-top:0px;">
        
        <div class="row bg-light">
  <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 p-5">
   <form class="needs-validation" novalidate >
  <div class="form-group">
    <label for="rationcardno">Ration Card No:</label>
    <input type="text" id="txtrationcardno" placeholder="Enter Ration Card No" name="rationcardno" required>
      <asp:Button ID="btnserch" runat="server" Text="Search" />
     
  </div>
</form>
  </div>

  <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 p-5 txt-center">  
      <div class="form-group">
       <label for="rationcardno">Card Holder Name:</label>
          <asp:Label ID="lblchn" runat="server" Text="Label"></asp:Label>
          <label for="rationcardno">Total Member:</label>
          <asp:Label ID="lblmember" runat="server" Text="Label"></asp:Label>
      </div>
      </div>
</div>

  <div class="row bg-light">

  <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 ">
 <asp:ListBox ID="lstallgoods" runat="server"  style="margin-left:35px;" Height="200px" Width="150px">
          <asp:ListItem>Wheat</asp:ListItem>
          <asp:ListItem>Rice</asp:ListItem>
          <asp:ListItem>Oil</asp:ListItem>
          <asp:ListItem>Soyabean</asp:ListItem>
          <asp:ListItem>Sugar</asp:ListItem>
          <asp:ListItem>Salt</asp:ListItem>
      </asp:ListBox>
      <asp:ListBox ID="lstselected" runat="server" style="margin-left:80px;" Height="200px" Width="150px">
          <asp:ListItem>Wheat</asp:ListItem>
          <asp:ListItem>Rice</asp:ListItem>
          <asp:ListItem>Oil</asp:ListItem>
          <asp:ListItem>Soyabean</asp:ListItem>
          <asp:ListItem>Sugar</asp:ListItem>
          <asp:ListItem>Salt</asp:ListItem>
      </asp:ListBox>

   </div>
  
  <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 p-5">
       <div class="form-group">
       <label for="totalprice">Total Price:</label>
          <asp:Label ID="lblprice" runat="server" Text="Label"></asp:Label>
          <label for="totalweight">Total Weight:</label>
          <asp:Label ID="lblweight" runat="server" Text="Label"></asp:Label>
      </div>
      <div class="form-group">
       <label for="date">Date:</label>
        <input type="text" id="txtdate" placeholder="" name="date" required>           
      </div>
  </div>

</div>

<div class="row bg-light">
  <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 p-5">
   <form class="needs-validation" novalidate >
   <div class="form-group">
    <label for="utype">Active Member</label>
     <asp:DropDownList ID="ddlactivemember" runat="server">
          <asp:ListItem value="value" selected="True">**SELECT**</asp:ListItem> 
          <asp:ListItem value="value" selected="False">Abhishek</asp:ListItem> 
          <asp:ListItem value="value" selected="False">ajay</asp:ListItem> 
          <asp:ListItem value="value" selected="False">ramesh </asp:ListItem>
     </asp:DropDownList> 
        <label for="utype">InActive Member</label>
     <asp:DropDownList ID="ddlinactivemember" runat="server">
          <asp:ListItem value="value" selected="True">**SELECT**</asp:ListItem> 
          <asp:ListItem value="value" selected="False">kaloo</asp:ListItem> 
          <asp:ListItem value="value" selected="False">niloo</asp:ListItem> 
          <asp:ListItem value="value" selected="False">raju </asp:ListItem>
     </asp:DropDownList>   
  </div>
</form>
  </div>

  <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 p-5 txt-center">  
      <div class="form-group">
          <asp:Button ID="btnupload" runat="server" Text="Upload" class="btn btn-info"/>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnclear" runat="server" Text="Clear" class="btn btn-danger"/>
      </div>
      </div>
      <%--<div class="row bg-light text-center pb-4 mt-0">
        <div class="col-lg-12 col-xl-12 col-md-12 col-sm-12 col-12">
              <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn btn-info" />
          <asp:Button ID="Button1" runat="server" Text="Clear" class="btn btn-danger"/>
            </div>--%>
     </div>
</div>
</asp:Content>
