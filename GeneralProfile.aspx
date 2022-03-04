<%@ Page Title="" Language="C#" MasterPageFile="~/Master/General.Master" AutoEventWireup="true" CodeBehind="GeneralProfile.aspx.cs" Inherits="e_ration_card.GeneralProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 15%; padding: 1px 16px; height: 100%; margin-top: 70px;" class="bg-light">
        <div class="row bg-light mb-3 text-center pt-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="cardholdername">Card Holder Name:</label>
                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtcardholdername" placeholder="Card Holder Name" name="cardholdername" required>
            </div>

            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="rationcardno">Ration Card No:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtrationcardno" placeholder="Ration Card No" name="rationcardno" required>
            </div>

            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="mobileno">Mobile No:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtmobileno" placeholder="Mobile No" name="mobileno" required>
            </div>
        </div>

        <div class="row bg-light mb-3 text-center  pt-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="aadharno">Aadhar Card No:</label>
                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtaadharno" placeholder="Aadhar Card No:" name="aadharno" required>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="pancardno">Pan Card No:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtpanno" placeholder="Pan Card No:" name="panno" required>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="email">Email:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtemail" placeholder="Email" name="email" required>
            </div>
        </div>

        <div class="row bg-light mb-3  pt-3">
            <div class="col-lg-12 col-xl-12 col-md-12 col-sm-12 col-12 ">
                <asp:GridView ID="gvmemberlist" runat="server" AutoGenerateColumns="true"></asp:GridView>
            </div>
        </div>

        <div class="row bg-light mb-3 text-center  pt-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="address">Address:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtaddress" placeholder="Address:" name="address" required>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="pincode">Pin Code No:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtpincode" placeholder="Pin Code No:" name="pincode" required>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="annualincome">Annual Income:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtannualincome" placeholder="Annual Income" name="annualincome" required>
            </div>
        </div>
        <div class="row bg-light mb-3 text-center">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
               
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="typeofrationcard">Type of Ration Card:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txttypeofrationcard" placeholder="" name="typeofrationcard" required>
            </div>
        </div>
        <div class="row bg-light mb-3 text-center  pt-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="utype">State:</label>
                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <asp:DropDownList ID="ddlstate" runat="server">
                    <asp:ListItem Value="value" Selected="True">**SELECT**</asp:ListItem>
                    <asp:ListItem Value="value" Selected="False">Uttar pardesh</asp:ListItem>
                    <asp:ListItem Value="value" Selected="False">Maharashtra</asp:ListItem>
                    <asp:ListItem Value="value" Selected="False">West Bengal </asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="utype">District:</label>
                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="value" Selected="True">**SELECT**</asp:ListItem>
                    <asp:ListItem Value="value" Selected="False">Mumbai City</asp:ListItem>
                    <asp:ListItem Value="value" Selected="False">Mumbai Suburban</asp:ListItem>
                    <asp:ListItem Value="value" Selected="False">Nagpur </asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="utype">Constituency:</label>
                        </div>
                    </div>
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                        <asp:DropDownList ID="ddlconstituency" runat="server">
                            <asp:ListItem Value="value" Selected="True">**SELECT**</asp:ListItem>
                            <asp:ListItem Value="value" Selected="False">Consumer</asp:ListItem>
                            <asp:ListItem Value="value" Selected="False">Distributor</asp:ListItem>
                            <asp:ListItem Value="value" Selected="False">Govt</asp:ListItem>
                        </asp:DropDownList>
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
