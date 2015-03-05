use AdventureWorks2012;
go

select *
from sys.schemas
where name = 'sqlob';

select *
from sys.tables
where name = 'meta';

select *
from sys.tables t
inner join sys.schemas s
on t.schema_id = s.schema_id
where s.name = 'sqlob';

if exists (select 1 from sys.tables where object_id = object_id('sqlob.meta'))
	select *
	from sqlob.meta;


/*
drop table sqlob.Product_9c1a20aad13f4b58b25d0667486ceef9;
drop table sqlob.meta;
drop schema sqlob;
*/