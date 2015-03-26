using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JustBlog.Core;
using JustBlog.Core.Objects;

namespace JustBlog.Models
{
    public class ListViewModel
    {
        public ListViewModel(IBlogRepository _blogRepository, int p)
        {
            Posts = _blogRepository.Posts(p - 1, 10);
            TotalPosts = _blogRepository.TotalPosts();
        }

        public IList<Post> Posts { get; private set; }
        public int TotalPosts { get; private set; }

        //public ListViewModel(IBlogRepository blogRepository, string categorySlug, int p)
        //{
        //    Posts = blogRepository.PostsForCategory(categorySlug, p - 1, 10);
        //    TotalPosts = blogRepository.TotalPostsForCategory(categorySlug);
        //    Category = blogRepository.Category(categorySlug);
        //}

        public Category Category { get; private set; }

        public ListViewModel(IBlogRepository blogRepository, string text, string type, int p)
        {            
            switch (type)
            {
                case "Category":
                    Posts = blogRepository.PostsForCategory(text, p - 1, 10);
                    TotalPosts = blogRepository.TotalPostsForCategory(text);
                    Category = blogRepository.Category(text);
                    break;
                case "Tag":
                    Posts = blogRepository.PostsForTag(text, p - 1, 10);
                    TotalPosts = blogRepository.TotalPostsForTag(text);
                    Tag = blogRepository.Tag(text);
                    break;
                default:
                    Posts = blogRepository.PostsForSearch(text, p - 1, 10);
                    TotalPosts = blogRepository.TotalPostsForSearch(text);
                    Search = text;
                    break;
            }

        }

        public Tag Tag { get; private set; }

        public string Search { get; private set; }
                
    }
}