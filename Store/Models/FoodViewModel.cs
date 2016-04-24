using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class FoodViewModel
    {
        private ObservableCollection<FoodItem> foods;

        public FoodViewModel()
        {
            this.Foods = new ObservableCollection<FoodItem>();
        }

        public IEnumerable<FoodItem> Foods
        {
            get
            {
                return this.foods;
            }
            set
            {
                if (this.foods == null)
                {
                    this.foods = new ObservableCollection<FoodItem>(value);
                }

                this.foods.Clear();
                value.ForEach(this.foods.Add);
            }
        }

        public void Add(FoodItem newItem)
        {
            this.foods.Add(newItem);
        }
    }
}
