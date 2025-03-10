<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Autosaloni_Inserimento.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="content-optimized">
        <div class="title">
            <p>Inserire un nuovo Autosalone</p>
        </div>
        <div class="griglia">
            <asp:GridView ID="griglia" runat="server" DataKeyNames="K_Salone" CssClass="grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDataBound="griglia_RowDataBound">
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
                    <asp:Label ID="lblNome" runat="server" Text="Nome: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-input"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCitta" runat="server" Text="Città: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCittà" runat="server" CssClass="form-input"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblProvincia" runat="server" Text="Provincia: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-input Upper" MaxLength="2" Width="40px"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblIndirizzo" runat="server" Text="Indirizzo: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtIndirizzo" runat="server" CssClass="form-input"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCap" runat="server" Text="CAP: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCAP" runat="server" CssClass="form-input Upper" MaxLength="5" Width="120px"></asp:TextBox>
                </div>

                <div class="form-group">
                    <p>&nbsp;</p>
                    <asp:Button ID="btnInserimento" runat="server" Text="Inserimento" OnClick="btnInserimento_Click" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>

