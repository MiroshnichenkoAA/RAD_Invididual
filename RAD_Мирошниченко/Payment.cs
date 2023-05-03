using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp2
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int ContractId { get; set; }
    }
}
