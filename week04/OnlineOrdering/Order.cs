using System.Collections.Generic;
using System.Text;

class Order
{
    private readonly List<Product> _products;
    private readonly Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        return total + GetShippingCost();
    }

    private double GetShippingCost()
    {
        return _customer.LivesInUSA() ? 5.0 : 35.0;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("=== Packing Label ===");
        foreach (Product product in _products)
        {
            label.AppendLine($"  {product.GetName()} (ID: {product.GetProductId()})");
            label.AppendLine($"    Quantity: {product.GetQuantity()}  Price: ${product.GetPrice():F2}  Subtotal: ${product.GetTotalCost():F2}");
        }
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("=== Shipping Label ===");
        label.AppendLine(_customer.GetName());
        label.AppendLine(_customer.GetAddress().GetFullAddress());
        return label.ToString();
    }
}
