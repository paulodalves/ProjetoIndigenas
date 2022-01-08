CREATE DATABASE ProjetoIndigenas;

USE ProjetoIndigenas

CREATE TABLE Pessoa(
PessoaID int primary key identity  not null,
Nome varchar(40) not null,
Cpf_Rani varchar(14) unique not null,
Tel1 varchar(20) not null,
Tel2 varchar(20),
Email varchar(40) not null,
Senha varchar (20) not null,
DatNasc date,
);

CREATE TABLE Denuncia(
DenunciaID int primary key identity not null,
Tipo varchar(12) not null,
Localizacao varchar(25) not null,
Descricao varchar (70), 
UltimaAtt Date not null,
PessoaID int not null,
constraint fk_pessoa_denuncia foreign key (PessoaID) references Pessoa,
)
