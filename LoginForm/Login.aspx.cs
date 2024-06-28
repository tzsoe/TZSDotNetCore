using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LoginForm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Data Source = DESKTOP-DCI8J14;Initial Catalog = LoginDB;Integrated Security = True;"))
            {
                string Query = "SELECT COUNT(1) FROM tblUser WHERE UserName = @UserName AND PASSWORD = @Password";
                SqlCommand sqlCmd = new SqlCommand(Query, sqlConn);
                sqlCmd.Parameters.AddWithValue("@UserName",txtUsername.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password",txtPassword.Text.Trim());
                sqlConn.Open();
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                if(count == 1)
                {
                    Session["Username"] = txtUsername.Text.Trim();
                    Response.Redirect("DashBoard.aspx");
                }
                else
                { lblErrorMessage.Visible = true; }
            }
        }
    }
}