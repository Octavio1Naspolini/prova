using Dominio.Entidades;
using Infraestrutura;
using Java.Lang;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using static Java.Util.Jar.Attributes;
using static System.Net.Mime.MediaTypeNames;

namespace prova;

public partial class ShareDetails : ContentPage
{
    private string _simboloAcao;
    private readonly BaseClient _client = new BaseClient();

    public ShareDetails(string simboloAcao)
    {
        InitializeComponent();
        _simboloAcao = simboloAcao;
        CarregarDados();
    }

    private async Task CarregarDados()
    {
            HttpResponseMessage respostaAPI = await _client.GetShare(_simboloAcao);
            string conteudo = await respostaAPI.Content.ReadAsStringAsync();
            Acao acao = JsonConvert.DeserializeObject<Acao>(conteudo);

            MainThread.BeginInvokeOnMainThread(() =>
            {
            Nome.Text = acao!.ShortName;
            Sobrenome.Text = acao.LongName;
            Capitalizacao.Text = acao.MarketCap.ToString();
            Variacao.Text = acao.RegularMarketChange.ToString();
            Percentual.Text = acao.RegularMarketChangePercent.ToString();
            Preco.Text = acao.RegularMarketPrice.ToString();
            });
    }
}