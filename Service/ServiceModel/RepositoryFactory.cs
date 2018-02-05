using EF6;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel
{
    public static class RepositoryFactory
    {
        public static IRepository<T> Create<T>() where T : BaseModel
        {
            return new NSEF6_Repository<T>();
        }
    }
}
