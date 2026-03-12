namespace POSSystem.Models.ResponseDTOModels
{
    public class ResponseUserDto : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
