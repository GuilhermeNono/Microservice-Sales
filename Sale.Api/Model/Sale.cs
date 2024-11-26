namespace Sale.Api.Model;

public class Sale
{
    public int Id { get; set; }
    public List<int> ProductsId { get; set; } = [];
}
