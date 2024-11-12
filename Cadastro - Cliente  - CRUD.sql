create database bd_Empresa;
use bd_Empresa;

select * from Clietes;

create table Clientes (
id int not null auto_increment primary key,
nome varchar(50),
telefone char(15),
sexo int
);
