using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.BusinessModels;
using msac_competition.BLL.Interfaces;
using msac_competition.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace msac_competition.BLL.Services
{
    public class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        //protected readonly IRepository<TEntity, TKey> _repository;

        //public BaseService(IRepository<TEntity, TKey> genericRepository)
        //{
        //    _repository = genericRepository;
        //}

        public async Task<string> SaveAvatarAsync(IFormFile file, string surname, string imageFolder)
        {
            try
            {
                if (file != null && file.Length != 0)
                {
                    var extenstion = Path.GetExtension(file.FileName);
                    var latSurname = Transliterate.Translit(surname);
                    var fileNewName = string.Format($"{latSurname}{extenstion}");
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

        public void RemoveAvatar(string fileName, string imageFolder)
        {
            try
            {
                if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(imageFolder))
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

        public virtual void Dispose()
        {
        }

        //public virtual async Task CommitAsync(bool shouldBeCommited = false)
        //{
        //    if (shouldBeCommited)
        //    {
        //        await _repository.CommitAsync();
        //    }
        //}

        //public void Dispose()
        //{
        //    _repository.Dispose();
        //}


        //public async Task Create(TEntityDto newItem, bool shouldBeCommited = false)
        //{
        //    if (newItem == null)
        //    {
        //        throw new ArgumentNullException();
        //    }
        //    await _repository.Create(newItem);
        //    await CommitAsync(shouldBeCommited);
        //}

        //public async Task Remove(TKey id, bool shouldBeCommited = false)
        //{
        //    if (id == null)
        //    {
        //        throw new ArgumentNullException();
        //    }
        //    await _repository.Delete(id);
        //    await CommitAsync(shouldBeCommited);
        //}

        //public async Task Update(TEntityDto itemDto, bool shouldBeCommited = false)
        //{
        //    //if (itemDto == null)
        //    //{
        //    //    throw new ArgumentNullException();
        //    //}
        //    //var item = Mapper.Map<TEntity>(itemDto);
        //    //await _repository.Update(item);
        //    await CommitAsync(shouldBeCommited);
        //}


    }
}
