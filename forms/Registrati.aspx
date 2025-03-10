<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registrati.aspx.cs" Inherits="forms_Registrati" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Autosaloni-Registrati</title>
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
             Registrati
         </p>
         <table>
            
             <%--primariga--%>
             <tr>
                 <td>
                     <asp:Label ID="Label1" runat="server" Text="User:"></asp:Label>

                 </td>
                 <td>
                     <%--va messo un MaxLenght per evitare che sfori il varchar(50) del database--%>
                     <asp:TextBox ID="txtUSR" runat="server"></asp:TextBox>
                 </td>
             </tr>

             <%--secondariga--%>
             <tr>
                 <td>
                     <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtPWD" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                 </td>
             </tr>

             <%--terzariga--%>
             <tr>
                 <td>
                     <asp:Label ID="Label3" runat="server" Text="Ripeti Pass.:"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtPWD2" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                 </td>
             </tr>

             <%--quartariga--%>
             <tr>
                 <td>
                     <asp:Label ID="Label4" runat="server" Text="Cognome:"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtCognome" runat="server" MaxLength="50"></asp:TextBox>
                 </td>
             </tr>
             <%--quintariga--%>
             <tr>
                 <td>
                     <asp:Label ID="Label5" runat="server" Text="Nome:"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtNome" runat="server"  MaxLength="50"></asp:TextBox>
                 </td>
             </tr>
             <%--sestariga--%>
             <tr>
                 <td>
                     <asp:Label ID="Label6" runat="server" Text="Città:"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtCittà" runat="server"  MaxLength="50"></asp:TextBox>
                     <%--va messo un MaxLenght per evitare che sfori il varchar(50) del database--%>
                 </td>
             </tr>


             <tr>
                 <td></td>
                 <td class="adx">
                     <asp:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click"/>
                 </td>
             </tr>

             <%--settimaariga--%>
             <tr>

                 <td colspan="2"></td>
                 <%--scrivendo colspan="2" si prende la grandezza di 2 colonne--%>
                 <asp:Label ID="lblMessaggio" runat="server" Text="&nbsp;"></asp:Label>
                 <%--"&nbsp;" permette di inserire uno spazio--%>
             </tr>

             <%--ottavariga--%>
             <tr>
                 <td class="asx piccolo"><%--aggiungo class=" adx o asx con piccolo per allinera e ordinare--%>
                   &nbsp;  
                 </td>
                 <td class="adx piccolo"><a href="Login.aspx">Torna al Login</a>

                 </td>
             </tr>
         </table>

     </div>
 </div>
    </form>
</body>
</html>
