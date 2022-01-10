using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HrSolution.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace HrSolution.Repositories
{
    public interface INotificationQueueRepository
    {
        void Add(NotificationQueue entity);
        void Remove(Int32 id);
        void Remove(NotificationQueue entityToDelete);
        void Remove(Expression<Func<NotificationQueue, bool>> filter);
        void Edit(NotificationQueue entityToUpdate);
        int GetCount(Expression<Func<NotificationQueue, bool>> filter = null);
        IList<NotificationQueue> Get(Expression<Func<NotificationQueue, bool>> filter);
        IList<NotificationQueue> GetAll();
        NotificationQueue GetById(Int32 id);

        (IList<NotificationQueue> data, int total, int totalDisplay) Get(
            Expression<Func<NotificationQueue, bool>> filter = null,
            Func<IQueryable<NotificationQueue>, IOrderedQueryable<NotificationQueue>> orderBy = null,
            Func<IQueryable<NotificationQueue>, IIncludableQueryable<NotificationQueue, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        (IList<NotificationQueue> data, int total, int totalDisplay) GetDynamic(
            Expression<Func<NotificationQueue, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<NotificationQueue>, IIncludableQueryable<NotificationQueue, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        IList<NotificationQueue> Get(Expression<Func<NotificationQueue, bool>> filter = null,
            Func<IQueryable<NotificationQueue>, IOrderedQueryable<NotificationQueue>> orderBy = null,
            Func<IQueryable<NotificationQueue>, IIncludableQueryable<NotificationQueue, object>> include = null, bool isTrackingOff = false);

        IList<NotificationQueue> GetDynamic(Expression<Func<NotificationQueue, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<NotificationQueue>, IIncludableQueryable<NotificationQueue, object>> include = null
            , bool isTrackingOff = false);
    }
}