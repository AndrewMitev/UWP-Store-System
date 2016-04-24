using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using Store.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Store
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Seed();
        }

        private SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");

            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        private async Task InitAsync()
        {
            var connection = this.GetDbConnectionAsync();
            await connection.CreateTableAsync<DrinkItem>();
            await connection.CreateTableAsync<FoodItem>();
            await connection.CreateTableAsync<StyleItem>();
        }

        private async void Seed()
        {
            var connection = this.GetDbConnectionAsync();

            await InitAsync();

            if (connection.Table<FoodItem>().CountAsync().Result == 0)
            {
                var foodItemOne = new FoodItem()
                {
                    Name = "Beef",
                    Price = 3.60m,
                    Image = File.ReadAllBytes("Images/food/beef.jpg")
                };

                await connection.InsertAsync(foodItemOne);

                var foodItemTwo = new FoodItem()
                {
                    Name = "Cheese",
                    Price = 2.40m,
                    Image = File.ReadAllBytes("Images/food/cheese.jpg")
                };

                await connection.InsertAsync(foodItemTwo);

                var foodItemThree = new FoodItem()
                {
                    Name = "Potatoes",
                    Price = 1.00m,
                    Image = File.ReadAllBytes("Images/food/potatoes.jpg")
                };

                await connection.InsertAsync(foodItemThree);

                var foodItemFour = new FoodItem()
                {
                    Name = "Tomatoes",
                    Price = 0.80m,
                    Image = File.ReadAllBytes("Images/food/tomatoes.jpg")
                };

                await connection.InsertAsync(foodItemFour);
            }

            if (connection.Table<DrinkItem>().CountAsync().Result == 0)
            {
                var drinkItemOne = new DrinkItem()
                {
                    Name = "Coca Cola",
                    Price = 1.20m,
                    Image = File.ReadAllBytes("Images/drinks/cola.jpg")
                };

                await connection.InsertAsync(drinkItemOne);

                var drinkItemTwo = new DrinkItem()
                {
                    Name = "Fanta",
                    Price = 1.40m,
                    Image = File.ReadAllBytes("Images/drinks/fanta.png")
                };

                await connection.InsertAsync(drinkItemTwo);

                var drinkItemThree = new DrinkItem()
                {
                    Name = "Juice",
                    Price = 0.80m,
                    Image = File.ReadAllBytes("Images/drinks/juice.jpg")
                };

                await connection.InsertAsync(drinkItemThree);

                var drinkItemFour = new DrinkItem()
                {
                    Name = "Milk",
                    Price = 1.45m,
                    Image = File.ReadAllBytes("Images/drinks/milk.png")
                };

                await connection.InsertAsync(drinkItemFour);
            }


            if (connection.Table<StyleItem>().CountAsync().Result == 0)
            {
                var styleItemOne = new StyleItem()
                {
                    Name = "Nike Shoes Sports Man Trainers Amd2016-Iso20",
                    Price = 240.00m,
                    Image = File.ReadAllBytes("Images/style/nike.jpg")
                };

                await connection.InsertAsync(styleItemOne);
            }

            //AsyncTableQuery<Article> query = conn.Table<Article>()
            //                                        .Where(x => x.Title.Contains(title));
            //List<Article> result = await query.ToListAsync();
        }

        private void Menu_Tapped(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(FoodPage));
        }

        private void foodButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FoodPage));
        }

        //private void drinksButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Drinks));
        //}

        //private void fashionButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Fashion));
        //}
    }
}
