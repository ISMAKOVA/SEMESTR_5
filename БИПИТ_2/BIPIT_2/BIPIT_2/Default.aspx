<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BIPIT_2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

       <p> <asp:Label ID="Label1" runat="server" Text="Число разбиения:"></asp:Label> 
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
           <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TextBox1" 
         ErrorMessage="Поле пустое" ></asp:RequiredFieldValidator>
           <asp:CompareValidator  runat="server" ID="Text1Valid" ControlToValidate="TextBox1" 
               Operator="DataTypeCheck" Type="Integer" ErrorMessage="Значение должно быть числовым"></asp:CompareValidator>
           </p>

        <p> <asp:Label ID="Label2" runat="server" Text="Количество потоков:"></asp:Label> 
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="ValidateName" ControlToValidate="TextBox2" 
         ErrorMessage="Поле пустое" ></asp:RequiredFieldValidator>
            <asp:CompareValidator  runat="server" ID="CompareValidator1" ControlToValidate="TextBox2" 
               Operator="DataTypeCheck" Type="Integer" ErrorMessage="Значение должно быть числовым"></asp:CompareValidator>
           </p>

        <asp:Button ID="Button1" runat="server" Text="Вычислить" OnClick="Button1_Click" />
        <p> <asp:Label ID="Label3" runat="server" Text="Результат:"></asp:Label> </p>
    </form>
</body>
</html>
