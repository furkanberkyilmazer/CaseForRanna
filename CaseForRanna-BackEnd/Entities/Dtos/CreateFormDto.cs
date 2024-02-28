using CaseForRanna_BackEnd.Entities.Enums;

namespace CaseForRanna_BackEnd.Entities.Dtos
{
    public class CreateFormDto
    {
       
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        public string Username { get; set; }


    }
}
