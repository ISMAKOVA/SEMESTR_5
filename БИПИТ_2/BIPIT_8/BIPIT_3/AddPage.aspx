<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AddPage.aspx.cs" Inherits="BIPIT_8.AddPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="container">
    <h1 class="m-2">Добавить перемещение</h1>

        <div class="row justify-content-md-center m-2">
            <div class="col">
            <asp:Label id="exhibit" runat="server" Text="Экспонат"></asp:Label>
      </div>
            <div class="col">
            <asp:DropDownList ID="exhibit_list" runat="server" CssClass="btn btn-secondary">
            </asp:DropDownList>   
                </div>
        </div>
        <div class="row justify-content-md-center m-2">
            <div class="col">
            <asp:Label id="Hall" runat="server" Text="Зал"></asp:Label>
                </div>
            <div class="col">
            <asp:DropDownList ID="halls_list" runat="server" CssClass="btn btn-secondary">
            </asp:DropDownList>
            </div>
        </div>




        <div class="row justify-content-md-center  m-2">
        <div class="col">   
            <asp:Label id="date" runat="server" Text="Даты"></asp:Label>
            <div class="row">
                         <div class="col-sm">
        <h4>c</h4>

        <asp:TextBox ID="from" runat="server" TextMode="Date" CssClass="p-2"></asp:TextBox>
                </div>
            <div class="col-sm">
        <h4>по</h4>
             <asp:TextBox ID="to" runat="server" TextMode="Date" CssClass="p-2"></asp:TextBox>
             </div>
               </div>
            
        </div>
        </div>
        <p><asp:Label id="error" Text="" runat="server"/></p>
        <div class="row justify-content-md-end m-2">
            
            <div class="col">
            <asp:Button ID="add" CssClass="btn btn-primary mt-4" runat="server" Text="Добавить" OnClick="Add" />
                </div>
        </div>

        </div>
</asp:Content>
