using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Teste_Expense
{
    public partial class Teste : System.Web.UI.Page
    {
        string api = "https://localhost:44316/";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            //Verifica campos vazios
            if ((txtNome.Text == string.Empty) || (txtResumo.Text == string.Empty) || (txtLogradouro.Text == string.Empty) ||
    (txtNumero.Text == string.Empty) || (txtBairro.Text == string.Empty) || (txtCidade.Text == string.Empty) ||
    (dropEstado.Text == string.Empty))
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "Favor preencher todos os campos";
                goto fim;
            }
            //Verifica se o número da rua é mesmo um número
            if ((!Regex.IsMatch(txtNumero.Text, @"^[0-9]+$")))
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "Favor preencher o número corretamente";
                goto fim;
            }


            //Zera variável das estrelas
            int radio = 0;

            //Verifica quantidade de estrelas
            if (RadioEstrela1.Checked == true)
            {
                radio = 1;
            }
            if (RadioEstrela2.Checked == true)
            {
                radio = 2;
            }
            if (RadioEstrela3.Checked == true)
            {
                radio = 3;
            }
            if (RadioEstrela4.Checked == true)
            {
                radio = 4;
            }
            if (RadioEstrela5.Checked == true)
            {
                radio = 5;
            }



            //Faz o cadastro de todos os campos da tabela alterados pelo usuário
            HOTEL cli = new HOTEL()
            {
                NOME = txtNome.Text,
                RES_HOTEL = txtResumo.Text,
                ESTRELAS =
                Convert.ToByte(radio),
                LOGRADOURO = txtLogradouro.Text,
                NUMERO =
                Convert.ToInt32(txtNumero.Text),
                BAIRRO = txtBairro.Text,
                CIDADE =
                txtCidade.Text,
                ESTADO = dropEstado.Text,
                ESTACIONAMENTO = checkEstacionamento.Checked,
                PISCINA = checkPiscina.Checked,
                SAUNA = checkSauna.Checked,
                WIFI = checkWifi.Checked,
                RESTAURANTE = checkRestaurante.Checked,
                BAR = checkBar.Checked,
                ACADEMIA =
                checkAcademia.Checked
            };
            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri(api + "api/");
            HttpResponseMessage responseCli = clint.PostAsJsonAsync("Hotel", cli).Result;

            txtNome.Text = string.Empty;
            txtResumo.Text = string.Empty;
            txtLogradouro.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            dropEstado.Text = string.Empty;
            lblMensagem.Visible = false;
            MessageBox.Show("Cadastro realizado com sucesso");

        fim:;

        }
    }
}