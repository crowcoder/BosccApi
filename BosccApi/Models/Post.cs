using System;

namespace BosccApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int? PostTypeId { get; set; }
        public DateTimeOffset? CreationDate { get; set; }
        public int? Score { get; set; }
        public int? ViewCount { get; set; }
        public string Title { get; set; }
        public string  Body { get; set; }
        public DateTimeOffset? LastActivityDate { get; set; }
        public int? OwnerUserId { get; set; }
        public int? LastEditorUserId { get; set; }
        public string LastEditDate { get; set; }
        public int? CommentCount { get; set; }
        public string Tags { get; set; }
        public int? AnswerCount { get; set; }
        public int? FavoriteCount { get; set; }
    }
}
