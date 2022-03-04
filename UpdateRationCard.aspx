<%@ Page Title="" Language="C#" MasterPageFile="~/Master/General.Master" AutoEventWireup="true" CodeBehind="UpdateRationCard.aspx.cs" Inherits="e_ration_card.UpdateRationCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:15%;padding:1px 16px;height:100%;margin-top:70px;">
     <div class="row bg-light">
            <div class="col-lg-12 col-xl-12 col-md-12 col-sm-12 col-12 ">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <asp:CheckBox ID="chkchangename" runat="server" Text="Name Correction" Font-Size="Large" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkchangeaddress" runat="server" Text="Change Address" Font-Size="Large" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkchangemembernam" runat="server" Text="Member Name Correction" Font-Size="Large" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkaddmember" runat="server" Text="Add Member" Font-Size="Large" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkremovemember" runat="server" Text="Remove Member" Font-Size="Large" />
                         &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkannualincome" runat="server" Text="Annual Income" Font-Size="Large" />
                          </div>
                    </form>
        </div>
          </div>
         <div class="row bg-light mb-3">
              <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <asp:Label ID="lblnamechange" runat="server" Text="Name Change:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                   <input type="text" id="txtoldname" placeholder="Old Name:" name="oldname" required>
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                 <input type="text" id="txtnewname" placeholder="New Name" name="newname" required>
                      </div>


             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:FileUpload ID="fu1changename" runat="server" />
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:FileUpload ID="fu2changename" runat="server" />
                              </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-5">
                 &nbsp;<asp:Button ID="btnchangename" runat="server" Text="submit" />
                      </div>
                
                </div>

         <div class="row bg-light mb-3">
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                  <asp:Label ID="lblchangeaddress" runat="server" Text="Address Correction:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                  <input type="text" id="txtoldaddress" placeholder="Old Address:" name="oldaddress" required>
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
                 &nbsp;<asp:Button ID="btnchangeaddress" runat="server" Text="submit" />
                      </div>
                
                </div>

        <div class="row bg-light mb-3">
            <%--<div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 pt-">
                <asp:Label ID="lblchangemembername" runat="server" Text="Member Name Correction:"></asp:Label>
                 <input type="text" id="txtolmembername" placeholder="Old Member Name:" name="oldmembername" required>
                 <input type="text" id="txtnewmembername" placeholder="New Member Name" name="newmembername" required>
                </div>--%>

            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:Label ID="lblchangemembername" runat="server" Text="Member Name Correction:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                  <input type="text" id="txtolmembername" placeholder="Old Member Name:" name="oldmembername" required>
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
                 &nbsp;<asp:Button ID="btnchangemembername" runat="server" Text="submit" />
                      </div>
                
                </div>

        <div class="row bg-light mb-3">
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
                 &nbsp;<asp:Button ID="btnaddmember" runat="server" Text="submit" />
                      </div>
                
                </div>

        <div class="row bg-light mb-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:Label ID="lblremovemember" runat="server" Text="Remove Member:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                  <input type="text" id="txtremovemembername" placeholder="Remove Member Name:" name="removemembername" required>
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
                 &nbsp;<asp:Button ID="btnremovemember" runat="server" Text="submit" />
                      </div>
                
                </div>

        <div class="row bg-light mb-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                 <asp:Label ID="lblincome" runat="server" Text="Annual Income:"></asp:Label>
                 </div> 
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">
                  <input type="text" id="txtlastyearincome" placeholder="Last Year Income:" name="lastyearincome" required>
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
                 &nbsp;<asp:Button ID="btnannualincome" runat="server" Text="submit" />
                      </div>
                
                </div>
        
    
   </div>

         
     
       
</asp:Content>
