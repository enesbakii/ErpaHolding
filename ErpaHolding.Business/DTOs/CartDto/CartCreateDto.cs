namespace ErpaHolding.Business.DTOs.CartDto
{
    public class CartCreateDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }

    public class CartDetailsCreateDto
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }

        public int Count { get; set; }
    }

    public class CartDetailsDto
    {
        public Guid ProductId { get; set; }

        public int Count { get; set; }        
    }
}
