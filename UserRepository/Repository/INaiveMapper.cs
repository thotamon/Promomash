namespace Promomash.UserRepository.Repository
{
    public interface INaiveMapper
    {
        V Map<T, V>(T source)
            where T : class
            where V : class;
        void Register<T, V>(Func<object, object> func)
            where T : class
            where V : class;
    }
}
