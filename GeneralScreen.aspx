<%@ Page Title="" Language="C#" MasterPageFile="~/Master/General.Master" AutoEventWireup="true" CodeBehind="GeneralScreen.aspx.cs" Inherits="e_ration_card.GeneralScreen" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-left: 15%; padding: 1px 16px;margin-top:0px;">
        <div class="panel panel-default" ">
           <div class="panel-body"  >         
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
                        <asp:Label ID="lblcardholdername" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
                    </div>
            </div>
            <div class="col-lg-4 col-xl-4 col-md-4 col-sm-12 col-12 ">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="rationcardno">Ration Card No:</label>
                        <asp:Label ID="lblrationca" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
                    </div>
            </div>
            <div class="col-lg-4 col-xl-4 col-md-4 col-sm-12 col-12 ">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        <label for="cardtype">Card Type:</label>
                       <asp:Label ID="lblcardtype" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
                    </div>
            </div>
        </div>

        <div class="row bg-light">
            <div class="col-lg-4 col-xl-4 col-md-4 col-sm-12 col-12 ">
                <form class="needs-validation" novalidate>
                    <div class="form-group">
                        &nbsp;<label for="mobile"> Mobile          :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
&nbsp;<asp:Label ID="lblmobileno" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
                    </div>
            </div>

            <div class="col-lg-4 col-xl-4 col-md-4 col-sm-12 col-12 ">                                         
                        <label for="address">Address:</label>
                        <textarea class="form-control w-50" name="address" id="txtaddress" runat="server" rows="3"  ></textarea>

                   
            </div>

            <div class="col-lg-4 col-xl-4 col-md-4 col-sm-12 col-12 ">               
                    <div class="form-group">
                        <label for="email">Email:</label>
                        <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>
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
                    <div class="modal-dialog modal-xl modal-dialog-centered">
                        <div class="modal-content">

                            <!-- Modal Header -->
                            <div class="modal-header">
                                <h4 class="modal-title">cereals</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>

                            <!-- Modal body -->
                            <div class="modal-body text-primary">
                                <asp:GridView ID="gvchangename" runat="server" HeaderStyle-BackColor="#ff9900" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
    AutoGenerateColumns="true" CssClass="table table-bordered table-responsive" Style="text-align: center" Width="100%">
       <EmptyDataTemplate>
       <CENTER><div>No records found.</div></CENTER>
    </EmptyDataTemplate>
</asp:GridView>
                            </div>

                            <!-- Modal footer -->
                            <div class="modal-footer">                              
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
