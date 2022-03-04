<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Distributor.Master" AutoEventWireup="true" CodeBehind="DistributorProfile.aspx.cs" Inherits="e_ration_card.DistributorProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 15%; padding: 1px 16px; height: 100%; margin-top: 0px;">
        <div class="row bg-light">
            <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12 ">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="kotedar">Kotedar Name11:</label>
                        <input type="text" class="form-control" id="txtkotedar" placeholder="Enter Name" name="kotedar" required>
                        <div class="valid-feedback">Valid.</div>
                        <div class="invalid-feedback">Please Enter Kotedar Name.</div>
                    </div>
                    <div class="form-group">
                        <label for="mobile">Mobile No22:</label>
                        <input type="text" class="form-control" id="txtmobile" placeholder="Enter Your Mobile No." name="mobile" required>
                        <div class="valid-feedback">Valid.</div>
                        <div class="invalid-feedback">Please Enter Your Mobile No.</div>
                    </div>
                    <div class="form-group">
                        <label for="email">Email:</label>
                        <input type="text" class="form-control" id="txtemail" placeholder="Enter Your Email " runat="server" name="email" required>
                        <div class="valid-feedback">Valid.</div>
                        <div class="invalid-feedback">Please Enter Your Email.</div>
                    </div>
                    <div class="form-group">
                        <label for="Address">Address:</label>
                        <input type="text" class="form-control" id="txtaddress" placeholder="Enter Your Address" name="Address" required>
                        <div class="valid-feedback">Valid.</div>
                        <div class="invalid-feedback">Please Enter Your Address.</div>
                    </div>
                    <div class="form-group">
                        <label for="utype">State: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
                        &nbsp;<asp:DropDownList ID="ddlstate" runat="server">
                            <asp:ListItem Value="value" Selected="True">**SELECT**</asp:ListItem>
                            <asp:ListItem Value="value" Selected="False">Uttar pardesh</asp:ListItem>
                            <asp:ListItem Value="value" Selected="False">Maharashtra</asp:ListItem>
                            <asp:ListItem Value="value" Selected="False">West Bengal </asp:ListItem>
                        </asp:DropDownList>
                        <label for="utype">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; District:</label>
                        <asp:DropDownList ID="ddldistrict" runat="server">
                            <asp:ListItem Value="value" Selected="True">**SELECT**</asp:ListItem>
                            <asp:ListItem Value="value" Selected="False">Mumbai City</asp:ListItem>
                            <asp:ListItem Value="value" Selected="False">Mumbai Suburban</asp:ListItem>
                            <asp:ListItem Value="value" Selected="False">Nagpur </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="utype">Constituency:</label>
                        <asp:DropDownList ID="ddlconstituency" runat="server">
                            <asp:ListItem Value="value" Selected="True">**SELECT**</asp:ListItem>
                            <asp:ListItem Value="value" Selected="False">Consumer</asp:ListItem>
                            <asp:ListItem Value="value" Selected="False">Distributor</asp:ListItem>
                            <asp:ListItem Value="value" Selected="False">Govt</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </form>
            </div>
            <div class="col-lg-6 col-xl-6 col-md-6 col-sm-12 col-12">
                <form action="" class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="kotedarid">Kotedar ID:</label>
                        <input type="text" class="form-control" id="txtkotedarid" placeholder="Enter Kotedar ID" name="kotedarid" required>
                        <div class="valid-feedback">Valid.</div>
                        <div class="invalid-feedback">Please Enter Your Kotedar ID.</div>
                    </div>
                    <div class="form-group">
                        <label for="aadharno">Aadhar No:</label>
                        <input type="text" class="form-control" id="txtaadharno" placeholder="Enter Aadhar No" name="aadharno" required>
                        <div class="valid-feedback">Valid.</div>
                        <div class="invalid-feedback">Please Enter Your Aadhar No.</div>
                    </div>
                    <div class="form-group">
                        <label for="panno">Pan No:</label>
                        <input type="text" class="form-control" id="txtpanno" placeholder="Enter Your Pan No" name="panno" required>
                        <div class="valid-feedback">Valid.</div>
                        <div class="invalid-feedback">Please Enter Your Pan No.</div>
                    </div>
                    <div class="form-group">
                        <label for="pincode">Pin Code:</label>
                        <input type="pincode" class="form-control" id="txtpincode" placeholder="Enter Your Pin Code" name="pincode" required>
                        <div class="valid-feedback">Valid.</div>
                        <div class="invalid-feedback">Please Enter Your Pin Code.</div>
                    </div>
                    <div class="form-group">
                        <label for="photo">Upload Photo:</label>
                        <asp:FileUpload ID="fuphoto" runat="server" AllowMultiple="True" />
                    </div>
                    <div class="form-group">
                        <label for="signature">Upload Signature</label>
                        <asp:FileUpload ID="fusignature" runat="server" AllowMultiple="True" />
                    </div>

                </form>
            </div>
        </div>
        <div class="row bg-light text-center pb-4 mt-0">
            <div class="col-lg-12 col-xl-12 col-md-12 col-sm-12 col-12">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn btn-info" />
                <asp:Button ID="btnclear" runat="server" Text="Clear" class="btn btn-danger" />
            </div>
        </div>
        


    </div>
</asp:Content>
