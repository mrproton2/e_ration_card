<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Distributor.Master" AutoEventWireup="true" CodeBehind="DistributorScreen.aspx.cs" Inherits="e_ration_card.Master.DistributorScreen" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:15%;padding:1px 16px;height:100%;margin-top:0px;">
        
  <div class="row bg-light">
  <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 p-5">
   <form class="needs-validation" novalidate >
  <div class="form-group">
    <label for="rationcardno">Ration Card No:</label>
    <input type="text" id="txtrationcardno" runat="server" placeholder="Enter Ration Card No" name="rationcardno" required>
      <asp:Button ID="btnserch" runat="server" Text="Search" OnClick="btnserch_Click" />
     
  </div>
</form>
  </div>

  <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 p-5 txt-center">  
      <div class="form-group">
       <label for="rationcardno">Card Holder Name:</label>
          <asp:Label ID="lblchn" runat="server" Text="" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
          <label for="rationcardno">Total Active Member:</label>
          <asp:Label ID="lblmember" runat="server" Text="" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
      </div>
      </div>
</div>

  <div id="detailDiv" runat="server" >
  <div class="row bg-light">


  <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 ">
<%-- <asp:ListBox ID="lstallgoods" runat="server"  style="margin-left:35px;" Height="200px" Width="150px" SelectionMode="Multiple">
          <asp:ListItem>Wheat</asp:ListItem>
          <asp:ListItem>Rice</asp:ListItem>
          <asp:ListItem>Oil</asp:ListItem>
          <asp:ListItem>Soyabean</asp:ListItem>
          <asp:ListItem>Sugar</asp:ListItem>
          <asp:ListItem>Salt</asp:ListItem>
      </asp:ListBox>




      <asp:ListBox ID="lstselected" runat="server" style="margin-left:80px;" Height="200px" Width="150px" SelectionMode="Multiple">
      </asp:ListBox>--%>

     <%-- <table border="0" cellpadding="0" cellspacing="5">
    <tr>
        <td>
            <asp:ListBox ID="lstLeft" runat="server" SelectionMode="Multiple" style="margin-left:35px;" Height="200px" Width="150px">
                <asp:ListItem>Wheat</asp:ListItem>
          <asp:ListItem>Rice</asp:ListItem>
          <asp:ListItem>Oil</asp:ListItem>
          <asp:ListItem>Soyabean</asp:ListItem>
          <asp:ListItem>Sugar</asp:ListItem>
          <asp:ListItem>Salt</asp:ListItem>
            </asp:ListBox>
           
        </td>
        <td>
            <asp:Button ID="btnLeft" Text="<<" runat="server" OnClick="LeftClick" />
            <asp:Button ID="btnRight" Text=">>" runat="server" OnClick="RightClick" />
        </td>
        <td>
            <asp:ListBox ID="lstRight" runat="server" SelectionMode="Multiple" style="margin-left:20px;" Height="200px" Width="150px"></asp:ListBox>
             

        </td>
    </tr>
