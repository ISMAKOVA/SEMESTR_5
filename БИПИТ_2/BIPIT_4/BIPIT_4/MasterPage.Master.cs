using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPIT_4
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_1(object sender, System.EventArgs e)
        {
            Server.Transfer("Table.aspx", true);
        }
        protected void Btn_2(object sender, System.EventArgs e)
        {
            Server.Transfer("AddPage.aspx", true);
        }

    }
}