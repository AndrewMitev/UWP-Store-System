using Store.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ItemCollectionViewModel
    {
        private ObservableCollection<ISellable> items;

        public ItemCollectionViewModel()
        {
            this.Items = new ObservableCollection<ISellable>();
        }

        public ItemCollectionViewModel(ICollection<ISellable> sellables)
        {
            this.Items = new ObservableCollection<ISellable>(sellables);
        }

        public IEnumerable<ISellable> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                if (this.items == null)
                {
                    this.items = new ObservableCollection<ISellable>(value);
                }

                this.items.Clear();
                value.ForEach(this.items.Add);
            }
        }

        public void Add(ISellable newItem)
        {
            this.items.Add(newItem);
        }

        public void Clear()
        {
            this.items.Clear();
        }
    }
}
