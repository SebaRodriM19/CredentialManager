create database CredentialManager
use CredentialManager

create table Account(
	idAccount int identity not null,
	username varchar(50) not null primary key,
	pwd varchar(50) not null,
	date_of_creation date not null
)