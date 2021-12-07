using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOT.Repository
{
    public class TabellaRepository: BaseRepository
    {

        public static String GetTabella()
        {
            var lookup = Execute(
@"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AspNetRoles' ");


            return lookup.ToString();
        }
    }
}