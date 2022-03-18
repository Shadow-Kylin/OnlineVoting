<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPages/NestedUserHome.master" AutoEventWireup="true" CodeBehind="CurrentUserSubject.aspx.cs" Inherits="OnlineVoting.UserPages.CurrentUserSubject" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserHome" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset class="subject_items">
                <legend>投票主题</legend>
                <asp:TextBox ID="subject_content" runat="server" Enabled="False" BorderStyle="None"></asp:TextBox>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Enabled="False" Visible="False"></asp:RadioButtonList>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" Enabled="False"></asp:CheckBoxList>
                <asp:LinkButton ID="EditButton" runat="server" CssClass="EditButton" OnClick="EditButton_Click" CausesValidation="False">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/编辑.png" /><label runat="server" id="edit_text">编辑</label>
                </asp:LinkButton>
            </fieldset>
            <%--统计数据--%>
            <div class="statistic">
                <asp:Chart ID="Chart1" runat="server" Width="400px" Palette="Fire">
                    <Titles>
                        <asp:Title Text="统计图"></asp:Title>
                    </Titles>
                    <Series>
                        <asp:Series Name="Series1" ChartType="Funnel" YValuesPerPoint="6" MarkerStyle="Circle"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div class="subject_details">
                <asp:Label ID="Label1" runat="server" Text="选项模式:">
                    <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None" Enabled="False"></asp:TextBox>
                </asp:Label>
                <asp:Label ID="Label2" runat="server" Text="截止日期:">
                    <asp:TextBox ID="TextBox2" runat="server" BorderStyle="None" Enabled="False" TextMode="Date" OnTextChanged="TextBox2_TextChanged" AutoPostBack="True"></asp:TextBox>
                </asp:Label>
                <asp:Label ID="Label3" runat="server" Text="是否可投?:">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatColumns="0" RepeatDirection="Horizontal" CssClass="deadlineSelect" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Text="true" Value="true"></asp:ListItem>
                        <asp:ListItem Text="false" Value="false"></asp:ListItem>
                    </asp:RadioButtonList>
                </asp:Label>
                <asp:Label ID="Label4" runat="server"></asp:Label>

                <asp:Button ID="Button1" runat="server" Text="保存" CssClass="SaveButton" Visible="False" OnClick="Button1_Click" CausesValidation="False" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
