<%@ Page Title="" Language="C#" MasterPageFile="~/Master/General.Master" AutoEventWireup="true" CodeBehind="UpdateRationCard.aspx.cs" Inherits="e_ration_card.UpdateRationCard" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:15%;padding:1px 16px;height:100%;margin-top:70px;">
     <div class="row bg-light">
            <div class="col-lg-12 col-xl-12 col-md-12 col-sm-12 col-12 ">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <asp:CheckBox ID="chkchangename" runat="server" Text="Name Correction" Font-Size="Large" AutoPostBack="true" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkchangeaddress" runat="server" Text="Change Address" Font-Size="Large" AutoPostBack="true"  />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkchangemembernam" runat="server" Text="Member Name Correction" Font-Size="Large" AutoPostBack="true"  />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkaddmember" runat="server" Text="Add Member" Font-Size="Large" AutoPostBack="true"  />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkremovemember" runat="server" Text="Remove Member" Font-Size="Large" AutoPostBack="true"  />
                         &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkannualincome" runat="server" Text="Annual Income" Font-Size="Large" AutoPostBack="true"  />
                          </div>
                    </form>
        </div>
          </div>
         <div id="changename" class="row bg-light mb-3" runat="server">
              <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <asp:Label ID="lblnamechange" runat="server" Text="Name Change:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                   <input type="text" id="txtoldname" placeholder="Old Name:" name="oldname" required readonly="readonly" >
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <input type="text" id="txtnewname" runat="server" placeholder="New Name" name="newname" required>
                      </div>


             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:FileUpload ID="fu1changename" runat="server" />
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:FileUpload ID="fu2changename" runat="server" />
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-5">
                 &nbsp;<asp:Button ID="btnchangename" runat="server" Text="Upload" OnClick="btnchangename_Click" />
                      </div>
                
                </div>

         <div id="changeaddress" class="row bg-light mb-3" runat="server">
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                  <asp:Label ID="lblchangeaddress" runat="server" Text="Address Correction:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                  <input type="text" id="txtoldaddress" placeholder="Old Address:" name="oldaddress" required readonly="readonly">
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <input type="text" id="txtnewaddress" placeholder="New address" name="newaddress" required>
                      </div>


             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:FileUpload ID="fu1address" runat="server" />
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:FileUpload ID="fu2address" runat="server" />
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-5">
                 &nbsp;<asp:Button ID="btnchangeaddress" runat="server" Text="Upload" OnClick="btnchangeaddress_Click" />
                      </div>
                
                </div>

        <div id="changemembernam" class="row bg-light mb-3" runat="server">
            <%--<div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 pt-">
                <asp:Label ID="lblchangemembername" runat="server" Text="Member Name Correction:"></asp:Label>
                 <input type="text" id="txtolmembername" placeholder="Old Member Name:" name="oldmembername" required>
                 <input type="text" id="txtnewmembername" placeholder="New Member Name" name="newmembername" required>
                </div>--%>

            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:Label ID="lblchangemembername" runat="server" Text="Member Name Correction:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                  <input type="text" id="txtolmembername" placeholder="Old Member Name:" name="oldmembername" required readonly="readonly">
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <input type="text" id="txtnewmembername" placeholder="New Member Name" name="newmembername" required>
                      </div>
                
                

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu1changemembername" runat="server" />
                 </div> 

                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu2changemembername" runat="server" />
                              </div>

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-5">
                 &nbsp;<asp:Button ID="btnchangemembername" runat="server" Text="Upload" />
                      </div>
                
                </div>

        <div id="addmember" class="row bg-light mb-3" runat="server">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:Label ID="lbladdmember" runat="server" Text="Add Member:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                  <input type="text" id="txtaddmembername" placeholder="Member Name:" name="membername" required>
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <input type="text" id="txtaddmemberrelation" placeholder="Relation" name="memberrelation" required>
                      </div>
                
                

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu1addmember" runat="server" />
                 </div> 

                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu2addmember" runat="server" />
                              </div>

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-5">
                 &nbsp;<asp:Button ID="btnaddmember" runat="server" Text="Upload" />
                      </div>
                
                </div>

        <div id="removemember" class="row bg-light mb-3" runat="server">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:Label ID="lblremovemember" runat="server" Text="Remove Member:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                  <%--<input type="text" id="txtremovemembername" placeholder="Remove Member Name:" name="removemembername" required>--%>
                    <asp:DropDownList ID="ddlremovemembername" runat="server">
                    <asp:ListItem Value="value" Selected="True">**SELECT**</asp:ListItem>
                </asp:DropDownList>
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <input type="text" id="txtmemberremovereson" placeholder="Reason" name="memberremovereson" required>
                      </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu1removemember" runat="server" />
                 </div> 

                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu2removemember" runat="server" />
                              </div>

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-5">
                 &nbsp;<asp:Button ID="btnremovemember" runat="server" Text="Upload" />
                      </div>
                
                </div>

        <div id="annualincome" class="row bg-light mb-3" runat="server">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:Label ID="lblincome" runat="server" Text="Annual Income:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                  <input type="text" id="txtlastyearincome" placeholder="Last Year Income:" name="lastyearincome" required readonly="readonly">
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <input type="text" id="txtcurrentyearincome" placeholder="Annual Income" name="currentyearincome" required>
                      </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu1incomecertificate" runat="server" />
                 </div> 

                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu2salarycertificate" runat="server" />
                              </div>

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-5">
                 &nbsp;<asp:Button ID="btnannualincome" runat="server" Text="Upload" />
                      </div>
                
                </div>
        

        <hr />
        <div class="x_content topmargin noPadding table-responsive">
<asp:GridView ID="gvchangename" runat="server" HeaderStyle-BackColor="#ff9900" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
    AutoGenerateColumns="false" CssClass="table table-bordered" Style="text-align: center" Width="100%" OnRowDataBound="gvchangename_RowDataBound" OnRowDeleting="gvchangename_RowDeleting">
    <Columns>
        <asp:BoundField DataField="new_name" HeaderText="New Name"/>
        <asp:BoundField DataField="cn_doc1_name" HeaderText="File Name 1"/>  
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="false">
            <ItemTemplate>
                <asp:LinkButton ID="lnkViewDoc1" runat="server" Text="View" OnClick="lnkViewDoc1_Click"
                    CommandArgument='<%# Eval("cn_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDoc1" runat="server" Text="Download" OnClick="lnkDownloadDoc1_Click"
                    CommandArgument='<%# Eval("cn_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="cn_doc2_name" HeaderText="File Name 2"/>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDoc2" runat="server" Text="Download" OnClick="lnkDownloadDoc2_Click"
                    CommandArgument='<%# Eval("cn_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Authorize" HeaderText="Approval"/>  
         <%--<asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" 
                    CommandArgument='<%# Eval("cn_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>--%>

        <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Link" />--%>
    </Columns>
</asp:GridView>
            </div>
    
   </div>

         
     
       
</asp:Content>
