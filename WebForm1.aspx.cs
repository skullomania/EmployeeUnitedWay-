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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected string strRequest, strGender, strSize, strCreateDate, strVariant, strPrizeType, strPayType, strPerPay, strPayPeriods,
            strAnnualPayroll, strGrandTotal, strCountyOrAgency, strUserID, strFirstTime, strLastName, strFirstName, strPrefName, strPosition,
            strCompany, strCC, strDepartment, strEmail, strManager, strVP;
        protected int num = 0, init, logged = 0, loggedNDonated = 0, donatedAlready = 0, loggedmore = 0, payrollBox = 0, nGotPrize = 0;
        protected decimal abc;

        private string[] users = new string[1] {
        "test.user" //Ryan Finch
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            strRequest = Request.QueryString["num"];
            bool res = int.TryParse(strRequest, out num);
            if (res == false)
            {
                Response.Redirect("https://www.kdmc.com/teamshirts/userlogin.aspx?error=invalid");
            }
            else
            {
                NumNotExist();
                if (num < 1)
                {
                    Response.Redirect("https://www.kdmc.com/teamshirts/userlogin.aspx?error=invalid");
                }
                LoggedDonated();
                if ((logged > 0) && (loggedNDonated > 0))
                {
                    Response.Redirect("https://www.kdmc.com/teamshirts/userlogin.aspx?error=expired");
                }
            }
        }

        protected void btnFleece_Click(object sender, EventArgs e)
        {
            GetLogData();
            GetEmployeeData();
            init = 0;
            strRequest = Request.QueryString["num"];
            num = Convert.ToInt32(strRequest);
            strSize = ddlShSize.SelectedItem.Text;
            strVariant = strSize;
            Response.Write(strCreateDate);
        }

        protected void UpdateLog()
        {
            using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand(@"UPDATE [TeamShirt_Logs] SET [Variant] = @Variant, [PrizeType]=@PrizeType, 
                [PayType]=@PayType, [PerPay]=@PerPay, [PayPeriods]=@PayPeriods, [AnnualPayroll]=@AnnualPayroll, 
                [GrandTotal]=@GrandTotal, [GotPrize]=@GotPrize WHERE [num] = @num", conn1);
                cmd1.Parameters.AddWithValue("@num", num);
                cmd1.CommandType = CommandType.Text;
                conn1.Open();

                cmd1.Parameters.Add("@Variant", SqlDbType.NVarChar, 60);
                cmd1.Parameters["@Variant"].Value = strVariant;
                cmd1.ExecuteNonQuery();
            }
        }

        protected void LoggedDonated()
        {
            GetLogData();
            GetEmployeeData();
            string mdt = DateTime.Now.Year.ToString();
            int ndt = Convert.ToInt32(mdt);
            int ny = ndt + 1;
            string DonateYear = Convert.ToString(ny);
        }

        protected void NumNotExist()
        {
            int ReqNum = Convert.ToInt32(strRequest);
            using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
            {
                SqlCommand cmdzero = new SqlCommand(@"SELECT COUNT(num) FROM [TeamShirt_Logs] Where [num] = @num", conn1);
                cmdzero.Parameters.AddWithValue("@num", ReqNum);
                conn1.Open();
                int countzero = (int)cmdzero.ExecuteScalar();
                int myNum = countzero;
                if (myNum < 1)
                {
                    Response.Redirect("https://www.kdmc.com/teamshirts/userlogin.aspx?error=invalid");
                }
            }
        }
        protected void GetLogData()
        {
            using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
            {
                strRequest = Request.QueryString["num"];
                SqlCommand cmd2 = new SqlCommand(@"SELECT [UserID],[CreateDate] FROM [TeamShirt_Logs] Where [num] = @num", conn1);
                cmd2.Parameters.AddWithValue("@num", num);
                conn1.Open();
                using (SqlDataReader reader1 = cmd2.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        strUserID = reader1.GetString(0);
                        strCreateDate = reader1.GetString(1);
                    }
                }
            }
        }

        protected void GetEmployeeData()
        {
            using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
            {
                SqlCommand cmd3 = new SqlCommand(@"SELECT [Last Name], [First Name], [Preferred Name], [Position], [Company], [CC#], [Department Name], [Email], [Manager], [VP] 
                                                        FROM [UnitedWay_Employee2017] Where [ID#] = @UserID", conn1);
                cmd3.Parameters.AddWithValue("@UserID", strUserID);
                conn1.Open();
                using (SqlDataReader reader1 = cmd3.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        strLastName = reader1.GetString(0);
                        strFirstName = reader1.GetString(1);
                        strPrefName = reader1.GetString(2);
                        strPosition = reader1.GetString(3);
                        strCompany = reader1.GetString(4);
                        strCC = reader1.GetString(5);
                        strDepartment = reader1.GetString(6);
                        strEmail = reader1.GetString(7);
                        strManager = reader1.GetString(8);
                        strVP = reader1.GetString(9);
                    }
                }
            }
        }

        protected void WillPass()
        {
            lblError.Visible = false;
            UpdateLog();
        }

        protected void SaveData()
        {
            using (SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [TeamShirt_KDMCOrders](EmpID, Fname, Lname, Email, Position, Department, 
                                                CostCenter, Manager, VP, DateEntered, PrizeCriteria, Logged) 
                                                VALUES (@EmpID, @Fname, @Lname, @Email, @Position, @Department, @CostCenter, @Manager, @VP, 
                                                @DateEntered, @PrizeCriteria, @Logged)", conn2);
                cmd1.CommandType = CommandType.Text;
                conn2.Open();
                cmd1.Parameters.AddWithValue("@EmpID", strUserID);
                cmd1.Parameters.AddWithValue("@Fname", strFirstName);
                cmd1.Parameters.AddWithValue("@Lname", strLastName);
                cmd1.Parameters.AddWithValue("@Email", strEmail);
                cmd1.Parameters.AddWithValue("@Position", strPosition);
                cmd1.Parameters.AddWithValue("@Department", strPosition);
                cmd1.Parameters.AddWithValue("@CostCenter", strCC);
                cmd1.Parameters.AddWithValue("@Manager", strManager);
                cmd1.Parameters.AddWithValue("@VP", strVP);
                cmd1.Parameters.AddWithValue("@DateEntered", strCreateDate);
                cmd1.Parameters.AddWithValue("@PrizeCriteria", strVariant);
                cmd1.Parameters.AddWithValue("@Logged", num);
                cmd1.ExecuteNonQuery();
            }
        }
    }
}