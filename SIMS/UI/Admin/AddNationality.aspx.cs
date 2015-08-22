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
    public partial class AddNationality : System.Web.UI.Page
    {
        AddNationalityBLL addNationalityBll = new AddNationalityBLL();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllNationality();
        }

        protected void saveNationalityButton_Click(object sender, EventArgs e)
        {
            NationalityModel nationalityModel = new NationalityModel();
            nationalityModel.Name = nationalityNameTextBox.Text;
            if (nationalityNameTextBox.Text=="")
            {
                failStatusLabel.InnerText = "Please enter the nationality";
            }
            else
            {
                if (addNationalityBll.IsNationalityExist(nationalityModel))
                {
                    successStatusLabel.InnerText = "";
                    failStatusLabel.InnerText = "Nationality already exist";

                }
                else
                {
                    if (addNationalityBll.SaveNationality(nationalityModel) > 0)
                    {
                        failStatusLabel.InnerText = "";
                        successStatusLabel.InnerText = "Nationality saved";
                        GetAllNationality();

                    }
                    else
                    {
                        successStatusLabel.InnerText = "";
                        failStatusLabel.InnerText = "Nationality not saved";
                    }
                }
            }
            

        }

        public void GetAllNationality()
        {
            nationalityGridView.DataSource = addNationalityBll.GetAllNationality();
            nationalityGridView.DataBind();
        }

    }
}