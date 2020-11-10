<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BIPIT_6_WEB_CLIENT.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 mt-2" style=" height:400px; overflow:scroll;">
                    <asp:GridView ID="Table1" 
                           HorizontalAlign="Center" 
                            Font-Names="Verdana" 
                            Font-Size="8pt" 
                            CellPadding="15" 
                            runat = "server">
                    </asp:GridView>
            </div>
    </div>
    <div class="row">
        <div class="col-6">
            <div class="row">
                <div class="my-2">
                <p>Экспонат</p>
            <asp:DropDownList ID="exhibit_list" runat="server">
                </asp:DropDownList>
                    </div>
            </div>
            <div class="row">
                <div class="my-2">
                <p>Музей</p>
            <asp:DropDownList ID="halls_list" runat="server">
                </asp:DropDownList>
                    </div>
            </div>
            
        </div>

        <div class="col-3 mt-2">
            <p>Дата поступления</p>
            <asp:TextBox ID="from" runat="server" TextMode="Date" CssClass="p-2"></asp:TextBox>
        </div>
        <div class="col-3 mt-2">
            <p>Дата отъезда</p>
            <asp:TextBox ID="to" runat="server" TextMode="Date" CssClass="p-2"></asp:TextBox>
        </div>
    </div>
    <div class="row justify-content-end">
        <div class="col-1 mr-2">
            <asp:Button ID="btn_add" CssClass ="btn btn-primary" onclick="Add" runat="server" Text="Добавить" />
            <asp:Label id="error" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
