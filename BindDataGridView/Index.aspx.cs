using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace BindDataGridView
{
    public partial class Index : System.Web.UI.Page
    {
        string ConnectingString = @"Data Source = DESKTOP-DCI8J14;Initial Catalog = LoginDB;Integrated Security = True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            using(SqlConnection sqlCon = new SqlConnection(ConnectingString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM PhoneBook",sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
            }
        }

        protected void lnkSelect_Click(object sender, EventArgs e)
        {
            int phonebookID = Convert.ToInt32((sender as LinkButton).CommandArgument);
        }
    }
}