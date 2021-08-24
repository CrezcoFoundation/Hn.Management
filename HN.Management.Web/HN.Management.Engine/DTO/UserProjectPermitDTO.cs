
namespace HN.ManagementEngine.DTO
{
    public class UserProjectPermitDTO
    {
        public int Id { get; set; }
        public bool Permit { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
