using System;
using InfastructureLib.Base;
using InfastructureLib.Data.Entities;
using InfastructureLib.Data.Repositories;
using Repository.Data;
using Repository.Factory;
using Repository.Helpers;
namespace InfastructureLib.Factory{
    internal class SqlSRepositoryFactory: IRepositoryFactory{
        public IDataRepository<T> Construct<T>(params object[] args) where T : IDataUnit{
            if (Polymorphism.IsInHierachy(typeof(T), typeof(Page))){
                //In the hierarchy tree of page type, a repository of it is built.
                return (IDataRepository<T>)Activator.CreateInstance(
                    typeof(SqlSPageRepository), args);
            }
            return null;
        }
    }
}
