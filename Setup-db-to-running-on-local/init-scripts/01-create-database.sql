create database customerdb;
go

use customerdb;
go

    create table customer (
        ID int identity(1,1) primary key,
        FullName nvarchar(100) not null,
        BirthDay date null,
        Email nvarchar(255) not null unique,
        PhoneNumber NVARCHAR(20) not null unique,
        Address nvarchar(500) null
    );