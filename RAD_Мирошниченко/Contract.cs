using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp2
{
    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ClientId { get; set; }
    }
}
