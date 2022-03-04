<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="NewRationCardRegistation.aspx.cs" Inherits="e_ration_card.NewRationCardRegistation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:70px;">
    <div class="row bg-light mb-3 text-center pt-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="nameofapplicant">Name of Applicant:</label>
                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtnameofapplicant" placeholder="Name of Applicant" name="nameofapplicant" required>
            </div>

            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="middlename">Middle Name:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtmiddlename" placeholder="Middle Name" name="middlename" required>
            </div>

            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="lastname">Last Name:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtlastname" placeholder="Last Name" name="lastname" required>
            </div>
        </div>

        <div class="row bg-light mb-3 text-center pt-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="email">Email:</label>
                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtemail" placeholder="Email" name="email" required>
            </div>

            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="dob">DOB:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtdob" placeholder="dd-mm-yy" name="dob" required>
            </div>

            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="lastname">Last Name:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtlastname" placeholder="Last Name" name="lastname" required>
            </div>
        </div>
<div>
    <li>Aadhar Card Number</li>
   <hr style="height:2px;border-width:0;color:gray;background-color:gray">
</div>
      <div class="row bg-light mb-3 text-center pt-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="nameofapplicant">Name of Applicant:</label>
                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtnameofapplicant" placeholder="Name of Applicant" name="nameofapplicant" required>
            </div>

            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="middlename">Middle Name:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtmiddlename" placeholder="Middle Name" name="middlename" required>
            </div>

            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="lastname">Last Name:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtlastname" placeholder="Last Name" name="lastname" required>
            </div>
        </div>

        </div>
</asp:Content>
