<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BIPIT_3.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">

    <asp:Label ID="Header" CssClass="h-auto" runat="server" Text="Туть будут таблицы "/>

    <div>
        <asp:Table id="Table1" 
        GridLines="Both" 
        HorizontalAlign="Center" 
        Font-Names="Verdana" 
        Font-Size="8pt" 
        CellPadding="15" 
        CellSpacing="0" 
        runat = "server"/>
    </div>
</asp:Content>
