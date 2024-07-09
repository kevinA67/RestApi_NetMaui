
namespace PM022024RestApi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //MainPage = new NavigationPage(new Views.PageListEmpleados());
            MainPage = new NavigationPage(new Views.PageCreate());
        }
    }
}
