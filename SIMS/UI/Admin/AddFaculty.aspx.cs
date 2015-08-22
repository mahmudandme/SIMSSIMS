using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMS.BLL.Admin;
using SIMS.Models;

namespace SIMS.UI.Admin
{
    public partial class AddFaculty : System.Web.UI.Page
    {
        AddFacultyBLL addFacultyBll = new AddFacultyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllFaculty();
        }

        protected void saveFacultyButton_Click(object sender, EventArgs e)
        {
            AddFacultyModel addFacultyModel = new AddFacultyModel();
            addFacultyModel.Name = facultyNameTextBox.Text;
            if (addFacultyBll.IsDepartNameExist(addFacultyModel))
            {
                failStatusLabel.InnerText = "Faculty name already exist";
                successStatusLabel.InnerText = "";
            }
            else
            {
                if (addFacultyBll.SaveDepartmentName(addFacultyModel)>0)
                {
                    successStatusLabel.InnerText = "Faculty name saved";
                    GetAllFaculty();
                    failStatusLabel.InnerText = "";

                }
                else
                {
                    successStatusLabel.InnerText = "";
                    failStatusLabel.InnerText = "Faculty name not saved.Try again";
                }
            }
        }

        public void GetAllFaculty()
        {
            facultyGridview.DataSource = addFacultyBll.GetAllFaculty();
            facultyGridview.DataBind();
        }

        protected void facultyGridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //DataTable sourceData = (DataTable)facultyGridview.DataSource;

            //sourceData.Rows[e.RowIndex].Delete();

            //facultyGridview.DataSource = sourceData;
            //facultyGridview.DataBind();

          //  string deptName = facultyGridview.SelectedRow.Cells[1].Text;

            //int categoryID = (int)GridView1.DataKeys[e.RowIndex].Value;
            //DeleteRecordByID(categoryID);

           
            AddFacultyModel addFacultyModel = new AddFacultyModel();
            addFacultyModel.Name = facultyGridview.DataKeys[e.RowIndex].Value.ToString();
            if (addFacultyBll.DeleteFaculty(addFacultyModel)>0)
            {
                successStatusLabel.InnerText = "Row deleted";
                failStatusLabel.InnerText = "";
                GetAllFaculty();
            }
            else
            {
                successStatusLabel.InnerText = "";
                failStatusLabel.InnerText = "Row not deleted";
            }



            //string username = GrdView1.DataKeys[e.RowIndex].Value.ToString();
            //MAconn.Open();
            //SqlCommand cmd = new SqlCommand("Delete From ROLES (UserId,GroupId) SELECT UserId FROM Users WHERE username= @username", MAconn);
            //cmd.Parameters.AddWithValue("@username", username);
            //cmd.ExecuteNonQuery();
            //MAconn.Close();
            //bind();



        }

        protected void facultyGridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}