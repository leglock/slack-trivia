using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using SlackTrivia.Models;

namespace SlackTrivia.Controllers
{
    public class TriviaController : ApiController
    {
        static private string slack_token = "gzjGlKQMiZ7jDjeUUKhycJ5f";

        public IHttpActionResult Beacon(SlackMessage message)
        {
            if (message.token != slack_token)
                return Unauthorized();

            return Content(HttpStatusCode.OK, new {text = message.user_name + "'s request processed at " + DateTime.Now});
        }
    }
}
