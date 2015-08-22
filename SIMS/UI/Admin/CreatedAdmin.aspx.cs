using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using SIMS.BLL.Admin;
using SIMS.Models;

namespace SIMS.UI.Admin
{
    public partial class CreatedAdmin : System.Web.UI.Page
    {
        AdminBLL adminBll = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAddedStudentInformationInGridView();
        }

        public void GetAddedStudentInformationInGridView()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Phone", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("AdminId", typeof(string));
            dataTable.Columns.Add("Password", typeof(string));

            List<AdminModel> adminModels = adminBll.GetAdminInformationByLastIdentity();
            foreach (AdminModel adminModel in adminModels)
            {
                dataTable.Rows.Add(adminModel.Name, adminModel.Phone, adminModel.Email,adminModel.AdminId, adminModel.OnlyPassword);
            }
            
            createdAdminGridView.DataSource = dataTable;
            createdAdminGridView.DataBind();
            Session["adminPassword"] = null;
        }
        protected void generatePDFButton_Click(object sender, EventArgs e)
        {
            if (createdAdminGridView.Rows.Count == 0)
            {
               //suyduy
            }
            else
            {
                PdfPTable pdfPTable = new PdfPTable(createdAdminGridView.HeaderRow.Cells.Count);

                foreach (TableCell headerCell in createdAdminGridView.HeaderRow.Cells)
                {
                    PdfPCell pfdPCell = new PdfPCell(new Phrase(headerCell.Text));
                    //pfdPCell.BackgroundColor = new BaseColor(newCenterGridView.HeaderStyle.ForeColor);
                    pdfPTable.AddCell(pfdPCell);
                }


                foreach (GridViewRow gridViewRow in createdAdminGridView.Rows)
                {
                    foreach (TableCell tableCell in gridViewRow.Cells)
                    {


                        PdfPCell pfdPCell = new PdfPCell(new Phrase(tableCell.Text));
                        //pfdPCell.BackgroundColor = new BaseColor(newCenterGridView.HeaderStyle.ForeColor);
                        pdfPTable.AddCell(pfdPCell);
                    }
                }
                Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

                pdfDocument.Open();
                pdfDocument.Add(pdfPTable);
                pdfDocument.Close();

                Response.ContentType = "application/pdf";
                Response.AppendHeader("content-disposition", "attachment;filename=NewCenter.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
            
        }
    }
}