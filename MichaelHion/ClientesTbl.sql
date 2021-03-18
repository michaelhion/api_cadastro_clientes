create DATABASE Intelitrader; 
use Intelitrader;
create table Clientes(
Id VARCHAR(255) PRIMARY KEY,
FirstName VARCHAR(255) NOT NULL,
Surname VARCHAR(255) NOT NULL,
Age INT NOT NULL,
CreationDate DATETIME
);