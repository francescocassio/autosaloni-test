<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="forms_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AUTOSALONI - Login</title>
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
             Login
         </p>
         <table>
             <%--primariga--%>
             <tr>
                 <td>
                     <asp:Label ID="Label1" runat="server" Text="User:"></asp:Label>

                 </td>
                 <td>
                     <asp:TextBox ID="txtUSR" runat="server"></asp:TextBox>
                 </td>
             </tr>

             <%--secondariga--%>
             <tr>
                 <td>
                     <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox>
                 </td>
             </tr>

             <%--terzariga--%>
             <tr>
                 <td></td>
                 <td class="adx">
                     <asp:Button ID="btnAccedi" runat="server" Text="Accedi" OnClick="btnAccedi_Click"/>
                 </td>
             </tr>

             <%--quartariga--%>
             <tr>
                 
                 <td colspan="2"></td> <%--scrivendo colspan="2" si prende la grandezza di 2 colonne--%>
                 <asp:Label ID="lblMessaggio" runat="server" Text="&nbsp;"></asp:Label>
                 <%--"&nbsp;" permette di inserire uno spazio--%>
             </tr>

             <%--quintariga--%>
             <tr>
                 <td class="asx piccolo"> <%--aggiungo class=" adx o asx con piccolo per allinera e ordinare--%>
                     <a href="Registrati.aspx">Registrati</a>
                 </td>
                 <td class="adx piccolo"><a href="RecuperaPassword.aspx">Recupera password</a>

                 </td>
             </tr>

         </table>

     </div>
 </div>
    </form>
</body>
</html>
