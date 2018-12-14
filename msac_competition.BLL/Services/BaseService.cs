using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using msac_competition.BLL.BusinessModels;
using msac_competition.BLL.Interfaces;
using msac_competition.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace msac_competition.BLL.Services
{
    public class BaseService<TEntity, TPrimaryId> : IBaseService<TEntity, TPrimaryId> where TEntity : class, IEntity<TPrimaryId>
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual void Commit(bool shouldBeCommited = false)
        {
            if (shouldBeCommited)
            {
                UnitOfWork.Commit();
            }
        }

        public virtual async Task CommitAsync(bool shouldBeCommited = false)
        {
            if (shouldBeCommited)
            {
                await UnitOfWork.CommitAsync();
            }
        }

        public virtual TEntity Create(TEntity newItem, bool shouldBeCommited = false)
        {
            if (newItem == null)
            {
                throw new ArgumentNullException();
            }
            UnitOfWork.Add(newItem);
            Commit(shouldBeCommited);
            return newItem;
        }

        public virtual async Task<TEntity> GetAsync(TPrimaryId id)
        {
            return await GetAll().FirstOrDefaultAsync(m => (object) m.Id == (object) id);
        }

        public virtual TEntity Get(TPrimaryId id)
        {
            return GetAll().FirstOrDefault(m => (object) m.Id == (object) id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return GetList<TEntity>();
        }

        protected virtual IQueryable<T> GetList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var list = GetList<T>();
            if (predicate != null)
            {
                return list.Where(predicate);
            }
            return list;
        }

        protected virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TKey>> orderBy) where T : class
        {
            return GetList(predicate).OrderBy(orderBy);
        }

        protected virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, TKey>> orderBy) where T : class
        {
            return GetList<T>().OrderBy(orderBy);
        }

        protected virtual IQueryable<T> GetList<T>() where T : class
        {
            return UnitOfWork.Get<T>();
        }

        public virtual void Remove(TEntity removeItem, bool shouldBeCommited = false)
        {
            if (removeItem == null)
            {
                throw new ArgumentNullException();
            }
            UnitOfWork.Remove(removeItem);
            Commit(shouldBeCommited);
        }

        public virtual void Update(TEntity item, bool shouldBeCommited = false)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveAavatarAsync(IFormFile file, string surname, string imageFolder)
        {
            try
            {
                if (file != null && file.Length != 0)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var latSurname = Transliterate.Translit(surname);
                    var fileNewName = string.Format($"{latSurname}{extention}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", $"{imageFolder}", fileNewName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    return fileNewName;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void RemoveAavatar(string fileName, string imageFolder)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName) && string.IsNullOrEmpty(imageFolder))
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", $"{imageFolder}", fileName);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

    }
}
