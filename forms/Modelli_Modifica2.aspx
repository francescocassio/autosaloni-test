<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Modelli_Modifica2.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="inserimento">
        <asp:Label ID="Label1" runat="server" Text="Seleziona Marca"></asp:Label>
        <div>&nbsp;</div>
        <asp:DropDownList ID="ddlMarche" runat="server"></asp:DropDownList>
        <div>&nbsp</div>
        <asp:Label ID="Label2" runat="server" Text="Seleziona Modello"></asp:Label>
        <div>&nbsp</div>
        <asp:TextBox ID="txtModello" runat="server"></asp:TextBox>
        <div>&nbsp</div>
        <asp:Button ID="btnSalva" runat="server" Text="Salva Modifica" ForeColor="#236BB3" OnClick="btnSalva_Click" />
    </div>
</asp:Content>

