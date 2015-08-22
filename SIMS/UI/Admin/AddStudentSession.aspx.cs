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
    public partial class AddStudentSession : System.Web.UI.Page
    {
        AddSessionBLL addSessionBll = new AddSessionBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllSessionInGridView();
            }
                
            
        }

        protected void saveSessionButton_Click(object sender, EventArgs e)
        {
            SessionMedel sessionMedel = new SessionMedel();
            sessionMedel.SessionValue = sessionValueTextBox.Text;
            if (sessionValueTextBox.Text=="")
            {
                successStatusLabel.InnerText = "Please enter the session name.";
            }
            else
            {
              if (addSessionBll.IsSessionExist(sessionMedel))
            {
                successStatusLabel.InnerText = "";
                failStatusLabel.InnerText = "This session already exist";

            }
            else
            {
                if (addSessionBll.SaveSession(sessionMedel) > 0)
                {
                    failStatusLabel.InnerText = "";
                    successStatusLabel.InnerText = "Session saved";
                    GetAllSessionInGridView();
                    ClearTextBox();
                }
                else
                {
                    successStatusLabel.InnerText = "";
                    failStatusLabel.InnerText = "Session not saved";
                }
            }
  
            }
            
        }

        private void GetAllSessionInGridView()
        {
            sessionGridView.DataSource = addSessionBll.GetAllSession();
            sessionGridView.DataBind();
        }

        public void ClearTextBox()
        {
            sessionValueTextBox.Text = "";
        }
    }
}