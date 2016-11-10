using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Architecture.Presentation.Models
{
    public class SQLiteConnection
    {
        private SQLitePlatformWinRT sQLitePlatformWinRT;
        private string v;

        public SQLiteConnection(SQLitePlatformWinRT sQLitePlatformWinRT, string v)
        {
            this.sQLitePlatformWinRT = sQLitePlatformWinRT;
            this.v = v;
        }

        private static SQLiteConnection DbConnection
        {
            get
            {
                return new SQLiteConnection(
                    new SQLitePlatformWinRT(),
                    Path.Combine(ApplicationData.Current.LocalFolder.Path, "Architecture.sqlite"));
            }
        }

    }
}
