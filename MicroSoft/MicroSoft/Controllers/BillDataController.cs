using MicroSoft.Classes;
using MicroSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroSoft.Controllers
{
    public class BillDataController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id = 0, string type = null)
        {
            Bill bill = new Bill();
            BillTrans billtran = new BillTrans();

            if (id > 0 && !String.IsNullOrWhiteSpace(type))
            {
                try
                {
                    if (type.ToLower().Equals("d"))
                    {
                        bill.Id = id;
                        bill.flag = "Delete";
                        bill.DocNo = 0;
                        bill.Date = Convert.ToDateTime("2008-12-24");                


                        bill.JobNo = 0;
                        bill.Customer = "";
                        bill.QuotNo = 0;
                        bill.EstNo = 0;
                        bill.EnqNo = 0;
                        bill.QuotationAmt = 0;
                        bill.InvoiceAmt = 0;
                        bill.MainJob = "";
                        bill.PaymentTerm = "";
                        bill.Remarks = "";

                        bill.buttonText = "Add";
                        bill = billtran.BillInsert(bill);


                        if (bill.Message.Equals("success"))
                            bill.Message = "Invoice delete successfully";

                        bill.lstBill = billtran.GetBill(0).lstBill;
                        bill.buttonText = "Add";
                        bill.flag = "Insert";
                    }

                    else if (type.ToLower().Equals("e"))
                    {

                        bill = billtran.GetBill(id);
                        bill.flag = "Update";
                        bill.buttonText = "Update";
                        bill.Message = "";
                        bill.lstBill = billtran.GetBill(0).lstBill;

                    }
                }
                catch (Exception ex)
                {

                    bill.lstBill = null;
                    bill.buttonText = "Add";
                    bill.flag = "Insert";
                    bill.Message = ex.Message.ToString();
                }
            }
            else
            {
                bill.Message = "";
                bill.flag = "Insert";
                bill.buttonText = "Add";
                bill.lstBill = billtran.GetBill(0).lstBill;
            }

            return View(bill);
        }


        [HttpPost]
        public ActionResult Index(Bill bil)
        {
            BillTrans billtran = new BillTrans();
            if (ModelState.IsValid)
            {
                Bill b = billtran.BillInsert(bil);
                if (!String.IsNullOrWhiteSpace(b.Message) && b.Message.Equals("success"))
                {
                    var c = billtran.GetBill(0);
                    if (c != null)
                    {
                        b.lstBill = c.lstBill;

                    }
                    b.buttonText = "Add";
                    if (b.Message.ToLower().Equals("success"))
                    {
                        b.Message = "Invoice Save successfully";
                        ModelState.Clear();

                    }
                    b.flag = "Insert";
                }

                else
                {
                    b.DocNo = bil.DocNo;
                    b.Date = bil.Date;
                    b.JobNo = bil.JobNo;
                    b.Customer = bil.Customer;
                    b.QuotNo = bil.QuotNo;
                    b.EstNo = bil.EstNo;
                    b.EnqNo = bil.EnqNo;
                    b.QuotationAmt = bil.QuotationAmt;
                    b.InvoiceAmt = bil.InvoiceAmt;
                    b.MainJob = bil.MainJob;
                    b.PaymentTerm = bil.PaymentTerm;
                    b.Remarks = bil.Remarks;
                    b.Id = bil.Id;
                    b.flag = bil.flag;
                    b.Message = bil.Message;
                    b.buttonText = "Update";
                }
                return View(b);
            }

            else
            {
                var c = billtran.GetBill(0);
                if (c != null)
                {
                    bil.lstBill = c.lstBill;

                }
                bil.buttonText = "Add";
                bil.flag = "Insert";
                return View(bil);
            }

        }

       



    }
}
