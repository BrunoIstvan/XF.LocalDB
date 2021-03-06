﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.LocalDB.ViewModel;

namespace XF.LocalDB.View.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        AlunoViewModel vmAluno;
        public MainPage()
        {
            InitializeComponent();
            vmAluno = new AlunoViewModel();
            BindingContext = vmAluno;
        }

        protected override void OnAppearing()
        {
            vmAluno = new AlunoViewModel();
            BindingContext = vmAluno;
            base.OnAppearing();
        }

        private void OnNovo(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NovoAlunoView());
        }

        private void OnAlunoTapped(object sender, ItemTappedEventArgs args)
        {
            var selecionado = args.Item as XF.LocalDB.Model.Aluno;
            // DisplayAlert("Aluno selecionado", "Aluno: " + selecionado.Id, "OK");

            Navigation.PushAsync(new NovoAlunoView()
            {
                Aluno = selecionado,
                BindingContext = selecionado
            });

        }

        private void OnSair(object sender, EventArgs args)
        {
            Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }

}