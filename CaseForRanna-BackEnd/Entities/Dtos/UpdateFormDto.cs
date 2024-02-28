using CaseForRanna_BackEnd.Entities.Enums;

namespace CaseForRanna_BackEnd.Entities.Dtos
{
    public class UpdateFormDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public FormCaseEnum State { get; set; }
    }
}
