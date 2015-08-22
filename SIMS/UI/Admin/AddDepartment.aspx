<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs" Inherits="SIMS.UI.Admin.AddDepartment" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
    <link href="../../Content/Styles/addDepartmentStyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    
    <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
          <h3 class="page-header">Add New Department</h3>
                        
     <div class="row placeholders">
    <div class="col-xs-6 col-sm-3 col-md-4 placeholder">
         
  
       
  
        
     <div class="form-group">
    <label for="inputdefault" style="float: left">Department Name</label><br/>
         <asp:TextBox ID="departmentNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
  </div>
         <div class="form-group">
    <label for="inputdefault" style="float: left">Select Faculty</label><br/>
             <asp:DropDownList ID="facultyDropDownList" Width="100%" Height="30px" CssClass="form-control" runat="server"></asp:DropDownList>
  </div>
        <div class="myButtonClass">
           
            <asp:Button ID="saveDepartmentButton" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="saveDepartmentButton_Click" />
  
        </div>
       

  </div>
     </div> 
       
        <div class="row placeholders">
 <div class="col-xs-6 col-sm-3 col-md-7 placeholder">        
     <span class="label label-success" style="float: left;font-size: 20px;position: relative" id="successStatusLabel" runat="server"></span>  
     <span class="label label-warning" style="float: left;font-size: 20px;position: relative" id="failStatusLabel" runat="server"></span>       
  </div>
     </div>                                        
        <div class="row placeholders">
 <div class="col-xs-6 col-sm-3 col-md-7 placeholder">        
     <asp:GridView ID="departmentGridView" AutoGenerateColumns="False" CssClass="table table-hover table-responsive" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
         <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
         <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
         <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
         <RowStyle BackColor="White" ForeColor="#003399" />
         <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
         <SortedAscendingCellStyle BackColor="#EDF6F6" />
         <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
         <SortedDescendingCellStyle BackColor="#D6DFDF" />
         <SortedDescendingHeaderStyle BackColor="#002876" />
         
        <Columns>
             <asp:TemplateField HeaderText="Serial">
                 <ItemTemplate>
                     <%#Container.DataItemIndex+1 %>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField HeaderText="Department Name" DataField="DepartmentName"/>
             <asp:BoundField HeaderText="Faculty Name" DataField="FacultyName"/>
         </Columns>
     </asp:GridView>         
  </div>
     </div>        
        </div>
   
 
    
    

</asp:Content>
