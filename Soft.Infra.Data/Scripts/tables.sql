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

create default defZero as 0
go

create default defNada as ''
go
--exec sp_bindefault 'defZero', 'Produtos.Pro_pvenda'

--
-- Produtos
--
create table Produtos (
	Pro_id				bigint				not null		identity(1, 1)
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
       (Pro_codigo) with fillfactor = 90
go
create unique index [Pro_descricaoUnique] ON Produtos
	   (Pro_descricao) with fillfactor = 90
go

--
-- Clientes
--
create table Clientes (
	Cli_id				bigint			identity(1, 1)	not null		
	,Cli_nome			varchar(100)	default('')		not null

	,CreateUser			varchar(50)		default('')		not null
	,UpdateUser			varchar(50)		default('')		not null
	,CreateAt			datetime
	,UpdateAt			datetime
	,Uniq				timestamp

	constraint [PK_Clientes] primary key (Cli_id)
)
go

create unique index [Cli_nomeUnique] on Clientes
       (Cli_nome) with fillfactor = 90
go

--
-- Pedidos
--
create table Pedidos (
	Ped_id							bigint			identity(1, 1)	not null
	,Cli_id							bigint			default(0)		not null
	,Ped_totgeralsdesc				decimal(10, 2)	default(0)		not null
	,Ped_totgeralcdesc				decimal(10, 2)	default(0)		not null
	,Ped_totgeralsdesc_prod			decimal(10, 2)	default(0)		not null
	,Ped_totgeralcdesc_prod			decimal(10, 2)	default(0)		not null
	,Ped_totgeralsdesc_serv			decimal(10, 2)	default(0)		not null
	,Ped_totgeralcdesc_serv			decimal(10, 2)	default(0)		not null
	,Ped_desc_acresc_prod			decimal(10, 2)	default(0)		not null
	,Ped_desc_acres_tipo_prod		smallint		default(0)		not null
	,Ped_desc_acresc_serv			decimal(10, 2)	default(0)		not null
	,Ped_desc_acres_tipo_serv		smallint		default(0)		not null

	,CreateUser						varchar(50)		default('')		not null
	,UpdateUser						varchar(50)		default('')		not null
	,CreateAt						datetime
	,UpdateAt						datetime
	,Uniq							timestamp

	constraint [PK_Pedidos] primary key (Ped_id)
	,constraint [FK_Pedidos_Clientes] foreign key ([Cli_id]) references Clientes([Cli_id])
	on delete cascade
)
go

--
-- Oritens
--
create table Peitens (
	Pei_id				bigint			identity(1, 1)	not null
	,Ped_id				bigint			default(0)		not null
	,Pro_id				bigint			default(0)		not null
	,Pei_vlunitario		decimal(10, 3)	default(0)		not null
	,Pei_quantidade		decimal(10, 3)	default(0)		not null

	,CreateUser			varchar(50)		default('')		not null
	,UpdateUser			varchar(50)		default('')		not null
	,CreateAt			datetime
	,UpdateAt			datetime
	,Uniq				timestamp

	constraint [PK_Peitens] primary key (Pei_id)
	,constraint [FK_Peitens_Pedidos] foreign key (Ped_id) references Pedidos(Ped_id)
		on delete cascade
	,constraint [FK_Peitens_Produtos] foreign key ([Pro_id]) references Produtos([Pro_id])
)
go