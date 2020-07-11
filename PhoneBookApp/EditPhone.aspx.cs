using PhoneBookApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhoneBookApp
{
    public partial class EditPhone : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["PhoneId"]))
                {
                    string id = Request.QueryString["PhoneId"];
                    var Id = int.Parse(id);

                    var model = new PhoneBookModel();
                    var _phoneNumber = model.PhoneNumbers.FirstOrDefault(m => m.PhoneNumberID == Id);
                    Number1.Text = _phoneNumber.Number;

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["PhoneId"]))
            {
                string id = Request.QueryString["PhoneId"];
                var Id = int.Parse(id);

                var model = new PhoneBookModel();
                var _phoneNumber = model.PhoneNumbers.FirstOrDefault(m => m.PhoneNumberID == Id);
                _phoneNumber.Number = Number1.Text;

                model.SaveChanges();

                Response.Redirect("~/edit?id=" + _phoneNumber.ContactId);
            }
            
        }
    }
}