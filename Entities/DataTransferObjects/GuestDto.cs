namespace Entities.DataTransferObjects
{
    [Serializable]
    public record GuestDto()
    {
        public Guid Id{ get; set; }
        public string firstName{ get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public long phone { get; set; }
    }

}
