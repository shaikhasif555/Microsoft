using MicroSoft.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MicroSoft.Classes
{
    public class BillTrans
    {
        SqlDataAdapter adapter;
        DataTable dt;
        SqlCommand cmd;


        public SqlConnection sqlConnection()
        {
            return (new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString));
        }

        public Bill BillInsert(Bill bill)
        {
            Bill result = new Bill();

            try
            {
                var connection = sqlConnection();
                connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Invoice";
                cmd.Parameters.AddWithValue("@Id",bill.Id);

                cmd.Parameters.AddWithValue("@DocNo", bill.DocNo);
                cmd.Parameters.AddWithValue("@Date", bill.Date);
                cmd.Parameters.AddWithValue("@JobNo", bill.JobNo);
                cmd.Parameters.AddWithValue("@Customer", bill.Customer);
                cmd.Parameters.AddWithValue("@QuotNo", bill.QuotNo);
                cmd.Parameters.AddWithValue("@EstNo", bill.EstNo);
                cmd.Parameters.AddWithValue("@EnqNo", bill.EnqNo);
                cmd.Parameters.AddWithValue("@QuotationAmt", bill.QuotationAmt);
                cmd.Parameters.AddWithValue("@InvoiceAmt", bill.InvoiceAmt);
                cmd.Parameters.AddWithValue("@MainJob", bill.MainJob);
                cmd.Parameters.AddWithValue("@PaymentTerm", bill.PaymentTerm);
                cmd.Parameters.AddWithValue("@Remarks", bill.Remarks);
                cmd.Parameters.AddWithValue("@flag", bill.flag);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.Message = "success";
                    result.Id = Convert.ToInt32(reader[0].ToString());

                }
                reader.Close();
                cmd.Dispose();
                connection.Close();

            }
            catch (Exception ex)
            {
                result.Message = "Error:" + ex.Message.ToString();
               
            }
            return result;

        }



        public Bill GetBill(int id)
        {
            try
            {
                var connection =  sqlConnection();

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "get_Invoice";
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Id",id);
                connection.Open();
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);

                Bill bil = new Bill();
                bil.lstBill = new List<BillProp>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        if (id == 0)
                        {

                            BillProp billp = new BillProp();
                            billp.Id = Convert.ToInt32(row["Id"].ToString());
                            billp.DocNo = Convert.ToInt32(row["DocNo"].ToString());
                            billp.Date = Convert.ToDateTime(row["Date"].ToString());
                            billp.JobNo = Convert.ToInt32(row["JobNo"].ToString());
                            billp.Customer = row["Customer"].ToString();
                            billp.QuotNo = Convert.ToInt32(row["QuotNo"].ToString());
                            billp.EstNo = Convert.ToInt32(row["EstNo"].ToString());
                            billp.EnqNo = Convert.ToInt32(row["EnqNo"].ToString());
                            billp.QuotationAmt = Convert.ToDecimal(row["QuotationAmt"].ToString());
                            billp.InvoiceAmt = Convert.ToDecimal(row["InvoiceAmt"].ToString());
                            billp.MainJob = row["MainJob"].ToString();
                            billp.PaymentTerm = row["PaymentTerm"].ToString();
                            billp.Remarks = row["Remarks"].ToString();

                            bil.lstBill.Add(billp);

                        }
                        else
                        {
                            bil.Id = Convert.ToInt32(row["Id"].ToString());
                            bil.DocNo = Convert.ToInt32(row["DocNo"].ToString());
                            bil.Date = Convert.ToDateTime(row["Date"].ToString());
                            bil.JobNo = Convert.ToInt32(row["JobNo"].ToString());
                            bil.Customer = row["Customer"].ToString();
                            bil.QuotNo = Convert.ToInt32(row["QuotNo"].ToString());
                            bil.EstNo = Convert.ToInt32(row["EstNo"].ToString());
                            bil.EnqNo = Convert.ToInt32(row["EnqNo"].ToString());
                            bil.QuotationAmt = Convert.ToDecimal(row["QuotationAmt"].ToString());
                            bil.InvoiceAmt = Convert.ToDecimal(row["InvoiceAmt"].ToString());
                            bil.MainJob = row["MainJob"].ToString();
                            bil.PaymentTerm = row["PaymentTerm"].ToString();
                            bil.Remarks = row["Remarks"].ToString();
                        }

                    }
                }

                return bil;

            }
            catch (Exception ex)
            {

                return null;
            }

        }
    }
}