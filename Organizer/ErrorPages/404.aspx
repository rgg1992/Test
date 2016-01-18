<%@ Page Title="Грешка" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="ErrorPages_404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <h2>Страницата не беше намерена.</h2>
    <br />
    <h4>
        Страницата, която заявихте не може да бъде намерена.
    </h4>
    <br />
    <asp:LinkButton ID="lnkButtonReturn" runat="server" OnClick="lnkButtonReturn_Click">Върнете се обратно на началната страница</asp:LinkButton>

</asp:Content>

