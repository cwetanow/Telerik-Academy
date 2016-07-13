using Dealership.Common;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string author;
        private string content;

        public Comment(string content)
        {
            this.Content = content;
        }
        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                Validator.ValidateNull(value, Constants.UserCannotBeNull);
                this.author = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                Validator.ValidateNull(value, Constants.CommentCannotBeNull);
                Validator.ValidateIntRange(value.Length, Constants.MinCommentLength, Constants.MaxCommentLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Content", Constants.MinCommentLength, Constants.MaxCommentLength));
                this.content = value;
            }
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("  ----------");
            builder.AppendLine("    "+this.Content);
            builder.AppendLine(string.Format("      User: {0}",this.Author));
            builder.Append("    ----------");
            return builder.ToString();
        }
    }
}
