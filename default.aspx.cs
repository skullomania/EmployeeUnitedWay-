using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace UnitedWay2017
{
    public partial class _default : System.Web.UI.Page
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
                Response.Redirect("userlogin.aspx?error=invalid");
            }
            else
            {
                NumNotExist();
                if (num < 1)
                {
                    Response.Redirect("userlogin.aspx?error=invalid");
                }
                LoggedDonated();
                if ((logged > 0) && (loggedNDonated > 0))
                {
                    Response.Redirect("userlogin.aspx?error=expired");
                }
                else
                {
                    if (donatedAlready > 0)
                    {
                        lblDonated.Visible = true;
                        lblDonated.Text = @"<p class='myalert alert-success' style='margin:-23px 0px 10px 0px;'>Our records indicate that you have donated already. Feel free to continue to make another or close out the page if you are done!</p>";
                    }
                    else if ((loggedmore > 0) && (donatedAlready < 1))
                    {
                        lblDonated.Visible = true;
                        lblDonated.Text = @"<p class='myalert alert-info' style='margin:-23px 0px 10px 0px;'>It seems that you have logged in before but have not made a donation. Please complete all the information to make a difference!</p>";
                    }
                    else
                    {
                        lblDonated.Visible = false;
                    }
                    num = Convert.ToInt32(strRequest);
                    strPayType = radPaymentType.SelectedValue;
                    switch (strPayType)
                    {
                        case "Payroll Deduction":
                            pnlPayroll.Visible = true;
                            pnlCheck.Visible = false;
                            pnlCash.Visible = false;
                            init = 3;
                            break;
                        case "Check":
                            pnlPayroll.Visible = false;
                            pnlCheck.Visible = true;
                            pnlCash.Visible = false;
                            init = 3;
                            break;
                        case "Cash":
                            pnlPayroll.Visible = false;
                            pnlCheck.Visible = false;
                            pnlCash.Visible = true;
                            init = 3;
                            break;
                    }
                }
            }
        }

        protected void btnFleece_Click(object sender, EventArgs e)
        {
            init = 0;
            strRequest = Request.QueryString["num"];
            num = Convert.ToInt32(strRequest);
            strGender = ddlGender.SelectedItem.Text;
            strSize = ddlFSize.SelectedItem.Text;
            strVariant = strGender + "-" + strSize;
            strPrizeType = "Fleece";
            strPayType = "Payroll Deduction";
            strPerPay = "10";
            strPayPeriods = "26";
            strAnnualPayroll = "260.00";
            strGrandTotal = "260.00";
            nGotPrize = 1;

            if ((strGender.Length < 1) || (strSize.Length < 1))
            {
                lblError.Visible = true;
                lblError.Text = @"<p class='alert alert-danger' style='margin:-23px;'>Please make sure you have chosen a gender type
                and size for your fleece jacket.</p>";
                init = 0;
            }
            else
            {
                lblError.Visible = false;
                UpdateLog();
                Response.Redirect("donateca.aspx?num=" + num);
            }
        }

        protected void btnLongSleeve_Click(object sender, EventArgs e)
        {
            init = 1;
            strRequest = Request.QueryString["num"];
            num = Convert.ToInt32(strRequest);
            strSize = ddlLsSize.SelectedItem.Text;
            strVariant = strSize;
            strPrizeType = "Long Sleeve Shirt";
            strPayType = "Payroll Deduction";
            strPerPay = "5";
            strPayPeriods = "26";
            strAnnualPayroll = "130.00";
            strGrandTotal = "130.00";
            nGotPrize = 1;

            if (strSize.Length < 1)
            {
                init = 1;
                lblError.Visible = true;
                lblError.Text = @"<p class='alert alert-danger' style='margin:-23px;'>Please make sure you have chosen a size for 
                your long sleeve shirt.</p>";
            }
            else
            {
                lblError.Visible = false;
                UpdateLog();
                Response.Redirect("donateca.aspx?num=" + num);
            }
        }

        protected void btnShortSleeve_Click(object sender, EventArgs e)
        {
            init = 2;
            strRequest = Request.QueryString["num"];
            num = Convert.ToInt32(strRequest);
            strSize = ddlShSize.SelectedItem.Text;
            strVariant = strSize;
            strPrizeType = "Short Sleeve Shirt";
            strPayType = "Payroll Deduction";
            strPerPay = "25";
            strPayPeriods = "1";
            strAnnualPayroll = "25.00";
            strGrandTotal = "25.00";
            nGotPrize = 1;

            if (strSize.Length < 1)
            {
                init = 2;
                lblError.Visible = true;
                lblError.Text = @"<p class='alert alert-danger' style='margin:-23px;'>Please make sure you have chosen a size for 
                your short sleeve shirt.</p>";
            }
            else
            {
                lblError.Visible = false;
                UpdateLog();
                Response.Redirect("donateca.aspx?num=" + num);
            }
        }

        protected void btnCustom_Click(object sender, EventArgs e)
        {
            init = 3;
            strRequest = Request.QueryString["num"];
            num = Convert.ToInt32(strRequest);
            strGender = ddlCGender.SelectedItem.Text;
            strSize = ddlCSize.SelectedItem.Text;
            strVariant = strGender + "-" + strSize;
            strPrizeType = "Custom";
            strPayType = "Payroll Deduction";
            strPerPay = txtPerPay.Text;
            strPayPeriods = txtPayPeriods.Text;
            strAnnualPayroll = txtAnnualPayroll.Text;
            strGrandTotal = txtAnnualPayroll.Text;


            if (Decimal.TryParse(txtAnnualPayroll.Text, out abc))
            {
                payrollBox = Convert.ToInt32(abc);
                if (payrollBox <= 24)
                {
                    nGotPrize = 0;
                    if ((strPerPay.Length < 1) || (strPayPeriods.Length < 1))
                    {
                        NoPass();
                    }
                    else
                    {
                        WillPass();
                    }

                }
                if ((payrollBox >= 25) && (payrollBox <= 259))
                {
                    nGotPrize = 1;
                    if (strSize.Length < 1)
                    {
                        NoPass();
                    }
                    else
                    {
                        WillPass();
                    }
                }
                if (payrollBox > 259)
                {
                    nGotPrize = 1;
                    if (strGender.Length < 1)
                    {
                        NoPass();
                    }
                    if (strSize.Length < 1)
                    {
                        NoPass();
                    }
                    if ((strGender.Length > 1) && (strSize.Length > 1))
                    {
                        WillPass();
                    }
                }
            }
        }

        protected void UpdateLog()
        {
            if ((strPayType == "Check") || (strPayType == "Cash"))
            {
                strGrandTotal = "0.00";
            }
            using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
            {
                SqlCommand cmd1 = new SqlCommand(@"UPDATE [UnitedWay_Logs] SET [Variant] = @Variant, [PrizeType]=@PrizeType, 
                [PayType]=@PayType, [PerPay]=@PerPay, [PayPeriods]=@PayPeriods, [AnnualPayroll]=@AnnualPayroll,
                [GrandTotal]=@GrandTotal, [GotPrize]=@GotPrize WHERE [num] = @num", conn1);
                cmd1.Parameters.AddWithValue("@num", num);
                cmd1.CommandType = CommandType.Text;
                conn1.Open();

                cmd1.Parameters.Add("@Variant", SqlDbType.NVarChar, 60);
                cmd1.Parameters["@Variant"].Value = strVariant;

                cmd1.Parameters.Add("@PrizeType", SqlDbType.NVarChar, 50);
                cmd1.Parameters["@PrizeType"].Value = strPrizeType;

                cmd1.Parameters.Add("@PayType", SqlDbType.NVarChar, 50);
                cmd1.Parameters["@PayType"].Value = strPayType;

                cmd1.Parameters.Add("@PerPay", SqlDbType.NVarChar, 50);
                cmd1.Parameters["@PerPay"].Value = strPerPay;

                cmd1.Parameters.Add("@PayPeriods", SqlDbType.NVarChar, 50);
                cmd1.Parameters["@PayPeriods"].Value = strPayPeriods;

                cmd1.Parameters.Add("@AnnualPayroll", SqlDbType.NVarChar, 50);
                cmd1.Parameters["@AnnualPayroll"].Value = strAnnualPayroll;

                cmd1.Parameters.Add("@GrandTotal", SqlDbType.NVarChar, 50);
                cmd1.Parameters["@GrandTotal"].Value = strGrandTotal;

                cmd1.Parameters.Add("@GotPrize", SqlDbType.Int, 1);
                cmd1.Parameters["@GotPrize"].Value = nGotPrize;
                cmd1.ExecuteNonQuery();
            }
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            init = 3;
            strRequest = Request.QueryString["num"];
            num = Convert.ToInt32(strRequest);
            strGender = ddlCGender.SelectedItem.Text;
            strSize = ddlCSize.SelectedItem.Text;
            strVariant = strGender + "-" + strSize;
            strPrizeType = "Custom";
            strPayType = "Check";
            strPerPay = "";
            strPayPeriods = "";
            strAnnualPayroll = "";
            strGrandTotal = "";
            UpdateLog();
            Response.Redirect("donateca.aspx?num=" + num);
        }

        protected void btnCash_Click(object sender, EventArgs e)
        {
            init = 3;
            strRequest = Request.QueryString["num"];
            num = Convert.ToInt32(strRequest);
            strGender = ddlCGender.SelectedItem.Text;
            strSize = ddlCSize.SelectedItem.Text;
            strVariant = strGender + "-" + strSize;
            strPrizeType = "Custom";
            strPayType = "Cash";
            strPerPay = "";
            strPayPeriods = "";
            strAnnualPayroll = "";
            strGrandTotal = "";
            UpdateLog();
            Response.Redirect("donateca.aspx?num=" + num);
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

                SqlCommand cmdseven = new SqlCommand(@"SELECT COUNT(id) FROM [UnitedWay_KDMC2Pledges] Where [EmpID] = @UserID AND [Logged] = @num", conn1);
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

                SqlCommand cmdeight = new SqlCommand(@"SELECT COUNT(id) FROM [UnitedWay_KDMC2Pledges] Where [EmpID] = @UserID AND [DonationYear] = @DonationYear", conn1);
                cmdeight.Parameters.AddWithValue("@UserID", strUserID);
                cmdeight.Parameters.AddWithValue("@DonationYear", DonateYear);
                int counttwo = (int)cmdeight.ExecuteScalar();
                int myNumy = counttwo;
                if (myNumy < 1)
                {
                    donatedAlready = 0;
                }
                else
                {
                    donatedAlready = 1;
                }

                SqlCommand cmdnine = new SqlCommand(@"SELECT COUNT(UserID) FROM [UnitedWay_Logs] Where [UserID] = @UserID", conn1);
                cmdnine.Parameters.AddWithValue("@UserID", strUserID);
                int countthree = (int)cmdnine.ExecuteScalar();
                int myNumx = countthree;
                if (myNumx > 1)
                {
                    loggedmore = 1;
                }
                else if (myNumx <= 1)
                {
                    loggedmore = 0;
                }
            }
        }

        protected void NumNotExist()
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
            }
        }
        protected void GetLogData()
        {
            using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer2"].ConnectionString))
            {
                strRequest = Request.QueryString["num"];
                SqlCommand cmd2 = new SqlCommand(@"SELECT [UserID] FROM [UnitedWay_Logs] Where [num] = @num", conn1);
                cmd2.Parameters.AddWithValue("@num", num);
                conn1.Open();
                using (SqlDataReader reader1 = cmd2.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        strUserID = reader1.GetString(0);
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

        protected void NoPass()
        {
            init = 3;
            lblError.Visible = true;
            lblError.Text = @"<p class='alert alert-danger' style='margin:-23px;'>Please make sure you have 
                completed all of the information for your custom donation.</p>";
            txtPayPeriods.Text = string.Empty;
            txtPerPay.Text = string.Empty;
        }

        protected void WillPass()
        {
            lblError.Visible = false;
            UpdateLog();
            Response.Redirect("donateca.aspx?num=" + num);
        }
               
    }
}