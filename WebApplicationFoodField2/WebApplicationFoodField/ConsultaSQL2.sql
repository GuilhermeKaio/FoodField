create table Clientes (
id int identity not null,
Nome varchar(200) not null,
RG  varchar(11) not null,
Telefone varchar(13) not null,
Email varchar(100) not null,
Login varchar(30) not null,
Senha varchar(50) not null,
DataCadastro Datetime not null,
primary key (id)
) 
Select * from Clientes

Insert into Clientes (RG, Telefone, Email, Login, Senha, Nome, DataCadastro) 
	VALUES ('002.719.902', '981858038', 'guilherme_kaio@outlook.com', 'teste', 'teste1234', 'Guilherme Kaio', '2000-09-10')

 create table Endereco (
 id int identity not null,
 Rua varchar(50) not null,
 Numero varchar(10) not null,
 Cep varchar(9) not null, 
 Bairro varchar(50) not null,
 Cidade varchar(50) not null,
 UF varchar(2) not null,
 id_cliente int not null,
 primary key (id),
 foreign key(id_cliente) references Clientes
 )