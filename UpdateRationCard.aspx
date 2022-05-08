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
                        <asp:CheckBox ID="chkannualincome" runat="server" Text="Annual Income" Font-Size="Large" AutoPostBack="true"  Visible="false"  />
                          </div>
                    </form>
        </div>
          </div>
         <div id="changename" class="row bg-light mb-3" runat="server">
              <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <asp:Label ID="lblnamechange" runat="server" Text="Name Change:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                   <input type="text" id="txtoldname" runat="server" placeholder="Old Name:" name="oldname" required readonly="readonly" >
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
                  <input type="text" id="txtoldaddress" runat="server" placeholder="Old Address:" name="oldaddress" required readonly="readonly">
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <input type="text" id="txtnewaddress" runat="server" placeholder="New address" name="newaddress" required>
                      </div>


             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:FileUpload ID="fu1address" runat="server" />
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:FileUpload ID="fu2address" runat="server" />
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-5">
                 &nbsp;<asp:Button ID="btnchangeaddress" runat="server" Text="Upload" OnClick="btnchangeaddress_Click1"/>
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
                  <%--<input type="text" id="txtolmembername" runat="server" placeholder="Old Member Name:" name="oldmembername" required readonly="readonly">--%>
                         <asp:DropDownList ID="ddlolmembername" runat="server" class="form-control" colDataTextField="mbr_name" DataValueField="mbr_name"></asp:DropDownList>
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <input type="text" id="txtnewmembername" runat="server" placeholder="New Member Name" name="newmembername" required>
                      </div>
                
                

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu1changemembername" runat="server" />
                 </div> 

                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu2changemembername" runat="server" />
                              </div>

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-5">
                 &nbsp;<asp:Button ID="btnchangemembername" runat="server" Text="Upload" OnClick="btnchangemembername_Click" />
                      </div>
                
                </div>

        <div id="addmember" class="row bg-light mb-3" runat="server">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:Label ID="lbladdmember" runat="server" Text="Add Member:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <input type="text" id="txtaddmembername" runat="server" placeholder="Member Name:" name="membername" required>
                       
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <input type="text" id="txtaddmemberrelation" runat="server" placeholder="Relation" name="memberrelation" required>
                      </div>
                
                

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu1addmember" runat="server" />
                 </div> 

                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu2addmember" runat="server" />
                              </div>

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-5">
                 &nbsp;<asp:Button ID="btnaddmember" runat="server" Text="Upload" OnClick="btnaddmember_Click" />
                      </div>
                
                </div>

        <div id="removemember" class="row bg-light mb-3" runat="server">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:Label ID="lblremovemember" runat="server" Text="Remove Member:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                  <%--<input type="text" id="txtremovemembername" placeholder="Remove Member Name:" name="removemembername" required>--%>
                    <asp:DropDownList ID="ddlremovemembername" runat="server" class="form-control" DataTextField="mbr_name" DataValueField="mbr_name">
                    <asp:ListItem Value="value" Selected="True">**SELECT**</asp:ListItem>
                </asp:DropDownList>
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <input type="text" id="txtmemberremovereson" runat="server" placeholder="Reason" name="memberremovereson" required>
                      </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu1removemember" runat="server" />
                 </div> 

                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <asp:FileUpload ID="fu2removemember" runat="server" />
                              </div>

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-5">
                 &nbsp;<asp:Button ID="btnremovemember" runat="server" Text="Upload" OnClick="btnremovemember_Click" />
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
        <asp:BoundField DataField="old_name" HeaderText="Old Name"/>
        <asp:BoundField DataField="new_name" HeaderText="New Name"/>
        <asp:BoundField DataField="cn_doc1_name" HeaderText="File Name"/>  
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
        <asp:BoundField DataField="cn_doc2_name" HeaderText="File Name 2" Visible="false"/>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="false">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDoc2" runat="server" Text="Download" OnClick="lnkDownloadDoc2_Click"
                    CommandArgument='<%# Eval("cn_id") %>' ></asp:LinkButton>
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
    
        <div class="x_content topmargin noPadding table-responsive">
