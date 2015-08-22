using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using SIMS.BLL.Admin;

namespace SIMS.UI.Admin
{
    public partial class AddedStudentInformation : System.Web.UI.Page
    {
        AddStudentBLL addStudentBll = new AddStudentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAddedStudentInformationInGridView();
        }

        public void GetAddedStudentInformationInGridView()
        {
            CreatedStudentInformationGridView.DataSource = addStudentBll.GetGeneratedStudentInformation();
            CreatedStudentInformationGridView.DataBind();
            Session["studentPassword"] = null;
        }

        protected void generatePDFButton_Click(object sender, EventArgs e)
        {

            PdfPTable pdfPTable = new PdfPTable(CreatedStudentInformationGridView.HeaderRow.Cells.Count);
           
            foreach (TableCell headerCell in CreatedStudentInformationGridView.HeaderRow.Cells)
            {                
                PdfPCell pfdPCell = new PdfPCell(new Phrase(headerCell.Text));
                //pfdPCell.BackgroundColor = new BaseColor(newCenterGridView.HeaderStyle.ForeColor);
                pdfPTable.AddCell(pfdPCell);
            }


            foreach (GridViewRow gridViewRow in CreatedStudentInformationGridView.Rows)
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