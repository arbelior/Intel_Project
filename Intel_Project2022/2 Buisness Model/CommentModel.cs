using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
   public  class CommentModel
    {
        public int Id { get; set; }

        public string? name { get; set; }

        public string? WWId { get; set; }

        public string? Subject { get; set; }

        public string? Comment { get; set; }

        public CommentModel() { }

        public CommentModel(Comments comment)
        {
            Id      = comment.Id;
            name    = comment.Name;
            WWId    = comment.WWid;
            Subject = comment.Subject;
            Comment = comment.Comment;
        }

        public Comments ConvertToCommentModel()
        {
            Comments New_Comment = new Comments
            {
                Id = Id,
                Name = name,
                WWid = WWId,
                Subject = Subject,
                Comment = Comment
            };

            return New_Comment;
        }
    }

    
}
