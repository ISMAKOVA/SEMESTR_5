﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="BIPIT_4.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="container">
    <h1>Таблица перемещений</h1>
    <asp:Label id="header" Text="" runat="server"/>
    <div class="m-2 p-2 form-group">
        <h3>Получить записи за период</h3>
        <div class="row">
            <div class="col-sm">
        <h4>c</h4>
        <asp:Calendar ID="from" runat="server" CssClass="p-2"></asp:Calendar>
                </div>
            <div class="col-sm">
        <h4>по</h4>
        <asp:Calendar ID="to" runat="server" CssClass="p-2"></asp:Calendar>
             </div>
            <div class="col-sm">
                <asp:Button ID="Button" CssClass ="btn btn-secondary" onclick="ShowTable" runat="server" Text="Показать"/>
            </div>
            </div>
    </div>
    <div class="row overflow">
        <asp:Label ID="tableHead" runat="server" CssClass="h-auto"></asp:Label>
        <div class="col m-4">        
            <asp:GridView ID="Table1" 
                           HorizontalAlign="Center" 
                            Font-Names="Verdana" 
                            Font-Size="8pt" 
                            CellPadding="15" 
                            runat = "server">
                <Columns>
                    <asp:TemplateField HeaderText="Выбрать">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

        </div>
</asp:Content>
