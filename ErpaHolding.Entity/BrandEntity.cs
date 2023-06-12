namespace ErpaHolding.Entity
{
    public class BrandEntity :BaseEntity
    {
        public string Defination { get; set; }     

        #region Navigation Properties
        public List<ProductEntity> Products { get; set; }
        #endregion

    }
}
