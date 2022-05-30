<%@ Page Title="" Language="C#" MasterPageFile="~/Master/General.Master" AutoEventWireup="true" CodeBehind="GeneralProfile.aspx.cs" Inherits="e_ration_card.GeneralProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 15%; padding: 1px 16px; height: 100%; margin-top: 70px;" class="bg-light">
        <div class="row bg-light mb-3 text-center pt-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">              
                    <div class="form-group">
                        <label for="cardholdername">Card Holder Name:</label>
                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtcardholdername" runat="server" placeholder="Card Holder Name" name="cardholdername" readonly="readonly">
            </div>

            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
            
                    <div class="form-group">
                        <label for="rationcardno">Ration Card No:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtrationcardno" runat="server" placeholder="Ration Card No" name="rationcardno" >
            </div>

            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
               
                    <div class="form-group">
                        <label for="mobileno">Mobile No:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="number" id="txtmobileno" runat="server" placeholder="Mobile No" name="mobileno" >
            </div>
        </div>

        <div class="row bg-light mb-3 text-center  pt-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
               
                    <div class="form-group">
                        <label for="aadharno">Aadhar Card No:</label>
                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="number" id="txtaadharcardno" runat="server" placeholder="Aadhar Card No:" name="aadharno">
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                
                    <div class="form-group">
                        <label for="pancardno">Pan Card No:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtpanno" runat="server" placeholder="Pan Card No:" name="panno">
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                
                    <div class="form-group">
                        <label for="email">Email:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="email" id="txtemail" runat="server" placeholder="Email" name="email" readonly="readonly" >
            </div>
        </div>

        <div class="row bg-light mb-3  pt-3">
            <div class="col-lg-12 col-xl-12 col-md-12 col-sm-12 col-12 ">
                <asp:GridView ID="gvmemberlist" runat="server" AutoGenerateColumns="true"></asp:GridView>
            </div>
        </div>

        <div class="row bg-light mb-3 text-center  pt-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">               
                    <div class="form-group">
                        <label for="address">Address:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txtaddress" runat="server" placeholder="Address:" name="address">
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">             
                    <div class="form-group">
                        <label for="pincode">Pin Code No:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="number" id="txtpincode" runat="server" placeholder="Pin Code No:" name="pincode">
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">              
                    <div class="form-group">
                        <label for="annualincome">Annual Income:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">               
                <asp:DropDownList ID="ddlannualincome" DataTextField="annual_income" DataValueField="typeof_rationcard" runat="server" OnSelectedIndexChanged="ddlannualincome_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
            </div>
        </div>
        <div class="row bg-light mb-3 text-center  pt-3">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                    <div class="form-group">
                        <label for="utype">State:</label>
                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <asp:DropDownList ID="ddlstate" runat="server" DataTextField="state_name" DataValueField="state_id" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true">                   
                </asp:DropDownList>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">               
                    <div class="form-group">
                        <label for="utype">District:</label>
                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <asp:DropDownList ID="ddldistrict" runat="server" DataTextField="district_name" DataValueField="district_name">
                    
                </asp:DropDownList>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                
                    <div class="form-group">
                        <label for="utype">Constituency:</label>
                        </div>
                    </div>
                    <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                        <asp:DropDownList ID="ddlconstituency" runat="server" DataTextField="consitiuency_name" DataValueField="consitiuency_name">                           
                        </asp:DropDownList>
                    </div>
            </div>
        <div class="row bg-light mb-3 text-center">
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
               
                    <div class="form-group">
                        <label for="typeofrationcard">Type of Ration Card:</label>

                    </div>
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                <input type="text" id="txttypeofrationcard" runat="server" placeholder="" name="typeofrationcard" />
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
               
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
                
            </div>
            <div class="col-lg-2 col-xl-2 col-md-2 col-sm-12 col-12">
           <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Add Members</button>
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
                                <h4 class="modal-title">Members Details</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>

                            <!-- Modal body -->
          <div class="container"> 
            <table class="table" id="maintable">  
                <thead>  
                    <tr>  
                        <th>Name:</th>  
                        <th>Relation:</th>  
                        <th>Age:</th>  
                        <th>DOB:</th>
                        <th>AadharNo:</th>
                    </tr>  
                </thead>  
                <tbody>  
                    <tr class="data-contact-person">  
                        <td>  
                            <input type="text" name="name" class="form-control name01" /></td>  
                        <td>  
                         
                            <asp:DropDownList ID="ddlrelation" class="form-control relation01" runat="server">
                            <asp:ListItem Value="SELECT" Selected="True">**SELECT**</asp:ListItem>
                            <asp:ListItem Value="Father" Selected="False">Father</asp:ListItem>
                            <asp:ListItem Value="Mother" Selected="False">Mother</asp:ListItem>
                            <asp:ListItem Value="Brother" Selected="False">Brother</asp:ListItem>
                            <asp:ListItem Value="Sister" Selected="False">Sister</asp:ListItem>
                            <asp:ListItem Value="Son" Selected="False">Son</asp:ListItem>
                            <asp:ListItem Value="Daughter" Selected="False">Daughter</asp:ListItem>
                            <asp:ListItem Value="Uncle" Selected="False">Uncle</asp:ListItem>
                            <asp:ListItem Value="Aunty" Selected="False">Aunty</asp:ListItem>
                            <asp:ListItem Value="Wife" Selected="False">Wife</asp:ListItem>
                            <asp:ListItem Value="Nephew" Selected="False">Nephew</asp:ListItem>
                            <asp:ListItem Value="Niece" Selected="False">Niece</asp:ListItem>
                            <asp:ListItem Value="Sister In Law" Selected="False">Sister In Law</asp:ListItem>
                           
                            </asp:DropDownList>

                        <td>  
                            <input type="text" name="age" class="form-control age01" /></td>  
                         <td>  
                            <input type="date" name="dob" class="form-control dob01" /></td>                        
                         <td>  
                            <input type="text" name="aadharno" class="form-control aadharno01" /></td>
                        <td>  
                         <td>  
                            <%--<input type="text" ranat="server" id="txtuserid" name="userid" class="form-control userid01" /></td>--%>
                        <asp:TextBox ID="txtuserid" runat="server" name="userid" class="form-control userid01" Visible="false"></asp:TextBox>
                        <td>  
                            <button type="button" id="btnAdd" class="btn btn-xs btn-primary classAdd">Add</button>  
                        </td>  
                    </tr>  
                </tbody>  
            </table>  
              <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
        </div>  

                            <!-- Modal footer -->
                            <div class="modal-footer">
                                <%--<asp:Button ID="btnaddmembers" runat="server" Text="Add" class="btn btn-primary" />--%>
                                <button type="button" id="btnSubmits" class="btn btn-primary">Submit</button> 
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                            </div>

                        </div>
                    </div>
                </div>

            </div>

        </section>
         <div class="row bg-light text-center pb-4 mt-0">
            <div class="col-lg-12 col-xl-12 col-md-12 col-sm-12 col-12">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn btn-info" OnClick="btnsubmit_Click" />
                <asp:Button ID="btnupdate" runat="server" Text="Update" class="btn btn-info" OnClick="btnupdate_Click" />
                <asp:Button ID="btnclear" runat="server" Text="Clear" class="btn btn-danger" OnClick="btnclear_Click" />
            </div>
        </div>
        </div>

    <script>
        debugger
        function ValidationGeneralf() {

            var rationcardno = document.getElementById("txtrationcardno").value;
            var address = document.getElementById("txtaddress").value;
            var aadharcardno = document.getElementById("txtaadharcardno").value;
            var panno = document.getElementById("txtpanno").value;
            var pincode = document.getElementById("txtpincode").value;
            var typeofrationcard = document.getElementById("txttypeofrationcard").value;

            if (rationcardno == "") {

                alert("Please Enter Rationcardno");
                txtname.focus();
                return false;
            }
            if (address == "") {
                alert("Please Enter address");
                txtusername.focus();
                return false;
            }
            if (aadharcardno == "") {
                alert("Please Enter aadharcard No");
                return false;
            }
            if (panno == "") {
                alert("Please Enter  Panno");
                return false;
            }
            if (pincode == "") {
                alert("Please Enter Pincode");
                return false;
            }
            if (typeofrationcard == "") {
                alert("Please Enter typeof rationcard");
                return false;
            }
            if (document.getElementById('<%=ddlstate.ClientID %>').selectedIndex == 0) {
               alert("Please Select State");
               return false;
           }
           if (document.getElementById('<%=ddldistrict.ClientID %>').selectedIndex == 0) {
                alert("Please Select District");
                return false;
            }
           if (document.getElementById('<%=ddlconstituency.ClientID %>').selectedIndex == 0) {
               alert("Please Select Constituency");
               return false;
           }
           else {
               return true;
           }
       }



       
            $(document).ready(function () {
                $(document).on("click", ".classAdd", function () { //
                    var rowCount = $('.data-contact-person').length + 1;
                    var contactdiv = '<tr class="data-contact-person">' +
                        '<td><input type="text" name="name' + rowCount + '" class="form-control name01" /></td>' +
                    /*'<td><input type="text" name="relation' + rowCount + '" class="form-control relation01" /></td>' +*/

                        '<td><select name="relation' + rowCount + '" class="form-control relation01" ><option value="SELECT">**SELECT**</option>< option value = "Father" > Father</option><option value="Mother">Mother</option><option value="Brother">Brother</option><option value="Sister">Sister</option></td >'+

                     
                        '<td><input type="text" name="age' + rowCount + '" class="form-control age01" /></td>' +
                        '<td><input type="date" name="dob' + rowCount + '"class="form-control dob01" /></td>' +
                        '<td><input type="text" name="aadharno' + rowCount + '"class="form-control aadharno01" /></td>'+
                        '<td><button type="button" id="btnAdd" class="btn btn-xs btn-primary classAdd">Add</button></td>' +
                        '<td><button type="button" id="btnDelete" class="deleteContact btn btn btn-danger btn-xs">Remove</button></td>' +
                        '</tr>';
                    $('#maintable').append(contactdiv); // Adding these controls to Main table class  
                });  
            });  

        $(document).on("click", ".deleteContact", function () {
            $(this).closest("tr").remove(); // closest used to remove the respective 'tr' in which I have my controls   
        }); 



        function getAllEmpData() {
            var data = [];
            $('tr.data-contact-person').each(function () {
                var Name = $(this).find('.name01').val();//Bind to the first name with class f-name01                 
                var Relation = $(this).find('.relation01').val();//Bind to the emailId with class email01
                var Age = $(this).find('.age01').val();//Bind to the first name with class f-name01 
                var DOB = $(this).find('.dob01').val();//Bind to the first name with class f-name01 
                var Aadharno = $(this).find('.aadharno01').val();//Bind to the first name with class f-name01 
                var Userid = $(this).find('.userid01').text()//Bind to the first name with class f-name01 
                var alldata = {
                    'Name': Name, //FName as per Employee class name in .cs  
                    'Relation': Relation, //LName as per Employee class name in .cs  
                    'Age': Age, //EmailId as per Employee class name in .cs   
                    'DOB': DOB, //EmailId as per Employee class name in .cs   
                    'Aadharno': Aadharno, //EmailId as per Employee class name in .cs  
                    'Userid': Userid //EmailId as per Employee class name in .cs  
                }
                data.push(alldata);
            });
            console.log(data);//  
            return data;
        }
        $("#btnSubmits").click(function () {
            var data = JSON.stringify(getAllEmpData());
            //console.log(data);    
            $.ajax({
                url: 'GeneralProfile.aspx/SaveData',//GeneralProfile.aspx is the page   
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ 'empdata': data }),
                success: function () {
                    alert("Data Added Successfully");                   

                },
                error: function () {
                    alert("Error while inserting data");
                }
            });
        });  


    </script>--%>
</asp:Content>
