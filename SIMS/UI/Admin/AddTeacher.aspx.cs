using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMS.BLL.Admin;

namespace SIMS.UI.Admin
{
    public partial class AddTeacher : System.Web.UI.Page
    {
        AddStudentBLL addStudentBll = new AddStudentBLL();
        AddNationalityBLL addNationalityBll = new AddNationalityBLL();
        AddDepartmentBLL addDepartmentBll = new AddDepartmentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                GetAllGenderInDropdownlist();
                ListItem listItemGender = new ListItem("Select gender","-1");
                genderDropDownList.Items.Insert(0,listItemGender);

                GetAllNationalityInDropdownlist();
                ListItem listItemNationality = new ListItem("Select nationality", "-1");
                nationalityDropDownList.Items.Insert(0, listItemNationality);

                GetAllDepartmentInDropdownlist();
                ListItem listItemDepartment = new ListItem("Select department", "-1");
                departmentDropDownList.Items.Insert(0, listItemDepartment);
            }
        }

        

        public void GetAllGenderInDropdownlist()
        {
            genderDropDownList.DataSource = addStudentBll.GetAllGender();
            genderDropDownList.DataTextField = "Gender";
            genderDropDownList.DataValueField = "ID";
            genderDropDownList.DataBind();
        }
        public void GetAllNationalityInDropdownlist()
        {
            nationalityDropDownList.DataSource = addNationalityBll.GetAllNationality();
            nationalityDropDownList.DataTextField = "Name";
            nationalityDropDownList.DataValueField = "ID";
            nationalityDropDownList.DataBind();
        }
        public void GetAllDepartmentInDropdownlist()
        {
            departmentDropDownList.DataSource = addStudentBll.GetAllDepartment();
            departmentDropDownList.DataTextField = "DepartmentName";
            departmentDropDownList.DataValueField = "DeptID";
            departmentDropDownList.DataBind();
        }


        protected void saveButton_Click(object sender, EventArgs e)
        {

        }

        protected void joiningDateCalendar_SelectionChanged(object sender, EventArgs e)
        {
            dateTextBox.Text = joiningDateCalendar.SelectedDate.ToShortDateString();
        }
        
              
    }
}