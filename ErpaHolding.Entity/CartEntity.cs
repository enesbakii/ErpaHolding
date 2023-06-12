namespace ErpaHolding.Entity
{
    public class CartEntity:BaseEntity
    {
        public Guid UserId { get; set; }


        #region Navigation Property

        public List<CartDetailsEntity> CartDetails { get; set; }
        #endregion
    }
}
