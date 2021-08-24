
namespace HN.ManagementEngine.DTO
{
    public class UserDonorPermitDTO
    {
        public int Id { get; set; }
        public bool Permit { get; set; }
        public int DonorId { get; set; }
        public int UserId { get; set; }
    }
}
