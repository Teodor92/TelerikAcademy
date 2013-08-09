namespace BookmarkSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BookmarkSystem.Model;
    using System.Text.RegularExpressions;

    public class BookmarkSystemDLA
    {
        public static void AddBookmarks(
            string username,
            string title,
            string url,
            string notes,
            IList<string> tags)
        {

            BookmarkSystemEntities context = new BookmarkSystemEntities();
            Bookmark newBookmark = new Bookmark
            {
                Title = title,
                Url = url,
                Notes = notes,
                User = CreateOrLoadUser(context, username)
            };

            foreach (var tagName in tags)
			{
				Tag tag = CreateOrLoadTag(context, tagName);
				newBookmark.Tags.Add(tag);
			}
			string[] titleTags = Regex.Split(title, @"[,'!\. ;?-]+");
			foreach (var titleTagName in titleTags)
			{
				Tag titleTag = CreateOrLoadTag(context, titleTagName);
				newBookmark.Tags.Add(titleTag);
			}
			context.Bookmarks.Add(newBookmark);
			context.SaveChanges();
        }

        public static User CreateOrLoadUser(
            BookmarkSystemEntities context,
            string username)
        {
            User existingUser =
                (from user in context.Users
                 where user.Username.ToLower() == username.ToLower()
                 select user).FirstOrDefault();

            if (existingUser != null)
            {
                return existingUser;
            }
            else
            {
                User newUser = new User
                {
                    Username = username
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                return newUser;
            }
        }

        public static Tag CreateOrLoadTag(BookmarkSystemEntities context, string tagTitle)
        {
            Tag existingTag =
                (from tag in context.Tags
                 where tag.Title.ToLower() == tagTitle.ToLower()
                 select tag).FirstOrDefault();

            if (existingTag != null)
            {
                return existingTag;
            }
            else
            {
                Tag newTag = new Tag
                {
                    Title = tagTitle
                };

                context.Tags.Add(newTag);
                context.SaveChanges();
                return newTag;
            }
        }
    }
}
