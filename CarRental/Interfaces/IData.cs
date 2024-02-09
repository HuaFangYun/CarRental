namespace CarRental.Interfaces;

public interface IData
{
    IEnumerable<T> Get<T>() where T : class;
    T Single<T>(Func<T, bool> predicate) where T : class;
    void Add<T>(T entity) where T : class;
}
