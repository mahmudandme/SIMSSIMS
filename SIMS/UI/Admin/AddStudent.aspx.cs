using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.Security.Cryptography;
using System.Web.UI.WebControls;
using SIMS.BLL.Admin;
using SIMS.Models;

namespace SIMS.UI.Admin
{
    public partial class AddStudent : System.Web.UI.Page
    {
        AddNationalityBLL addNationalityBll = new AddNationalityBLL();
        AddStudentBLL addStudentBll = new AddStudentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllNationalityInDropDownList();
                ListItem listItemNationality = new ListItem("Select nationality","-1");
                nationalityDropDownList.Items.Insert(0, listItemNationality);

                GetAllDepartmentInDropDownList();
                ListItem listItemDepartment = new ListItem("Select Department", "-1");
                departmentDropDownList.Items.Insert(0, listItemDepartment);

                GetAllGenderInDropDownList();
                ListItem listItemGender = new ListItem("Select gender", "-1");
                genderDropDownList.Items.Insert(0, listItemGender);

                GetAllYearTermInDropDownList();
                ListItem listItemYearTerm = new ListItem("Select year-term", "-1");
                yearTermDropDownList.Items.Insert(0, listItemYearTerm);

                GetAllSessionInDropDownList();
                ListItem listItemSession = new ListItem("Select session", "-1");
                sessionDropDownList.Items.Insert(0, listItemSession);
               

            }
        }

        private void GetAllNationalityInDropDownList()
        {
            nationalityDropDownList.DataSource = addNationalityBll.GetAllNationality();
            nationalityDropDownList.DataTextField = "Name";
            nationalityDropDownList.DataValueField = "ID";
            nationalityDropDownList.DataBind();
        }

        private void GetAllGenderInDropDownList()
        {
            genderDropDownList.DataSource = addStudentBll.GetAllGender();
            genderDropDownList.DataTextField = "Gender";
            genderDropDownList.DataValueField = "ID";
            genderDropDownList.DataBind();
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

        protected void saveButton_Click(object sender, EventArgs e)
        {
            AddStudentModel addStudentModel = new AddStudentModel();
            addStudentModel.StudentId = studentIdTextBox.Text;
            addStudentModel.Name = studentNameTextBox.Text;
            addStudentModel.Phone = phoneNumberTextBox.Text;
            addStudentModel.Email = emailTextBox.Text;
            addStudentModel.PresentAddress = presentAddressTextBox.Text;
            addStudentModel.PermanentAddress = permanentAddressTextBox.Text;
            addStudentModel.GenderId = Convert.ToInt32(genderDropDownList.SelectedValue);
            addStudentModel.NationalityId = Convert.ToInt32(nationalityDropDownList.SelectedValue);
            addStudentModel.DeptId = Convert.ToInt32(departmentDropDownList.SelectedValue);
            addStudentModel.YearTermId = Convert.ToInt32(yearTermDropDownList.SelectedValue);
            addStudentModel.SessionId = Convert.ToInt32(sessionDropDownList.SelectedValue);
            addStudentModel.Salt = GenerateSalt();
            string passwordStd = GeneratePassword();
            Session["studentPassword"] = passwordStd;
            addStudentModel.Password = GenerateHashValue(passwordStd, addStudentModel.Salt);
            addStudentModel.Type = 2;

            if (IsTextBoxEmpty())
            {
                failStatusLabel.InnerText = "Please enter the value";
                successStatusLabel.InnerText = "";
            }
            else
            {
                if (CheckSelectedValue())
                {
                    failStatusLabel.InnerText = "Please select a value";
                    successStatusLabel.InnerText = "";
                }
                else
                {
                    if (addStudentBll.IsStudenrExist(addStudentModel))
                    {
                        failStatusLabel.InnerText = "This student already exist";
                        successStatusLabel.InnerText = "";
                    }
                    else
                    {
                        if (addStudentBll.SaveNewStudentInformation(addStudentModel)>0)
                        {
                            //successStatusLabel.InnerText = "Student information saved";
                            //failStatusLabel.InnerText = "";
                            Response.Redirect("AddedStudentInformation.aspx");
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

        private string GenerateHashValue(string password,string salt)
        {
           // string hashValue = Convert.ToString(SHA256CryptoServiceProvider.Create(password));
            SHA256 sha256 = SHA256.Create();
           string hashValue = Convert.ToBase64String(sha256.ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(password+salt)));
           return hashValue;
        }

        private string GenerateSalt()
        {
            Random random = new Random();
            string salt = studentIdTextBox.Text;
            salt = salt + Convert.ToString(random.Next(11,99));
            return salt;
        }

        private string GeneratePassword()
        {
            Random random = new Random();
            int[] symbol = new[] { 33, 35, 36, 37, 38, 42, 95};
            StringWriter stringWriter = new StringWriter();
            int length = 5;
            for (int i = length; i > 0; i--)
            {
                if (random.Next(i, length) == 2)
                {
                    stringWriter.Write((char)random.Next(65, 91));
                }
                else if (random.Next(i, length) == 3)
                {
                    stringWriter.Write((char)random.Next(97, 123));
                }
                else if (random.Next(i, length) == 4)
                {
                    stringWriter.Write((char)random.Next(48, 58));
                }
                else if (random.Next(i, length) == 5)
                {
                    stringWriter.Write((char)random.Next(65, 97));
                }
                else
                {
                    stringWriter.Write((char)symbol[random.Next(0, 7)]);
                }                
            }
            stringWriter.Write(random.Next(0,9));
            stringWriter.Write((char)random.Next(65,97));
            Session["studentPassword"] = stringWriter.ToString();
            return stringWriter.ToString();
         }


        private bool IsTextBoxEmpty()
        {
            if (studentIdTextBox.Text == String.Empty || studentNameTextBox.Text == String.Empty || emailTextBox.Text == String.Empty || phoneNumberTextBox.Text == String.Empty || presentAddressTextBox.Text == String.Empty || permanentAddressTextBox.Text == String.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckSelectedValue()
        {
            if (genderDropDownList.SelectedValue == "-1" || nationalityDropDownList.SelectedValue == "-1" || departmentDropDownList.SelectedValue == "-1" || yearTermDropDownList.SelectedValue == "-1" || sessionDropDownList.SelectedValue == "-1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       }
    }
