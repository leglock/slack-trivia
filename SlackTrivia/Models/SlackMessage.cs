﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackTrivia.Models
{
    public class SlackMessage
    {
        public string token { get; set; }
        public string team_id { get; set; }
        public string team_domain { get; set; }
        public string channel_id { get; set; }
        public string channel_name { get; set; }
        public string timestamp { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string text { get; set; }
        public string trigger_word { get; set; }
    }
}