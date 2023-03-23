using CuongShop.Data.Infrastructure;
using CuongShop.Data.Repositories;
using CuongShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CuongShop.Service
{
    public interface IPostService
    {
        void Add(Post Post);

        void Update(Post Post);

        void Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(string tag, int page, int pageSize, out int totalRow);

        Post GetById(int id);

        IEnumerable<Post> GetByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChange();
    }

    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post Post)
        {
            _postRepository.Add(Post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] {"PostCategory"});
        }

        public IEnumerable<Post> GetAllPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x=>x.Status, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public IEnumerable<Post> GetByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post Post)
        {
            _postRepository.Update(Post);
        }
    }
}