using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnitedWay2017
{
    public partial class userlogin : System.Web.UI.Page
    {
        private string[] users = new string[1] {
        "test.user" //test user
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOrderAttemptTime.Text = DateTime.Now.ToString("MM-dd-yyyy h:mmtt");
         
            if (Request.QueryString.ToString().Length > 0)
            {
                string strError = Request.QueryString["error"];
                if (strError == "invalid")
                {
                    lblNotInDB.Visible = true;
                    lblNotInDB.Text = @"<p class='alert alert-danger' style='margin:-50px;'>Invalid Request. Our system 
                    detected something fishy on your end, because of this your request and/or data was not submitted. 
                    Feel free to log in and try again!</p>";
                }
                else if (strError == "expired")
                {
                    lblNotInDB.Visible = true;
                    lblNotInDB.Text = @"<p class='alert alert-warning' style='margin:-50px;'>The session requested has expired. If you 
                    would like to make a donation feel free to log in!</p>";
                }
            }
        }
        
        public bool AuthenticateActiveDirectory(string Domain, string EmployeeID, string Password)
        {
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://" + Domain, EmployeeID, Password);
                object nativeObject = entry.NativeObject;
                return true;
            }
            catch
            {
                //DirectoryServicesCOMException
                return false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strUserID = txtUserID.Text;

            using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
            {
                SqlCommand cmdzero = new SqlCommand(@"SELECT COUNT(ID#) FROM [UnitedWay_Employee2017] Where [ID#] = @UserID", conn1);
                cmdzero.Parameters.AddWithValue("@UserID", strUserID);
                conn1.Open();
                int countzero = (int)cmdzero.ExecuteScalar();
                int myNum = countzero;
                if (myNum < 1)
                {
                    lblNotInDB.Visible = true;
                    lblNotInDB.Text = @"<p class='alert alert-warning' style='margin:-50px;'>The Employee ID does not exist in our records 
                    for United Way. If you are sure that you have the correct employee ID and the error persist please contact a member 
                    of the marketing team.</p>";
                }
                else
                {
                    string Domain = "kdmc.local";
                    string EmployeeID = txtUserID.Text;
                    string Password = txtPassword.Text;
                    string ADStatus = null;

                    if ((users.Contains(txtUserID.Text)) || (AuthenticateActiveDirectory(Domain, EmployeeID, Password) == true))
                    {
                        SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [UnitedWay_Logs](UserID, CreateDate) values (@UserID, @CreateDate); 
                                                            Select SCOPE_IDENTITY();", conn1);
                        cmd1.CommandType = CommandType.Text;

                        cmd1.Parameters.Add("@UserID", SqlDbType.NVarChar, 50);
                        cmd1.Parameters["@UserID"].Value = strUserID;

                        string strCreateDate = lblOrderAttemptTime.Text;
                        cmd1.Parameters.Add("@CreateDate", SqlDbType.NVarChar, 50);
                        cmd1.Parameters["@CreateDate"].Value = strCreateDate;

                        string numScope = Convert.ToString(cmd1.ExecuteScalar());                         

                        ADStatus = "Success";
                        Session["SessionLoginStatus"] = ADStatus;
                        Response.Redirect("default.aspx?num=" + numScope);
                    }
                    else
                    {
                        ADStatus = "Failure";
                        Session["SessionLoginStatus"] = ADStatus;
                        lblADError.Visible = true;
                        lblADError.Text = "Please Check Your Password<br />";
                    }

                }
            }
             
        }
    }
}