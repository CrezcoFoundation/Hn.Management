
namespace HN.ManagementEngine.DTO
{
    public class UserPermitDTO : UserDTO
    {
        public int Id { get; set; }
        public bool DonorPermit { get; set; }
        public bool ProjectPermit { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
