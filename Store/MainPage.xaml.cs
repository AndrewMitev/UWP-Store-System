namespace Store
{
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using Helpers;
    using Models;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Windows.Storage;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const int FoodIdCategory = 1;
        private const int DrinkIdCategory = 2;
        private const int StyleIdCategory = 3;

        public MainPage()
        {
            this.InitializeComponent();
            this.Init();

            this.UserName.Text = Cart.UserChart.FirstName;
            this.Money.Text = Cart.UserChart.Money.ToString() + " $";
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

            //await connection.QueryAsync<Item>("DELETE FROM Item");

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
                    Name = "Beef",
                    Price = 3.60m,
                    Image = File.ReadAllBytes("Images/food/beef.jpg"),
                    Measurement = "Kg.",
                    Quantity = 30,
                    CategoryId = 1
                };

                await connection.InsertAsync(foodItemOne);

                var foodItemTwo = new Item()
                {
                    Id = 2,
                    Name = "Cheese",
                    Price = 2.40m,
                    Image = File.ReadAllBytes("Images/food/cheese.jpg"),
                    Measurement = "Kg.",
                    Quantity = 24,
                    CategoryId = 1
                };

                await connection.InsertAsync(foodItemTwo);

                var foodItemThree = new Item()
                {
                    Id = 3,
                    Name = "Potatoes",
                    Price = 1.00m,
                    Image = File.ReadAllBytes("Images/food/potatoes.jpg"),
                    Measurement = "Kg.",
                    Quantity = 1000,
                    CategoryId = 1
                };

                await connection.InsertAsync(foodItemThree);

                var foodItemFour = new Item()
                {
                    Id = 4,
                    Name = "Tomatoes",
                    Price = 0.80m,
                    Image = File.ReadAllBytes("Images/food/tomatoes.jpg"),
                    Measurement = "Kg.",
                    Quantity = 200,
                    CategoryId = 1
                };

                await connection.InsertAsync(foodItemFour);

                var drinkItemOne = new Item()
                {
                    Id = 1,
                    Name = "Coca Cola",
                    Price = 1.20m,
                    Image = File.ReadAllBytes("Images/drinks/cola.jpg"),
                    Measurement = "750ml.",
                    Quantity = 300,
                    CategoryId = 2
                };

                await connection.InsertAsync(drinkItemOne);

                var drinkItemTwo = new Item()
                {
                    Id = 2,
                    Name = "Fanta",
                    Price = 1.40m,
                    Image = File.ReadAllBytes("Images/drinks/fanta.png"),
                    Measurement = "600ml.",
                    Quantity = 400,
                    CategoryId = 2
                };

                await connection.InsertAsync(drinkItemTwo);

                var drinkItemThree = new Item()
                {
                    Id = 3,
                    Name = "Juice",
                    Price = 0.80m,
                    Image = File.ReadAllBytes("Images/drinks/juice.jpg"),
                    Measurement = "1.2L.",
                    Quantity = 40,
                    CategoryId = 2
                };

                await connection.InsertAsync(drinkItemThree);

                var drinkItemFour = new Item()
                {
                    Id = 4,
                    Name = "Milk",
                    Price = 1.45m,
                    Image = File.ReadAllBytes("Images/drinks/milk.png"),
                    Measurement = "1.2L.",
                    Quantity = 50,
                    CategoryId = 2
                };

                await connection.InsertAsync(drinkItemFour);

                var styleItemOne = new Item()
                {
                    Id = 1,
                    Name = "Nike Shoes Sports Man Trainers Amd2016-Iso20",
                    Price = 240.00m,
                    Image = File.ReadAllBytes("Images/style/nike.jpg"),
                    Measurement = "Item",
                    Quantity = 10,
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
            this.Frame.Navigate(typeof(ItemPage), FoodIdCategory);
        }

        private void drinksButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ItemPage), DrinkIdCategory);
        }

        private void fashionButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ItemPage), StyleIdCategory);
        }

        private void My_Cart(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MyCart));
        }
    }
}
