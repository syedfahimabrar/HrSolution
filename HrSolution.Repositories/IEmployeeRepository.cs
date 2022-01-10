using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HrSolution.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace HrSolution.Repositories
{
    public interface IEmployeeRepository
    {
        void Add(Employee entity);
        void Remove(Int32 id);
        void Remove(Employee entityToDelete);
        void Remove(Expression<Func<Employee, bool>> filter);
        void Edit(Employee entityToUpdate);
        int GetCount(Expression<Func<Employee, bool>> filter = null);
        IList<Employee> Get(Expression<Func<Employee, bool>> filter);
        IList<Employee> GetAll();
        Employee GetById(Int32 id);

        (IList<Employee> data, int total, int totalDisplay) Get(
            Expression<Func<Employee, bool>> filter = null,
            Func<IQueryable<Employee>, IOrderedQueryable<Employee>> orderBy = null,
            Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        (IList<Employee> data, int total, int totalDisplay) GetDynamic(
            Expression<Func<Employee, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        IList<Employee> Get(Expression<Func<Employee, bool>> filter = null,
            Func<IQueryable<Employee>, IOrderedQueryable<Employee>> orderBy = null,
            Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>> include = null, bool isTrackingOff = false);

        IList<Employee> GetDynamic(Expression<Func<Employee, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>> include = null
            , bool isTrackingOff = false);
    }
}