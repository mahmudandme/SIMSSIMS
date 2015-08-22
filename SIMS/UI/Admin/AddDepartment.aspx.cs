using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMS.BLL.Admin;
using SIMS.Models;

namespace SIMS.UI.Admin
{
    public partial class AddDepartment : System.Web.UI.Page
    {
        AddDepartmentBLL addDepartmentBll = new AddDepartmentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllFacultyInDropDownList();
                ShowDepartmentInformationInGridView();
                ListItem listItem = new ListItem("Select faculty", "-1");
                facultyDropDownList.Items.Insert(0,listItem);
            }
            
        }

        public void GetAllFacultyInDropDownList()
        {
            facultyDropDownList.DataSource = addDepartmentBll.GetAllFacultyName();
            facultyDropDownList.DataTextField = "Name";
            facultyDropDownList.DataValueField = "ID";
            facultyDropDownList.DataBind();

        }



        public void saveDepartmentButton_Click(object sender, EventArgs e)
        {
            DepartmentModel departmentModel = new DepartmentModel();
            departmentModel.DepartmentName = departmentNameTextBox.Text;
            departmentModel.FacultyID = Convert.ToInt32(facultyDropDownList.SelectedItem.Value);
            if (departmentNameTextBox.Text=="")
            {
                successStatusLabel.InnerText = "Please enter the department name";
            }
            else
            {
                if (facultyDropDownList.SelectedValue=="-1")
                {
                    successStatusLabel.InnerText = "Please select the faculty.";
                }
                else
                {
                    if (addDepartmentBll.IsDepartNameExist(departmentModel))
                    {
                        failStatusLabel.InnerText = "Department name already exist";
                        successStatusLabel.InnerText = "";
                    }
                    else
                    {
                        if (addDepartmentBll.SaveDepartmentName(departmentModel) > 0)
                        {
                            failStatusLabel.InnerText = "";
                            successStatusLabel.InnerText = "Department name saved";
                            ShowDepartmentInformationInGridView();
                            GetAllFacultyInDropDownList();
                            ListItem listItem = new ListItem("Select faculty", "-1");
                            facultyDropDownList.Items.Insert(0, listItem);


                        }
                        else
                        {
                            failStatusLabel.InnerText = "";
                            failStatusLabel.InnerText = "Department name not saved";
                        }
                    } 
                }
            }
            
        }

        public void ShowDepartmentInformationInGridView()
        {
            departmentGridView.DataSource = addDepartmentBll.ShowAllDepartment();
            departmentGridView.DataBind();
        }
    }
}