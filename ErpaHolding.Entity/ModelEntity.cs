namespace ErpaHolding.Entity
{
    public class ModelEntity:BaseEntity
    {
        public string Name { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}
