create table TransacaoPacote (
id int identity not null,
Pacote_id int,
Cliente_id int,
foreign key(Pacote_Id) references Pacote,
foreign key(Cliente_Id) references Clientes,
primary key (id)
)

create table Refeicao (
id int identity not null,
Ingredientes varchar(1000),
ModoPreparo varchar(1000),
Pacote_Id int,
primary key (id),
foreign key(Pacote_Id) references Pacote
)
SELECT * From Pacote WHERE Pacote_id = 1

create table Administrador (
id int identity not null,
Nome varchar(200),
Telefone varchar(11),
Email varchar(200),
Login varchar(30),
Senha varchar(50),
DataNascimento DateTime,
primary key (id)
)

create table Nutricionista (
id int identity not null,
Nome varchar(200),
Telefone varchar(11),
Email varchar(200),
Login varchar(30),
Senha varchar(50),
DataNascimento DateTime,
primary key (id),
)
SELECT * FROM Nutricionista, Administrador

INSERT INTO Pacote(Nome, Preço, Descricao, ValorCalorico)
	VALUES('Pacote 1','30.10','Dolor a sit amet','5')

INSERT INTO Refeicao(Ingredientes, ModoPreparo, Pacote_Id)
	VALUES('Feijão, Batata','Dolor a sit amet','3')

	SELECT * FROM Refeicao,Pacote

INSERT INTO Administrador(Nome, Telefone, Email, Login, Senha)
	VALUES('Alessandro Medeiros','4002-8922','leleconatal@gmail.com','leleco', 'araruna123')

INSERT INTO Administrador(Nome, Telefone, Email, Login, Senha)
	VALUES('Guilherme Kaio','4002-8922','guilkaio@gmail.com','login1', 'senha123')

	SELECT * FROM Administrador, Nutricionista

INSERT INTO Nutricionista(Nome, Telefone, Email, Login, Senha)
	VALUES('Kaio Guilherme','4002-8922','guilkaio@gmail.com','login1', 'senha123')

INSERT INTO Nutricionista(Nome, Telefone, Email, Login, Senha)
	VALUES('Medeiros Alessandro','4002-8922','leleconatal@gmail.com','leleco', 'araruna123')