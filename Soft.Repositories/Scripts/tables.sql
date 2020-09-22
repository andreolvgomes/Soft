/*
use master
go
drop database soft
go
*/
create database soft
go
use soft
go

create table Produtos (
	Pro_id				int				not null		identity(1, 1)
	,Pro_codigo			varchar(20)		default('')		not null
	,Pro_descricao		varchar(100)	default('')		not null
	,Pro_pvenda			decimal(10, 2)	default(0)		not null

	,CreateUser			varchar(50)		default('')		not null
	,UpdateUser			varchar(50)		default('')		not null
	,CreateAt			datetime
	,UpdateAt			datetime
	,Uniq				timestamp

	constraint [PK_Produtos] primary key (Pro_id)
)
go

create unique index [Pro_codigoUnique] ON Produtos
       (Pro_codigo) WITH FILLFACTOR = 90
go
create unique index [Pro_descricaoUnique] ON Produtos
       (Pro_descricao) WITH FILLFACTOR = 90
go
