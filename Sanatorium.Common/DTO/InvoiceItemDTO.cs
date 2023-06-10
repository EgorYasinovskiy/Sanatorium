namespace Sanatorium.Common.DTO
{
    public class InvoiceItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quanitity { get; set; }
        public double Price { get; set; }
        public double Sum { get => Quanitity * Price; }
    }
}
