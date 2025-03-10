<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Clienti_Modifica2.aspx.cs" Inherits="_Default" %>

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
        <asp:Label ID="Label6" runat="server" Text="Codice Fiscale:"></asp:Label>
        <div>&nbsp</div>
        <asp:TextBox ID="txtCodiceFiscale" runat="server" CssClass="Upper" MaxLength="16"></asp:TextBox>
        <div>&nbsp</div>
        <asp:Label ID="Label5" runat="server" Text="Città:"></asp:Label>
        <div>&nbsp</div>
        <asp:TextBox ID="txtCitta" runat="server"></asp:TextBox>
        <div>&nbsp</div>
        <asp:Label ID="Label4" runat="server" Text="Provincia:"></asp:Label>
        <div>&nbsp</div>
        <asp:TextBox ID="txtProvincia" runat="server" CssClass="Upper" MaxLength="2" Width="40px"></asp:TextBox>
        <div>&nbsp</div>
        <div>&nbsp;</div>
        <asp:Label ID="Label7" runat="server" Text="Indirizzo:"></asp:Label>
        <div>&nbsp</div>
        <asp:TextBox ID="txtIndirizzo" runat="server" Width="300px"></asp:TextBox>
        <div>&nbsp</div>
        <asp:Label ID="Label3" runat="server" Text="CAP:"></asp:Label>
        <div>&nbsp</div>
        <asp:TextBox ID="txtCAP" runat="server" MaxLength="5" Width="120px"></asp:TextBox>
        <div>&nbsp</div>
        <asp:Label ID="lblPatente" runat="server" Text="Codice Patente:"></asp:Label>
        <div>&nbsp</div>
        <asp:TextBox ID="txtPatente" runat="server" CssClass="Upper" MaxLength="10" Width="150px"></asp:TextBox>
        <div>&nbsp</div>
        <asp:Label ID="Label8" runat="server" Text="Data di Nascità: " CssClass="form-label"></asp:Label>
        <div>&nbsp</div>
        <asp:TextBox ID="txtDataNascita" runat="server" CssClass="form-input" MaxLength="10"></asp:TextBox>
        <div>&nbsp</div>
        <asp:Button ID="btnSalva" runat="server" Text="Salva Modifica" ForeColor="#236BB3" OnClick="btnSalva_Click"/>
    </div>
</asp:Content>

