using localbusinessExplore.Pages;

namespace localbusinessExplore
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));

        }
    }
}
