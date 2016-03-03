using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orwell
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkGo_Click(object sender, EventArgs e)
        {
            Session["KeyID"] = txtKeyID.Text;
            Session["vCode"] = txtvCode.Text;

            Response.Redirect("~/ThingsToKnockDown.aspx");
        }
    }
}