<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Teste_Expense.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-eOJMYsd53ii+scO/bJGFsiCZc+5NDVN2yr8+0RDqr0Ql0h+rP48ckxlpbzKgwra6" crossorigin="anonymous">
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
            font-size: x-large;
            color: #0D6EFD;
            text-align: center;
            text-transform: uppercase;
        }
    </style>
</head>
<body>
    <div class="auto-style1">
        Teste Expense ON
    </div>


    <div class="container">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" aria-current="page" href="Index.aspx">Home</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="Cadastro.aspx">Cadastro de hoteis</a>
            </li>
            
        </ul>

        <form id="form1" runat="server">

            <div class="mb-3">
            </div>
            <asp:Button runat="server" type="button" Text="Pesquisar pelo nome do hotel e as suas comodidades" class="btn btn-outline-primary" OnClick="Unnamed1_Click" Width="1116px"></asp:Button>

            <div class="mb-3">
            </div>




            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Nome</label>
                <asp:TextBox ID="txtNome" runat="server" type="text" class="form-control" placeholder="Preencha o nome hotel para pesquisar"></asp:TextBox>
            </div>

            <div class="mb-3">
            </div>

            <div class="mb-3">
            </div>

            <div class="mb-1">
                <label for="exampleFormControlTextarea1" class="form-label">Selecione as comodidades do hotel para realizar a pesquisa : </label>
            </div>
            <div class="form-check form-check-inline">
                <asp:CheckBox ID="checkEstacionamento" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                <label class="form-check-label" for="RadioEstrela1">Estacionamento</label>
            </div>
            <div class="form-check form-check-inline">
                <asp:CheckBox ID="checkPiscina" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                <label class="form-check-label" for="RadioEstrela2">Piscina</label>
            </div>
            <div class="form-check form-check-inline">
                <asp:CheckBox ID="checkSauna" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                <label class="form-check-label" for="RadioEstrela3">Sauna</label>
            </div>
            <div class="form-check form-check-inline">
                <asp:CheckBox ID="checkWifi" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                <label class="form-check-label" for="RadioEstrela4">Wi-fi</label>
            </div>
            <div class="form-check form-check-inline">
                <asp:CheckBox ID="checkRestaurante" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                <label class="form-check-label" for="RadioEstrela5">Restaurante</label>
            </div>
            <div class="form-check form-check-inline">
                <asp:CheckBox ID="checkBar" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                <label class="form-check-label" for="RadioEstrela5">Bar</label>
            </div>
            <div class="form-check form-check-inline">
                <asp:CheckBox ID="checkAcademia" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                <label class="form-check-label" for="RadioEstrela5">Academia</label>
            </div>


            <div class="mb-3">
            </div>
            <div class="mb-3">
            </div>
            <div class="mb-1">
                <asp:label runat="server" id="lblRelacao" text="Relação de hoteis encontrados : " for="exampleFormControlTextarea1" class="form-label" Visible="False"></asp:label>
            </div>





            <asp:GridView ID="gridHotel" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Width="1114px"
                OnRowDeleting="GridHotel_ApagarLinha" OnRowDataBound="gridHotel_RowDataBound" OnRowEditing="gridHotel_RowEditing">

                <Columns>

                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate><%#Eval("nome") %>    </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtnome" runat="server" Text='<%#Eval("nome") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estrelas">
                        <ItemTemplate><%#Eval("estrelas") %>    </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtendereco" runat="server" Text='<%#Eval("estrelas") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cidade">
                        <ItemTemplate><%#Eval("cidade") %>    </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCidade" runat="server" Text='<%#Eval("cidade") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate><%#Eval("estado") %>    </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEstado" runat="server" Text='<%#Eval("estado") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ButtonType="Image"
                        EditImageUrl="Imagem/editar.jpg"
                        UpdateImageUrl="Imagem/aceitar.jpg"
                        CancelImageUrl="Imagem/deleta.jpg" HeaderText="Editar" />
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="Imagem/deleta.jpg" HeaderText="Deletar" />
                </Columns>
            </asp:GridView>



            <asp:Panel ID="panelAtualizacao" runat="server" Visible="False">

                <div class="container">


                    <div class="card">
                        <div class="card-header">Atualização dos dados do cliente selecionado</div>
                        <div class="card-body">
                            <asp:Button id="btnSalvar" runat="server" type="button" Text="Salvar alterações" class="btn btn-outline-primary"  Width="563px" OnClick="Unnamed2_Click"></asp:Button>
                            <asp:Button id="btnVoltar" runat="server" type="button" Text="Voltar" class="btn btn-outline-primary"  Width="560px" OnClick="btnVoltar_Click"></asp:Button>                            
                            <div class="mb-3">
                            </div>

                            <center>
            <asp:Label ID="lblMensagem" runat="server" Text="Label" Visible="false" position="center" ForeColor="red"></asp:Label>
            </center>







                            <div class="mb-3">
                                <label for="exampleFormControlInput1" class="form-label">Nome</label>
                                <asp:TextBox ID="txtNomeAt" runat="server" type="text" class="form-control" placeholder="Preencher o nome completo"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label for="exampleFormControlTextarea1" class="form-label">Resumo do Hotel</label>
                                <asp:TextBox ID="txtResumo" runat="server" TextMode="MultiLine" type="text" class="form-control" placeholder="Preencher o resumo do hotel" Rows="3" Height="84px"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                            </div>


                            <div class="mb-1">
                                <label for="exampleFormControlTextarea1" class="form-label">Selecione o número de estrelas do hotel : </label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="RadioEstrela1" value="1" Checked="false" GroupName="RadioGroup1" runat="server"></asp:RadioButton>
                                <label class="form-check-label" for="RadioEstrela1">1</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="RadioEstrela2" value="2" Checked="false" GroupName="RadioGroup1" runat="server"></asp:RadioButton>
                                <label class="form-check-label" for="RadioEstrela2">2</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="RadioEstrela3" value="3" Checked="false" GroupName="RadioGroup1" runat="server"></asp:RadioButton>
                                <label class="form-check-label" for="RadioEstrela3">3</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="RadioEstrela4" value="4" Checked="false" GroupName="RadioGroup1" runat="server"></asp:RadioButton>
                                <label class="form-check-label" for="RadioEstrela4">4</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="RadioEstrela5" value="5" Checked="false" GroupName="RadioGroup1" runat="server"></asp:RadioButton>
                                <label class="form-check-label" for="RadioEstrela5">5</label>
                            </div>


                            <div class="mb-3">
                            </div>

                            <div class="row g-3">
                                <div class="col">
                                    <label for="exampleFormControlTextarea1" class="form-label">Logradouro </label>
                                </div>
                                <div class="col-2">
                                    <label for="exampleFormControlTextarea1" class="form-label">Número </label>
                                </div>
                            </div>


                            <div class="row g-3">
                                <div class="col">
                                    <asp:TextBox ID="txtLogradouro" runat="server" type="text" class="form-control" placeholder="Preencher o logradouro do hotel"></asp:TextBox>
                                </div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtNumero" runat="server" type="text" class="form-control" placeholder="Preencher o número"></asp:TextBox>
                                </div>
                            </div>



                            <div class="mb-3">
                            </div>

                            <div class="row g-3">
                                <div class="col-4">
                                    <label for="exampleFormControlTextarea1" class="form-label">Bairro </label>
                                </div>
                                <div class="col-4">
                                    <label for="exampleFormControlTextarea1" class="form-label">Cidade </label>
                                </div>
                                <div class="col-4">
                                    <label for="exampleFormControlTextarea1" class="form-label">Estado </label>
                                </div>
                            </div>


                            <div class="row g-3">
                                <div class="col-4">
                                    <asp:TextBox ID="txtBairro" runat="server" type="text" class="form-control" placeholder="Preencher o bairro"></asp:TextBox>
                                </div>
                                <div class="col-4">
                                    <asp:TextBox ID="txtCidade" runat="server" type="text" class="form-control" placeholder="Preencher a cidade"></asp:TextBox>
                                </div>
                                <div class="col-4">
                                    <asp:DropDownList class="form-select" ID="dropEstado" runat="server">
                                        <asp:ListItem>Acre</asp:ListItem>
                                        <asp:ListItem>Alagoas</asp:ListItem>
                                        <asp:ListItem>Amapá</asp:ListItem>
                                        <asp:ListItem>Amazonas</asp:ListItem>
                                        <asp:ListItem>Bahia</asp:ListItem>
                                        <asp:ListItem>Ceará</asp:ListItem>
                                        <asp:ListItem>Distrito Federal</asp:ListItem>
                                        <asp:ListItem>Espírito Santo</asp:ListItem>
                                        <asp:ListItem>Goiás</asp:ListItem>
                                        <asp:ListItem>Maranhão</asp:ListItem>
                                        <asp:ListItem>Mato Grosso</asp:ListItem>
                                        <asp:ListItem>Mato Grosso do Sul</asp:ListItem>
                                        <asp:ListItem>Minas Gerais</asp:ListItem>
                                        <asp:ListItem>Pará</asp:ListItem>
                                        <asp:ListItem>Paraíba</asp:ListItem>
                                        <asp:ListItem>Paraná</asp:ListItem>
                                        <asp:ListItem>Pernambuco</asp:ListItem>
                                        <asp:ListItem>Piauí</asp:ListItem>
                                        <asp:ListItem>Rio de Janeiro</asp:ListItem>
                                        <asp:ListItem>Rio Grande do Norte</asp:ListItem>
                                        <asp:ListItem>Rio Grande do Sul</asp:ListItem>
                                        <asp:ListItem>Rondônia</asp:ListItem>
                                        <asp:ListItem>Roraima</asp:ListItem>
                                        <asp:ListItem>Santa Catarina</asp:ListItem>
                                        <asp:ListItem>São Paulo</asp:ListItem>
                                        <asp:ListItem>Sergipe</asp:ListItem>
                                        <asp:ListItem>Tocantins</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="mb-3">
                            </div>

                            <div class="mb-1">
                                <label for="exampleFormControlTextarea1" class="form-label">Selecione as comodidades presentes no hotel : </label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox ID="checkEstacionamentoAt" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                                <label class="form-check-label" for="RadioEstrela1">Estacionamento</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox ID="checkPiscinaAt" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                                <label class="form-check-label" for="RadioEstrela2">Piscina</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox ID="checkSaunaAt" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                                <label class="form-check-label" for="RadioEstrela3">Sauna</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox ID="checkWifiAt" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                                <label class="form-check-label" for="RadioEstrela4">Wi-fi</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox ID="checkRestauranteAt" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                                <label class="form-check-label" for="RadioEstrela5">Restaurante</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox ID="checkBarAt" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                                <label class="form-check-label" for="RadioEstrela5">Bar</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox ID="checkAcademiaAt" Checked="false" GroupName="RadioGroup1" runat="server"></asp:CheckBox>
                                <label class="form-check-label" for="RadioEstrela5">Academia</label>
                            </div>
                        </div>
                </div>
    </div>


    <asp:GridView ID="gridHotelAt" runat="server" OnRowDataBound="gridHotelAt_RowDataBound" Visible="False">
    </asp:GridView>

    </asp:Panel>



        </form>
    </div>





</body>
</html>
