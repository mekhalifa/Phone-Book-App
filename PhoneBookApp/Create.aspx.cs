using PhoneBookApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneBookApp
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var model = new PhoneBookModel();
          //  var id= model.Contacts.Count() + 1;
            var num = Number1.Text;
            var contact = new Contact();
         //   contact.ContactId = id;
            contact.Name = Name1.Text;
            contact.NationalId = NationalId1.Text;
            var m=  model.Contacts.Add(contact);
            model.PhoneNumbers.Add( new PhoneNumber { ContactId = m.ContactId, Number = num.ToString() ,Contact=m} );

            model.SaveChanges();

            Response.Redirect("Default.aspx");
        }
    }
}