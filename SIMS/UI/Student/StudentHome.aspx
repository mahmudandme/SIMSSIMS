<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="SIMS.UI.Student.StudentHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
          <h3 class="page-header">Your basic information</h3>
                        
     <div class="row placeholders">
    <div class="col-xs-6 col-sm-3 col-md-4 placeholder">  
        <table class="table table-responsive">
            <tr>
                <th colspan="3"> You are belong to the following information</th>
            </tr>
             <tr>
               <td>
                    <asp:Label ID="Label10" Width="200px" CssClass="text-primary" runat="server" Text="Label">Student ID:</asp:Label></td>
                <td>
                    <asp:TextBox ID="idTextBox" runat="server" ReadOnly="True" CssClass="form-control" Width="200px"></asp:TextBox>
                </td>                
                    <td >
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" Width="200px" CssClass="text-primary" runat="server" Text="Label">Student Name:</asp:Label></td>
                <td>
                    <asp:TextBox ID="nameTextBox" runat="server" ReadOnly="True"  CssClass="form-control" Width="200px"></asp:TextBox></td>                
                    <td >
                   </td>
            </tr>
            <tr>
             <td>
                    <asp:Label ID="Label8" Width="200px" CssClass="text-primary" runat="server" Text="Label">Gender:</asp:Label></td>
                <td>                   
                    <asp:TextBox ID="genderTextBox" runat="server" ReadOnly="True"  Width="200px" CssClass="form-control"></asp:TextBox>
                </td>                
                    <td></td>
            </tr>
            <tr>
               <td>
                    <asp:Label ID="Label7" Width="200px" CssClass="text-primary" runat="server" Text="Label">Nationality:</asp:Label></td>
                <td>                   
                    <asp:TextBox ID="nationalityTextBox" runat="server" ReadOnly="True"  Width="200px" CssClass="form-control"></asp:TextBox>
                </td>                
                    <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" Width="200px" CssClass="text-primary" runat="server" Text="Label">Department Name:</asp:Label></td>
                <td>                   
                    <asp:TextBox ID="departmentNameTextBox" ReadOnly="True" runat="server" Width="200px" CssClass="form-control"></asp:TextBox>
                </td>                
                    <td></td>
            </tr>
            <tr>
               <td>
                    <asp:Label ID="Label5" Width="200px" CssClass="text-primary" runat="server" Text="Label">Session:</asp:Label></td>
                <td>                   
                    <asp:TextBox ID="sessionTextBox" ReadOnly="True" runat="server" Width="200px" CssClass="form-control"></asp:TextBox>
                </td>                
                    <td></td>
            </tr>
            <tr>
               <td>
                    <asp:Label ID="Label4" Width="200px" CssClass="text-primary" runat="server" Text="Label">Email:</asp:Label></td>
                <td>                   
                    <asp:TextBox ID="emailTextBox" runat="server" ReadOnly="True" TextMode="Email" Width="200px" CssClass="form-control"></asp:TextBox>
                </td>                
                    <td></td>
            </tr>
            <tr>
               <td>
                    <asp:Label ID="Label3" Width="200px" CssClass="text-primary" runat="server" Text="Label">Phone:</asp:Label></td>
                <td>                   
                    <asp:TextBox ID="phoneTextBox" runat="server" ReadOnly="True" Width="200px" CssClass="form-control"></asp:TextBox>
                </td>                
                    <td>
                   
                    </td> 
                
               
            </tr>
            <tr>
              <td>
                    <asp:Label ID="Label2" Width="200px" CssClass="text-primary" runat="server" Text="Label">Present Address:</asp:Label></td>
                <td>                   
                    <asp:TextBox ID="presentAddressTextBox" runat="server" ReadOnly="True" TextMode="MultiLine" Width="200px" CssClass="form-control"></asp:TextBox>
                </td>                
                   <td>
                    
                   </td> 
               
               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" Width="200px" CssClass="text-primary" runat="server" Text="Label">Permanent Address:</asp:Label></td>
                <td>                   
                    <asp:TextBox ID="permanentAddressTextBox" ReadOnly="True" runat="server" TextMode="MultiLine" Width="200px" CssClass="form-control"></asp:TextBox>
                </td>                
                    <td></td>
            </tr>                          
            <tr>                
                <td colspan="2">
                     <span class="label label-warning" style="float: left;font-size: 20px;position: relative" id="failStatusLabel" runat="server"></span> 
                    <span class="label label-warning" style="float: left;font-size: 20px;position: relative" id="successStatusLabel" runat="server"></span> 
                </td>                
            </tr>
        </table>                            
            </div> 
          </div> 
       </div>          
</asp:Content>
