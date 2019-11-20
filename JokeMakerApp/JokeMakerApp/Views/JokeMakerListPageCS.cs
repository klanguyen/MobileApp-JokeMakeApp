using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace JokeMakerApp
{
    public class JokeMakerListPageCS : ContentPage
    {
        ListView listView;

        public JokeMakerListPageCS()
        {
            Title = "JokeList";

            listView = new ListView
            {
                Margin = new Thickness(20),
                ItemTemplate = new DataTemplate(() =>
                {
                    var addButton = new Button { Text = "Add Joke" };
                    addButton.Clicked += async (sender, e) =>
                    {
                        var jokeItem = (JokeMakerItem)BindingContext;
                        await App.Database.SaveItemAsync(jokeItem);
                        await Navigation.PopAsync();
                    };

                    var label = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    label.SetBinding(Label.TextProperty, "Jokes");

                    var stackLayout = new StackLayout
                    {
                        Margin = new Thickness(20, 0, 0, 0),
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { label }
                    };

                    return new ViewCell { View = stackLayout };
                })
            };
            listView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new JokeMakerItemPageCS
                    {
                        BindingContext = e.SelectedItem as JokeMakerItem
                    });
                }
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    listView
                }
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ((App)App.Current).ResumeAtJokeId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
    }
}
