<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="PhoneBookApp.Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    
        <div class="form-group">
            <label for="Name1" class="col-sm-2 control-label">Name</label>
            <div class="col-sm-10">
                <asp:TextBox type="text" class="form-control" ID="Name1" runat="server" > </asp:TextBox>

            </div>
        </div>
    <br /><br />
    <div class="form-group">
            <label for="NationalId1" class="col-sm-2 control-label">National ID</label>
            <div class="col-sm-10">
                <asp:TextBox type="text" class="form-control" ID="NationalId1" runat="server" > </asp:TextBox>
            </div>
        </div>
    <br /><br />
       <%
           var list = GetPhoneNumbers();
           foreach (var i in list)
           {
               Response.Write("<div class='form-inline'><label for='Number"+i.PhoneNumberID+"' class='col-sm-2 control-label'>Phones</label><div class='col-sm-10'>");

               Response.Write("<p class='form-control' ID='Number"+i.PhoneNumberID+"' runat='server' value=''  >"+i.Number+" </p> ");

               Response.Write("  <a class='btn btn-danger btn-sm' runat='server' href='EditPhone?PhoneId=" + i.PhoneNumberID + "' >Edit Phone</a></div></div> <br /><br />");

           }
        %>

    <br />
    <br />
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">   
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Edit Contact" class="btn btn-default" />
            </div>
        </div>

</asp:Content>