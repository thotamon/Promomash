namespace Promomash.UserRepository.Repository
{
    public class NaiveMapper : INaiveMapper
    {
        private readonly Dictionary<(Type, Type), Func<object, object>> _mapFunctions = new();

        public void Register<T, V>(Func<object, object> func) where T : class
                                                              where V : class
        {
            _mapFunctions[(typeof(T), typeof(V))] = func;
        }

        public V Map<T, V>(T source) where T : class
                                     where V : class
        {
            var key = (typeof(T), typeof(V));
            if (!_mapFunctions.ContainsKey(key))
            {
                throw new ArgumentException();
            }

            return (V)_mapFunctions[key](source);
        }
    }
}
