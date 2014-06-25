using System;

namespace ClockShop.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        CardRepository CardRepository { get; }
        CardRatingRepository CardRatingRepository { get; }
        CommentRatingRepository CommentRatingRepository { get; }
        CommentRepository CommentRepository { get; }
        PhotoRepository PhotoRepository { get; }
        TagRepository TagRepository { get; }
        UserRepository UserRepository { get; }
        void Save();
    }
}