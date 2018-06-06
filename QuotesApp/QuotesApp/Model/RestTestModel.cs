using System;
using System.Collections.Generic;
using System.Text;

namespace QuotesApp.Model
{
    class RestTestModel
    {
        public long UserId { get; }
        public long Id { get; }
        public string Title { get; }
        public string Body { get; }

        public RestTestModel(long userId, long id, string title, string body)
        {
            UserId = userId;
            Id = id;
            Title = title;
            Body = body;
        }
    }
}
