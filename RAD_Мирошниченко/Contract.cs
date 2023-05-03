using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp2
{
    public class Contract
    {
        //contracInfo table (id, contractId, idProduct, quantity, price)
        public int Id { get; set; }    
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public bool isPrePaid { get; set; }
        public bool isCargo { get; set; }
        public int ClientId { get; set; } 
        public int TotalSum { get; set; }
    }
}
