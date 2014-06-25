using System;

namespace ClockShop.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClockShopContext _context = new ClockShopContext();
        private CardRepository _cardRepository;
        private CardRatingRepository _cardRatingRepository;
        private CommentRatingRepository _commentRatingRepository;
        private CommentRepository _commentRepository;
        private PhotoRepository _photoRepository;
        private TagRepository _tagRepository;
        private UserRepository _userRepository;
        private bool _disposed = false;

        public CardRepository CardRepository
        {
            get { return _cardRepository ?? (_cardRepository = new CardRepository(_context)); }
        }

        public CardRatingRepository CardRatingRepository
        {
            get { return _cardRatingRepository ?? (_cardRatingRepository = new CardRatingRepository(_context)); }
        }

        public CommentRatingRepository CommentRatingRepository
        {
            get { return _commentRatingRepository ?? (_commentRatingRepository = new CommentRatingRepository(_context)); }
        }

        public CommentRepository CommentRepository
        {
            get { return _commentRepository ?? (_commentRepository = new CommentRepository(_context)); }
        }

        public PhotoRepository PhotoRepository
        {
            get { return _photoRepository ?? (_photoRepository = new PhotoRepository(_context)); }
        }

        public TagRepository TagRepository
        {
            get { return _tagRepository ?? (_tagRepository = new TagRepository(_context)); }
        }

        public UserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
