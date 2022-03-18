<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UsersMaster.Master" AutoEventWireup="true" CodeBehind="PersonalCenter.aspx.cs" Inherits="OnlineVoting.UserPages.PersonalCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div style="display: flex; justify-content: space-evenly;">
        <div class="personal_nav">
            <asp:ListBox ID="ListBox1" runat="server" CssClass="ListBox_nav" AutoPostBack="True" ValidateRequestMode="Disabled">
                <asp:ListItem Selected="True">个人资料</asp:ListItem>
                <asp:ListItem>发布投票</asp:ListItem>
                <asp:ListItem>发布的投票</asp:ListItem>
            </asp:ListBox>
            <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="3000" OnTick="Timer1_Tick">
            </asp:Timer>
        </div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View4" runat="server" OnLoad="View4_Load">
                        <div class="userinf_show">
                            <div>
                                <label>用户名</label>
                                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div>
                                <label>密码</label>
                                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div>
                                <label>电话</label>
                                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div>
                                <label>邮箱</label>
                                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div>
                                <label>居住地</label>
                                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div>
                                <label>生日</label>
                                <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div>
                                <label>头像</label>
                                <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
                            </div>
                            <div>
                                <label>签名</label>
                                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                                <br />
                                <asp:Button ID="cancelButton" runat="server" Text="注销账户" OnClientClick="return confirm('确定注销吗？')" OnClick="CancelAcc_Click" />
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="View5" runat="server">
                        <div class="pc_FileUpload">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="Button4" runat="server" Text="上传" OnClick="Button4_Click" />
                        </div>
                    </asp:View>
                    <asp:View ID="View6" runat="server">
                        <div style="width: 430px; height: 60px; display: flex; flex-direction: column; align-items: center; background: aqua;">
                            <asp:Label ID="Label14" runat="server" Text="输入旧密码"></asp:Label>
                            <div>
                                <asp:TextBox ID="TextBox7" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:Button ID="Button5" runat="server" Text="确定" OnClick="Button5_Click" />
                            </div>
                            <asp:Label ID="Label15" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </asp:View>
                    <asp:View ID="View7" runat="server" OnLoad="View7_Load">
                        <div class="userinf_show">
                            <div>
                                <label>用户名</label>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="不能包含特殊字符@#$/" ControlToValidate="TextBox1" ValidationExpression="^[^@#$/]+" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <label>电话</label>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="MediumSlateBlue" Display="Dynamic" ErrorMessage="11位数字" ControlToValidate="TextBox3" ValidationExpression="\d{11}"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <label>邮箱</label>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="格式不正确,形如xxx@xxx.xxx" ControlToValidate="TextBox4" Display="Dynamic" ForeColor="MediumSlateBlue" Font-Size="17px" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </div>
                            <div>
                                <label>性别</label>
                                <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" CssClass="sex_select">
                                    <asp:ListItem>男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div>
                                        <label>居住地</label>
                                        (省)
                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                                        (市)
                                <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div>
                                <label>生日</label>
                                <asp:TextBox ID="TextBox5" runat="server" TextMode="Date"></asp:TextBox>
                            </div>
                            <div>
                                <label>签名</label>
                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                            </div>
                            <asp:Button ID="Button3" runat="server" Text="保存编辑" CssClass="saveedit_button" OnClick="Button3_Click" />
                        </div>
                    </asp:View>
                </asp:MultiView>
                <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="True" CssClass="pc_edit" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged">
                    <asp:ListItem>换头像</asp:ListItem>
                    <asp:ListItem>修改密码</asp:ListItem>
                    <asp:ListItem>编辑其他</asp:ListItem>
                    <asp:ListItem>返回</asp:ListItem>
                </asp:ListBox>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <%--发布投票--%>
                <div class="user_setvote" style="background-color: aqua;">
                    <asp:Label ID="Label1" runat="server" Text="发布成功" CssClass="tooltipLabel" Visible="False"></asp:Label>
                    <div class="setsubject">
                        <label>投票主题</label>
                        <asp:TextBox ID="subject" runat="server" TextMode="MultiLine" Rows="3" AutoPostBack="True" OnTextChanged="subject_TextChanged"></asp:TextBox>
                        <asp:Label ID="Label3" runat="server" Visible="False" Text="不可为空!" ForeColor="Red"></asp:Label>
                    </div>
                    <fieldset>
                        <legend>添加选项
                        </legend>
                        <div style="display: flex; align-items: center; padding: 10px; width: 500px; justify-content: space-evenly;">
                            <asp:ImageButton ID="additem" runat="server" CssClass="additem" ImageUrl="~/Images/添加.png" ToolTip="添加" OnClick="additem_Click" />
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            <asp:Button ID="Button2" runat="server" Text="清空" OnClick="Button2_Click" />
                        </div>
                        <asp:Label ID="Label6" runat="server" CssClass="AddedItem"></asp:Label>
                    </fieldset>
                    <div>
                        <asp:Label ID="Label5" runat="server" Text="Label">选择模式：</asp:Label>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">单选</asp:ListItem>
                            <asp:ListItem>多选</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div>
                        <asp:Label ID="Label4" runat="server" Text="Label">截止时间：</asp:Label>
                        <asp:TextBox ID="deadline" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                    <asp:Button ID="Button1" runat="server" Text="发布" OnClick="Button1_Click" />
                </div>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <asp:MultiView ID="MultiView3" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View8" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="subject_id" DataSourceID="SqlDataSource1" EmptyDataText="(空)" Font-Names="Microsoft YaHei UI" GridLines="Vertical" PageSize="5">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:BoundField DataField="subject_content" HeaderText="投票主题" SortExpression="subject_content" />
                                <asp:TemplateField HeaderText="投票模式" SortExpression="select_mode">
                                    <EditItemTemplate>
                                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" SelectedValue='<%# Bind("select_mode") %>'>
                                            <asp:ListItem>单选</asp:ListItem>
                                            <asp:ListItem>多选</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("select_mode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="截止日期" SortExpression="deadline">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("deadline", "{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("deadline") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="是否可投?" SortExpression="votable">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("votable") %>'>
                                            <asp:ListItem>true</asp:ListItem>
                                            <asp:ListItem>false</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("votable") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                <asp:BoundField DataField="subject_id" HeaderText="subject_id" ReadOnly="True" SortExpression="subject_id" Visible="False" />
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Cancel" OnClick="LinkButton1_Click" Text="查看选项" PostBackUrl='<%# Request.CurrentExecutionFilePath+"?subject_id="+Eval("subject_id") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Size="X-Large" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VotingSystemConnectionString %>" DeleteCommand="DELETE FROM [Subject] WHERE [subject_id] = @subject_id" InsertCommand="INSERT INTO [Subject] ([subject_content], [select_mode], [deadline], [votable], [subject_id]) VALUES (@subject_content, @select_mode, @deadline, @votable, @subject_id)" SelectCommand="SELECT [subject_content], [select_mode], [deadline], [votable], [subject_id] FROM [Subject] WHERE ([user_name] = @user_name)" UpdateCommand="UPDATE [Subject] SET [subject_content] = @subject_content, [select_mode] = @select_mode, [deadline] = @deadline, [votable] = @votable WHERE [subject_id] = @subject_id">
                            <DeleteParameters>
                                <asp:Parameter Name="subject_id" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="subject_content" Type="String" />
                                <asp:Parameter Name="select_mode" Type="String" />
                                <asp:Parameter DbType="Date" Name="deadline" />
                                <asp:Parameter Name="votable" Type="String" />
                                <asp:Parameter Name="subject_id" Type="Int32" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter Name="user_name" SessionField="user_name" Type="String" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="subject_content" Type="String" />
                                <asp:Parameter Name="select_mode" Type="String" />
                                <asp:Parameter DbType="Date" Name="deadline" />
                                <asp:Parameter Name="votable" Type="String" />
                                <asp:Parameter Name="subject_id" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </asp:View>
                    <asp:View ID="View9" runat="server">
                        <div>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:VotingSystemConnectionString %>" DeleteCommand="DELETE FROM [Item] WHERE [item_id] = @item_id" InsertCommand="INSERT INTO [Item] ([subject_id], [item_content]) VALUES (@subject_id, @item_content)" SelectCommand="SELECT * FROM [Item] WHERE ([subject_id] = @subject_id)" UpdateCommand="UPDATE [Item] SET [subject_id] = @subject_id, [item_content] = @item_content WHERE [item_id] = @item_id">
                                <DeleteParameters>
                                    <asp:Parameter Name="item_id" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:QueryStringParameter Name="subject_id" QueryStringField="subject_id" Type="Int32" />
                                    <asp:Parameter Name="item_content" Type="String" />
                                </InsertParameters>
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="subject_id" QueryStringField="subject_id" Type="Int32" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="subject_id" Type="Int32" />
                                    <asp:Parameter Name="item_content" Type="String" />
                                    <asp:Parameter Name="item_id" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <br />
                            <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" CellPadding="6" CellSpacing="3" DataKeyNames="item_id" DataSourceID="SqlDataSource2" Font-Size="Larger" ForeColor="#333333" Height="50px" Width="314px">
                                <AlternatingRowStyle BackColor="White" />
                                <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                                <Fields>
                                    <asp:BoundField DataField="item_id" HeaderText="item_id" InsertVisible="False" ReadOnly="True" SortExpression="item_id" Visible="False" />
                                    <asp:BoundField DataField="subject_id" HeaderText="subject_id" SortExpression="subject_id" Visible="False" />
                                    <asp:BoundField DataField="item_content" HeaderText="选项" SortExpression="item_content" />
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                                </Fields>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerSettings FirstPageText="First&amp;nbsp" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next&amp;nbsp" PreviousPageText="Previous&amp;nbsp" />
                                <PagerStyle BackColor="#2461BF" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                            </asp:DetailsView>
                            <asp:Button ID="Button6" runat="server" Text="返回" OnClick="Button6_Click" />
                        </div>
                    </asp:View>
                </asp:MultiView>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
