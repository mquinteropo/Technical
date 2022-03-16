using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TECHNICAL.APP
{
    public partial class Page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var name = Request.QueryString["name"];
            var age = Request.QueryString["age"];
            var type = Request.QueryString["type"];

            lblName.Text = name;
            lblAge.Text = age;
            lblType.Text = type;
        }
    }
}