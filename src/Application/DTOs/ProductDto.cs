namespace Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string CreatedByUserId { get; set; }
    public string Name { get; set; }
    public DateOnly ProduceDate { get; set; }
    public string ManufactureEmail { get; set; }
    public string ManufacturePhone { get; set; }
    public bool IsAvailable { get; set; }
}
