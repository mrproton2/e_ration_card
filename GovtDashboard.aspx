<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Govt.Master" AutoEventWireup="true" CodeBehind="GovtDashboard.aspx.cs" Inherits="e_ration_card.GovtDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div style="margin-left:10%;padding:1px 16px;height:100%;margin-top:70px;">

        <div id="addmember" class="row bg-light mb-3" runat="server" style="padding-top:30px;">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:Label ID="lbladdmember" runat="server"  Text="Correction Type:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                        <asp:DropDownList ID="ddlcorrectiontype" class="form-control" runat="server" AutoPostBack="true">
                        <asp:ListItem Value="**SELECT**" Selected="True">**SELECT**</asp:ListItem>
                        <asp:ListItem Value="Name Correction" Selected="false">Name Correction</asp:ListItem>
                        <asp:ListItem Value="Change Address" Selected="false">Change Address</asp:ListItem>
                        <asp:ListItem Value="Member Name Correction" Selected="false">Member Name Correction</asp:ListItem>
                        <asp:ListItem Value="Add Member" Selected="false">Add Member</asp:ListItem>
                        <asp:ListItem Value="Remove Member" Selected="false">Remove Member</asp:ListItem>
                        <asp:ListItem Value="Annual Income" Selected="false">Annual Income</asp:ListItem>
                            </asp:DropDownList>
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                
                      </div>
                
                

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:Label ID="lblconstituency" runat="server" Text="Constituency:"></asp:Label>
               
                 </div> 

                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                         <asp:TextBox ID="txtconstituency" class="form-control" runat="server"></asp:TextBox>
                              </div>

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-5">
                 <asp:Button ID="btnserch" runat="server" class="btn-primary" Text="Search" OnClick="btnserch_Click" />
                 <asp:Button ID="btnclear" runat="server" class="btn-danger" Text="Clear"  />
                      </div>
                
                </div>

   <div class="x_content topmargin noPadding table-responsive">
  <asp:GridView ID="gvchangename" runat="server" HeaderStyle-BackColor="#ff9900" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
    AutoGenerateColumns="false" CssClass="table table-bordered table-responsive" Style="text-align: center" Width="100%" OnRowDataBound="gvchangename_RowDataBound" OnRowDeleting="gvchangename_RowDeleting" OnPreRender="gvchangename_PreRender">
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
         <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="cn_id" Visible="false" >
            <ItemTemplate>
                <asp:Label ID="lblcnid" runat="server" Text='<%# Eval("cn_id") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
          <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="Old Name" >
            <ItemTemplate>
                <asp:Label ID="lbloldname" runat="server" Text='<%# Eval("old_name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>       
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="New Name" >
            <ItemTemplate>
                <asp:Label ID="lblnewname" runat="server" Text='<%# Eval("new_name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="Card holder name" >
            <ItemTemplate>
                <asp:Label ID="lblcardholder" runat="server" Text='<%# Eval("card_holder_name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="Ration Card No" >
            <ItemTemplate>
                <asp:Label ID="lblrationcardno" runat="server" Text='<%# Eval("rationcard_no") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="Constituency" >
            <ItemTemplate>
                <asp:Label ID="lblconstituency" runat="server" Text='<%# Eval("constituency") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
         <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="District" >
            <ItemTemplate>
                <asp:Label ID="lbldistrict" runat="server" Text='<%# Eval("district") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
         <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="States" >
            <ItemTemplate>
                <asp:Label ID="lblstates" runat="server" Text='<%# Eval("states") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>                   
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center"  HeaderText="FileName1">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDoc1" runat="server" Text="Download" OnClick="lnkDownloadDoc1_Click"
                    CommandArgument='<%# Eval("cn_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>      
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="FileName2">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDoc2" runat="server" Text="Download" OnClick="lnkDownloadDoc2_Click"
                    CommandArgument='<%# Eval("cn_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>      
         <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="Approval">
            <ItemTemplate>
                <asp:DropDownList ID="ddlapprovestatus" runat="server">
                       <asp:ListItem Value="Pending" Selected="True">Pending</asp:ListItem>
                        <asp:ListItem Value="Approved" Selected="false">Approved</asp:ListItem>
                        <asp:ListItem Value="Rejected" Selected="false">Rejected</asp:ListItem>

                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="Reason">
            <ItemTemplate>
                <asp:TextBox ID="txtrejectreason" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>

        <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Link" />--%>
    </Columns>
</asp:GridView>
            </div>
        </div>
     <script>

         debugger
        function SelectAll(toggle) {
            var gvlist = document.getElementById('<%=gvchangename.ClientID %>')
            var len = gvchangename.rows.length;

            for (intGv = 1; intGv < len; intGv++) {
                if (!gvchangename.rows[intGv].cells[0].children[0].firstChild.disabled) {
                    gvchangename.rows[intGv].cells[0].children[0].firstChild.checked = toggle;
                  
                }
            }
        }

       

     </script>
</asp:Content>
