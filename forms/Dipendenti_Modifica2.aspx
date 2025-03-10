<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dipendenti_Modifica2.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="inserimento">
        <asp:Label ID="Label1" runat="server" Text="Cognome:"></asp:Label>
        <div>&nbsp;</div>
        <asp:TextBox ID="txtCognome" runat="server"></asp:TextBox>
        <div>&nbsp;</div>
        <asp:Label ID="Label2" runat="server" Text="Nome:"></asp:Label>
        <div>&nbsp</div>
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        <div>&nbsp</div>
        <asp:Label ID="Label3" runat="server" Text="Ruolo:"></asp:Label>
        <div>&nbsp</div>
        <asp:DropDownList ID="ddlRuoli" runat="server"></asp:DropDownList>
        <div>&nbsp</div>
        <asp:Label ID="Label4" runat="server" Text="Salone:"></asp:Label>
        <div>&nbsp</div>
        <asp:DropDownList ID="ddlSaloni" runat="server"></asp:DropDownList>
        <div>&nbsp</div>
        <asp:Label ID="Label5" runat="server" Text="Codice Fiscale:"></asp:Label>
        <div>&nbsp</div>
        <asp:TextBox ID="txtCodiceFiscale" runat="server" CssClass="Upper" MaxLength="16"></asp:TextBox>
        <div>&nbsp</div>
        <asp:Button ID="btnSalva" runat="server" Text="Salva Modifica" ForeColor="#236BB3" OnClick="btnSalva_Click" />
    </div>
</asp:Content>

