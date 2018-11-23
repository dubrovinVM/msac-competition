using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.DAL.Entities;

namespace msac_competition.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void CreateUserProfile(User item);
        void DeleteUserProfile(string id);
    }
}
