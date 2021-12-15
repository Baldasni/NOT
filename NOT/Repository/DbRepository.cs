using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOT.Repository
{
    public class DbRepository: BaseRepository
    {

        public static String GetTabelle()
        {
            var lookup = Execute(GetSqlFromFile("EstraiTutteLeTabelle.sql"));
//@"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AspNetRoles' ") ;


            return lookup.ToString();
        }
    }
}