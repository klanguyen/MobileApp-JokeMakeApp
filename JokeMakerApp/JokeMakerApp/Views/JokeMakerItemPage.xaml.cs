using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JokeMakerApp
{
    public partial class JokeMakerItemPage : ContentPage
    {
        public JokeMakerItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var jokeItem = (JokeMakerItem)BindingContext;
            await App.Database.SaveItemAsync(jokeItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var jokeItem = (JokeMakerItem)BindingContext;
            await App.Database.DeleteItemAsync(jokeItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
