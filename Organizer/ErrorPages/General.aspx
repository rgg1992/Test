<%@ Page Title="Грешка" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="General.aspx.cs" Inherits="ErrorPages_General" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2>Възникна грешка</h2>
    <br />
    <h4>
        Възникна неочаквана грешка при обработката на вашата заявка. Молим да ни извините.
    </h4>
    <br />
    <asp:LinkButton ID="lnkButtonReturn" runat="server" OnClick="lnkButtonReturn_Click">Върнете се обратно на началната страница</asp:LinkButton>

</asp:Content>

