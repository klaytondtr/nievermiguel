<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ListaConvidados.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <h2>Lista de Convidados</h2>
    </center>
    <div class="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                        <div style="overflow-y: scroll;height: 200px;">

                <asp:GridView runat="server" ID="GridViewLista" CssClass="table" GridLines="None"
                    AutoGenerateColumns="false" OnSorted="GridViewLista_Sorted" OnSorting="GridViewLista_Sorting" AllowSorting="true">
                    <Columns>
                        <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                        <asp:BoundField DataField="Pagante" HeaderText="Pagante" SortExpression="Pagante" />
                        <asp:BoundField DataField="Situacao" HeaderText="Situação Atual" SortExpression="Situacao" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownListSituacao" runat="server">
                                    <asp:ListItem Text="Nao Convidado" Value="Nao Convidado"></asp:ListItem>
                                    <asp:ListItem Text="Confirmado" Value="Confirmado"></asp:ListItem>
                                    <asp:ListItem Text="Removido" Value="Removido"></asp:ListItem>
                                    <asp:ListItem Text="Aguardando" Value="Aguardando"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row">

            <asp:Button ID="ButtonSalvar" runat="server" CssClass="btn btn-primary" Text="Salvar" OnClick="ButtonSalvar_Click" />
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Voltar" OnClick="Button1_Click" />

        </div>
        <div class="row">

            <asp:Label ID="LabelTotalConfirmados" Style="background-color: rgb(242, 255, 250)" runat="server"></asp:Label>
        </div>
        <div class="row">

            <asp:Label ID="LabelTotalConfirmadosPagantes" Style="background-color: rgb(242, 255, 250)" runat="server"></asp:Label>
        </div>
        <div class="row">

            <asp:Label ID="LabelTotalAguardando" Style="background-color: rgb(255, 255, 225)" runat="server"></asp:Label>
        </div>
        <div class="row">

            <asp:Label ID="LabelTotalAguardandoPagantes" Style="background-color: rgb(255, 255, 225)" runat="server"></asp:Label>
        </div>
        <div class="row">
            <asp:Label ID="LabelTotalNaoConvidados" runat="server"></asp:Label>
        </div>
        <div class="row">
            <asp:Label ID="LabelTotalNaoConvidadosPagantes" runat="server"></asp:Label>
        </div>
        <div class="row">
            <asp:Label ID="LabelTotalRemovidos" Style="background-color: rgb(255, 228, 225)" runat="server"></asp:Label>
        </div>
        <div class="row">
            <asp:Label ID="LabelTotalRemovidosPagantes" Style="background-color: rgb(255, 228, 225)" runat="server"></asp:Label>
        </div>

    </div>
</asp:Content>
