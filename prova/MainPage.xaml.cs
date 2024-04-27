namespace prova
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void CliqueBuscarInformacoes(object sender, EventArgs e)
        {
            string simboloAcao = campoSimbolo.Text;
            ShareDetails shareDetails = new ShareDetails(simboloAcao);
            await Navigation.PushAsync(shareDetails);
        }

    }

}