</table>--%>

 <div id="divrecord">
      <asp:GridView ID="gvlist" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" Width="100%"
                                    OnRowDataBound="gvlist_RowDataBound" Style="text-align: center" 
          RowStyle-BackColor="" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
          HeaderStyle-BackColor="#ff9900" HeaderStyle-ForeColor="White">
                                    
                                 <%--       <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="false" Checked="true"
                                                    Style="text-align: center; width: 100%" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkChange" runat="server" AutoPostBack="false" Checked="true" Style="text-align: center"
                                                    Width="100%" Text=" " />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                               
                                                <asp:TextBox ID="txtperunitprice" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" />
                                        </asp:TemplateField>



                                    </Columns>--%>

             <Columns>
              <asp:TemplateField>
              <HeaderTemplate>
                   <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="false" Checked="true"
                                     Style="text-align: center; width: 100%" />
             </HeaderTemplate>
                         <ItemTemplate>
                 <asp:CheckBox ID="chkChange" runat="server" AutoPostBack="false" Checked="true" Style="text-align: center"
                                                    Width="100%" Text=" " />
                     </ItemTemplate>
                 </asp:TemplateField>
              <%--<asp:BoundField DataField="Name" HeaderText="Name" />
              <asp:BoundField DataField="Units" HeaderText="Units" />--%>

                 <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="true">
                  <HeaderTemplate>
                      <asp:Label runat="server" Text="Name"></asp:Label>
                      
                  </HeaderTemplate>
            <ItemTemplate>
                 <asp:Label ID="name" runat="server" Text='<%#Eval("[Name]")%>'></asp:Label>
                
            </ItemTemplate>
                      
        </asp:TemplateField>

                  <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="true">
                  <HeaderTemplate>
                      <asp:Label runat="server" Text="Units"></asp:Label>
                      
                  </HeaderTemplate>
            <ItemTemplate>
                 <asp:Label ID="units" runat="server" Text='<%#Eval("[Units]")%>'></asp:Label>
                
            </ItemTemplate>
                      
        </asp:TemplateField>

              <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="true">
                  <HeaderTemplate>
                      <asp:Label runat="server" Text="Weight"></asp:Label> 
                      <asp:Label runat="server" Text="Units"></asp:Label>
                  </HeaderTemplate>
            <ItemTemplate>                               
                <asp:Label ID="acm" runat="server" Text='<%#Eval("[weight]")%>'></asp:Label>
                <asp:Label ID="unitsign" runat="server" Text=""></asp:Label>
            </ItemTemplate>
                      
        </asp:TemplateField>
                 <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="true">
                  <HeaderTemplate>
                      <asp:Label runat="server" Text="Price"></asp:Label>
                      
                  </HeaderTemplate>
            <ItemTemplate>
                 <asp:Label ID="price" runat="server" Text='<%#Eval("[price]")%>'></asp:Label>
                
            </ItemTemplate>
                      
        </asp:TemplateField>
   
        </Columns>
                                </asp:GridView>
     
                            
                

   </div>
  
  <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 p-5">
       <div class="form-group">
       <label for="totalprice">Total Price:</label>
          <asp:Label ID="lblprice" runat="server" Text="" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
          <label for="totalweight">Total Weight:</label>
          <asp:Label ID="lblweight" runat="server" Text="" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
      </div>
      <div class="form-group">
       <label for="date">Date:</label>
        <%--<input type="text" id="txtdate" placeholder="" name="date" required>  --%>  
         <asp:Label ID="lbldatetime" runat="server" Text=""></asp:Label> 
      </div>
  </div>



<div class="row bg-light">
  <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 p-5">
   <form class="needs-validation" novalidate >
   <div class="form-group">
    <label for="utype">Active Mbr</label>
     <asp:DropDownList ID="ddlactivemember" runat="server" DataTextField="Member_Name" DataValueField="Member_Name" AutoPostBack="false">          
     </asp:DropDownList> 
        <label for="utype">InActive Mbr</label>
     <asp:DropDownList ID="ddlinactivemember" runat="server" DataTextField="Member_Name" DataValueField="Member_Name">
     </asp:DropDownList>   
  </div>
</form>
  </div>

  <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 p-5 txt-center">  
      <div class="form-group">
          <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn btn-info" OnClick="btnsubmit_Click"/>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnclear" runat="server" Text="Clear" class="btn btn-danger" OnClick="btnclear_Click"/>
          
           <div style="display:none"><asp:Label ID="lblgeneralid" runat="server" Text=""></asp:Label></div>
      </div>
      </div>
 

    </div>
     </div>


    </div>
      </div>
      
      <script>


        function SelectAll(toggle) {
            var gvlist = document.getElementById('<%=gvlist.ClientID %>')
            var len = gvlist.rows.length;

            for (intGv = 1; intGv < len; intGv++) {
                if (!gvlist.rows[intGv].cells[0].children[0].firstChild.disabled) {
                    gvlist.rows[intGv].cells[0].children[0].firstChild.checked = toggle;
                  
                }
            }
        }

       

    </script>
</asp:Content>
