/*
Created: 20.04.2022
Modified: 20.04.2022
Model: Lab6(Variant_18)
Database: MS SQL Server 2019
*/


-- Create tables section -------------------------------------------------

-- Table Пользователи

CREATE TABLE [Пользователи]
(
 [Код_пользователя] Int NOT NULL,
 [Логин] Char(50) NOT NULL,
 [Имя] Char(50) NOT NULL,
 [Статус] Char(50) NOT NULL,
 [История_оплаты] Char(50) NOT NULL,
 [Оставшееся_количество_дней_использования] Int NOT NULL
)
go

-- Add keys for table Пользователи

ALTER TABLE [Пользователи] ADD CONSTRAINT [Код_пользователя] PRIMARY KEY ([Код_пользователя])
go

-- Table Видеозаписи

CREATE TABLE [Видеозаписи]
(
 [Код_видеозаписи] Int NOT NULL,
 [Название_видеозаписи] Char(50) NOT NULL,
 [Адрес_хранения_видеозаписи] Char(50) NOT NULL,
 [Доступное качество] Char(10) NOT NULL,
 [Перевод] Char(20) NOT NULL,
 [Рейтинг] Char(30) NOT NULL,
 [Год_выхода] Date NOT NULL,
 [Страна] Char(30) NOT NULL,
 [Жанр] Char(30) NOT NULL,
 [Режиссер] Char(30) NOT NULL,
 [Актеры] Char(100) NOT NULL,
 [Ограничения_по_возрасту] Char(15) NOT NULL
)
go

-- Add keys for table Видеозаписи

ALTER TABLE [Видеозаписи] ADD CONSTRAINT [Код_видеозаписи] PRIMARY KEY ([Код_видеозаписи])
go

-- Table Категория видеозаписей/E3

CREATE TABLE [Категория видеозаписей/E3]
(
 [Код_категории_видеозаписей] Int NOT NULL,
 [Название_категории] Char(30) NOT NULL,
 [Описание_категории] Char(100) NOT NULL,
 [Сериалы] Char(30) NULL,
 [Названия_каждой_серии_сериала] Char(30) NULL
)
go

-- Add keys for table Категория видеозаписей/E3

ALTER TABLE [Категория видеозаписей/E3] ADD CONSTRAINT [Код_категории] PRIMARY KEY ([Код_категории_видеозаписей])
go

-- Table Списки_ просмотров

CREATE TABLE [Списки_ просмотров]
(
 [Код_списка] Int NOT NULL,
 [Код_видеозаписи] Int NULL,
 [История_просмотров] Char(40) NOT NULL,
 [Название_списка] Char(30) NULL
)
go

-- Create indexes for table Списки_ просмотров

CREATE INDEX [IX_R5] ON [Списки_ просмотров] ([Код_видеозаписи])
go

-- Add keys for table Списки_ просмотров

ALTER TABLE [Списки_ просмотров] ADD CONSTRAINT [Номер_списка] PRIMARY KEY ([Код_списка])
go

-- Table Пользователи_Списки_ просмотров

CREATE TABLE [Пользователи_Списки_ просмотров]
(
 [Attribute1] Int NOT NULL,
 [Attribute2] Int NOT NULL
)
go

-- Table Пользователи_Видеозаписи

CREATE TABLE [Пользователи_Видеозаписи]
(
 [Attribute1] Int NOT NULL,
 [Код_видеозаписи] Int NOT NULL
)
go

-- Table Видеозаписи_Категория видеозаписей/E3

CREATE TABLE [Видеозаписи_Категория видеозаписей/E3]
(
 [Attribute1] Int NOT NULL,
 [Код_видеозаписи] Int NOT NULL
)
go

-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE [Списки_ просмотров] ADD CONSTRAINT [R5] FOREIGN KEY ([Код_видеозаписи]) REFERENCES [Видеозаписи] ([Код_видеозаписи]) ON UPDATE NO ACTION ON DELETE NO ACTION
go
