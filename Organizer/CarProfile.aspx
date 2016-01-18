<%@ Page Title="Гараж" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CarProfile.aspx.cs" Inherits="CarProfile" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
        
    <br />

    
    <table style="width: 100%; height: 100%">
        <tr>
            <td><div style="float:left"><h2>Моите автомобили</h2></div></td>
            <td></td>
            <td><div style="float:left"><asp:Button ID="btnAddNew" OnClick="btnAddNew_Click" Text="Добави нов" Font-Size="22" runat="server" style="margin-left:20px" CssClass="btn"/></div></td>
        </tr>
    </table>
     
<%--    <div>
        <asp:LinkButton ID="lnkButton" OnClick="lnkButton_Click" Font-Size="20" runat="server"></asp:LinkButton>
    </div>--%>
        <asp:Panel ID="Panel1" runat="server">
    <%--<table style="width: 100%; height: 100%">
        <tr>
            <td rowspan="5" style="width: 20%;">
                <asp:Image ID="imgProfile" runat="server" ImageUrl="~/no_photo.png" Width="300px" style="min-height: 150px; min-width: 100px" Height="150px" />
            </td>
            <td colspan="4" style="height: 10px">

                <asp:Label ID="lblCarInfo" runat="server" Text="дизел, 1.9l, 101 к.с., 2003" Font-Size="10"></asp:Label>

            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblAverageCons" runat="server" Text="5,57" Style="margin-left: 10px" Font-Bold="true" Font-Size="35"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblAverageConsInfo" runat="server" Text="l/100 km Дизел" Style="margin-left: 10px" Font-Size="10"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbfillUps" Width="100%" runat="server" Text="40" Font-Size="11" Font-Bold="true" Style="margin-left: 10px; text-align: center"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbMinCons" Width="100%" runat="server" Text="3,82" Font-Size="11" Font-Bold="true" Style="margin-left: 10px; text-align: center"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbKM" Width="100%" runat="server" Text="24942" Font-Size="11" Font-Bold="true" Style="margin-left: 10px; text-align: center"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbPricePerKM" Width="100%" runat="server" Text="0.13" Font-Size="11" Font-Bold="true" Style="margin-left: 10px; text-align: center"></asp:Label>
            </td>

        </tr>
        <tr>
            <td style="width: 15%">
                <asp:Label ID="lbFillUpsInfo" runat="server" Width="100%" Text="зареждания" Font-Size="9" Style="margin-left: 10px; text-align: center"></asp:Label>
            </td>
            <td style="width: 15%">
                <asp:Label ID="lbMinConsInfo" runat="server" Width="100%" Text="мин l/100km" Font-Size="9" Style="margin-left: 10px; text-align: center"></asp:Label>
            </td>
            <td style="width: 15%">
                <asp:Label ID="lbKmInfo" runat="server" Width="100%" Text="изминати km" Font-Size="9" Style="margin-left: 10px; text-align: center"></asp:Label>
            </td>
            <td style="width: 15%">
                <asp:Label ID="lbPricePerKmInfo" runat="server" Width="100%" Text="цена на km" Font-Size="9" Style="margin-left: 10px; text-align: center"></asp:Label>
            </td>
            <td style="width: 20%"></td>
        </tr>
        <tr>
            <td />
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td colspan="2">
                <asp:Button ID="btnAddFuel" Width="75%" Style="margin-left: 15px; margin-right: 15px" runat="server" Text="Добави гориво" /></td>
            <td colspan="2">
                <asp:Button ID="btnAddOtherCost" Width="75%" Style="margin-left: 15px; margin-right: 15px" runat="server" Text="Добави друг разход" />
            </td>
        </tr>
    </table>--%>
    </asp:Panel>
</asp:Content>

