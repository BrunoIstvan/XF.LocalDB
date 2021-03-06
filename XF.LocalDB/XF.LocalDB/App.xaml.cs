using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.LocalDB.Model;
using XF.LocalDB.View.Aluno;
using XF.LocalDB.ViewModel;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XF.LocalDB
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            if (UsuarioVM == null)
            {
                UsuarioVM = new UsuarioViewModel();
            }

            MainPage = new NavigationPage(new View.Login.LoginView()
            {
                BindingContext = App.UsuarioVM
            });
        }

        public static UsuarioViewModel UsuarioVM { get; set; }

        static Aluno alunoModel;

        public static Aluno AlunoModel
        {
            get
            {
                if (alunoModel == null)
                {
                    alunoModel = new Aluno();
                }
                return alunoModel;
            }
        }        
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}
    
		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
