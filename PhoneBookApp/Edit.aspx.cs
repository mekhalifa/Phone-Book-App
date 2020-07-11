using PhoneBookApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneBookApp
{
    public partial class Edit : System.Web.UI.Page
    {
        public int Id { get; set; }
        
        public List<PhoneNumber> PhoneNumbers { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string id = Request.QueryString["id"];
                    Id = int.Parse(id);

                    var model = new PhoneBookModel();
                    
                    var _contact = model.Contacts.FirstOrDefault(m => m.ContactId == Id);

                    Name1.Text = _contact.Name;
                    NationalId1.Text = _contact.NationalId;
                    PhoneNumbers = _contact.PhoneNumbers.ToList();
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
                string id = Request.QueryString["id"];
                Id = int.Parse(id);
                var model = new PhoneBookModel();
            var c =model.Contacts.FirstOrDefault(m=>m.ContactId==Id);
            c.Name = Name1.Text;
            c.NationalId = NationalId1.Text;

            model.SaveChanges();

            Response.Redirect("Default.aspx");
        }



       public List<PhoneNumber> GetPhoneNumbers()
        {
            return PhoneNumbers;
        }
    }
}