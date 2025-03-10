<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Marche_Modifica2.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="inserimento">
        <div>
            <div id="div_modifica" runat="server">
                <asp:TextBox ID="txtAggiorna" Text="Inserisci una nuova marca:" runat="server"></asp:TextBox>
                <div>&nbsp;</div>
                <asp:Button ID="btnAggiorna" runat="server" Text="aggiorna" ForeColor="#236BB3" OnClick="btnAggiorna_Click" />
            </div>
        </div>
    </div>
</asp:Content>

