namespace BlazingPizza.Data
{
    public class PizzaService
    {
        // Returns an empty list of pizzas for now. Replace with real implementation later.
        public Task<Pizza[]> GetPizzasAsync()
        {
            return Task.FromResult(Array.Empty<Pizza>());
        }
    }
}
