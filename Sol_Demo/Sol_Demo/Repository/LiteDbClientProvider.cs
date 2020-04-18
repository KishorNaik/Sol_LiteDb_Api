using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Repository
{
    public interface ILiteDbClientProvider
    {
        ILiteDatabase GetLitDbConnection { get; }
    }

    public class LiteDbClientProvider : ILiteDbClientProvider
    {
        private readonly ILiteDatabase liteDatabase = null;

        public LiteDbClientProvider(string connectionString)
        {
            liteDatabase = new LiteDatabase(connectionString);
        }

        ILiteDatabase ILiteDbClientProvider.GetLitDbConnection => liteDatabase;
    }
}
