<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="SemisterRegistration.aspx.cs" Inherits="SIMS.UI.Student.SemisterRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
          <h3 class="page-header">Semister registration</h3>                        
     <div class="row placeholders">
    <div class="col-xs-5 col-sm-6 col-md-4 placeholder">                                 
        <table class="table table-responsive">
            <tr>
                <td colspan="2">
                    <asp:Label ID="headerTextLabel" CssClass="text-info text-center " Width="400px" runat="server" Text="Click the register button to complete the registration"></asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="text-primary" Text="Student ID:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="studentIdLabel" CssClass="text-primary"  runat="server" Text=""></asp:Label> 
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" CssClass="text-primary" Text="Department Name:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="departmentNameLabel" CssClass="text-primary"  runat="server" Text=""></asp:Label> 
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" CssClass="text-primary"  runat="server" Text="Session:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="sessionLabel" CssClass="text-primary"  runat="server" Text=""></asp:Label> 
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" CssClass="text-primary"  runat="server" Text="Year-Term:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="yearTermLabel" CssClass="text-primary"  runat="server" Text=""></asp:Label> 
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="regStatusLabel" runat="server" CssClass="text-success"  Text=""></asp:Label>  
                </td>
                <td>
                    <asp:Button ID="registerButton" CssClass="btn btn-primary pull-right"   runat="server" Text="Register" OnClick="registerButton_Click" />  
                </td>
            </tr>
        </table>      
  </div>
     </div>        
        <div class="row placeholders">
 <div class="col-xs-6 col-sm-3 col-md-7 placeholder">        
     <span class="label label-success" style="float: left;font-size: 20px;position:relative" id="successStatusLabel" runat="server"></span>  
     <span class="label label-warning" style="float: left;font-size: 20px;position:relative" id="failStatusLabel" runat="server"></span>       
  </div>
     </div> 
      <div class="row placeholders">
    <div class="col-xs-6 col-sm-3 col-md-4 placeholder">                            
     <div class="form-group">
    <label for="inputdefault" style="float: left">Total Courses: </label><br/>
         <asp:TextBox ID="courseNumberTextBox" CssClass="form-control" ReadOnly="True" runat="server"></asp:TextBox>
  </div> 
        <div class="form-group">
    <label for="inputdefault" style="float: left">Total credit: </label><br/>
         <asp:TextBox ID="totalCreditTextBox" CssClass="form-control" ReadOnly="True" runat="server"></asp:TextBox>
  </div>               
  </div>
     </div>                                          
        <div class="row placeholders">
 <div class="col-xs-6 col-sm-6 col-md-9 placeholder"> 
     <asp:GridView ID="courseGridView" CssClass="table table-hover table-bordered" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
         <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
         <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
         <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
         <RowStyle BackColor="White" ForeColor="#003399" />
         <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
         <SortedAscendingCellStyle BackColor="#EDF6F6" />
         <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
         <SortedDescendingCellStyle BackColor="#D6DFDF" />
         <SortedDescendingHeaderStyle BackColor="#002876" />
         
     </asp:GridView>           
  </div>
     </div>        
        </div>
</asp:Content>
