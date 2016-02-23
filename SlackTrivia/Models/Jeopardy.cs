using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackTrivia.Models
{
    public class Jeopardy
    {
        public class Clue
        {
            public DateTime airdate { get; set; }
            public string answer { get; set; }
            public Category category { get; set; }
            public int? category_id { get; set; }
            public DateTime created_at { get; set; }
            public int? game_id { get; set; }
            public int? id { get; set; }
            public int? invalid_count { get; set; }
            public string question { get; set; }
            public DateTime updated_at { get; set; }
            public int? value { get; set; }
        }

        public class Category
        {
            public int? clues_count { get; set; }
            public DateTime created_at { get; set; }
            public int? id { get; set; }
            public string title { get; set; }
            public DateTime updated_at { get; set; }
        }
    }
}