using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroSoft.Models
{
    public class Bill
    {

        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter DocNo")]
        [Range(1,10000)]
        public int DocNo { get; set; }

        [Required(ErrorMessage = "Please enter Date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }


        [Required(ErrorMessage = "Please enter JobNo")]
        [Range(1, 10000)]
        public int JobNo { get; set; }


        [Required(ErrorMessage = "Please enter Customer")]
        public string Customer { get; set; }

        [Required(ErrorMessage = "Please enter QuotNo")]
        [Range(1, 10000)]
        public int QuotNo { get; set; }

        [Required(ErrorMessage = "Please enter EstNo")]
        [Range(1, 10000)]
        public int EstNo { get; set; }

        [Required(ErrorMessage = "Please enter EnqNo")]
        [Range(1, 10000)]
        public int EnqNo { get; set; }

        [Required(ErrorMessage = "Please enter QuotationAmt")]
        [Range(1, 10000)]
        public decimal QuotationAmt { get; set; }

        [Required(ErrorMessage = "Please enter InvoiceAmt")]
        [Range(1, 10000)]
        public decimal InvoiceAmt { get; set; }

        [Required(ErrorMessage = "Please enter MainJob")]
        public string MainJob { get; set; }

        [Required(ErrorMessage = "Please enter PaymentTerm")]
        public string PaymentTerm { get; set; }

        [Required(ErrorMessage = "Please enter Remarks")]
        public string Remarks { get; set; }


        public string flag { get; set; }
        public string buttonText { get; set; }
        public string Message { get; set; }

        public List<Classes.BillProp> lstBill { get; set; }



        //[Display(Name = "Date")]
        //[DataType(DataType.Date)]
        //public DateTime? Date { get; set; }




    }
}