<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenericErrorPage.aspx.cs" Inherits="OnlineVoting.ErrorPages.GenericErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>错误页面</title>
    <link href="<%=this.ResolveUrl("~/Images/flower.png") %>"" rel="icon" />
    <style>
        body {
            margin: 0;
            background: linear-gradient(to top,white 50%,lightgray 50%);
            width: 100vw;
            height: 100vh;
        }

        .container {
            display: flex;
            position: absolute;
            width: 600px;
            height: 400px;
            top: 50%;
            left: 50%;
            transform: translate(-50%,-50%);
            background-color: white;
            box-shadow: 0px 10px 10px 10px #c4c4c4;
            align-content: center;
            flex-direction: row;
            justify-content: space-evenly;
            align-items: center;
        }

        .errorMessage {
            word-break: break-word;
            font-family: 'Cascadia Mono';
        }

        .Label2 {
            display: block;
            font-size: xx-large;
            font-weight: bolder;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="left">
                <asp:Label ID="Label2" runat="server" Text="The Page Is Lost." CssClass="Label2"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Label" CssClass="errorMessage"></asp:Label>
            </div>
            <div class="right">
                <img src="../Images/flower.png" alt=""/>
            </div>
        </div>
    </form>
</body>
</html>
