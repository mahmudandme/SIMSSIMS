<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="AddTeacher.aspx.cs" Inherits="SIMS.UI.Admin.AddTeacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
          <h3 class="page-header">Add New Teacher</h3>                        
            <div class="row">
<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
         <div class="form-group">
    <label for="inputdefault" style="float: left">Teacher name</label><br/>
         <asp:TextBox ID="teacherNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
  </div>         
</div>
<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
         <div class="form-group">
    <label for="inputdefault" style="float: left">Designation</label><br/>
         <asp:TextBox ID="designationTextBox" CssClass="form-control" runat="server"></asp:TextBox>
  </div>
         
</div>

       <%-- <div class="row placeholders">
 <div class="col-xs-6 col-sm-3 col-md-7 placeholder">        
     <span class="label label-success" style="float: left;font-size: 20px;position: relative" id="successStatusLabel" runat="server"></span>  
     <span class="label label-warning" style="float: left;font-size: 20px;position: relative" id="failStatusLabel" runat="server"></span>       
  </div>
     </div> --%>                                       
               
        </div>
            <div class="row">
<!-- the below code is for 3 columns in a row for all devices-->
<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
         <div class="form-group">
    <label for="inputdefault" style="float: left">Phone </label><br/>
         <asp:TextBox ID="phoneNumberTextBox" CssClass="form-control" runat="server"></asp:TextBox>
  </div>
         
</div>
<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
         <div class="form-group">
    <label for="inputdefault" style="float: left">Email</label><br/>
         <asp:TextBox ID="emailTextBox" CssClass="form-control" runat="server"></asp:TextBox>
  </div>         
</div>
                                             
               
        </div>
          
            <div class="row">
<!-- the below code is for 3 columns in a row for all devices-->
<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
         <div class="form-group">
    <label for="inputdefault" style="float: left">Gender</label><br/>
             <asp:DropDownList ID="genderDropDownList" Width="100%" Height="30px" CssClass="form-control" runat="server"></asp:DropDownList>
  </div>
         
</div>
<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
        <div class="form-group">
    <label for="inputdefault" style="float: left">Nationality</label><br/>
             <asp:DropDownList ID="nationalityDropDownList" Width="100%" Height="30px" CssClass="form-control" runat="server"></asp:DropDownList>
  </div>         
</div>                                                            
        </div>
            <div class="row">
<!-- the below code is for 3 columns in a row for all devices-->
<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
         <div class="form-group">
    <label for="inputdefault" style="float: left">Department</label><br/>
             <asp:DropDownList ID="departmentDropDownList" Width="100%" Height="30px" CssClass="form-control" runat="server"></asp:DropDownList>
  </div>
         
</div>
                                                           
        </div>             
            <div class="row">

<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
         <div class="form-group">
    <label for="inputdefault" style="float: left">Joining date</label><br/>
           <asp:TextBox ID="dateTextBox" CssClass="form-control" runat="server"></asp:TextBox>  
  </div>        
</div> 
<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
        <div class="form-group">
    <label for="inputdefault"  class="text-center" >Select date</label><br/>
            <asp:Calendar ID="joiningDateCalendar" runat="server" OnSelectionChanged="joiningDateCalendar_SelectionChanged"></asp:Calendar>
  </div>         
</div>                                                              
        </div>
            <div class="row">
<!-- the below code is for 3 columns in a row for all devices-->
<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
        
         
</div>
<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
        <div class="form-group">    
            <asp:Button ID="saveButton" runat="server" CssClass="btn btn-primary pull-right" Width="100px" Text="Save" OnClick="saveButton_Click"/>
  </div>         
</div>                                                             
        </div> 
              
</div> 


</asp:Content>
