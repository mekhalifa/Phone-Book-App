<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhoneBookApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container row">
    <div  class="col-md-8">
    <a runat='server' href='~/create' class="btn btn-dark btn-danger">Create Contact</a>
    
   <asp:Button ID="ButtonCSV" runat="server" OnClick="ButtonCSV_Click" Text="Create CSV" class="btn btn-default" />
    </div>
    <div class="right form-inline col-md-4">
        
          <asp:TextBox type="text" class="form-control" ID="searchword" name="searchword" runat="server" placeholder="Search"  > </asp:TextBox>

           <asp:Button ID="ButtonSearch" runat="server"  Text="Search" class="btn btn-default" type="submit" OnClick="ButtonSearch_Click"/>

    </div>
      </div>
    <hr />
   

   
    <table class="table">
        <thead class="thead-dark">
            <tr>

                <th scope="col">Name</th>
                <th scope="col">Phones</th>

            </tr>
        </thead>
        <tbody>

            <%
                var list = GetAll();
                foreach (var item in list)
                {

                    Response.Write("<tr><td>" + item.Name + "</td>");
                    Response.Write("<td>"+string.Join(" , ", item.PhoneNumbers.Select(x => x.Number).ToList())+"</td>");
                    Response.Write("");
                    Response.Write("<td>   <a class='btn btn-danger' runat='server' href='edit?id=" + item.ContactId + "' >Edit</a>");
                    Response.Write("  <a class='btn btn-danger' runat='server' href='AddPhone?id=" + item.ContactId + "' >Add Phone</a></td></tr>");

                }

            %>
        </tbody>
    </table>




</asp:Content>
