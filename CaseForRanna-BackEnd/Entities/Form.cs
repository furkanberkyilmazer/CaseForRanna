using CaseForRanna_BackEnd.Entities.Enums;

namespace CaseForRanna_BackEnd.Entities
{
    public class Form
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public FormCaseEnum State { get; set; }


    }
}
