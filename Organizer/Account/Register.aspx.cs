using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using Organizer;

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = UserName.Text };
        IdentityResult result = manager.Create(user, Password.Text);
        if (result.Succeeded)
        {
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
        else
        {
            string res = result.Errors.FirstOrDefault();
            if(res.Equals("Passwords must be at least 6 characters."))
            ErrorMessage.Text = "Паролата трябва да бъде поне 6 символа";
        }
    }
}