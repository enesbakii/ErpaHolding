namespace ErpaHolding.Entity
{
    public class RoleEntity:BaseEntity
    {
        public string Name { get; set; }


        public List<UserRolesEntity> UserRoles { get; set; }
    }
}
