

namespace MovilApplication.Interface
{
    public interface IDataBase
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
