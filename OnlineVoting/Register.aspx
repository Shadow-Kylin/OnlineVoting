<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OnlineVoting.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>注册</title>
    <link href="Images/flower.png" rel="icon" />
    <link href="CSS/Register.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conStr %>" SelectCommand="SELECT * FROM [users_inf]"></asp:SqlDataSource>
        <div class="container">
            <div class="row1">
                <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
                <asp:TextBox ID="username" runat="server" OnTextChanged="username_TextChanged" AutoPostBack="True" CausesValidation="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="username" Display="Dynamic" ForeColor="MediumSlateBlue"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="不能包含特殊字符*,/,$,@" ControlToValidate="username" ValidationExpression="^[^*/$@]+$" Display="Dynamic" Font-Size="17px" ForeColor="MediumSlateBlue"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="Label11" runat="server" Text="用户名已存在" Visible="False" Font-Size="17px" ForeColor="MediumSlateBlue"></asp:Label>
            </div>
            <div class="row2">
                <asp:Label ID="Label2" runat="server" Text="Label">密码</asp:Label>
                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="password" Display="Dynamic" ForeColor="MediumSlateBlue"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="密码2-10位,包括数字\字母\下划线" ControlToValidate="password" ValidationExpression="^\w{2,10}$" Display="Dynamic" Font-Size="17px" ForeColor="MediumSlateBlue"></asp:RegularExpressionValidator>
            </div>
            <div class="row3">
                <asp:Label ID="Label3" runat="server" Text="Label">确认密码</asp:Label>
                <asp:TextBox ID="confirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="密码不一致" ControlToCompare="password" ControlToValidate="confirmPassword" Display="Dynamic" Font-Size="17px" ForeColor="MediumSlateBlue"></asp:CompareValidator>
            </div>
            <div class="row4">
                <asp:Label ID="Label4" runat="server" Text="Label">邮箱</asp:Label>
                <asp:TextBox ID="email" runat="server" AutoCompleteType="Email" TextMode="Email"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="格式不正确,形如xxx@xxx.xxx" ControlToValidate="email" Display="Dynamic" ForeColor="MediumSlateBlue" Font-Size="17px" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div class="row5">
                <asp:Label ID="Label5" runat="server" Text="Label">电话</asp:Label>
                <asp:TextBox ID="phone" runat="server" TextMode="Phone"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ForeColor="MediumSlateBlue" Display="Dynamic" ErrorMessage="11位数字" ControlToValidate="phone" ValidationExpression="\d{11}"></asp:RegularExpressionValidator>
            </div>
            <div class="row6">
                <asp:Label ID="Label6" runat="server" Text="Label">性别</asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" ForeColor="#FFCCCC" RepeatDirection="Horizontal">
                    <asp:ListItem>男</asp:ListItem>
                    <asp:ListItem>女</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="row7">
                <asp:Label ID="Label7" runat="server" Text="Label">生日</asp:Label>
                <asp:TextBox ID="birthday" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row8">
                        <asp:Label ID="Label8" runat="server" Text="Label">居住地</asp:Label>
                        (省)
                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        (市)
                        <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DropDownList1" />
                    <asp:AsyncPostBackTrigger ControlID="DropDownList2" />
                </Triggers>
            </asp:UpdatePanel>
            <div class="row9">
                <asp:Label ID="Label9" runat="server" Text="Label">头像</asp:Label>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="200px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="FileUpload1" Display="Dynamic" ErrorMessage="仅允许jpg,png,gif格式" Font-Size="17px" ForeColor="MediumSlateBlue" ValidationExpression=".+\.(jpg|png|gif)$"></asp:RegularExpressionValidator>
            </div>
            <div class="row10">
                <asp:Label ID="Label10" runat="server" Text="Label">签名</asp:Label>
                <asp:TextBox ID="signature" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>
            <div class="row11">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/登录、注册.png" ToolTip="注册" OnClick="ImageButton1_Click" />
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/返回.png" CausesValidation="False" PostBackUrl="~/Login.aspx" ToolTip="返回" />
            </div>
        </div>
    </form>
</body>
</html>
