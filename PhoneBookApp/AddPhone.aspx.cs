using PhoneBookApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneBookApp
{
    public partial class AddPhone : System.Web.UI.Page
    {
        public int Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string id = Request.QueryString["id"];
                Id = int.Parse(id);
                
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var model = new PhoneBookModel();
            var contact = model.Contacts.FirstOrDefault(m=>m.ContactId==Id);
            var num = Number1.Text;
           
            model.PhoneNumbers.Add(new PhoneNumber { ContactId = Id, Number = num.ToString(), Contact = contact });

            model.SaveChanges();

            Response.Redirect("Default.aspx");
        }
    }
}