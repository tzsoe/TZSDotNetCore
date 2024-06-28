<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="User_Registration.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfUserID" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:label text="First Name" runat="server"></asp:label>
                    </td>
                    <td colspan="2">
                        <asp:Textbox ID="txtFirstName" runat="server"></asp:Textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label text="Last Name" runat="server"></asp:label>
                    </td>
                    <td colspan="2">
                        <asp:Textbox ID="txtLastName" runat="server"></asp:Textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label text="Contact" runat="server"></asp:label>
                    </td>
                    <td colspan="2">
                        <asp:Textbox ID="txtContact" runat="server"></asp:Textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label text="Gender" runat="server"></asp:label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlGender" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList> 
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label text="Address" runat="server"></asp:label>
                    </td>
                    <td colspan="2">
                        <asp:Textbox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:Textbox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label text="UserName" runat="server"></asp:label>
                    </td>
                    <td colspan="2">
                        <asp:Textbox ID="txtUserName" runat="server"></asp:Textbox>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label text="Password" runat="server"></asp:label>
                    </td>
                    <td colspan="2">
                        <asp:Textbox ID="txtPassword" runat="server" TextMode="Password"></asp:Textbox>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label text="Confirm Password" runat="server"></asp:label>
                    </td>
                    <td colspan="2">
                        <asp:Textbox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:Textbox>
                        <asp:Label Text="*" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Submit" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblSuccessMessage" runat="server" ForeColor="Green"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
