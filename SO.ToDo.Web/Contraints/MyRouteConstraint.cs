namespace SO.ToDo.Web.Contraints
{
    public class MyRouteConstraint : IRouteConstraint
    {
        public List<string?> MyList = new List<string?> { "charp", "java", "python", "php" };
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return MyList.Contains(values[routeKey]?.ToString()?.ToLower());
        }
    }
}
