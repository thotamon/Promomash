namespace Promomash.UserRepository.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public bool Agree { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }

}
