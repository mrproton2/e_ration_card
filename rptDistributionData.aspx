<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Govt.Master" AutoEventWireup="true" CodeBehind="rptDistributionData.aspx.cs" Inherits="e_ration_card.rptDistributionData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:10%;padding:1px 16px;height:100%;padding-top:5px;">
        <div id="addmember1" class="row bg-light mb-3 border:solid" runat="server" >
          
                    <div class="col-lg-1 col-xl-1 col-md-1 col-sm-12 col-12 pl-0 pr-0">
                        <asp:Label ID="lblstate" runat="server" Text="State:"></asp:Label>                      
                              </div> 
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0">                        
                        <asp:DropDownList ID="ddlstate" runat="server" class="form-control" DataTextField="state_name" DataValueField="state_id" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                        <asp:ListItem Value="**SELECT**" Selected="True">**SELECT**</asp:ListItem>
                        <asp:ListItem Value="Name Correction" Selected="false">Name Correction</asp:ListItem>
                            </asp:DropDownList>
                              </div> 
             

                    <div class="col-lg-1 col-xl-1 col-md-1 col-sm-12 col-12 pl-0 pr-0"> 
                         <asp:Label ID="lbldistrict" runat="server" Text="District:"></asp:Label>
                        
                              </div>

             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0"> 
                <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" AutoPostBack="true" DataTextField="district_name"></asp:DropDownList>
                </div>

            <div class="col-lg-1 col-xl-1 col-md-1 col-sm-12 col-12 pl-0 pr-0"> 
                <asp:Label ID="lblconsti" runat="server" Text="Constituency:">
                 
                        
                       
                </asp:Label>
               
                      </div>
             <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0"> 
                 <asp:DropDownList ID="ddlconstituency" runat="server" class="form-control"  AutoPostBack="true" DataTextField="consitiuency_name" DataValueField="consitiuency_name">
                    
                 </asp:DropDownList>
                </div>
        </div>

         <div id="addmember" class="row bg-light mb-3" runat="server">    

        <div class="col-lg-1 col-xl-1 col-md-1 col-sm-12 col-12 pl-0 pr-0">
                 <asp:Label ID="lblrationcard" runat="server" Text="RationCardNo:"></asp:Label>               
                 
                 </div> 
              <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0"> 
                 <asp:TextBox ID="txtration" runat="server" class="form-control" TextMode="Number" MaxLength="10"></asp:TextBox>
                 </div>
          <div class="col-lg-1 col-xl-1 col-md-1 col-sm-12 col-12 pl-0 pr-0">
                  <asp:Label ID="lblkotedarno" runat="server" Text="KotedarNo:"></asp:Label>               
                
                 </div> 
              <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12 pl-0 pr-0"> 
                  <asp:TextBox ID="txtkotedarno" runat="server" class="form-control" TextMode="Number" MaxLength="10" ></asp:TextBox>
                 </div>

       <div class="col-lg-1 col-xl-1 col-md-1 col-sm-12 col-12 pl-0 pr-0">
                
                      </div>
              <div class="col-lg-3 col-xl-3 col-md-3 col-sm-12 col-12 pl-0 pr-0 align-content-center"> 
                  <asp:Button ID="btnserch" class="btn-primary" runat="server" Text="Search" OnClick="btnserch_Click"/> 
                  <asp:Button ID="btnclear" class="btn-danger" runat="server" Text="Clear" OnClick="btnclear_Click"/>
                 </div>
                
                </div>

        <div class="x_content topmargin noPadding table-responsive">
  <asp:GridView ID="gvchangename" runat="server" HeaderStyle-BackColor="#ff9900" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
    AutoGenerateColumns="true" Allowpaging="true" PageSize="5" OnPageIndexChanging="gvchangename_PageIndexChanging" CssClass="table table-bordered table-responsive" Style="text-align: center" Width="100%">
       <EmptyDataTemplate>
       <CENTER><div>No records found.</div></CENTER>
    </EmptyDataTemplate>
</asp:GridView>
            </div>
      </div>
</asp:Content>
