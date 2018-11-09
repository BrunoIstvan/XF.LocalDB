using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.LocalDB.Model;

namespace XF.LocalDB.View.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoAlunoView : ContentPage
    {

        //private int alunoId = 0;
        private XF.LocalDB.Model.Aluno aluno;

        public XF.LocalDB.Model.Aluno Aluno
        {
            get { return aluno; }
            set { aluno = value; }
        }

        protected override void OnAppearing()
        {
            btnExcluir.IsEnabled = true;
            if (aluno == null)
            {
                btnExcluir.IsEnabled = false;
            }

        }

        public NovoAlunoView()
        {
            InitializeComponent();
        }
        
        public void OnSalvar(object sender, EventArgs args)
        {
            if(aluno == null)
            {
                aluno = new XF.LocalDB.Model.Aluno()
                {
                    Nome = txtNome.Text,
                    RM = txtRM.Text,
                    Email = txtEmail.Text,
                    Aprovado = IsAprovado.IsToggled,
                    Id = 0
                };
                Limpar();
            }
            
            App.AlunoModel.SalvarAluno(aluno);
            Navigation.PopAsync();
        }

        public void OnCancelar(object sender, EventArgs args)
        {
            Limpar();
            Navigation.PopAsync();
        }

        public void OnExcluir(object sender, EventArgs args)
        {
            App.AlunoModel.RemoverAluno(aluno.Id);
            Navigation.PopAsync();
        }

        private void Limpar()
        {
            txtNome.Text = txtRM.Text = txtEmail.Text = string.Empty;
            IsAprovado.IsToggled = false;
        }
    }

}
