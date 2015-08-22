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
    public partial class GiveRegistrationPermission : System.Web.UI.Page
    {
        AddStudentBLL addStudentBll = new AddStudentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (! IsPostBack)
            {
                GetAllDepartmentInDropDownList();
                ListItem listItemDepartment = new ListItem("Select Department", "-1");
                departmentDropDownList.Items.Insert(0, listItemDepartment);

                GetAllYearTermInDropDownList();
                ListItem listItemYearTerm = new ListItem("Select year-term", "-1");
                yearTermDropDownList.Items.Insert(0, listItemYearTerm);

                GetAllSessionInDropDownList();
                ListItem listItemSession = new ListItem("Select session", "-1");
                sessionDropDownList.Items.Insert(0, listItemSession); 
            }            
        }
        private void GetAllDepartmentInDropDownList()
        {
            departmentDropDownList.DataSource = addStudentBll.GetAllDepartment();
            departmentDropDownList.DataTextField = "DepartmentName";
            departmentDropDownList.DataValueField = "DeptID";
            departmentDropDownList.DataBind();
        }
        private void GetAllYearTermInDropDownList()
        {
            yearTermDropDownList.DataSource = addStudentBll.GetAllYearTerm();
            yearTermDropDownList.DataTextField = "YearTerm";
            yearTermDropDownList.DataValueField = "ID";
            yearTermDropDownList.DataBind();
        }
        private void GetAllSessionInDropDownList()
        {
            sessionDropDownList.DataSource = addStudentBll.GetAllSession();
            sessionDropDownList.DataTextField = "SessionValue";
            sessionDropDownList.DataValueField = "ID";
            sessionDropDownList.DataBind();
        }

        protected void saveRegistrationPermissionButton_Click(object sender, EventArgs e)
        {
            RegistrationPermissionModel registrationPermissionModel = new RegistrationPermissionModel();
            registrationPermissionModel.DeptId = Convert.ToInt32(departmentDropDownList.SelectedValue);
            registrationPermissionModel.SessionId = Convert.ToInt32(sessionDropDownList.SelectedValue);
            registrationPermissionModel.YearTermId = Convert.ToInt32(yearTermDropDownList.SelectedValue);

            
                if (addStudentBll.IsRegistrationPermissionExist(registrationPermissionModel))
                {
                    failStatusLabel.InnerText = "This registration permission already given";
                    successStatusLabel.InnerText = "";
                }
                else
                {
                    if (addStudentBll.SaveRegistrationPermission(registrationPermissionModel) > 0)
                    {
                        successStatusLabel.InnerText = "Permission is given to the " + " " + departmentDropDownList.SelectedItem.Text + "," + " " + sessionDropDownList.SelectedItem.Text + "," + " " + yearTermDropDownList.SelectedItem.Text;
                        failStatusLabel.InnerText = "";
                    }
                    else
                    {
                        failStatusLabel.InnerText = "Not saved";
                        successStatusLabel.InnerText = "";
                    }
                }
                       
        }

        
    }
}