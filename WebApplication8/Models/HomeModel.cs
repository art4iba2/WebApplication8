using System.Web.Mvc;
using System.Web.Routing;

public class MyController : IController
{
    public void Execute(RequestContext requestContext)
    {
        string actionName = requestContext.RouteData.Values["action"].ToString();
        int id = int.Parse(requestContext.RouteData.Values["id"].ToString());

        if (actionName == "start" && id == 0)
        {
            // Выполнение перехода на метод Index() контроллера HomeController
            var controller = DependencyResolver.Current.GetService(typeof(HomeController)) as HomeController;
            controller.Index();
        }
        else
        {
            // Вывод сообщения об ошибке и URL запроса
            requestContext.HttpContext.Response.Write("Error: Invalid action or id value.<br>");
            requestContext.HttpContext.Response.Write("Requested URL: " + requestContext.HttpContext.Request.Url.ToString());
        }
    }

  
}
