using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Windows;


namespace Teste_Expense
{
    public partial class Index : System.Web.UI.Page
    {
        string api = "http://apiexpense.gearhostpreview.com/";
        string inicial = "http://testeexpense.gearhostpreview.com/";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            //Tira a visibilidade do painel de atualização , volta o label de pesquisa e o gridview
            lblRelacao.Visible = true;
            gridHotel.Visible = true;
            panelAtualizacao.Visible = false;


            //Conecta ao Web Api , pesquisa pelo nome do hotel e as suas comodidades
            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri(api + "api/");
            HttpResponseMessage responseCli = clint.GetAsync("Hotel?nome=" + txtNome.Text + "&estacionamento=" + checkEstacionamento.Checked + "&piscina=" + checkPiscina.Checked + "&sauna=" + checkSauna.Checked + "&wifi=" + checkWifi.Checked + "&restaurante=" + checkRestaurante.Checked + "&bar=" + checkBar.Checked + "&academia=" + checkAcademia.Checked).Result;

            var cli = responseCli.Content.ReadAsAsync<IEnumerable<HOTEL>>().Result;

            gridHotel.DataSource = cli;
            gridHotel.DataBind();

        }
        protected void GridHotel_ApagarLinha(object sender, GridViewDeleteEventArgs e)
        {
            //Conecta ao Web Api e deleta a linha em que o delete foi clicado
            int id = Convert.ToInt32(gridHotel.DataKeys[e.RowIndex].Value.ToString());

            
                HttpClient clint = new HttpClient();
                clint.BaseAddress = new Uri(api + "/api/");
                HttpResponseMessage responseCli = clint.DeleteAsync("Hotel?id=" + id).Result;
         

        }

        

        protected void gridHotel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate) | e.Row.RowState == DataControlRowState.Edit)
            {
                return;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Referencia ao linkbutton delete
                ImageButton deleteButton = (ImageButton)e.Row.Cells[5].Controls[0];
                deleteButton.OnClientClick = "if (!window.confirm('Confirma a exclusão deste registro ?')) return false;";
            }
        }

        protected void gridHotel_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Conecta ao Web Api e deleta a linha em que o delete foi clicado
            int id = Convert.ToInt32(gridHotel.DataKeys[e.NewEditIndex].Value.ToString());

            //Tira a visibilidade do label de pesquisa, do grid view e volta o a do painel de atualização
            lblRelacao.Visible = false;
            gridHotel.Visible = false;
            panelAtualizacao.Visible = true;

            //Conecta ao Web Api , pesquisa pelo nome do hotel e as suas comodidades
            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri(api + "api/");
            HttpResponseMessage responseCli = clint.GetAsync("Hotel/" + id).Result;

            var cli = responseCli.Content.ReadAsAsync<IEnumerable<HOTEL>>().Result;

            
                gridHotelAt.DataSource = cli;
                gridHotelAt.DataBind();        

            

            //Atualiza dados no painel de atualização

            txtNomeAt.Text = Server.HtmlDecode(gridHotelAt.Rows[0].Cells[1].Text);

            txtResumo.Text = Server.HtmlDecode(gridHotelAt.Rows[0].Cells[2].Text);

            switch (Convert.ToInt32(gridHotelAt.Rows[0].Cells[3].Text))
            {
                case 1:
                    RadioEstrela1.Checked = true;
                    break;
                case 2:
                    RadioEstrela2.Checked = true;
                    break;
                case 3:
                    RadioEstrela3.Checked = true;
                    break;
                case 4:
                    RadioEstrela4.Checked = true;
                    break;
                case 5:
                    RadioEstrela5.Checked = true;
                    break;
            }

            txtLogradouro.Text = Server.HtmlDecode(gridHotelAt.Rows[0].Cells[4].Text);

            txtNumero.Text = Server.HtmlDecode(gridHotelAt.Rows[0].Cells[5].Text);

            txtBairro.Text = Server.HtmlDecode(gridHotelAt.Rows[0].Cells[6].Text);

            txtCidade.Text = Server.HtmlDecode(gridHotelAt.Rows[0].Cells[7].Text);

            dropEstado.Text = Server.HtmlDecode(gridHotelAt.Rows[0].Cells[8].Text);

            

            /*

            
           if (Convert.ToBoolean(gridHotelAt.Rows[0].Cells[9].Text) == true)
           {
               checkEstacionamentoAt.Checked = true;
           }
            
            if (gridHotelAt.Rows[0].Cells[9].Text == "1")
            {
                checkPiscinaAt.Checked = true;
            }
            if (gridHotelAt.Rows[0].Cells[9].Text == "1")
            {
                checkSaunaAt.Checked = true;
            }
            if (gridHotelAt.Rows[0].Cells[9].Text == "1")
            {
                checkWifiAt.Checked = true;
            }
            if (gridHotelAt.Rows[0].Cells[9].Text == "1")
            {
                checkRestauranteAt.Checked = true;
            }
            if (gridHotelAt.Rows[0].Cells[9].Text == "1")
            {
                checkBarAt.Checked = true;
            }
            if (gridHotelAt.Rows[0].Cells[9].Text == "1")
            {
                checkAcademiaAt.Checked = true;
            }
 
            */
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            //Verifica se o número da rua é mesmo um número
            if ((!Regex.IsMatch(txtNumero.Text, @"^[0-9]+$")))
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "Favor preencher o número corretamente";
                goto fim;
            }
            //Salva na variável id o valor da grid view e zera o radio
            int id = Convert.ToInt32(gridHotelAt.Rows[0].Cells[0].Text);
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



            //Faz a atualização de todos os campos da tabela alterados pelo usuário
            HOTEL cli = new HOTEL();
            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri(api + "api/");
            HttpResponseMessage responseCli = clint.PutAsJsonAsync("Hotel?nome=" + txtNomeAt.Text + "&resumo="
                + txtResumo.Text + "&estrelas=" + radio + "&logradouro=" + txtLogradouro.Text +
                "&numero=" + txtNumero.Text + "&bairro=" + txtBairro.Text + "&cidade=" + txtCidade.Text +
                "&estado=" + dropEstado.Text + "&estacionamento=" + checkEstacionamentoAt.Checked +
                "&piscina=" + checkPiscinaAt.Checked + "&sauna=" + checkSaunaAt.Checked + "&wifi="
                + checkWifiAt.Checked + "&restaurante=" + checkRestauranteAt.Checked + "&bar=" + checkBarAt.Checked
                + "&academia=" + checkAcademiaAt.Checked + "&id=" + id, cli).Result;

            txtNomeAt.Text = string.Empty;
            txtResumo.Text = string.Empty;
            txtLogradouro.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            dropEstado.Text = string.Empty;
            lblMensagem.Visible = false;
            MessageBox.Show("Alteração realizada com sucesso");
            panelAtualizacao.Visible = false;

            gridHotel.DataSource = null;

            System.Diagnostics.Process.Start(inicial);


        fim:;
        }

        protected void gridHotelAt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            txtNomeAt.Text = string.Empty;
            txtResumo.Text = string.Empty;
            txtLogradouro.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            dropEstado.Text = string.Empty;
            lblMensagem.Visible = false;            
            panelAtualizacao.Visible = false;

            gridHotel.DataSource = null;

            System.Diagnostics.Process.Start(inicial);
        }
    }
}