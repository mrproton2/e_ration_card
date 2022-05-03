<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Distributor.Master" AutoEventWireup="true" CodeBehind="DistributorProfile.aspx.cs" Inherits="e_ration_card.DistributorProfile" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="margin-left: 15%; padding: 1px 16px; height: 100%; margin-top: 0px;"> 
        <div class="row bg-light">
            <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 ">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="kotedar">Kotedar Name:</label>
                        <input type="text" class="form-control" id="txtkotedar" runat="server" placeholder="Enter Name" name="kotedar" required readonly="readonly">
                        <div class="valid-feedback">Valid.</div>
                        <div class="invalid-feedback">Please Enter Kotedar Name.</div>
                    </div>
                    <div class="form-group">
                        <label for="mobile">Mobile No:</label>
                        <input type="text" class="form-control" id="txtmobile" runat="server" placeholder="Enter Your Mobile No." name="mobile" required readonly="readonly">
                        <div class="valid-feedback">Valid.</div>
                        <div class="invalid-feedback">Please Enter Your Mobile No.</div>
                    </div>
                    <div class="form-group">
                        <label for="email">Email:</label>
                        <input type="text" class="form-control" id="txtemail" runat="server" placeholder="Enter Your Email " runat="server" name="email" required readonly="readonly">
                        <div class="valid-feedback">Valid.</div>
                        <div class="invalid-feedback">Please Enter Your Email.</div>
                    </div>
                    <div class="form-group">
                        <label for="Address">Address:</label>
                        <input type="text" class="form-control" id="txtaddress" runat="server" placeholder="Enter Your Address" name="Address" required>
                        <div class="valid-feedback">Valid.</div>
                        <div class="invalid-feedback">Please Enter Your Address.</div>
                    </div>
                    <div class="form-group">
                        <label for="utype">State: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
                        &nbsp;<asp:DropDownList ID="ddlstate" runat="server" DataTextField="state_name" DataValueField="state_id" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                            
                        </asp:DropDownList>
                        <label for="utype">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; District:</label>
                        <asp:DropDownList ID="ddldistrict" runat="server" DataTextField="district_name">                          
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="utype">Constituency:</label>
                        <asp:DropDownList ID="ddlconstituency" runat="server" DataTextField="consitiuency_name" DataValueField="consitiuency_name">
                            <asp:ListItem Value="SELECT" Selected="True">**SELECT**</asp:ListItem>
                            <asp:ListItem Value="Chandivali" Selected="False">Chandivali</asp:ListItem>                          
                        </asp:DropDownList>
                    </div>

                </form>
            </div>
            <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12">               
                    <div class="form-group">
                        <label for="kotedarid">Kotedar ID:</label>
                        <input type="text" class="form-control" id="txtkotedarid" runat="server" placeholder="Enter Kotedar ID" >
                    </div>
                    <div class="form-group">
                        <label for="aadharno">Aadhar No:</label>
                        <input type="text" class="form-control" id="txtaadharno" runat="server" placeholder="Enter Aadhar No">                        
                    </div>
                    <div class="form-group">
                        <label for="panno">Pan No:</label>
                        <input type="text" class="form-control" id="txtpanno" runat="server" placeholder="Enter Your Pan No" name="panno" required>         
                    </div>
                    <div class="form-group">
                        <label for="pincode">Pin Code:</label>
                        <input type="number" class="form-control" id="txtpincode" runat="server" placeholder="Enter Your Pin Code" name="pincode" required />                   
                    </div>
                    <div class="form-group">
                        <label for="photo">Upload Photo:</label>
                        <asp:FileUpload ID="fuphoto" runat="server" AllowMultiple="false" />
                        <asp:Label ID="lblphotoname" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group">
                        <label for="signature">Upload Signature</label>
                        <asp:FileUpload ID="fusignature" runat="server" AllowMultiple="false" />
                        <asp:Label ID="lblsignature" runat="server" Text=""></asp:Label>
                    </div>

             
            </div>
        </div>
            
        <div class="row bg-light text-center pb-4 mt-0">
            <div class="col-lg-12 col-xl-12 col-md-12 col-sm-12 col-12">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn btn-info" OnClick="btnsubmit_Click" />
                <asp:Button ID="btnupdate" runat="server" Text="Update" class="btn btn-info" OnClick="btnupdate_Click"/>
                <asp:Button ID="btnclear" runat="server" Text="Clear" class="btn btn-danger" />
            </div>
        </div>

    </div>
</asp:Content>
