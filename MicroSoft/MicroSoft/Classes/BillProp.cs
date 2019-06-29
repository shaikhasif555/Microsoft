using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroSoft.Classes
{
    public class BillProp
    {
        public int Id { get; set; }
        public int DocNo { get; set; }
        public DateTime Date { get; set; }
        public int JobNo { get; set; }
        public string Customer { get; set; }
        public int QuotNo { get; set; }
        public int EstNo { get; set; }
        public int EnqNo { get; set; }
        public decimal QuotationAmt { get; set; }
        public decimal InvoiceAmt { get; set; }
        public string MainJob { get; set; }
        public string PaymentTerm { get; set; }
        public string Remarks { get; set; }


        public List<BillProp> lstBill { get; set; }
    }
}