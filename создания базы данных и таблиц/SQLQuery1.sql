IF DB_ID('rental_property') IS NOT NULL
begin
	USE master
	drop database rental_property 
end

create database rental_property
ON PRIMARY
( 
  NAME = rental_property_data_base_data,
  FILENAME = 'c:\SqlDataBase\testDataBase.mdf',
  SIZE = 100MB,
  MAXSIZE = UNLIMITED,
  FILEGROWTH = 300MB 
 ),
 (
 NAME = rental_property_data_base2_data,
  FILENAME = 'c:\SqlDataBase\testDataBase2.mdf',
  SIZE = 100MB,
  MAXSIZE = UNLIMITED,
  FILEGROWTH = 300MB 
 ),
 FILEGROUP MyDB_FG1
  ( NAME = 'MyDB_FG1_Dat1',
    FILENAME =
       'c:\SqlDataBase\testDataBase3.ndf',
     SIZE = 100MB,
  MAXSIZE = UNLIMITED,
  FILEGROWTH = 300MB),
  ( NAME = 'MyDB_FG1_Dat2',
    FILENAME =
       'c:\SqlDataBase\testDataBase4.ndf',
     SIZE = 100MB,
  MAXSIZE = UNLIMITED,
  FILEGROWTH = 300MB)
LOG ON
( 
  NAME = rental_property_data_base_log,
  FILENAME = 'c:\SqlDataBase\ldf.ldf',
  SIZE = 50MB,
  MAXSIZE = 500MB,
  FILEGROWTH = 150MB
 )
 -- Этап 2
 use rental_property
 CREATE TABLE Owner
 (
 owner_code int,
 surname nvarchar(40) not null,
 name nvarchar(40) not null,
 middle_name nvarchar(40) null,
 passport_date nvarchar(300) not null,
 adress nvarchar(100) not null,
 phone int null,
 CONSTRAINT check_phone CHECK
 (phone LIKE 
   '([0-9][0-9][0-9]) [0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]'),
   CONSTRAINT PK1 PRIMARY KEY (owner_code)
 )
  CREATE TABLE Real_estate
 (
 number_of_object int,
 type_of_object nvarchar(70) NOT NULL,
 adress_of_object nvarchar(100) NOT NULL,
 total_area int NOT NULL,
 living_space int NOT NULL,
 rent_amount money NOT NULL,
 owner_code int NOT NULL
 CONSTRAINT FK1 Foreign key (owner_code) references Owner(owner_code),
 CONSTRAINT PK2 PRIMARY KEY (number_of_object)
 )
 CREATE TABLE Tenants 
 (
 tenant_code int,
 surname nvarchar(40) not null,
 name nvarchar(40) not null,
 middle_name nvarchar(40) null,
 passport_date nvarchar(300) not null,
 phone int null,
 CONSTRAINT check_phone2 CHECK
 (phone LIKE 
   '([0-9][0-9][0-9]) [0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]'),
   CONSTRAINT PK3 PRIMARY KEY (tenant_code)
 )
  CREATE TABLE lease_agreements
 (
 contract_number int,
 rental_start_date date not null,
 rental_end_date date not null,
 number_of_object int not null,
 tenant_code int,
 CONSTRAINT FK2 Foreign key (tenant_code) references Tenants(tenant_code),
 CONSTRAINT FK3 Foreign key (number_of_object) references Real_estate(number_of_object),
 CONSTRAINT PK4 PRIMARY KEY (contract_number)
 )
 CREATE TABLE Individuals 
 (
 tenant_code int,
 place_of_work nvarchar(100) not null,
 job_title nvarchar(80) not null,
 CONSTRAINT FK4 Foreign key (tenant_code) references Tenants(tenant_code),
 CONSTRAINT PK5 PRIMARY KEY (tenant_code)
 )
 CREATE TABLE Legal_entities
 (
 tenant_code int,
 name_of_organization nvarchar(80) not null,
 organization_adress nvarchar(100) not null,
 bank_details nvarchar(300) not null,
 CONSTRAINT FK5 Foreign key (tenant_code) references Tenants(tenant_code),
 CONSTRAINT PK6 PRIMARY KEY (tenant_code)
 )