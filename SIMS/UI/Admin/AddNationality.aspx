<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="AddNationality.aspx.cs" Inherits="SIMS.UI.Admin.AddNationality" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/Styles/addDepartmentStyleSheet.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
          <h3 class="page-header">Add New Nationality</h3>
                        
     <div class="row placeholders">
    <div class="col-xs-6 col-sm-3 col-md-4 placeholder">
         
  
       
  
        
     <div class="form-group">
    <label for="inputdefault" style="float: left">Nationality</label><br/>
         <asp:TextBox ID="nationalityNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
  </div>
        <div class="myButtonClass">
           
            <asp:Button ID="saveNationalityButton" CssClass="btn btn-default" runat="server" Text="Save" OnClick="saveNationalityButton_Click"/>
  
        </div>
       

  </div>
     </div> 
       
        <div class="row placeholders">
 <div class="col-xs-6 col-sm-3 col-md-7 placeholder">        
     <span class="label label-success" style="float: left;font-size: 20px;position:relative" id="successStatusLabel" runat="server"></span>  
     <span class="label label-warning" style="float: left;font-size: 20px;position:relative" id="failStatusLabel" runat="server"></span>       
  </div>
     </div>  
        
        
        
                
        <div class="row placeholders">
 <div class="col-xs-6 col-sm-3 col-md-7 placeholder">        
     <asp:GridView ID="nationalityGridView" CssClass="table table-responsive table-hover" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
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
