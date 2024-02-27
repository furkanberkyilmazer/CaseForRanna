namespace CaseForRanna_BackEnd.Entities.Dtos
{
    public record CreateUserDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
