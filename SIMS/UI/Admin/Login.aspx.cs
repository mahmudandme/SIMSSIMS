using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMS.BLL.Admin;
using SIMS.Models;

namespace SIMS.UI.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        private AdminBLL adminBll = new AdminBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            LoginModel loginModel = new LoginModel();
            loginModel.ID = idTextBox.Text;
            loginModel.Email = emailTextBox.Text;
            loginModel.Password = passwordTextBox.Text;
            if (idTextBox.Text.Length <20 && emailTextBox.Text.Length <30 && passwordTextBox.Text.Length <20)
            {
                LoginModel loginModelFromDB = adminBll.GetLoginInformation(loginModel.ID, loginModel.Email);                
                SHA256 sha256 = SHA256.Create();
                string passwordToCompare = Convert.ToBase64String(sha256.ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(loginModel.Password + loginModelFromDB.Salt)));
                if (passwordToCompare == loginModelFromDB.Hash)
                {
                    Session["loginInformation"] = loginModelFromDB;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    failStatusLabel.InnerText = "Login information is incorrect.";
                }
            }
            else
            {
                failStatusLabel.InnerText = "Please enter the information in correct format";
                successStatusLabel.InnerText = "";
            }

        }
    }
}