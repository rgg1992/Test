<%@ Application Language="C#" %>
<%@ Import Namespace="Organizer" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    void Application_Error(object sender, EventArgs e)
{
    Exception exc = Server.GetLastError();

    if (exc is HttpUnhandledException)
    {
        // Pass the error on to the error page.
        Server.Transfer("ErrorPages/General.aspx?handler=Application_Error%20-%20Global.asax", true);
    }
}

</script>
