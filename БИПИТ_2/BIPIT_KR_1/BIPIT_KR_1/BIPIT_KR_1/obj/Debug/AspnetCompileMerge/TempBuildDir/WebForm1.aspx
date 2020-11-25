<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BIPIT_KR_1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row overflow-auto justify-content-center">
            <div class="col my-3">
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
            
        <div class="row">
            <div class="col">
                <h5>Дата и время</h5>
                <asp:TextBox ID="date" runat="server" TextMode="DateTimeLocal" CssClass="form-control" ></asp:TextBox>
            </div>
            <div class="col">
                <h5>Автор</h5>
                <asp:TextBox ID="author" runat="server" TextMode="SingleLine" CssClass="form-control" ></asp:TextBox>

            </div>
            <div class="col">
                <h5>Описание проблемы</h5>
                <asp:TextBox ID="problem" runat="server" TextMode="MultiLine" CssClass="form-control" ></asp:TextBox>

            </div>
        </div>

        <div class="row">
             <div class="col my-3">
            <asp:Button ID="btn_add" CssClass ="btn btn-primary btn-block" onclick="NewRec" runat="server" Text="Добавить" /></div>

            <div class="col my-3">
            <asp:Button ID="btn_delete" CssClass ="btn btn-danger btn-block" onclick="Delete" runat="server" Text="Удалить" /></div>
            <div class="col my-3">
            <asp:Button ID="btn_update" CssClass ="btn btn-info btn-block"  onclick="Update" runat="server" Text="Обновить" /></div>
        </div>
        
        <div class="row justify-content-start">
            <div class="col-4"><asp:Label runat="server" id="error" Text="" CssClass="alert-warning"></asp:Label></div></div>
    </div>

</asp:Content>
