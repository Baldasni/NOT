Sqlcmd -S .\SQLEXPRESS -E -i dbo.TipologieContatto.sql
Sqlcmd -S .\SQLEXPRESS -E -i dbo.TipologiePratica.sql
Sqlcmd -S .\SQLEXPRESS -E -i dbo.StatiPratica.sql
Sqlcmd -S .\SQLEXPRESS -E -i dbo.Sportelli.sql
Sqlcmd -S .\SQLEXPRESS -E -i dbo.Province.sql
Sqlcmd -S .\SQLEXPRESS -E -i dbo.Comuni.sql
Sqlcmd -S .\SQLEXPRESS -E -i dbo.Soci.sql
Sqlcmd -S .\SQLEXPRESS -E -i dbo.Rinnovi.sql
Sqlcmd -S .\SQLEXPRESS -E -i dbo.Pratiche.sql
Sqlcmd -S .\SQLEXPRESS -E -i dbo.Consulenze.sql
Sqlcmd -S .\SQLEXPRESS -E -i Insert.dbo.Province.sql -o Output.Insert.dbo.Province.txt
Sqlcmd -S .\SQLEXPRESS -E -i Insert.dbo.Comuni.sql -o Output.Insert.dbo.Comuni.txt
pause