using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text.RegularExpressions;
using System.Web.Http;
using Newtonsoft.Json;
using SlackTrivia.Models;
using System.Configuration;

namespace SlackTrivia.Controllers
{
    public class TriviaController : ApiController
    {
        static private string slack_token = ConfigurationManager.AppSettings["SlackToken"];
        static HttpClient client = new HttpClient();
        private static Jeopardy.Clue game;

        public IHttpActionResult Beacon(SlackMessage message)
        {
            if (message.token != slack_token)
                return Unauthorized();

            string keyword = ParseKeyword(message.text);

            if (keyword == "clue")
            {
                game = GetClue();
                var text = new 
                {
                    text = String.Format("*{0}* - *${1}* - {2}", game.category.title, game.value, game.question)
                };

                return Content(HttpStatusCode.OK, text);
            }

            if (keyword == "answer")
            {
                var text = new 
                {
                    text = String.Format("The answer I was looking for was *{0}*.", game.answer)
                };

                game = null;

                return Content(HttpStatusCode.OK, text);
            }


            return Ok();
        }

        public Jeopardy.Clue GetClue()
        {
            List<Jeopardy.Clue> model;

            var task = client.GetAsync("http://jservice.io/api/random/").Result;
            var response = task.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<List<Jeopardy.Clue>>(response.Result);

            return model.First();
        }

        public string ParseKeyword(string message)
        {
            string keyword = null;

            try {
	            keyword = Regex.Match(message, "(?>!trivia )([a-z0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline).Groups[1].Value;
            } catch (ArgumentException ex) {
	            // Syntax error in the regular expression
            }

            return keyword;
        } 
    }
}
