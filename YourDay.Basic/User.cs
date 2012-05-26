using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourDay.POCO;

namespace YourDay.POCO
{
    public class User
    {
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Login
        {
            get;
            set;
        }

        public string EMail
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public string AvatarSrc
        { get; set; }

        public ICollection<EventCard> EventCards
        { get; set; }

       
        public ICollection<MediaRate> MediaRates
        { get; set; }

        public ICollection<ArticleRate> ArticleRates
        { get; set; }

        public ICollection<NewsRate> NewsRates
        { get; set; }

        public bool IsDeleted
        { get; set; }

        public byte[] Password
        { get; set; }
        public Guid Salt
        { get; set; }
        public bool IsApproved
        { get; set; }

        public ICollection<FavouriteItem> FavouriteItems
        { get; set; }

        public ICollection<UserActivity> UserActivities
        { get; set; }

        public string FullName
        {
            get { return String.Format("{0} {1}", this.FirstName, this.LastName); }
        }

        public ICollection<Comment> Comments
        { get; set; }

        public ICollection<Comment> Comments1
        { get; set; }

        public ICollection<MailQueue> MailQueue
        { get; set; }

        public ICollection<Avatar> Avatars
        { get; set; }

    }
}
