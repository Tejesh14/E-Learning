namespace E_Learning.DAL.Models.Identity
{
    public class AspNetUserLogins
    {
        public string LoginProvider { get; set; } = string.Empty;
        public string ProviderKey { get; set; } = string.Empty;
        public string ProviderDisplayName { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
