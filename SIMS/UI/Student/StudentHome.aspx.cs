using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMS.BLL.Student;
using SIMS.Models;

namespace SIMS.UI.Student
{
    public partial class StudentHome : System.Web.UI.Page
    {
        //private bool isUpdateModePhone = false;
        
       // private bool isUpdateModePresentAddress = false;
        StudentBLL studentBll = new StudentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetTheStudentInformation();
        }

        public void GetTheStudentInformation()
        {
            
            LoginModel loginModel = (LoginModel)Session["loginInformation"];
            string studentID = loginModel.ID;
            StudentModel studentModel = studentBll.GetStudentInfirmation(studentID);
            idTextBox.Text = studentModel.ID;
            nameTextBox.Text = studentModel.Name;
            genderTextBox.Text = studentModel.Gender;
            nationalityTextBox.Text = studentModel.Nationality;
            departmentNameTextBox.Text = studentModel.DepartmentName;
            sessionTextBox.Text = studentModel.Session;
            emailTextBox.Text = studentModel.Email;
            phoneTextBox.Text = studentModel.Phone;
            presentAddressTextBox.Text = studentModel.PresentAddress;
            permanentAddressTextBox.Text = studentModel.PermanentAddress;
        }

        
        }

        
    }
