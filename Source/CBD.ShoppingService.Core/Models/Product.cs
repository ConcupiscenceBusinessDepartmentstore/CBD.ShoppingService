namespace ShoppingService.Core.Models;

public class Product {
	public Product() {
		Id = Guid.NewGuid().ToString();
	}

	public Product(string name, string description, string price, string quantity) {
		this.Id = Guid.NewGuid().ToString();
		this.Name = name;
		this.Description = description;
		this.Price = double.Parse(price);
		this.Quantity = double.Parse(quantity);
		this.DateTimePosted = DateTime.UtcNow;
	}

	public string Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public DateTime DateTimePosted { get; set; }
	public double Quantity { get; set; } = 0;
	public double Price { get; set; } = 0;
}