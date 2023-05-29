namespace ContactRegister.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int ContatId { get; set; }
        public Contact Contat { get; set; }
    }
}
