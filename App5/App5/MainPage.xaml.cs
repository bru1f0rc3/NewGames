using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

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
        /// <summary>
        /// Первоначальный рандомайзер чисел для умножения
        /// </summary>
        protected override void OnAppearing()
        {
            LoadPoints();
            answerss.Text = $"Правильно: {verity}";
            scores.Text = $"Твои очки: {score}";
            not_answer.Text = $"Неправильно: {no_verity}";

            int a = rand.Next(1, 10);
            int b = rand.Next(1, 10);

            label_rand_first.Text = $"{a}";
            label_rand_second.Text = $"{b}";

            answer = a * b;
        }
        /// <summary>
        /// Отвечаем на таблицу с умножением
        /// </summary>
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (TbNumber.Text == answer.ToString())
            {
                await Navigation.PushModalAsync(new Page1(answer));
                await Task.Delay(1500);
                await Navigation.PopModalAsync();
                verity++;
                answerss.Text = $"Правильно: {verity}";
                score += 10;
                scores.Text = $"Твои очки: {score}";
                TbNumber.Text = "";
            }
            else
            {
                await Navigation.PushModalAsync(new Page2(answer));
                await Task.Delay(1500);
                await Navigation.PopModalAsync();
                no_verity++;
                not_answer.Text = $"Неправильно: {no_verity}";
                score -= 10;
                scores.Text = $"Твои очки: {score}";
                TbNumber.Text = "";
            }

            SavePoints();

            int a = rand.Next(1, 10);
            int b = rand.Next(1, 10);

            label_rand_first.Text = $"{a}";
            label_rand_second.Text = $"{b}";

            answer = a * b;
        }
        /// <summary>
        /// Загрузка очков при запуске приложения
        /// </summary>
        private void LoadPoints()
        {
            List<Points> points = App.Db.GetPoints();
            if (points.Count > 0)
            {
                Points lastPoint = points[points.Count - 1];
                verity = lastPoint.Verity;
                no_verity = lastPoint.No_verity;
                score = lastPoint.Score;
            }
        }
        /// <summary>
        /// Сохранение очков
        /// </summary>
        private void SavePoints()
        {
            Points point = new Points
            {
                Answer = answer,
                Verity = verity,
                No_verity = no_verity,
                Score = score,
            };
            App.Db.SavePoints(point);
        }
    }
}
