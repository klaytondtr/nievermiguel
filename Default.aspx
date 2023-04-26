<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ListaConvidados._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div >
        <div class="teste" >
            <div class="text-center" >
                <asp:Button runat="server" ID="ButtonNovo" OnClick="ButtonNovo_Click" Text="Novo Convidado" CssClass="btn btn-lg btn-success" style="text-align:center" />
                <hr />
                <asp:Button runat="server" ID="ButtonLista" OnClick="ButtonLista_Click" Text="Lista de Convidados" CssClass="btn btn-lg btn-success" style="text-align:center" />
            </div>
        </div>
    </div>
<style>
    .teste{
         display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    min-height: 70vh;
    }
</style>
</asp:Content>