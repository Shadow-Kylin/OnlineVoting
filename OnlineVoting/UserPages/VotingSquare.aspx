<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UsersMaster.Master" AutoEventWireup="true" CodeBehind="VotingSquare.aspx.cs" Inherits="OnlineVoting.UserPages.VotingSquare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div class="vs_container">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate></HeaderTemplate>
            <ItemTemplate>
                <section class="voteSubject">
                    <%--投票话题--%>
                    <header>
                        <label class="subjectContent"><%#Eval("subject_content")%></label>
                        <span class="subjectState" id="<%#"subject"+Eval("subject_id")%>"><%# GetSubjectState()%></span>
                    </header>
                    <footer>
                        <%--发表用户（此处不用显示，左侧可见），截止时间--%>
                        <label class="deadline">截止时间：<%#Convert.ToDateTime(Eval("deadline").ToString()).ToShortDateString() %></label>
                        <a href="<%#ResolveUrl("~/UserPages/OtherUserSubject.aspx")+"?" +
                    "subject_id="+Eval("subject_id")+"&state1="+((GetSubjectState()!="已截止"&&GetSubjectState()!="不可投")?"0":GetSubjectState()) 
                    %>"
                            class="ViewDetails">>> View Details</a>
                    </footer>
                </section>
            </ItemTemplate>
            <FooterTemplate></FooterTemplate>
        </asp:Repeater>
        <div class="page_control">
            <asp:Label ID="Label1" runat="server" ForeColor="White"></asp:Label>
            <asp:Button ID="PreButton" runat="server" Text="上一页" CssClass="PreButton" />
            <asp:Button ID="NextButton" runat="server" Text="下一页" CssClass="NextButton" />
            <asp:TextBox ID="InputPage" runat="server" Width="50px"></asp:TextBox>
            <asp:LinkButton ID="GOURL" runat="server" ForeColor="White">GO</asp:LinkButton>
        </div>
    </div>
</asp:Content>
