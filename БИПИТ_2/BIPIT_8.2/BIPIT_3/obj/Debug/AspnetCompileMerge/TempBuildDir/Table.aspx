﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="BIPIT_3.Table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="container">
    <h1 class="m-2">Таблица перемещений</h1>
    <asp:Label id="header" Text="" runat="server"/>
    <div class="m-2 p-2 form-group">
        <h3>Получить записи за период</h3>
        <div class="row">
            <div class="col-sm">
        <h4>c</h4>
        <asp:TextBox ID="from" runat="server" TextMode="Date" CssClass="p-2"></asp:TextBox>
                </div>
            <div class="col-sm">
        <h4>по</h4>
        <asp:TextBox ID="to" runat="server" TextMode="Date" CssClass="p-2"></asp:TextBox>
             </div>
            <div class="col-sm">
                <asp:Button ID="Button" CssClass ="btn btn-secondary" onclick="ShowTable" runat="server" Text="Показать"/>
                <asp:Button ID="btn_delete" CssClass ="btn btn-danger m-3" onclick="Delete" runat="server" Text="Удалить" />
            </div>
            </div>
    </div>
               <p>        <asp:Label ID="tableHead" runat="server" CssClass="h-auto "></asp:Label></p>
    <div class="row ">

        <div class="col m-4 overflow-auto">        
            <asp:GridView ID="Table1" 
                           HorizontalAlign="Center" 
                            Font-Names="Verdana" 
                            Font-Size="8pt" 
                            CellPadding="15" 
                            runat = "server">
                <Columns>
                    <asp:TemplateField HeaderText="Выбрать">
                        <ItemTemplate>
                            <asp:CheckBox ID="ch" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        
    </div>

        </div>
</asp:Content>
