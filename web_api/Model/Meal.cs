namespace web_api.Model
{
    public class Meal
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
