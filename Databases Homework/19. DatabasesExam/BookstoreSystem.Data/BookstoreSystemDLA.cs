namespace BookstoreSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BookstoreSystem.Model;

    public class BookstoreSystemDLA
    {
        public static void CreateBookComplex(
            string title,
            IList<string> authors,
            string isbn,
            string price,
            string webSite,
            IList<ReviewInfo> allReviews)
        {
            using (BookstoreSystemEntities context 
                = new BookstoreSystemEntities())
            {
                Book newBook = new Book();

                newBook.Title = title;
                foreach (var item in authors)
                {
                    newBook.Authors.Add(CreateOrLoadAuthor(context, item));
                }

                newBook.ISBN = isbn;
                newBook.Price = Convert.ToDecimal(price);
                newBook.WebSite = webSite;
                CreteReview(context, allReviews);
                

                context.Books.Add(newBook);
                context.SaveChanges();
            }

            
        }

        public static void CreateBook(
            string author,
            string title,
            string isbn,
            string price,
            string webSite)
        {
            using (BookstoreSystemEntities context
                = new BookstoreSystemEntities())
            {
                Book newBook = new Book();
                newBook.Authors.Add(CreateOrLoadAuthor(context, author));
                newBook.Title = title;
                newBook.ISBN = isbn;
                newBook.Price = Convert.ToDecimal(price);
                newBook.WebSite = webSite;
                context.Books.Add(newBook);
                context.SaveChanges();
            }
        }

        public static Author CreateOrLoadAuthor(BookstoreSystemEntities context, string authorName)
        {
            Author exsistingAuthor =
                (from auth in context.Authors
                 where auth.AuthorName.ToLower() == authorName.ToLower()
                 select auth).FirstOrDefault();

            if (exsistingAuthor != null)
            {
                return exsistingAuthor;
            }
            else
            {
                Author newAuthor = new Author
                {
                    AuthorName = authorName
                };

                context.Authors.Add(newAuthor);
                //context.SaveChanges();

                return newAuthor;
            }
        }

        public static void CreteReview(
            BookstoreSystemEntities context,
            IList<ReviewInfo> allReviews)
        {
            foreach (var review in allReviews)
            {
                Review newReview = new Review();
                newReview.ReviewText = review.Text;
                if (!string.IsNullOrWhiteSpace(review.Author))
                {
                    newReview.Author = CreateOrLoadAuthor(context, review.Author);
                }
                if (string.IsNullOrWhiteSpace(review.Date))
                {
                    newReview.DateOfCreation = DateTime.Now;
                }
                else
                {
                    newReview.DateOfCreation = DateTime.Parse(review.Date);
                }

                context.Reviews.Add(newReview);
            }
        }

        public static IList<Book> SimpleSearch(
                string title,
            string author,
            string isbn
            )
        {
            BookstoreSystemEntities context = new BookstoreSystemEntities();
            
                var searchResult = 
                    (from all in context.Books.Include("Authors")
                        select all).AsQueryable();

                if (!string.IsNullOrWhiteSpace(title))
                {
                    searchResult = searchResult.Where(x => x.Title == title);
                }

                if (!string.IsNullOrWhiteSpace(author))
                {
                    searchResult = searchResult.Where(x => x.Authors.Any(y => y.AuthorName.ToLower() == author.ToLower()));
                }

                if (!string.IsNullOrWhiteSpace(isbn))
                {
                    searchResult = searchResult.Where(x => x.ISBN == isbn);
                }

                return searchResult.ToList();
            
        }

        public static IEnumerable<Review> FindReviewsByAuthor(string authorName)
        {
            BookstoreSystemEntities context = new BookstoreSystemEntities();

            //IQueryable<Review> searchResult = context.Reviews.Where(x => x.Author.AuthorName.ToLower() == authorName.ToLower());

            IQueryable<Review> searchResult =
                from s in context.Reviews.Include("Book")
                where s.Author.AuthorName.ToLower() == authorName.ToLower()
                select s;

            return searchResult;
        }
        
        public static IEnumerable<Review> FindReviewsByDates(DateTime startDate, DateTime endDate)
        {
            BookstoreSystemEntities context = new BookstoreSystemEntities();

            //IQueryable<Review> searchResult = context.Reviews.Where(x => x.Author.AuthorName.ToLower() == authorName.ToLower());

            IQueryable<Review> searchResult =
                from s in context.Reviews.Include("Book")
                where s.DateOfCreation >= startDate && s.DateOfCreation <= endDate
                select s;

            return searchResult;
        }
    }
}
