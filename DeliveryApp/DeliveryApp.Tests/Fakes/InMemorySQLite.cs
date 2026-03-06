using DeliveryApp.Models;
using SQLite;
using System;
using System.IO;

namespace DeliveryApp.Tests.Fakes
{
    /// <summary>
    /// File-based SQLite fake for unit tests.
    /// Each call to GetConnection() returns a new connection to the same temp file,
    /// so the service can freely open/close connections without losing data.
    /// The temp file is deleted when Dispose() is called.
    /// </summary>
    public class InMemorySQLite : ISQLite, IDisposable
    {
        private readonly string _dbPath;

        public InMemorySQLite()
        {
            _dbPath = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid():N}.db");
            using var cn = new SQLiteConnection(_dbPath);
            cn.CreateTable<CartItem>();
        }

        public SQLiteConnection GetConnection() => new SQLiteConnection(_dbPath);

        public void Dispose()
        {
            if (File.Exists(_dbPath))
                File.Delete(_dbPath);
        }
    }
}
