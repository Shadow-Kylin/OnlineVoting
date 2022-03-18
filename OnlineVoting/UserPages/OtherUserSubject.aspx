<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UsersMaster.Master" AutoEventWireup="true" CodeBehind="OtherUserSubject.aspx.cs" Inherits="OnlineVoting.UserPages.OtherUserSubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="otherSubject">
        <fieldset class="subject_items">
            <legend>投票主题</legend>
            <asp:TextBox ID="subject_content" runat="server" Enabled="False" BorderStyle="None"></asp:TextBox>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Enabled="False" Visible="False"></asp:RadioButtonList>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" Enabled="False"></asp:CheckBoxList>
        </fieldset>
        <div class="subject_details">
            <asp:Label ID="Label1" runat="server" Text="选项模式:">
                <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None" Enabled="False"></asp:TextBox>
            </asp:Label>
            <asp:Label ID="Label2" runat="server" Text="截止日期:">
                <asp:TextBox ID="TextBox2" runat="server" BorderStyle="None" Enabled="False" TextMode="Date"></asp:TextBox>
            </asp:Label>
            <asp:Label ID="Label3" runat="server" Text="是否可投?:">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatColumns="0" RepeatDirection="Horizontal" CssClass="deadlineSelect" Enabled="False">
                    <asp:ListItem Text="true" Value="true"></asp:ListItem>
                    <asp:ListItem Text="false" Value="false"></asp:ListItem>
                </asp:RadioButtonList>
            </asp:Label>
            <asp:Label ID="Label4" runat="server"></asp:Label>

            <asp:Button ID="Button1" runat="server" Text="保存" CssClass="SaveButton" OnClick="Button1_Click" CausesValidation="False" />
        </div>
    </div>
</asp:Content>
