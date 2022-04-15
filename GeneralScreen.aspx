<%@ Page Title="" Language="C#" MasterPageFile="~/Master/General.Master" AutoEventWireup="true" CodeBehind="GeneralScreen.aspx.cs" Inherits="e_ration_card.GeneralScreen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="border border-dark rounded" style="margin-left: 15%; padding: 1px 16px; height: 100%; margin-top:0px;">
        <div class="panel panel-default">
           <div class="panel-body">         
        <div class="row bg-light pt-3" style="padding-left:70%;">
            <div class="col-lg-12 col-xl-12 col-md-12 col-sm-12 col-12 ">
                 <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Check Units</button>
         <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModalThum">Biometric History</button>
                </div>
            </div>

        <div class="row bg-light pt-3">
            <div class="col-lg-4 col-xl-4 col-md-4 col-sm-12 col-12 ">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="cardholdername">Card Holder Name</label>
                        <input type="text" id="txtcardholdername" placeholder="" name="cardholdername" required>
                    </div>
            </div>
            <div class="col-lg-4 col-xl-4 col-md-4 col-sm-12 col-12 ">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="rationcardno">Ration Card No:</label>
                        <input type="text" id="txtrationcardno" placeholder="" name="rationCardNo" required>
                    </div>
            </div>
            <div class="col-lg-4 col-xl-4 col-md-4 col-sm-12 col-12 ">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="cardtype">Card Type:</label>
                        <input type="text" id="txtcardtype" placeholder="" name="cardtype" required>
                    </div>
            </div>
        </div>

        <div class="row bg-light">
            <div class="col-lg-4 col-xl-4 col-md-4 col-sm-12 col-12 ">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        &nbsp;<label for="mobile"> Mobile          :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
&nbsp;<input type="text" id="txtmobile" placeholder="" name="mobile" required>
                    </div>
            </div>

            <div class="col-lg-4 col-xl-4 col-md-4 col-sm-12 col-12 ">                                         
                        <label for="address">Address:</label>
                        <textarea class="form-control w-50" name="address" id="txtaddress" rows="3"  ></textarea>

                   
            </div>

            <div class="col-lg-4 col-xl-4 col-md-4 col-sm-12 col-12 ">               
                    <div class="form-group">
                        <label for="email">Email:</label>
                        <input type="text" id="txtemail" placeholder="" name="email" required>
                    </div>
            </div>

        </div>

        <div class="row bg-light pt-3">
            <div class="col-lg-12 col-xl-12 col-md-12 col-sm-12 col-12 ">
                <asp:GridView ID="gvmemberlist" runat="server" AutoGenerateColumns="true"></asp:GridView>
    </div>
    </div>

                        </div>
                      </div>
        
        <section>
            <div class="container">
                <!-- The Modal -->
                <div class="modal fade" id="myModal">
                    <div class="modal-dialog modal-dialog-centered">
                        <div class="modal-content">

                            <!-- Modal Header -->
                            <div class="modal-header">
                                <h4 class="modal-title">cereals</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>

                            <!-- Modal body -->
                            <div class="modal-body text-primary">
                                <form action="" class="needs-validation" novalidate>
                                    <div class="form-group">
                                        <label for="uname">Username:</label>
                                        <input type="text" class="form-control" id="uname" placeholder="Enter username" name="uname" required>
                                        <div class="valid-feedback">Valid.</div>
                                        <div class="invalid-feedback">Please fill out this field.</div>
                                    </div>
                                    <div class="form-group">
                                        <label for="pwd">Password:</label>
                                        <input type="password" class="form-control" id="pwd" placeholder="Enter password" name="pswd" required>
                                        <div class="valid-feedback">Valid.</div>
                                        <div class="invalid-feedback">Please fill out this field.</div>
                                    </div>
                                </form>
                            </div>

                            <!-- Modal footer -->
                            <div class="modal-footer">
                                <asp:Button ID="btnlogin" runat="server" Text="Login" class="btn btn-primary" />
                                <asp:Button ID="btnsignup1" runat="server" Text="Sign Up" class="btn btn-primary" data-toggle="modal" data-target="#myModalSignUp" />
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                            </div>

                        </div>
                    </div>
                </div>

            </div>

        </section>

        <section>
            <div class="container">
                <!-- The Modal -->
                <div class="modal fade" id="myModalThum">
                    <div class="modal-dialog modal-dialog-centered">
                        <div class="modal-content">

                            <!-- Modal Header -->
                            <div class="modal-header">
                                <h4 class="modal-title">cereals</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>

                            <!-- Modal body -->
                            <div class="modal-body text-primary">
                                <form action="" class="needs-validation" novalidate>
                                    <div class="form-group">
                                        <label for="uname">Username:</label>
                                        <input type="text" class="form-control" id="uname" placeholder="Enter username" name="uname" required>
                                        <div class="valid-feedback">Valid.</div>
                                        <div class="invalid-feedback">Please fill out this field.</div>
                                    </div>
                                    <div class="form-group">
                                        <label for="pwd">Password:</label>
                                        <input type="password" class="form-control" id="pwd" placeholder="Enter password" name="pswd" required>
                                        <div class="valid-feedback">Valid.</div>
                                        <div class="invalid-feedback">Please fill out this field.</div>
                                    </div>
                                </form>
                            </div>

                            <!-- Modal footer -->
                            <div class="modal-footer">
                                <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-primary" />
                                <asp:Button ID="Button2" runat="server" Text="Sign Up" class="btn btn-primary" data-toggle="modal" data-target="#myModalSignUp" />
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                            </div>

                        </div>
                    </div>
                </div>

            </div>

        </section>
    </div>
</asp:Content>
