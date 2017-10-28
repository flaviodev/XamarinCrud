
using SQLite.Net.Interop;

namespace CrudAula.model
{
    public interface IConfig
    {
        string DiretorioDB { get; }

        ISQLitePlatform Plataforma { get; }
    }
}
