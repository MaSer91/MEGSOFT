<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="TestEmployeeAPP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validateForm() {
            var isValid = document.getElementById('<%= txtFirstName.Text %>');
            if (isValid.value.trim() === '') {
                alert('Se recomienda ingresar un primer nombre.');
                return false;
            }
            return true;
        }
    </script>
    <main>
        <div style="background-color:cornflowerblue; font-size:xx-large" align="center">
            DEV - ASSESSMENT (MEGSOFT)
        </div>
    
        <br />
        <div style="padding:15px">
                <table class="nav-justified">
            <tr>
                <td style="width: 494px">
                    <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                </td>
                <td style="width: 1324px">
                    <asp:TextBox ID="txtId" runat="server" Enabled="False" Width="58px"></asp:TextBox>
                &nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" Enabled="False" Text="SEARCH" />
&nbsp;
                    <asp:Button ID="Button4" runat="server" Enabled="False" Text="NEW EMPLOYEE" />
                </td>
            </tr>
            <tr>
                <td style="height: 24px; width: 494px">
                    <asp:Label ID="Label2" runat="server" Text="FIRST NAME"></asp:Label>
                </td>
                <td style="width: 1324px; height: 24px">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 494px">
                    <asp:Label ID="Label3" runat="server" Text="SECOND NAME"></asp:Label>
                </td>
                <td style="width: 1324px">
                    <asp:TextBox ID="txtSecondName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 494px">
                    <asp:Label ID="Label4" runat="server" Text="PHONE NUMBER"></asp:Label>
                </td>
                <td style="width: 1324px">
                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 494px">
                    <asp:Label ID="Label5" runat="server" Text="EMPLOYEE TYPE"></asp:Label>
                </td>
                <td style="width: 1324px">
                    <asp:DropDownList ID="ddlEmplType" runat="server" Font-Size="Medium" Width="200px" DataSourceID="sqlDataCombo" DataTextField="Definition" DataValueField="Definition">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="sqlDataCombo" runat="server" ConnectionString="<%$ ConnectionStrings:employeeDBConnectionString %>" ProviderName="<%$ ConnectionStrings:employeeDBConnectionString.ProviderName %>" SelectCommand="SELECT [Definition] FROM [EmployeeType]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="width: 494px">&nbsp;</td>
                <td style="width: 1324px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 494px">&nbsp;</td>
                <td style="width: 1324px">
                    <asp:Button ID="Button1" runat="server" BackColor="#3366FF" ForeColor="White" Text="INSERT" OnClientClick="return validateForm();" />
                &nbsp;
                    <asp:Button ID="Button2" runat="server" BackColor="#3366FF" ForeColor="White" Text="UPDATE" Enabled="False" />
                &nbsp;<asp:Button ID="Button5" runat="server" BackColor="#3366FF" ForeColor="White" Text="DELETE" Enabled="False" />
                </td>
            </tr>
    </table>
            <div align="center">
            <hr />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlEmployee" Width="80%">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                        <asp:BoundField DataField="SecondName" HeaderText="SecondName" SortExpression="SecondName" />
                        <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                        <asp:BoundField DataField="EmployeeType" HeaderText="EmployeeType" SortExpression="EmployeeType" />
                    </Columns>
                    <HeaderStyle BackColor="#3366FF" ForeColor="White" />
                </asp:GridView>

                <asp:SqlDataSource ID="SqlEmployee" runat="server" ConnectionString="<%$ ConnectionStrings:employeeDBConnectionString %>" SelectCommand="SELECT [ID], [FirstName], [SecondName], [PhoneNumber], [EmployeeType] FROM [Employee]"></asp:SqlDataSource>

            </div>
        </div>
    </main>

</asp:Content>
