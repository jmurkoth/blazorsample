using BlazorSample.Shared;
using System;
using System.Collections.Generic;

namespace BlazorSample.Client
{
    public class OrderState
    {
        public Pizza ConfiguringPizza { get; set; }
        
        public bool ShowconfigurationDialog  { get; set; }
     
        public Order PizzaOrder { get; private set; } = new Order();

        public event EventHandler StateChanged;

        public void ShowConfigurePizzaDialog(PizzaSpecial special)
        {
            this.ConfiguringPizza = new Pizza
            {
                Special = special,
                SpecialId = special.Id,
                Size = Pizza.DefaultSize,
                Toppings = new List<PizzaTopping>()
            };
            this.ShowconfigurationDialog = true;
        }
        public void CancelConfigurePizzaDialog()
        {
           
            this.ConfiguringPizza = null;
            this.ShowconfigurationDialog= false;
            StateHasChanged();
        }
        public void RemovePizzaFromOrder(Pizza configuredPizza)
        {

            if (this.PizzaOrder != null && configuredPizza != null)
            {

                this.PizzaOrder.Pizzas.Remove(configuredPizza);
            }
            StateHasChanged();
        }

        public void ResetOrder()
        {
            this.PizzaOrder = new Order();
        }

        public void OrderConfiguredPizza()
        {
           
            if (this.ConfiguringPizza != null)
            {
                this.PizzaOrder.Pizzas.Add(this.ConfiguringPizza);
                this.ConfiguringPizza = null;
            }

            this.ShowconfigurationDialog = false;
            StateHasChanged();
        }

        public void AddTopping(Topping topping)
        {
            if (this.ConfiguringPizza != null && this.ConfiguringPizza.Toppings != null && this.ConfiguringPizza.Toppings.Find(pt => pt.Topping == topping) == null)
            {
                this.ConfiguringPizza.Toppings.Add(new PizzaTopping { Topping = topping });

            }
        }
       public void RemoveTopping(Topping topping)
        {
            if (this.ConfiguringPizza != null && this.ConfiguringPizza.Toppings != null)
            {
                this.ConfiguringPizza.Toppings.RemoveAll(pt => pt.Topping == topping);

            }
        }

        private void StateHasChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}