namespace HrSolution.Data
{
    public interface IUnitOfWork
    {
        public void Dispose();
        public void Save();
    }
}