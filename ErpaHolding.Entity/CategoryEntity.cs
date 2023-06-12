namespace ErpaHolding.Entity
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        //rel prop
        public List<ProductEntity> Products { get; set; }
    }
}
