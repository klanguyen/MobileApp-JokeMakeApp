using System;
using Xamarin.Forms;
namespace JokeMakerApp
{
    public class JokeMakerItemPageCS : ContentPage
    {
        public JokeMakerItemPageCS()
        {
            Title = "Joke Item";

            var jokesEntry = new Entry();
            jokesEntry.SetBinding(Entry.TextProperty, "Jokes");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var jokeItem = (JokeMakerItem)BindingContext;
                await App.Database.SaveItemAsync(jokeItem);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var jokeItem = (JokeMakerItem)BindingContext;
                await App.Database.DeleteItemAsync(jokeItem);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Jokes" },
                    jokesEntry,
                    saveButton,
                    deleteButton,
                    cancelButton
                }
            };
        }
    }
}
