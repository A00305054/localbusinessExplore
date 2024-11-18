namespace localbusinessExplore.Pages
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void OnNavigateToSignUp(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }
    }
}