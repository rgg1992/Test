﻿using Organizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorPages_404 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lnkButtonReturn_Click(object sender, EventArgs e)
    {
        IdentityHelper.RedirectToReturnUrl("~/CarProfile.aspx", Response);
    }
}