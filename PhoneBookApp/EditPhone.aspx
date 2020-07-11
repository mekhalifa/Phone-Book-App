<%@ Page Title="EditPhone" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPhone.aspx.cs" Inherits="PhoneBookApp.EditPhone" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


<div class="form-group">
            <label for="Number1" class="col-sm-2 control-label">Phone</label>
            <div class="col-sm-10">
                 <asp:TextBox type="text" class="form-control" ID="Number1" runat="server" > </asp:TextBox>
            </div>
        </div>
    <br />
    <br />
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Edit Phone" class="btn btn-danger" />
            </div>
        </div>

    </asp:Content>