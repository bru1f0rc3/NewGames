using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{
    public partial class MainPage : ContentPage
    {
        int answer = 0;
        int verity = 1;
        int no_verity = 1;
        int score = 0;
        Random rand = new Random();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            int a = rand.Next(1, 10);
            int b = rand.Next(1, 10);

            label_rand_first.Text = $"{a}";
            label_rand_second.Text = $"{b}";

            answer = a * b;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (TbNumber.Text == answer.ToString())
            {
                await Navigation.PushModalAsync(new Page1());
                await Task.Delay(1500);
                await Navigation.PopModalAsync();
                answerss.Text = $"Правильно: {verity++}";
                await Task.Delay(500);
                scores.Text = $"Твои очки: {score += 10}";
            }
            else
            {
                await Navigation.PushModalAsync(new Page2());
                await Task.Delay(1500);
                await Navigation.PopModalAsync();
                not_answer.Text = $"Неправильно: {no_verity++}";
                await Task.Delay(500);
                scores.Text = $"Твои очки: {score -= 10}";
            }

            int a = rand.Next(1, 10);
            int b = rand.Next(1, 10);

            label_rand_first.Text = $"{a}";
            label_rand_second.Text = $"{b}";

            answer = a * b;
        }
    }
}
