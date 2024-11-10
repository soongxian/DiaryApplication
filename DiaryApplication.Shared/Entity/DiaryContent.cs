using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Shared.Entity
{
    public class DiaryContent
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Content { get; set; }
    }
}
