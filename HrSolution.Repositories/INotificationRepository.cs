using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HrSolution.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace HrSolution.Repositories
{
    public interface INotificationRepository
    {
        void Add(Notification entity);
        void Remove(Int32 id);
        void Remove(Notification entityToDelete);
        void Remove(Expression<Func<Notification, bool>> filter);
        void Edit(Notification entityToUpdate);
        int GetCount(Expression<Func<Notification, bool>> filter = null);
        IList<Notification> Get(Expression<Func<Notification, bool>> filter);
        IList<Notification> GetAll();
        Notification GetById(Int32 id);

        (IList<Notification> data, int total, int totalDisplay) Get(
            Expression<Func<Notification, bool>> filter = null,
            Func<IQueryable<Notification>, IOrderedQueryable<Notification>> orderBy = null,
            Func<IQueryable<Notification>, IIncludableQueryable<Notification, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        (IList<Notification> data, int total, int totalDisplay) GetDynamic(
            Expression<Func<Notification, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<Notification>, IIncludableQueryable<Notification, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        IList<Notification> Get(Expression<Func<Notification, bool>> filter = null,
            Func<IQueryable<Notification>, IOrderedQueryable<Notification>> orderBy = null,
            Func<IQueryable<Notification>, IIncludableQueryable<Notification, object>> include = null, bool isTrackingOff = false);

        IList<Notification> GetDynamic(Expression<Func<Notification, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<Notification>, IIncludableQueryable<Notification, object>> include = null
            , bool isTrackingOff = false);
    }
}