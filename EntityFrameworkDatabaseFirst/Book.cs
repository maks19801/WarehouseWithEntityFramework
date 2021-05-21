using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkDatabaseFirst
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int IdAuthor { get; set; }
        public int? Pages { get; set; }
        public int? Price { get; set; }
        public int IdPublisher { get; set; }

        public virtual Author IdAuthorNavigation { get; set; }
        public virtual Publisher IdPublisherNavigation { get; set; }
    }
}
