using DomainModel;
using EF6;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Infrastructure
{
    public static class RepositoryFactory
    {
        public static Repository<T> Create<T>() where T : BaseModel
        {
            return new NSEF6_Repository<T>();
        }        
    }
}
