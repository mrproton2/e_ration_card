<%@ Page Title="" Language="C#" MasterPageFile="~/Master/General.Master" AutoEventWireup="true" CodeBehind="CardMemberDetails.aspx.cs" Inherits="e_ration_card.Master.CardMemberDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div style="margin-left: 15%; padding: 1px 16px;margin-top:0px;">
        <div class="row bg-light mb-3 text-center pt-3">
         
                      
   <div class="x_content topmargin noPadding table-responsive">
  <asp:GridView ID="gvmemberlist" runat="server" HeaderStyle-BackColor="#ff9900" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
    AutoGenerateColumns="true" CssClass="table table-bordered table-responsive" Style="text-align: center" Width="100%">
    <Columns> 
       <%-- <asp:TemplateField>
              <HeaderTemplate>
                   <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="false" Checked="true"
                                     Style="text-align: center; width: 100%" />
             </HeaderTemplate>
                         <ItemTemplate>
                 <asp:CheckBox ID="chkChange" runat="server" AutoPostBack="false" Checked="true" Style="text-align: center"
                                                    Width="100%" Text=" " />
                     </ItemTemplate>
                 </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="user_id" Visible="false" >
            <ItemTemplate>
                <asp:Label ID="lbluserid" runat="server" Text='<%# Eval("user_id") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
         <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="cn_id" Visible="false" >
            <ItemTemplate>
                <asp:Label ID="lblcnid" runat="server" Text='<%# Eval("mbr_id") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
          <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="Old Name" >
            <ItemTemplate>
                <asp:Label ID="lbloldname" runat="server" Text='<%# Eval("old_mbrname") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>       
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="New Name" >
            <ItemTemplate>
                <asp:Label ID="lblnewname" runat="server" Text='<%# Eval("new_mbrname") %>'></asp:Label>
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
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center"  HeaderText="FileName">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadMbrnameDoc1" runat="server" Text="Download" OnClick="lnkDownloadMbrnameDoc1_Click"
                    CommandArgument='<%# Eval("mbr_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>      
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="FileName2" Visible="false">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDoc2" runat="server" Text="Download" 
                    CommandArgument='<%# Eval("mbr_id") %>'></asp:LinkButton>
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
        </asp:TemplateField>--%>

        <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Link" />--%>
       
    </Columns>
        <EmptyDataTemplate>
       <CENTER><div>No records found.</div></CENTER>
    </EmptyDataTemplate>
</asp:GridView>
            </div>


        </div>
          </div>
</asp:Content>
