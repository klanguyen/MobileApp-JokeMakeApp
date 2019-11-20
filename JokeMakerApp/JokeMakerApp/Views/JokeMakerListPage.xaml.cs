using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace JokeMakerApp
{
    public partial class JokeMakerListPage : ContentPage
    {
        public JokeMakerListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ((App)App.Current).ResumeAtJokeId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JokeMakerItemPage
            {
                BindingContext = new JokeMakerItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new JokeMakerItemPage
                {
                    BindingContext = e.SelectedItem as JokeMakerItem
                });
            }
        }

        internal static void OnAppearing(ContentPage contentPage)
        {
            throw new NotImplementedException();
        }
    }
}
