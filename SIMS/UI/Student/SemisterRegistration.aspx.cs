using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMS.BLL.Admin;
using SIMS.BLL.Student;
using SIMS.Models;
using Login = SIMS.UI.Admin.Login;

namespace SIMS.UI.Student
{
    public partial class SemisterRegistration : System.Web.UI.Page
    {
        StudentBLL studentBll = new StudentBLL();
        AdminBLL adminBll = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetDeptIdAndSessionId();
        }

       

        public void GetDeptIdAndSessionId()
        {
            LoginModel loginModel = new LoginModel();
            if (Session["loginInformation"] != null)
            {
                loginModel = (LoginModel)Session["loginInformation"];
                string email = loginModel.Email;
                string studentId = loginModel.ID;
                StudentModel studentModel = new StudentModel();
                studentModel = studentBll.GetStudentInfirmation(studentId);
                AddStudentModel addStudentModel = new AddStudentModel();
                addStudentModel = studentBll.GetDeptIdAndSessionIdByStudentIdAndEmail(studentId, email);
                int maxValueOfYearTerm = adminBll.GetMaxValueOfYearTermIdFromRegPermission(addStudentModel.DeptId,
                    addStudentModel.SessionId);
                 
                if (maxValueOfYearTerm == 0)
                {
                    registerButton.Enabled = false;
                    headerTextLabel.Text = "Registration not available now.";
                    headerTextLabel.CssClass = "text-danger";
                    headerTextLabel.CssClass = "glyphicon glyphicon-hand-right";
                    regStatusLabel.Text = "Not registered for first semister";
                    studentIdLabel.Text = studentId;                    
                    departmentNameLabel.Text = studentModel.DepartmentName;
                    sessionLabel.Text = studentModel.Session;
                    //yearTermLabel.Text = studentBll.GetYearTermByYearTermId(maxValueOfYearTerm);
                    yearTermLabel.Text = "1st year;1st term";
                }
                else
                {
                    RegistrationPermissionModel registrationPermissionModel = new RegistrationPermissionModel();
                    registrationPermissionModel.studentId = studentId;
                    registrationPermissionModel.DeptId = addStudentModel.DeptId;
                    registrationPermissionModel.SessionId = addStudentModel.SessionId;
                    registrationPermissionModel.YearTermId = maxValueOfYearTerm;
                    if (studentBll.IsSemisterRegisteredForStudentId(registrationPermissionModel))
                    {
                        registerButton.Enabled = false;
                        regStatusLabel.Text = "You are registered for the current semister";
                        studentIdLabel.Text = studentId;
                        departmentNameLabel.Text = studentModel.DepartmentName;
                        sessionLabel.Text = studentModel.Session;
                        yearTermLabel.Text = studentBll.GetYearTermByYearTermId(maxValueOfYearTerm);
                    }
                    else
                    {
                        registerButton.Enabled = true;
                        studentIdLabel.Text = studentId;
                        departmentNameLabel.Text = studentModel.DepartmentName;
                        sessionLabel.Text = studentModel.Session;
                        yearTermLabel.Text = studentBll.GetYearTermByYearTermId(maxValueOfYearTerm);
                        regStatusLabel.Text = "Not registered yet";
                        List<CourseModel> courseModels = new List<CourseModel>();
                        courseModels = studentBll.GetAllCoursesByDeptIdAndYearTermId(addStudentModel.DeptId,
                            maxValueOfYearTerm);
                        decimal totalCredit = 0;
                        int totalSubject = 0;
                        foreach (CourseModel courseModel in courseModels)
                        {
                            totalCredit = courseModel.Credit + totalCredit;
                            totalSubject++;
                        }
                        courseGridView.DataSource = courseModels;
                        courseGridView.DataBind();
                        totalCreditTextBox.Text = Convert.ToString(totalCredit);
                        courseNumberTextBox.Text = Convert.ToString(totalSubject);
                    }

                }
            }
        }

        
        protected void registerButton_Click(object sender, EventArgs e)
        {
            if (Session["loginInformation"] != null)
            {
                LoginModel loginModel = new LoginModel();
                loginModel = (LoginModel)Session["loginInformation"];
                string studentId = loginModel.ID;
                string email = loginModel.Email;
                AddStudentModel addStudentModel = new AddStudentModel();
                addStudentModel = studentBll.GetDeptIdAndSessionIdByStudentIdAndEmail(studentId, email);
                RegistrationPermissionModel registrationPermissionModel = new RegistrationPermissionModel();
                registrationPermissionModel.studentId = studentId;
                registrationPermissionModel.DeptId = addStudentModel.DeptId;
                registrationPermissionModel.SessionId = addStudentModel.SessionId;

                int maxValueOfYearTerm = adminBll.GetMaxValueOfYearTermIdFromRegPermission(addStudentModel.DeptId,
                    addStudentModel.SessionId);
                registrationPermissionModel.YearTermId = maxValueOfYearTerm;

                if (studentBll.IsSemisterRegisteredForStudentId(registrationPermissionModel))
                {
                    failStatusLabel.InnerText = "You are already registered";
                    successStatusLabel.InnerText = "";
                }
                else
                {
                    if (studentBll.SaveSemisterRegistrationForStudent(registrationPermissionModel) >0)
                    {
                        failStatusLabel.InnerText = "";
                        successStatusLabel.InnerText = "Your registration completed";
                        regStatusLabel.Text = "You are registered for current semister";
                        registerButton.Enabled = false;
                    }
                }
            }
        }
    }
}