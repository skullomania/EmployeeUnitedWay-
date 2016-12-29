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
    public partial class donateca : System.Web.UI.Page
    {
        private string[] users = new string[1] {
        "test.user" //test user
        };
        protected string strRequest, strGender, strSize, strCreateDate, strVariant, strPrizeType, strPayType, strPerPay, strPayPeriods,
            strAnnualPayroll, strGrandTotal, strCountyOrAgency, strUserID, strFirstTime, strLastName, strFirstName, strPrefName, strPosition, 
            strCompany, strCC, strDepartment, strEmail, strManager, strVP;

        protected string SuggestionList = "";
        protected int num = 0, ft = 0, ag = 0, ct = 0, pw = 0, logged = 0, loggedNDonated = 0, nGotPrize = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            strRequest = Request.QueryString["num"];
            bool res = int.TryParse(strRequest, out num);

            if ((res == false) || num < 1)
            {
                Response.Redirect("userlogin.aspx?error=invalid");
            }
            else
            {
                LoggedDonated();
                if ((logged > 0) && (loggedNDonated > 0))
                {
                    Response.Redirect("userlogin.aspx?error=expired");
                }
                else
                {
                    int ReqNum = Convert.ToInt32(strRequest);
                    using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
                    {
                        SqlCommand cmdzero = new SqlCommand(@"SELECT COUNT(num) FROM [UnitedWay_Logs] Where [num] = @num", conn1);
                        cmdzero.Parameters.AddWithValue("@num", ReqNum);
                        conn1.Open();
                        int countzero = (int)cmdzero.ExecuteScalar();
                        int myNum = countzero;
                        if (myNum < 1)
                        {
                            Response.Redirect("userlogin.aspx?error=invalid");
                        }
                        else
                        {
                            num = Convert.ToInt32(strRequest);

                            strCountyOrAgency = radCountyOrAgency.SelectedValue;
                            switch (strCountyOrAgency)
                            {
                                case "Most Needed":
                                    pnlNeededMost.Visible = true;
                                    btnNeededMost.Visible = true;
                                    btnCounty.Visible = false;
                                    btnAgency.Visible = false;
                                    pnlCounty.Visible = false;
                                    pnlAgency.Visible = false;
                                    pnlPassword.Visible = true;
                                    break;
                                case "County":
                                    pnlNeededMost.Visible = false;
                                    btnNeededMost.Visible = false;
                                    btnCounty.Visible = true;
                                    btnAgency.Visible = false;
                                    pnlCounty.Visible = true;
                                    pnlAgency.Visible = false;
                                    pnlPassword.Visible = true;
                                    break;
                                case "Agency":
                                    pnlNeededMost.Visible = false;                                    
                                    btnNeededMost.Visible = false;
                                    btnCounty.Visible = false;
                                    btnAgency.Visible = true;
                                    pnlCounty.Visible = false;
                                    pnlAgency.Visible = true;
                                    pnlPassword.Visible = true;
                                    break;
                            }
                        }

                        SqlCommand cmdone = new SqlCommand(@"SELECT [Agencies] FROM [UnitedWay_Agencies] order by [Agencies];", conn1);
                        using (SqlDataReader reader = cmdone.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                SuggestionList = SuggestionList.Replace("-", " ");
                                if (string.IsNullOrEmpty(SuggestionList))
                                {
                                    SuggestionList += "\"" + reader["Agencies"].ToString() + "\"";
                                }
                                else
                                {
                                    SuggestionList += ", \"" + reader["Agencies"].ToString() + "\"";
                                }
                            }
                        }
                    }
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

        protected void btnNeededMost_Click(object sender, EventArgs e)
        {
            CheckFirstTime();
            if (ft > 0)
            {
                CheckAD();
                if (pw > 0)
                {
                    GetLogData();
                    GetEmployeeData();
                    SaveData();
                    Response.Redirect("success.aspx#no-back");
                }
                else
                {
                    lblError.Visible = true;
                }
            }
            else 
            {
                lblError.Visible = true;
            }
        }

        protected void btnCounty_Click(object sender, EventArgs e)
        {
            CheckFirstTime();
            if(ft > 0)
            {
                CheckCounty();
                if (ct > 0)
                {
                    CheckAD();
                    if (pw > 0)
                    {
                        GetLogData();
                        GetEmployeeData();
                        SaveData();
                        Response.Redirect("success.aspx#no-back");
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }
                else
                {
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }

        protected void btnAgency_Click(object sender, EventArgs e)
        {
            CheckFirstTime();
            if (ft > 0)
            {
                CheckAgency();
                if (ag > 0)
                {

                    CheckAD();
                    if (pw > 0)
                    {
                        GetLogData();
                        GetEmployeeData();
                        SaveData();
                        Response.Redirect("success.aspx#no-back");
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }
                else
                {
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }

        protected void GetLogData()
        {
            using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
            {
                strRequest = Request.QueryString["num"];
                SqlCommand cmd2 = new SqlCommand(@"SELECT [UserID],[CreateDate],[Variant],[PrizeType],[PayType],[PerPay],[PayPeriods],[AnnualPayroll],[GrandTotal],[GotPrize]
                                                        FROM [UnitedWay_Logs] Where [num] = @num", conn1);
                cmd2.Parameters.AddWithValue("@num", num);
                conn1.Open();
                using (SqlDataReader reader1 = cmd2.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        strUserID = reader1.GetString(0);
                        strCreateDate = reader1.GetString(1);
                        strVariant = reader1.GetString(2);
                        strPrizeType = reader1.GetString(3);
                        strPayType = reader1.GetString(4);
                        strPerPay = reader1.GetString(5);
                        strPayPeriods = reader1.GetString(6);
                        strAnnualPayroll = reader1.GetString(7);
                        strGrandTotal = reader1.GetString(8);
                        nGotPrize = reader1.GetInt32(9);
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

        protected void SaveData()
        {
            string strCounty = string.Empty;
            string strAgency = string.Empty;
            string mdt = DateTime.Now.Year.ToString();
            int ndt = Convert.ToInt32(mdt);
            int ny = ndt + 1;
            string DonateYear = Convert.ToString(ny);

            int firstTime = 0;

            if (radFirstTime.SelectedValue == "Yes")
            {
                firstTime = 1;
            }
            else if (radFirstTime.SelectedValue == "No")
            {
                firstTime = 0;
            }

            strCountyOrAgency = radCountyOrAgency.SelectedValue;
            switch (strCountyOrAgency)
            {
                case "Most Needed":
                    strCounty = "Not Designated";
                    strAgency = "Not Designated";
                    break;
                case "County":
                    strCounty = ddlCounties.SelectedValue;
                    strAgency = "Not Designated";
                    break;
                case "Agency":
                    strCounty = "Not Designated";
                    strAgency = txtAgencies.Text;
                    break;
            }
            

            using (SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [UnitedWay_KDMCPledges](EmpID, Fname, Lname, Email, Position, Department, 
                                                CostCenter, Manager, VP, DateEntered, FirstTime, ProcessLevel, PrizeCriteria, PayType, PerPay, 
                                                PayPeriods, AnnualPayroll, GrandTotal, County, Agency, DonationYear, Logged, GotPrize) 
                                                VALUES (@EmpID, @Fname, @Lname, @Email, @Position, @Department, @CostCenter, @Manager, @VP, 
                                                @DateEntered, @FirstTime, @ProcessLevel, @PrizeCriteria, @PayType, @PerPay, @PayPeriods, @AnnualPayroll, 
                                                @GrandTotal, @County, @Agency, @DonationYear, @Logged, @GotPrize)", conn2);
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
                cmd1.Parameters.AddWithValue("@FirstTime", firstTime);
                cmd1.Parameters.AddWithValue("@ProcessLevel", strCompany);
                cmd1.Parameters.AddWithValue("@PrizeCriteria", strVariant);
                cmd1.Parameters.AddWithValue("@PayType", strPayType);
                cmd1.Parameters.AddWithValue("@PerPay", strPerPay);
                cmd1.Parameters.AddWithValue("@PayPeriods", strPayPeriods);
                cmd1.Parameters.AddWithValue("@AnnualPayroll", strAnnualPayroll);
                cmd1.Parameters.AddWithValue("@GrandTotal", strGrandTotal);
                cmd1.Parameters.AddWithValue("@County", strCounty);
                cmd1.Parameters.AddWithValue("@Agency", strAgency);
                cmd1.Parameters.AddWithValue("@DonationYear", DonateYear);
                cmd1.Parameters.AddWithValue("@Logged", num);
                cmd1.Parameters.AddWithValue("@GotPrize", nGotPrize);
                cmd1.ExecuteNonQuery();
            }
        }
        protected void CheckFirstTime()
        {
            strFirstTime = radFirstTime.SelectedValue;
            if(strFirstTime.Length < 1)
            {
                lblError.Visible = true;
                lblError.Text = @"<p class='alert alert-danger' style='margin:-23px;'>Please tell us if this is your first time donating 
                to United Way</p>";
                ft = 0;
            }
            else 
            {
                lblError.Visible = false;
                ft = 1;
            }
        }

        protected void CheckAgency()
        {
            string Agency = txtAgencies.Text;
            using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
            {
                SqlCommand cmdfive = new SqlCommand(@"SELECT COUNT(id) FROM [UnitedWay_Agencies] Where [Agencies] = @Agencies", conn1);
                cmdfive.Parameters.AddWithValue("@Agencies", Agency);
                conn1.Open();
                int countzero = (int)cmdfive.ExecuteScalar();
                int myNum = countzero;
                if(myNum < 1)
                {
                    lblError.Visible = true;
                    lblError.Text = @"<p class='alert alert-warning' style='margin:-23px;'>The agency you have chosen is not on out list of valid choices for 
                    donating to United Way this year. Please try again.</p>";
                    ag = 0;
                }
                else
                {
                    lblError.Visible = false;
                    ag = 1;
                }
            }
        }

        protected void CheckCounty()
        {
            string County = ddlCounties.SelectedValue;
            if(County.Length < 1)
            {
                lblError.Visible = true;
                lblError.Text = @"<p class='alert alert-danger' style='margin:-23px;'>Please select a county</p>";
                ct = 0;
            }
            else 
            {
                lblError.Visible = false;
                ct = 1;
            }
        }

        protected void CheckAD()
        {
            string Domain = "kdmc.local";
            string EmployeeID = strUserID;
            string Password = txtPassword.Text;
            string ADStatus = null;
            if (Password.Length < 1)
            {
                lblError.Visible = true;
                lblError.Text = @"<p class='alert alert-danger' style='margin:-23px;'>Please enter a password</p>";
                pw = 0;
            }
            else
            {
                pw = 1;
                if ((users.Contains(strUserID)) || (AuthenticateActiveDirectory(Domain, EmployeeID, Password) == true))
                {
                    lblError.Visible = false;
                    ADStatus = "Success";
                    Session["SessionLoginStatus"] = ADStatus;
                }
                else
                {
                    ADStatus = "Failure";
                    Session["SessionLoginStatus"] = ADStatus;
                    lblError.Visible = true;
                    lblError.Text = @"<p class='alert alert-danger' style='margin:-23px;'>Invalid Password. Please check your password and try again!</p>";
                }
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

            using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
            {
                SqlCommand cmdsix = new SqlCommand(@"SELECT COUNT(num) FROM [UnitedWay_Logs] Where [num] = @num", conn1);
                cmdsix.Parameters.AddWithValue("@num", num);
                conn1.Open();
                int countzero = (int)cmdsix.ExecuteScalar();
                int myNum = countzero;
                if (myNum < 1)
                {
                    logged = 0;
                }
                else
                {
                    logged = 1;
                }

                SqlCommand cmdseven = new SqlCommand(@"SELECT COUNT(id) FROM [UnitedWay_KDMCPledges] Where [EmpID] = @UserID AND [Logged] = @num", conn1);
                cmdseven.Parameters.AddWithValue("@UserID", strUserID);
                cmdseven.Parameters.AddWithValue("@DonationYear", DonateYear);
                cmdseven.Parameters.AddWithValue("@num", num);                
                int countone = (int)cmdseven.ExecuteScalar();
                int myNumz = countone;
                if (myNumz < 1)
                {
                    loggedNDonated = 0;
                }
                else
                {
                    loggedNDonated = 1;
                }
            }
        }
            
    }
}