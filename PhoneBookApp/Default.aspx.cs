using PhoneBookApp.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneBookApp
{
    public partial class _Default : Page
    {
        public List<Contact> Contacts { get; set; }
        protected void Page_Load(object sender, EventArgs e)
            {
            
             var model = new PhoneBookModel();

            if (!string.IsNullOrEmpty(Request.QueryString["searchword"]))
            {
                string searchword = Request.QueryString["searchword"];
                Contacts = model.Contacts.Where(m => m.Name.ToLower().Contains(searchword.ToLower())).ToList();
                GetAll();
            }
            else
            {
                Contacts = model.Contacts.Include(m => m.PhoneNumbers).ToList();
                GetAll();
            }

        }

      public List<Contact>  GetAll()
        {

            if (Contacts == null)
            {
                 PhoneBookModel model = new PhoneBookModel();
                return model.Contacts.Include(m => m.PhoneNumbers).ToList();
            }
            return Contacts;    
        }





        private System.Data.DataTable GetData()
        {
            PhoneBookModel model = new PhoneBookModel();

            var contacts= model.Contacts.Include(m => m.PhoneNumbers).ToList();

            System.Data.DataTable dt = new System.Data.DataTable("TestTable");
            dt.Columns.Add("Name");
            dt.Columns.Add("National ID");
           
            var count= 1;
            foreach (var item in contacts)
            {
                
                foreach (var i in item.PhoneNumbers)
                {
                    if(item.PhoneNumbers.Count>=count)
                    dt.Columns.Add("Phone Numbers "+count++);
                }
                dt.Rows.Add(item.Name, item.NationalId, string.Join(" , ", item.PhoneNumbers.Select(x => x.Number).ToList()));

            }
            return dt;
        }
        protected void ButtonCSV_Click(object sender, EventArgs e)
        {
            var dataTable = GetData();
            StringBuilder builder = new StringBuilder();
            List<string> columnNames = new List<string>();
            List<string> rows = new List<string>();

            foreach (DataColumn column in dataTable.Columns)
            {
                columnNames.Add(column.ColumnName);
            }

            builder.Append(string.Join(",", columnNames.ToArray())).Append("\n");

            foreach (DataRow row in dataTable.Rows)
            {
                List<string> currentRow = new List<string>();

                foreach (DataColumn column in dataTable.Columns)
                {
                    object item = row[column];

                    currentRow.Add(item.ToString());
                }

                rows.Add(string.Join(",", currentRow.ToArray()));
            }

            builder.Append(string.Join("\n", rows.ToArray()));

            Response.Clear();
            Response.ContentType = "text/csv";
            Response.AddHeader("Content-Disposition", "attachment;filename=MyContact.csv");
            Response.Write(builder.ToString());
            Response.End();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default?searchword="+searchword.Text);
        }




        //private void fillGrid()
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultDb"].ConnectionString);
        //    SqlCommand command = new SqlCommand();
        //    command.CommandText = "SELECT Contact.Name ,PhoneNumber.Number FROM Contact, PhoneNumber where Contact.ContactId=PhoneNumber.ContactId";
        //    command.Connection = con;
        //    try
        //    {
        //        con.Open();

        //    SqlDataReader dr = command.ExecuteReader();
        //    GridView1.DataSource = dr;
        //    GridView1.DataBind();
        //}
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}






    }
}