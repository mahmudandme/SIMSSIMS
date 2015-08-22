<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="AddStudentResult.aspx.cs" Inherits="SIMS.UI.Admin.AddStudentResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
        <h3 class="page-header">Add student result</h3>
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                <div class="form-group">
                    <label for="inputdefault" style="float: left">Select Department</label><br />
                    <asp:DropDownList ID="departmentDropDownList" Width="100%" Height="30px" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="departmentDropDownList_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                <div class="form-group">
                    <label for="inputdefault" style="float: left">Select Session</label><br />
                    <asp:DropDownList ID="sessionDropDownList" Width="100%" Height="30px" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="sessionDropDownList_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                <div class="form-group">
                    <label for="inputdefault" style="float: left">Select Year Term</label><br />
                    <asp:DropDownList ID="yearTermDropDownList" Width="100%" Height="30px" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="yearTermDropDownList_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                <div class="form-group">
                    <label for="inputdefault" style="float: left">Select StudentId</label><br />
                    <asp:DropDownList ID="studentIdDropDownList" Width="100%" Height="30px" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="studentIdDropDownList_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-10 col-md-10 col-sm-4 col-xs-10">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:Table ID="gpaTable" runat="server">
                        
                    </asp:Table>
                </asp:Panel>
            </div>
        </div>
        <div class="myButtonClass">
            <asp:Button ID="saveStudentResultButton" CssClass="btn btn-primary pull-left" Width="100px" runat="server" Text="Save" OnClick="saveStudentResultButton_Click" />
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
