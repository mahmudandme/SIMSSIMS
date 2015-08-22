using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMS.BLL.Admin;

namespace SIMS.UI.Admin
{
    public partial class ShowStudent : System.Web.UI.Page
    {
       AddStudentBLL addStudentBll = new AddStudentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllDepartmentNameInDropDownList();
                ListItem listItemDepartment = new ListItem("Select Department", "-1");
                departmentDropDownlist.Items.Insert(0, listItemDepartment);
            }
            
        }

        private void GetAllDepartmentNameInDropDownList()
        {
            departmentDropDownlist.DataSource = addStudentBll.GetAllDepartment();
            departmentDropDownlist.DataTextField = "DepartmentName";
            departmentDropDownlist.DataValueField = "DeptID";
            departmentDropDownlist.DataBind();
        }

        protected void departmentDropDownlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            studentInformationGridView.DataSource =
                addStudentBll.GetStudentInformationByAndDepartmentId(studentIdTextBox.Text,
                    Convert.ToInt32(departmentDropDownlist.SelectedValue));
            studentInformationGridView.DataBind();
        }
    }
}