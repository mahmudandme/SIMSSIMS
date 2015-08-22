using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMS.BLL.Admin;
using SIMS.Models;

namespace SIMS.UI.Admin
{
    public partial class ShowAdmins : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllAdmin();
        }
        AdminBLL adminBll = new AdminBLL();
        protected void saveAdminButton_Click(object sender, EventArgs e)
        {
            AdminModel adminModel = new AdminModel();
            adminModel.Name = adminNameTextBox.Text;
            adminModel.Phone = phoneTextBox.Text;
            adminModel.Email = emailTextBox.Text;
            adminModel.AdminId = GetAdminId(adminModel.Email);
            adminModel.Salt = GenerateSalt(adminModel.AdminId);
            string passwordAdmin = GeneratePassword();
            Session["adminPassword"] = passwordAdmin;
            adminModel.Password = GenerateHashValue(passwordAdmin, adminModel.Salt);
            adminModel.Type = 1;

            if (adminNameTextBox.Text.Length > 3 && adminNameTextBox.Text.Length < 40 && phoneTextBox.Text.Length < 20 &&
                emailTextBox.Text.Length < 50)
            {

                if (adminBll.IsAdminExist(adminModel))
                {
                    failStatusLabel.InnerText = "Admin already exist";
                    successStatusLabel.InnerText = "";
                }
                else
                {
                    if (adminBll.SaveAdminInformation(adminModel) > 0)
                    {
                        Response.Redirect("CreatedAdmin.aspx");
                        //successStatusLabel.InnerText = "Admin information saved";
                        //failStatusLabel.InnerText = "";
                    }
                    else
                    {
                        failStatusLabel.InnerText = "Not saved";
                        successStatusLabel.InnerText = "";
                    }
                }                        
            }
            else
            {
                failStatusLabel.InnerText = "Please enter the correct value";
            }
        }
        private string GenerateHashValue(string password, string salt)
        {
            // string hashValue = Convert.ToString(SHA256CryptoServiceProvider.Create(password));
            SHA256 sha256 = SHA256.Create();
            string hashValue = Convert.ToBase64String(sha256.ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(password + salt)));
            return hashValue;
        }

        private string GeneratePassword()
        {
            Random random = new Random();
            int[] symbol = new[] { 33, 35, 36, 37, 38, 42, 95 };
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
            stringWriter.Write(random.Next(0, 9));
            stringWriter.Write((char)random.Next(65, 97));
         //   Session["adminPassword"] = stringWriter.ToString();
            return stringWriter.ToString();
        }
        private string GenerateSalt(string adminId)
        {
            StringWriter stringWriter = new StringWriter();
            Random random = new Random();
            string salt = adminId;
            stringWriter.Write((char) random.Next(65, 91));
            stringWriter.Write((char) random.Next(97, 123));
            salt = salt + stringWriter.ToString();
            return salt;
        }

        private string GetAdminId(string email)
        {
            string emailPart = email.Substring(0,email.IndexOf("@"));
            return emailPart + Convert.ToString(new Random().Next(3377,9988));
        }

        private void GetAllAdmin()
        {                                   
            adminGridView.DataSource = adminBll.GetAllAdmin();
            adminGridView.DataBind();
        }


    }
}