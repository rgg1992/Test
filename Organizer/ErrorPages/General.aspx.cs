using Organizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Logic;

public partial class ErrorPages_General : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Create safe error messages.
        string httpErrorMsg = "An HTTP error occurred. Page Not found. Please try again.";
        string unhandledErrorMsg = "The error was unhandled by application code.";

        // Determine where error was handled.
        string errorHandler = Request.QueryString["handler"];
        if (errorHandler == null)
        {
            errorHandler = "Error Page";
        }

        // Get the last error from the server.
        Exception ex = Server.GetLastError();

        // Get the error number passed as a querystring value.
        string errorMsg = Request.QueryString["msg"];
        if (errorMsg == "404")
        {
            ex = new HttpException(404, httpErrorMsg, ex);
            //FriendlyErrorMsg.Text = ex.Message;
        }

        // If the exception no longer exists, create a generic exception.
        if (ex == null)
        {
            ex = new Exception(unhandledErrorMsg);
        }

        // Log the exception.
        ExceptionUtility.LogException(ex, errorHandler);

        // Clear the error from the server.
        Server.ClearError();
    }

    protected void lnkButtonReturn_Click(object sender, EventArgs e)
    {
        IdentityHelper.RedirectToReturnUrl("~/CarProfile.aspx", Response);
    }
}