namespace Project.DataAccess.Abstract.Base;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
