namespace ErpaHolding.Entity
{
    public class OrderEntity :BaseEntity
    {
        public Guid UserId { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }

        public int CartTotalItems { get; set; }
       
        public bool OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }


        #region Navigation Properties
        public UserEntity User { get; set; }
        public List<OrderDetailsEntity> OrderDetails { get; set; }
        #endregion

    }
}
