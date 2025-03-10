<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecuperaPassword.aspx.cs" Inherits="forms_RecuperaPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/LoginStile.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <div id="divLogo">
                <img id="logo" src="../images/logo.png" alt="logo" />
            </div>
            <div id="main">
                <p class="titolo">
                    Recupera Password
                </p>
                <table>

                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="User:"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox ID="txtUSR" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td></td>
                        <td class="adx">
                            <asp:Button ID="btnRecupera" runat="server" Text="Recupera" OnClick="btnRecupera_Click" />
                        </td>
                    </tr>

                    <tr>
                        <td></td>
                        <td></td>
                    </tr>


                    <tr>

                        <td colspan="2">
                            <asp:Label ID="lblMessaggio" runat="server" Text="&nbsp;"></asp:Label>
                        </td>

                    </tr>

                    <tr>
                        <td class="asx piccolo"><%--doppia classe--%>
                            <a href="Registrati.aspx">Vai a registrati</a>
                        </td>

                        <td class="asx piccolo"><%--doppia classe--%>
                            <a href="Login.aspx">Torna a Login</a>
                        </td>

                    </tr>


                </table>

            </div>
        </div>
    </form>
</body>
</html>
