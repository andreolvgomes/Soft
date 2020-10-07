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
-- Vendedores
--
create table Vendedores (
	Ven_id				bigint				not null		identity(1, 1)
	,Ven_nome			varchar(20)		default('')		not null
	,Ven_inativo		bit				default(0)		not null
	,CreateUser			varchar(50)		default('')		not null
	,UpdateUser			varchar(50)		default('')		not null
	,CreateAt			datetime
	,UpdateAt			datetime
	,Uniq				timestamp

	constraint [PK_Vendedores] primary key (Ven_id)
)
go
create unique index [Ven_nomeUnique] ON Vendedores
       (Ven_nome) with fillfactor = 90
go

--
-- Categorias
--
create table Categorias (
	Cat_id				bigint			identity(1, 1)	not null
	,Cat_descricao		bigint			default(0)		not null
	,Cat_inativo		bit				default(0)		not null

	,CreateUser			varchar(50)		default('')		not null
	,UpdateUser			varchar(50)		default('')		not null
	,CreateAt			datetime
	,UpdateAt			datetime
	,Uniq				timestamp

	constraint [PK_Grupos] primary key (Cat_id)
)
go
--
-- Subcategorias
--
create table Subcategorias (
	Sub_id				bigint			identity(1, 1)	not null
	,Sub_descricao		bigint			default(0)		not null
	,Sub_inativo		bit				default(0)		not null

	,CreateUser			varchar(50)		default('')		not null
	,UpdateUser			varchar(50)		default('')		not null
	,CreateAt			datetime
	,UpdateAt			datetime
	,Uniq				timestamp

	constraint [PK_Subcategorias] primary key (Sub_id)
)
go
--
-- Familiasprod
--
create table Familiasprod (
	Fam_id				bigint			identity(1, 1)	not null
	,Fam_descricao		bigint			default(0)		not null
	,Fam_inativo		bit				default(0)		not null

	,CreateUser			varchar(50)		default('')		not null
	,UpdateUser			varchar(50)		default('')		not null
	,CreateAt			datetime
	,UpdateAt			datetime
	,Uniq				timestamp

	constraint [PK_Familiasprod] primary key (Fam_id)
)
go

--
-- Produtos
--
create table Produtos (
	Pro_id				bigint				not null		identity(1, 1)
	,Cat_id				bigint			default(0)		not null
	,Sub_id				bigint			default(0)		not null
	,Fam_id				bigint			default(0)		not null
	,Pro_codigo			varchar(20)		default('')		not null
	,Pro_descricao		varchar(100)	default('')		not null
	,Pro_pvenda			decimal(10, 2)	default(0)		not null
	,Pro_inativo		bit				default(0)		not null
	,CreateUser			varchar(50)		default('')		not null
	,UpdateUser			varchar(50)		default('')		not null
	,CreateAt			datetime
	,UpdateAt			datetime
	,Uniq				timestamp

	constraint [PK_Produtos] primary key (Pro_id)
	,constraint [FK_Produtos_Categorias] foreign key ([Cat_id]) references Categorias([Cat_id])
	,constraint [FK_Produtos_Subcategorias] foreign key ([Sub_id]) references Subcategorias([Sub_id])
	,constraint [FK_Produtos_Familiasprod] foreign key ([Fam_id]) references Familiasprod([Fam_id])
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
	,Cli_inativo		bit				default(0)		not null
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
	,Ped_canc						bit				default(0)		not null
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
	,Ven_id				bigint			default(0)		not null
	,Pei_vlunitario		decimal(10, 3)	default(0)		not null
	,Pei_quantidade		decimal(10, 3)	default(0)		not null
	,Pei_canc			bit				default(0)		not null
	,Pei_canc_indiv		bit				default(0)		not null
	,CreateUser			varchar(50)		default('')		not null
	,UpdateUser			varchar(50)		default('')		not null
	,CreateAt			datetime
	,UpdateAt			datetime
	,Uniq				timestamp

	constraint [PK_Peitens] primary key (Pei_id)
	,constraint [FK_Peitens_Pedidos] foreign key (Ped_id) references Pedidos(Ped_id)
		on delete cascade
	,constraint [FK_Peitens_Vendedores] foreign key (Ven_id) references Vendedores(Ven_id)
		on delete cascade
	,constraint [FK_Peitens_Produtos] foreign key ([Pro_id]) references Produtos([Pro_id])
)
go

