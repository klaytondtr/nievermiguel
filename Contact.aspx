<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ListaConvidados.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <h2>Novo Convidado</h2>
    </center>
    <div class="container">
        <h2>Novo Convidado</h2>
        <div class="form-inline">
            <div class="form-group">
                <label>Nome:</label>
                <asp:TextBox runat="server" ID="TextBoxNome" class="form-control" placeholder="Nome do Convidado" Width="250px" />
            </div>
        </div>
        <br />
        <div class="form-inline">
            <div class="form-group">
                <label>Pagante:</label>
                <asp:CheckBox CssClass="checkbox" name="remember" runat="server" ID="CheckBoxPagante" Text="" />
            </div>
        </div>
        <br />
        <div class="form-inline">
            <asp:Button runat="server" ID="ButtonSalvar" Text="Salvar" OnClick="ButtonSalvar_Click" CssClass="btn btn-success" />
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Voltar" OnClick="Button1_Click" />

        </div>
    </div>
    
</asp:Content>
