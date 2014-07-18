using SimpleCookBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;

namespace SimpleCookBook.Api.Models
{
    [DataContract]
    public class NoteFullViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "postAddress")]
        public string PostAddress { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "latitude")]
        public decimal Latitude { get; set; }

        [DataMember(Name = "lontitude")]
        public decimal Lontitude { get; set; }

        public static Expression<Func<Note, NoteFullViewModel>> FromNote
        {
            get
            {
                return x =>
                    new NoteFullViewModel
                    {
                        Author = x.Author,
                        Content = x.Content,
                        Id = x.Id,
                        Latitude = x.Latitude,
                        Lontitude = x.Lontitude,
                        PostAddress = x.PostAddress,
                        PostDate = x.PostDate,
                        Title = x.Title
                    };
            }
        }
    }
}