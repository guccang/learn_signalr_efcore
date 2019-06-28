using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_signalR_efcore.Datas
{
    // efcore自动创建student表。
    [Table("student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }

        public string desc { get; set; }
    }
}
