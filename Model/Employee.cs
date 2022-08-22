using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dapperAPIpractice.Model
{
    [Table("Employee")]
    public class Employee
    {                   
            [Key]
            public int id { get; set; }
            public string ?ename { get; set; }
            public double salary { get; set; }
        
    }
}
