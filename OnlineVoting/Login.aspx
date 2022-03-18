<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineVoting.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录</title>
    <link rel="stylesheet" href="CSS/index.css" />
    <link href="Images/flower.png" rel="icon" />
    <script src="js/index.js" type="text/javascript"></script>
</head>
<body onload="tip()">
    <form id="form1" runat="server" autocomplete="off">
        <div id="container">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/flower.png"/>
            <div>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/个人.png" ImageAlign="NotSet" />
                <asp:TextBox ID="username" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="username" Font-Bold="True" Font-Size="18pt" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="username" ErrorMessage="" ForeColor="#CC0000" Display="Dynamic" ValidationExpression="^[^@#/$]+$" Font-Size="17px" Font-Underline="True">首字符须为字母，后15个字符为字母、数字或下划线</asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="Label2" runat="server" Text="用户不存在" Visible="False" Font-Size="17px" ForeColor="#CC0000"></asp:Label>
            </div>
            <div>
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/密码.png" />
                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="password" Font-Bold="True" Font-Size="18pt" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Text="包含字母、数字或下划线，2-10位" Font-Bold="False" Font-Size="17px" ForeColor="#CC0000" ValidationExpression="^\w{2,10}$" ControlToValidate="password"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="Label3" runat="server" Text="密码错误" Font-Size="17px" ForeColor="#CC0000" Visible="False"></asp:Label>
            </div>
            <asp:Button ID="LoginButton" runat="server" Text="登录" onmouseover="changeColor()" onmouseout="recoveryColor()" OnClick="LoginButton_Click" />
            <asp:Label ID="Label1" runat="server" Text="Label">还没有账户?
                <asp:LinkButton ID="RegisterButton" runat="server" PostBackUrl="~/Register.aspx" CausesValidation="False">👉点此注册</asp:LinkButton></asp:Label>
        </div>
    </form>
</body>
</html>
