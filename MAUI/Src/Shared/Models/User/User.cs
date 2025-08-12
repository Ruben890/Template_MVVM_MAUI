namespace Shared.Models
{
    public class UserModel : BaseResponse
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? LasName { get; set; }

        public string? UserName { get; set; }
    }
}
