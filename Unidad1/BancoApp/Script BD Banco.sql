create database bankApp_412459
go
use bankApp_412459
go

create table clientes(
dni int,
nombre varchar(50),
apellido varchar(50)
constraint pk_dni primary key (dni)
)

create table cuentas(
cbu varchar(50),
saldo decimal,
tipo_cuenta varchar(50),
ultimo_mov decimal,
id_cliente int
constraint pk_cbu primary key (cbu)
constraint fk_id_cliente foreign key (id_cliente)
references clientes (dni)
)

go

create proc SP_Insertar_Cuenta
@dni int,
@nombre varchar(50),
@apellido varchar(50),
@cbu varchar(50),
@saldo decimal,
@tipo varchar(50),
@ultimo decimal
as
begin
Insert into clientes (dni, nombre, apellido)
values (@dni, @nombre, @apellido);
Insert into cuentas (cbu, saldo, tipo_cuenta, ultimo_mov, id_cliente)
values (@cbu, @saldo, @tipo, @ultimo, @dni);
end

select * from cuentas
select * from clientes