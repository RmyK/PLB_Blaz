using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListWASM.Shared.DTOs
{
    public class TodoDTO
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string TodoLabel { get; set; }
        public bool IsDone { get; set; }
        public int UserId { get; set; }
    }
}
