using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SIMS.BLL;
using SIMS.BLL.Admin;
using SIMS.Models;

namespace SIMS.UI.Admin
{
    public partial class AddStudentResult : System.Web.UI.Page
    {
        ResultBLL resultBll = new ResultBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllDepartment();
                ListItem listItemDepartment = new ListItem("Select department","-1");
                departmentDropDownList.Items.Insert(0, listItemDepartment);

                ListItem listItemSession = new ListItem("Select session", "-1");
                sessionDropDownList.Items.Insert(0, listItemSession);

                ListItem listItemYearTerm = new ListItem("Select year-term", "-1");
                yearTermDropDownList.Items.Insert(0, listItemYearTerm);

                ListItem listItemStudentId = new ListItem("Select studentId", "-1");
                studentIdDropDownList.Items.Insert(0, listItemStudentId);
                sessionDropDownList.Enabled = false;
                yearTermDropDownList.Enabled = false;
                studentIdDropDownList.Enabled = false;
            }
        }

        public void GetAllDepartment()
        {
            List<DepartmentModel> departmentModelsForId = new List<DepartmentModel>();
            departmentModelsForId = resultBll.GetAllDepartmentId();
            List<DepartmentModel> departmentModels = new List<DepartmentModel>();
            departmentModels = resultBll.GetAllDepartmentName(departmentModelsForId);
            departmentDropDownList.DataSource = departmentModels;
            departmentDropDownList.DataTextField = "DepartmentName";
            departmentDropDownList.DataValueField = "DeptId";
            departmentDropDownList.DataBind();
        }

        protected void departmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<SessionMedel> sessionMedelsForParameter = resultBll.GetAllSessionIdByDepetId(Convert.ToInt32(departmentDropDownList.SelectedValue));
            List<SessionMedel> sessionMedels = new List<SessionMedel>();
            sessionMedels = resultBll.GetAllSessionBySessionId(sessionMedelsForParameter);
            sessionDropDownList.DataSource = sessionMedels;
            sessionDropDownList.DataTextField = "SessionValue";
            sessionDropDownList.DataValueField = "ID";
            sessionDropDownList.DataBind();
            sessionDropDownList.Enabled = true;
            ListItem listItemSession = new ListItem("Select session", "-1");
            sessionDropDownList.Items.Insert(0, listItemSession);
        }

        protected void sessionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<YearTermModel> yearTermModelsForParameter = resultBll.GetAllYearTermIdBysessionId(Convert.ToInt32(sessionDropDownList.SelectedValue));
            List<YearTermModel> yearTermModels = new List<YearTermModel>();
            yearTermModels = resultBll.GetAllYearTermByYearTermId(yearTermModelsForParameter);
            yearTermDropDownList.DataSource = yearTermModels;
            yearTermDropDownList.DataTextField = "YearTerm";
            yearTermDropDownList.DataValueField = "ID";
            yearTermDropDownList.DataBind();
            yearTermDropDownList.Enabled = true;
            ListItem listItemYearTerm = new ListItem("Select year-term", "-1");
            yearTermDropDownList.Items.Insert(0, listItemYearTerm);
        }

        protected void yearTermDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<StudentModel> studentModels = resultBll.GetAllStudentIdByDeptIdSessionIdYearTermId(Convert.ToInt32(departmentDropDownList.SelectedValue), Convert.ToInt32(sessionDropDownList.SelectedValue),Convert.ToInt32(yearTermDropDownList.SelectedValue));           
            studentIdDropDownList.DataSource = studentModels;
            studentIdDropDownList.DataTextField = "ID";
            studentIdDropDownList.DataValueField = "ID";
            studentIdDropDownList.DataBind();
            studentIdDropDownList.Enabled = true;
            ListItem listItemStudentId = new ListItem("Select studentId", "-1");
            studentIdDropDownList.Items.Insert(0, listItemStudentId);
        }

        protected void studentIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
           // List<GPAModel> gpaModels = new List<GPAModel>();
           // gpaModels = resultBll.GetAllGPA();
            List<CourseModel> courseModels = new List<CourseModel>();
            courseModels =
                resultBll.GetAllCourseByDeptIdYearTermId(Convert.ToInt32(departmentDropDownList.SelectedValue),
                    Convert.ToInt32(yearTermDropDownList.SelectedValue));
            int idd = 0;
            foreach (CourseModel courseModel in courseModels)
            {
                idd++;
                TableRow tr = new TableRow();
                Label label = new Label();
                label.ID =idd.ToString() ;
                idd++;
                label.Text = courseModel.CourseCode;
                label.Width = 100;
                Label label2 = new Label();
                label2.Text = "Enter GPA:"+"     ";
                
                 // label.CssClass = "form-control";
                label.CssClass = "text-primary";
                TextBox textBox = new TextBox();
                textBox.ID = idd.ToString();
                textBox.Width = Unit.Pixel(100);
             //   textBox.CssClass = "form-control";
                //DropDownList dropDownList = new DropDownList();
                //dropDownList.DataSource = gpaModels;
                //dropDownList.DataTextField = "GPA";
                //dropDownList.DataValueField = "GPAType";
                //dropDownList.DataBind();

                //foreach (GPAModel gpaModel in gpaModels)
                //{
                //    ListItem listItem = new ListItem(Convert.ToString(gpaModel.GPA), gpaModel.GPAType);
                //    dropDownList.Items.Add(listItem);
                //}

                // gpaDiv.Controls.Add(label);
               //  gpaDiv.Controls.Add(textBox);
              // Panel1.Controls.Add(label);
             // Panel1.Controls.Add(textBox);
               
                TableCell tc = new TableCell();               
                tc.Controls.Add(label);
                tc.Controls.Add(label2);
                tc.Controls.Add(textBox);               
                tr.Cells.Add(tc);
                //tr.Style.Add("margin-top", "10");

                gpaTable.Rows.Add(tr);
            }
            Panel1.Controls.Add(new LiteralControl("<br />"));
            
        }

        protected void saveStudentResultButton_Click(object sender, EventArgs e)
        {   
            ////

            List<CourseModel> courseModels = new List<CourseModel>();
            courseModels =
                resultBll.GetAllCourseByDeptIdYearTermId(Convert.ToInt32(departmentDropDownList.SelectedValue),
                    Convert.ToInt32(yearTermDropDownList.SelectedValue));
            int idd = 0;
            foreach (CourseModel courseModel in courseModels)
            {
                idd++;
                TableRow tr = new TableRow();
                Label label = new Label();
                label.ID = idd.ToString();
                idd++;
                label.Text = courseModel.CourseCode;
                label.Width = 100;
                Label label2 = new Label();
                label2.Text = "Enter GPA:" + "     ";
                
                label.CssClass = "text-primary";
                TextBox textBox = new TextBox();
                textBox.ID = idd.ToString();
                textBox.Width = Unit.Pixel(100);                
                TableCell tc = new TableCell();
                tc.Controls.Add(label);
                tc.Controls.Add(label2);
                tc.Controls.Add(textBox);
                tr.Cells.Add(tc);               
                gpaTable.Rows.Add(tr);
            }
            Panel1.Controls.Add(new LiteralControl("<br />"));                                   

            ////
            int idd1 = 0;
            for (int i = 0; i < gpaTable.Rows.Count; i++)
            {
                for (int j = 0; j < gpaTable.Rows[i].Cells.Count; j++)
                {
                    idd1++;
                  Control control   = (Control) gpaTable.Rows[i].Cells[j].FindControl(idd1.ToString());
                    if (control is Label)
                    {
                        var text = (control as Label).Text;
                        Response.Write(text);
                    }
                    idd++;
                    if (control is TextBox)
                    {
                       
                        var text = (control as TextBox).Text;
                        Label1.Text = text;
                    }
                }
            }
              
        }
    }
}