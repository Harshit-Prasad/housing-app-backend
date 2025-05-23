﻿using server.Interfaces;
using server.Repository;

namespace server.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public UnitOfWork(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public ICityRepository CityRepository => new CityRepository(_dataContext);

        public async Task<bool> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
