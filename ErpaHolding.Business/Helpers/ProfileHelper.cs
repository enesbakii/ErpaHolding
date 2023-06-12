using AutoMapper;
using ErpaHolding.Business.Mappings.AutoMapper;

namespace ErpaHolding.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {

            return new List<Profile>
            {
                new CategoryProfile(),
                new ProductProfile(),
                new BrandProfile(),
                new ProductImagesProfile(),
                new UserProfile(),
                new RoleProfile(),
                new UserRoleProfile(),
                new CartProfile(),
                new ModelProfile(),
                new CartDetailProfile(),
            };
        }
    }
}
