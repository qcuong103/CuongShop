using CuongShop.Data.Infrastructure;
using CuongShop.Data.Repositories;
using CuongShop.Model.Models;
using System.Collections.Generic;

namespace CuongShop.Service
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postCategory);
        void Update(PostCategory postCategory);
        //void Delete(PostCategory postCategory);
        void Delete(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParentId(int parentTd);
        PostCategory GetById(int Id);
    }
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        void IPostCategoryService.Add(PostCategory postCategory)
        {
            _postCategoryRepository.Add(postCategory);
        }

        void IPostCategoryService.Delete(int id)
        {
            _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentTd)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentTd);
        }

        public PostCategory GetById(int Id)
        {
            return _postCategoryRepository.GetSingleById(Id);
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }
    }
}
