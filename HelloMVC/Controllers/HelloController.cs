using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet] //Tells method to respond to GET
        [Route("/Hello")]
        public IActionResult Index()
        {
            //return Content("Hello World");
            string html = "<form method='post'>" + "Name" + 
                "<input type='text', name='name' />" + 
                "<select name='language'>" +
                "<option value='en' selected>English</option>" +
                "<option value='fr'>French</option>" +
                "<option value='de'>German</option>" +
                "<option value='gj'>Gujarati</option>" +
                "<option value='it'>Italian</option>" +
                "<option value='es'>Spanish</option>" +
                "<input type='submit' value='Greet me!' />" +
                "</form>";
            
            return Content(html, "text/html");
            //return Redirect("/Hello/Goodbye");
            // return Content("<h1>Hello World</h1>"); - This will retrun literal <h1>
        }
        //Line below is route attribute
        [Route("/Hello")] //route that we want method to be mapped to for incoming requests. Also need to differentiate by display type, get or post
        [HttpPost] //Tell method to respond to POST
        public IActionResult Display (string name = "World", string language = "en")
        {
            string Message = CreateMessage(name, language);
            //Message = CreateMessage(name, language);
            return Content(Message, "text/html");
            //return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");
        }

        public static string CreateMessage(string name, string language)
        {
            if (language == "fr")
            {
                return string.Format("<h1>Bonjour {0}</h1>", name);
            }
            else if (language == "de")
            {
                return string.Format("<h1>Hallo {0}</h1>", name);
            }
            else if (language == "gj")
            {
                return string.Format("<h1>Kem Cho {0}</h1>", name);
            }
            else if (language == "it")
            {
                return string.Format("<h1>Ciao {0}</h1>", name);
            }
            else if (language =="es")
            {
                return string.Format("<h1>Hola {0}</h1>", name);
            }
            else
            {
                return string.Format("<h1>Hello {0}</h1>", name);
            }
        }

        // Handle requests to /Hello/Jigish (URL segment)
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");
        }

        // Line below is called from /Hello/Goodbye
        public IActionResult Goodbye()
        {
           return Content("Goodbye");
        }
        // alter the route to this controller to be : /Hello/Aloha
        //public IActionResult Aloha()
        //[Route("/Hello/Aloha")]
        //public IActionResult Goodbye()
        //{
        //   return Content("Goodbye");
        //}
    }
}
