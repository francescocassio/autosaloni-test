<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Marche_Inserimento.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="title">
            <p>Inserire una nuova marca</p>
        </div>
        <div class="griglia">
            <asp:GridView ID="grigliaMarche" runat="server" DataKeyNames="K_Marca" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDataBound="grigliaMarche_RowDataBound">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
        <div class="inserimento">
            <div>
                <asp:Label ID="Label1" CssClass="Label" runat="server" Text="Inserisci una nuova marca:" ForeColor="#236BB3"></asp:Label>
            </div>
            <div>&nbsp;</div>
            <asp:TextBox ID="txtInserimento" runat="server"></asp:TextBox>
            <div>&nbsp;</div>
            <asp:Button ID="btnSalva" runat="server" Text="salva" ForeColor="#236BB3" OnClick="btnSalva_Click" />
        </div>
    </div>


</asp:Content>

