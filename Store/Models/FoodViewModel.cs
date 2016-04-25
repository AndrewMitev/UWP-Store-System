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
        private ObservableCollection<FoodItemViewModel> foods;

        public FoodViewModel()
        {
            this.Foods = new ObservableCollection<FoodItemViewModel>();
        }

        public IEnumerable<FoodItemViewModel> Foods
        {
            get
            {
                return this.foods;
            }
            set
            {
                if (this.foods == null)
                {
                    this.foods = new ObservableCollection<FoodItemViewModel>(value);
                }

                this.foods.Clear();
                value.ForEach(this.foods.Add);
            }
        }

        public void Add(FoodItemViewModel newItem)
        {
            this.foods.Add(newItem);
        }
    }
}
