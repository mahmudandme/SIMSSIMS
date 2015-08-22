<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="ShowAdmins.aspx.cs" Inherits="SIMS.UI.Admin.ShowAdmins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         
     <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
          <h3 class="page-header">Add New Faculty</h3>
                        
     <div class="row placeholders">
    <div class="col-xs-6 col-sm-3 col-md-4 placeholder">
         
  
       
  
        
     <div class="form-group">
    <label for="inputdefault" style="float: left">Enter name: </label><br/>
         <asp:TextBox ID="adminNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="pull-right" ControlToValidate="adminNameTextBox" ErrorMessage="Name is required" ForeColor="red"></asp:RequiredFieldValidator>
  </div>
         <div class="form-group">
    <label for="inputdefault" style="float: left">Phone: </label><br/>
         <asp:TextBox ID="phoneTextBox" CssClass="form-control" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="red" ControlToValidate="phoneTextBox" CssClass="pull-right" runat="server" ErrorMessage="Phone number is required"></asp:RequiredFieldValidator>
  </div>
         <div class="form-group">
    <label for="inputdefault" style="float: left">Enter email: </label><br/>
         <asp:TextBox ID="emailTextBox" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="red" runat="server" CssClass="pull-right" ControlToValidate="emailTextBox" ErrorMessage="Emai is required"></asp:RequiredFieldValidator>
  </div>
        <br/>
        <div class="myButtonClass">           
            <asp:Button ID="saveAdminButton" CssClass="btn btn-primary pull-right" runat="server" Width="100px" Text="Save" OnClick="saveAdminButton_Click"/>  
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
 <div class="col-xs-12 col-sm-12 col-md-12 placeholder">        
    <%-- GridView--%>
     <asp:GridView ID="adminGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
         <Columns>
             <asp:TemplateField HeaderText="No.">
             <ItemTemplate>
                 <%# Container.DataItemIndex +1 %>
             </ItemTemplate>
         </asp:TemplateField>
         <asp:BoundField HeaderText="Name" DataField="Name"/>
         <asp:BoundField HeaderText="Phone" DataField="Phone"/>
         <asp:BoundField HeaderText="Email" DataField="Email"/>
         </Columns>
         
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
