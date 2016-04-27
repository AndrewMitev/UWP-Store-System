using Store.Models.Contracts;
using System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Store.Models
{
    public class ItemViewModel : ISellable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Total
        {
            get
            {
                return (this.Price * this.Quantity);
            }

        }

        public string Measurement { get; set; }

        public byte[] ImageBytes { get; set; }

        public string TempImage { get; set; } = "http://simpleicon.com/wp-content/uploads/mobile-1.png";

        public BitmapImage Image
        {
            get
            {
                return this.GetImage().Result;
            }
        }

        private async Task<BitmapImage> GetImage()
        {
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(this.ImageBytes);
                    await writer.StoreAsync();
                }

                var image = new BitmapImage();
                await image.SetSourceAsync(stream);
                return image;
            }
        }
    }
}
