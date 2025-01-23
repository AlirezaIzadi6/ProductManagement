namespace Web.DTOs;

public class CreateProductDto
{
    public string Name { get; set; }
    public DateOnly ProduceDate { get; set; }
    public string ManufactureEmail { get; set; }
    public string ManufacturePhone { get; set; }
    public bool IsAvailable { get; set; }
}
