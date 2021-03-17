using System;
using System.Linq;

namespace EFCoreBook
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                Console.WriteLine("add blog");
                db.Add(new Blog
                {
                    Url="http://blogs.msdn.com/dotnet"
                });
                db.SaveChanges();
                Console.WriteLine("search blog");
                var blog = db.Blogs.OrderBy(b => b.BlogId).First();
                Console.WriteLine("edit blog");
                blog.Url = "xxxxxxx";
                blog.Posts.Add(new Post
                {
                    Title = "hello world",
                    Content = "first code"
                }); ;
                db.SaveChanges();
                Console.WriteLine("delete blog");
                db.Remove(blog);
                db.SaveChanges();
            }
        }
    }
}
