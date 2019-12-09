using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Student.Current.username == null && University.Current.username != null)
                HyperLink1.NavigateUrl = "UniProfile.aspx";
            else if (University.Current.username == null && Student.Current.username != null)
                HyperLink1.NavigateUrl = "StuProfile.aspx";
            else if (University.Current.username == null && Student.Current.username == null)
                HyperLink1.NavigateUrl = "#";
        }
    }
}