using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Description;

namespace User_Registration
{
    public partial class Index : System.Web.UI.Page
    {
        string ConnectionString = @"Data Source = DESKTOP-DCI8J14; Initial Catalog = UserRegistrationDB; Integrated Security = True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Clear();
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int userID = Convert.ToInt32(Request.QueryString["id"]);
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("UserViewByID",sqlCon);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDa.SelectCommand.Parameters.AddWithValue("@UserID",userID);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);

                    hfUserID.Value = userID.ToString();
                    txtFirstName.Text = dtbl.Rows[0][1].ToString();
                    txtLastName.Text = dtbl.Rows[0][2].ToString();
                    txtContact.Text = dtbl.Rows[0][3].ToString();
                    ddlGender.Items.FindByValue(dtbl.Rows[0][4].ToString()).Selected = true;
                    txtAddress.Text = dtbl.Rows[0][5].ToString();
                    txtUserName.Text = dtbl.Rows[0][6].ToString();
                    txtPassword.Text = dtbl.Rows[0][7].ToString();
                    txtPassword.Attributes.Add("value", dtbl.Rows[0][7].ToString());
                    txtConfirmPassword.Text = dtbl.Rows[0][7].ToString();
                    txtConfirmPassword.Attributes.Add("value", dtbl.Rows[0][7].ToString());
                }

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
                lblErrorMessage.Text = "Please Fill Mandatory Fileds!";
            else if (txtPassword.Text != txtConfirmPassword.Text)
                lblErrorMessage.Text = "Password do not match!";
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                    sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                    sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    Clear();
                    lblSuccessMessage.Text = "Submitted Successfully!";
                }
            }
        }
        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtContact.Text = txtAddress.Text = txtUserName.Text = txtPassword.Text = txtConfirmPassword.Text = string.Empty;
            hfUserID.Value = string.Empty;
            lblSuccessMessage.Text = lblErrorMessage.Text = string.Empty;
        }
    }
}