using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HrSolution.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace HrSolution.Repositories
{
    public interface ILeaveApplicationRepository
    {
        void Add(LeaveApplication entity);
        void Remove(Int32 id);
        void Remove(LeaveApplication entityToDelete);
        void Remove(Expression<Func<LeaveApplication, bool>> filter);
        void Edit(LeaveApplication entityToUpdate);
        int GetCount(Expression<Func<LeaveApplication, bool>> filter = null);
        IList<LeaveApplication> Get(Expression<Func<LeaveApplication, bool>> filter);
        IList<LeaveApplication> GetAll();
        LeaveApplication GetById(Int32 id);

        (IList<LeaveApplication> data, int total, int totalDisplay) Get(
            Expression<Func<LeaveApplication, bool>> filter = null,
            Func<IQueryable<LeaveApplication>, IOrderedQueryable<LeaveApplication>> orderBy = null,
            Func<IQueryable<LeaveApplication>, IIncludableQueryable<LeaveApplication, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        (IList<LeaveApplication> data, int total, int totalDisplay) GetDynamic(
            Expression<Func<LeaveApplication, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<LeaveApplication>, IIncludableQueryable<LeaveApplication, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        IList<LeaveApplication> Get(Expression<Func<LeaveApplication, bool>> filter = null,
            Func<IQueryable<LeaveApplication>, IOrderedQueryable<LeaveApplication>> orderBy = null,
            Func<IQueryable<LeaveApplication>, IIncludableQueryable<LeaveApplication, object>> include = null, bool isTrackingOff = false);

        IList<LeaveApplication> GetDynamic(Expression<Func<LeaveApplication, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<LeaveApplication>, IIncludableQueryable<LeaveApplication, object>> include = null
            , bool isTrackingOff = false);
    }
}