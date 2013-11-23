using Repository.Factory;
namespace InfastructureLib.Factory{
    internal sealed class RepositoryFactory : SqlSRepositoryFactory, IRepositoryFactory{
        private static volatile RepositoryFactory _instance;

        private static object _lock = new object();

        private RepositoryFactory() { }

        internal static RepositoryFactory Instance{
            get{
                if (_instance == null){
                    lock (_lock){
                        if (_instance == null){
                            _instance = new RepositoryFactory();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
