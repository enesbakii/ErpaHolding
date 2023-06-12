namespace ErpaHolding.Entity
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        #region Navigation Properties
        public List<UserRolesEntity> UserRoles { get; set; }
        public List<OrderEntity> Orders { get; set; }

        #endregion

    }
}