<asp:GridView ID="gvchangeaddress" runat="server" HeaderStyle-BackColor="#ff9900" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
    AutoGenerateColumns="false" CssClass="table table-bordered" Style="text-align: center" Width="100%" OnRowDataBound="gvchangename_RowDataBound" OnRowDeleting="gvchangename_RowDeleting">
    <Columns>
        <asp:BoundField DataField="old_address" HeaderText="Old Address"/>
        <asp:BoundField DataField="new_address" HeaderText="New Address"/>
        <asp:BoundField DataField="ac_doc1_name" HeaderText="File Name"/>  
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="false">
            <ItemTemplate>
                <asp:LinkButton ID="lnkViewDoc1" runat="server" Text="View" OnClick="lnkViewDoc1_Click"
                    CommandArgument='<%# Eval("ac_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDocadd1" runat="server" Text="Download" OnClick="lnkDownloadDocadd1_Click"
                    CommandArgument='<%# Eval("ac_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="ac_doc2_name" HeaderText="File Name 2" Visible="false"/>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="false">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDocadd2" runat="server" Text="Download" OnClick="lnkDownloadDocadd2_Click"
                    CommandArgument='<%# Eval("ac_id") %>'></asp:LinkButton>
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


          
        <div class="x_content topmargin noPadding table-responsive">
<asp:GridView ID="gvmbrcorrection" runat="server" HeaderStyle-BackColor="#ff9900" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
    AutoGenerateColumns="false" CssClass="table table-bordered" Style="text-align: center" Width="100%" OnRowDataBound="gvmbrcorrection_RowDataBound">
    <Columns>
        <asp:BoundField DataField="old_mbrname" HeaderText="Old Member"/>
        <asp:BoundField DataField="new_mbrname" HeaderText="New Member"/>
        <asp:BoundField DataField="mbr_doc1_name" HeaderText="File Name"/>  
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="false">
            <ItemTemplate>
                <asp:LinkButton ID="lnkViewDoc1" runat="server" Text="View" OnClick="lnkViewDoc1_Click"
                    CommandArgument='<%# Eval("mbr_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDocmbr1" runat="server" Text="Download" OnClick="lnkDownloadDocmbr1_Click"
                    CommandArgument='<%# Eval("mbr_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="mbr_doc2_name" HeaderText="File Name 2" Visible="false"/>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="false">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDocmbr2" runat="server" Text="Download" OnClick="lnkDownloadDocmbr2_Click"
                    CommandArgument='<%# Eval("mbr_id") %>' ></asp:LinkButton>
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

        
        <div class="x_content topmargin noPadding table-responsive">
<asp:GridView ID="gvaddmember" runat="server" HeaderStyle-BackColor="#ff9900" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
    AutoGenerateColumns="false" CssClass="table table-bordered" Style="text-align: center" Width="100%" OnRowDataBound="gvaddmember_RowDataBound">
    <Columns>
        
        <asp:BoundField DataField="membername" HeaderText="Add Member"/>
        <asp:BoundField DataField="relation" HeaderText="Relation"/>
        <asp:BoundField DataField="addmbr_doc1_name" HeaderText="File Name"/>  
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="false">
            <ItemTemplate>
                <asp:LinkButton ID="lnkViewDoc1" runat="server" Text="View" OnClick="lnkViewDoc1_Click"
                    CommandArgument='<%# Eval("addmbr_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDocaddmbr1" runat="server" Text="Download" OnClick="lnkDownloadDocaddmbr1_Click"
                    CommandArgument='<%# Eval("addmbr_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="addmbr_doc2_name" HeaderText="File Name 2" Visible="false"/>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="false">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDocaddmbr2" runat="server" Text="Download" OnClick="lnkDownloadDocaddmbr2_Click"
                    CommandArgument='<%# Eval("addmbr_id") %>'></asp:LinkButton>
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

         <div class="x_content topmargin noPadding table-responsive">
<asp:GridView ID="gbremovembr" runat="server" HeaderStyle-BackColor="#ff9900" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
    AutoGenerateColumns="false" CssClass="table table-bordered" Style="text-align: center" Width="100%" OnRowDataBound="gvaddmember_RowDataBound">
    <Columns>
        
        <asp:BoundField DataField="membername" HeaderText="Remove Member"/>
        <asp:BoundField DataField="Relation" HeaderText="Reason"/>
        <asp:BoundField DataField="removembr_doc1_name" HeaderText="File Name"/>  
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="false">
            <ItemTemplate>
                <asp:LinkButton ID="lnkViewDoc1" runat="server" Text="View" OnClick="lnkViewDoc1_Click"
                    CommandArgument='<%# Eval("removembr_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDocremovembr1" runat="server" Text="Download" OnClick="lnkDownloadDocremovembr1_Click"
                    CommandArgument='<%# Eval("removembr_id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="removembr_doc2_name" HeaderText="File Name 2" Visible="false"/>
        <asp:TemplateField ItemStyle-HorizontalAlign = "Center" Visible="false">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownloadDocremovembr2" runat="server" Text="Download" OnClick="lnkDownloadDocremovembr2_Click"
                    CommandArgument='<%# Eval("removembr_id") %>'></asp:LinkButton>
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
