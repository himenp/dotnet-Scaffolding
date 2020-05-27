using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace dotnetfundaScaffolding.Models
{
    public class Utilities
    {
        public static string ConvertCollectionToString(ICollection<Tag> tags)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var tag in tags)
            {
                builder.Append(tag.Tags);
                builder.Append(',');
            }
            return builder.ToString();
        }
        public static List<Tag> ConvertToCollection(PostModel model)
        {
            IRepository<Tag> tagrepository = new Repository<Tag>();
            List<Tag> tag = new List<Tag>();
            string[] temptag = model.Tags.Split(',');
            foreach (string tg in temptag)
            {
                var taG = new Tag
                {
                    Tags = tg
                };
                tag.Add(taG);
            }
            return tag;
        }
    }
}