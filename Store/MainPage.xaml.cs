using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using Store.Helpers;
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
            this.Init();

            this.UserName.Text = Cart.UserChart.FirstName;
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

        private async void Init()
        {
            await this.InitAsync(Seed);
        }

        private async Task InitAsync(Action seedCallback)
        {
            var connection = this.GetDbConnectionAsync();
            await connection.CreateTableAsync<Category>();
            await connection.CreateTableAsync<Item>();

            seedCallback();
        }

        private async void Seed()
        {
            var connection = this.GetDbConnectionAsync();

            var food = new Category { Name = "Food" };
            var drink = new Category { Name = "Drink" };
            var style = new Category { Name = "Style" };

            if (connection.Table<Category>().CountAsync().Result == 0)
            {
                await connection.InsertAsync(food);
                await connection.InsertAsync(drink);
                await connection.InsertAsync(style);
            }

            if (connection.Table<Item>().CountAsync().Result == 0)
            {
                var foodItemOne = new Item()
                {
                    Id = 1,
                    Name = "Beefh",
                    Price = 3.60m,
                    Image = File.ReadAllBytes("Images/food/beef.jpg"),
                    CategoryId = 1
                };

                await connection.InsertAsync(foodItemOne);

                var foodItemTwo = new Item()
                {
                    Id = 2,
                    Name = "Cheese",
                    Price = 2.40m,
                    Image = File.ReadAllBytes("Images/food/cheese.jpg"),
                    CategoryId = 1
                };

                await connection.InsertAsync(foodItemTwo);

                var foodItemThree = new Item()
                {
                    Id = 3,
                    Name = "Potatoes",
                    Price = 1.00m,
                    Image = File.ReadAllBytes("Images/food/potatoes.jpg"),
                    CategoryId = 1
                };

                await connection.InsertAsync(foodItemThree);

                var foodItemFour = new Item()
                {
                    Id = 4,
                    Name = "Tomatoes",
                    Price = 0.80m,
                    Image = File.ReadAllBytes("Images/food/tomatoes.jpg"),
                    CategoryId = 1
                };

                await connection.InsertAsync(foodItemFour);

                var drinkItemOne = new Item()
                {
                    Id = 1,
                    Name = "Coca Cola",
                    Price = 1.20m,
                    Image = File.ReadAllBytes("Images/drinks/cola.jpg"),
                    CategoryId = 2
                };

                await connection.InsertAsync(drinkItemOne);

                var drinkItemTwo = new Item()
                {
                    Id = 2,
                    Name = "Fanta",
                    Price = 1.40m,
                    Image = File.ReadAllBytes("Images/drinks/fanta.png"),
                    CategoryId = 2
                };

                await connection.InsertAsync(drinkItemTwo);

                var drinkItemThree = new Item()
                {
                    Id = 3,
                    Name = "Juice",
                    Price = 0.80m,
                    Image = File.ReadAllBytes("Images/drinks/juice.jpg"),
                    CategoryId = 2
                };

                await connection.InsertAsync(drinkItemThree);

                var drinkItemFour = new Item()
                {
                    Id = 4,
                    Name = "Milk",
                    Price = 1.45m,
                    Image = File.ReadAllBytes("Images/drinks/milk.png"),
                    CategoryId = 2
                };

                await connection.InsertAsync(drinkItemFour);

                var styleItemOne = new Item()
                {
                    Id = 1,
                    Name = "Nike Shoes Sports Man Trainers Amd2016-Iso20",
                    Price = 240.00m,
                    Image = File.ReadAllBytes("Images/style/nike.jpg"),
                    CategoryId = 3
                };

                await connection.InsertAsync(styleItemOne);
            }
        }

        private void Menu_Tapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
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

        private void My_Cart(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyCart));
        }
    }
}
