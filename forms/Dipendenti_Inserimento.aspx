<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dipendenti_Inserimento.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content">
        <div class="title">
            <p>Inserire una nuovo Dipendente</p>
        </div>
        <div class="griglia">
            <asp:GridView ID="griglia" runat="server" DataKeyNames="K_Dipendente" CssClass="grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDataBound="griglia_RowDataBound">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#1495db" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
        <div class="inserimento">
            <div class="form-container">
                <div class="form-group">
                    <asp:Label ID="lblSalone" runat="server" Text="Salone: " CssClass="form-label"></asp:Label>
                    <asp:DropDownList ID="ddlSaloni" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCognome" runat="server" Text="Cognome: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCognome" runat="server" CssClass="form-input"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblNome" runat="server" Text="Nome: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-input"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblRuolo" runat="server" Text="Ruolo: " CssClass="form-label"></asp:Label>
                    <asp:DropDownList ID="ddlRuoli" runat="server" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Codice Fiscale:"></asp:Label>
                    <asp:TextBox ID="txtCodiceFiscale" runat="server" CssClass="form-input Upper" MaxLength="16"></asp:TextBox>
                </div>
                <div class="form-group">
                    <p>&nbsp;</p>
                    <asp:Button ID="btnInserimento" runat="server" Text="Inserimento" OnClick="btnInserimento_Click" />
                </div>
            </div>
        </div>
    </div>



</asp:Content>

