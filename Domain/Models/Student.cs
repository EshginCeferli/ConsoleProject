using Domain.Common;

namespace Domain.Models
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Group Group { get; set; }
    }
}
