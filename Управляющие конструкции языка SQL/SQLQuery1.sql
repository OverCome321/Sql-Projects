-- Задание 1 
-- Дано целое положительное число. Необходимо заменить каждую цифру на её дополнение до максимальной в числе. Результат вывести в область системных сообщений. 
--Арифметический

DECLARE @x1 int, @digitMax int, @secondX1 int, @result int 
SET @x1 = 240552543
SET @digitMax = @x1 % 10
SET @secondX1 = @x1
SET @result = @x1
print @result
WHILE @x1 > 0
begin 
if @digitMax <= @x1 % 10
begin 
SET @digitMax = @x1 % 10
end
SET @x1 = @x1 / 10
end
while @secondX1 > 0
begin
SET @x1 = @x1 * 10 + @digitMax
SET @secondX1 = @secondX1/10
end
SET @result = @x1 - @result
print @result

-- Строковый 

DECLARE @i int,
        @s varchar(10)
set @i = 250254
set @s = CAST(@i AS varchar(10))
SELECT CAST(REPLICATE(CASE WHEN CHARINDEX('9',@s)>0 THEN '9'
                           WHEN CHARINDEX('8',@s)>0 THEN '8'
                           WHEN CHARINDEX('7',@s)>0 THEN '7'
                           WHEN CHARINDEX('6',@s)>0 THEN '6'
                           WHEN CHARINDEX('5',@s)>0 THEN '5'
                           WHEN CHARINDEX('4',@s)>0 THEN '4'
                           WHEN CHARINDEX('3',@s)>0 THEN '3'
                           WHEN CHARINDEX('2',@s)>0 THEN '2'
                           WHEN CHARINDEX('1',@s)>0 THEN '1'
                           ELSE '0' END, LEN(@s)) AS int)-@i

-- Табличиный 

DECLARE @x3 int
DECLARE @tableResult table (result int)
SET @x3 = 4552221
insert into @tableResult values(@x3)
SELECT CAST(REPLICATE(CASE WHEN CHARINDEX('9',result)>0 THEN '9'
                           WHEN CHARINDEX('8',result)>0 THEN '8'
                           WHEN CHARINDEX('7',result)>0 THEN '7'
                           WHEN CHARINDEX('6',result)>0 THEN '6'
                           WHEN CHARINDEX('5',result)>0 THEN '5'
                           WHEN CHARINDEX('4',result)>0 THEN '4'
                           WHEN CHARINDEX('3',result)>0 THEN '3'
                           WHEN CHARINDEX('2',result)>0 THEN '2'
                           WHEN CHARINDEX('1',result)>0 THEN '1'
                           ELSE '0' END, LEN(result)) AS int)-result from @tableResult


-- Задание 2
-- Дана произвольная строка. Проверить правильность написания «жи» и «ши». Результат вывести в области отображения данных. 

--Строковый 

Declare @stringResult nvarchar(max), @counter int, @pos int, @word varchar(max)
Set @pos = 1
Set @word = ''
Set @counter = 1
Set @stringResult= 'ежик камышы лыжи уши широкий дружить шить кружыть ножык лужи'
while @counter <= len(@stringResult)
begin 
Set @pos  = CHARINDEX(' ', @stringResult) 
Set @word = SUBSTRING(@stringResult, 1, @pos-1)
Set @stringResult = SUBSTRING(@stringResult, @pos+1, LEN(@stringResult)-@pos)
if @word like '%ши%' or @word like '%жи%'
begin
print CONCAT(@word, ' - правильно')
end
Set @counter = @counter + 1
end
if @stringResult like '%ши%' or @stringResult like '%жи%'
begin
print CONCAT(@stringResult, ' - правильно')
end
 
 -- Строковый способ 2

 declare @stringSecondTry varchar(max), @counterOfElements int
 Set @stringSecondTry = 'ежик камышы лыжи уши широкий дружить шить кружыть ножык лужи'
 Set @counterOfElements = 1
 while @counterOfElements <= Len(@stringSecondTry)
 begin 
 if SUBSTRING(@stringSecondTry,@counterOfElements, 2) like '%ши%' or SUBSTRING(@stringSecondTry,@counterOfElements, 2) like '%жи%'
 begin
 print SUBSTRING(@stringSecondTry,@counterOfElements, 2) + ' - правильно'
 end
 Set @counterOfElements = @counterOfElements + 1
 end
 

 -- Строковый способ 3

 declare @stringThirdTry varchar(max), @countrOfElements2 int, @pastElement int, @word2 varchar(max)
 Set @pastElement = 1
 Set @word2 = ''
 Set @stringThirdTry = ' ежик камышы лыжи уши широкий дружить шить кружыть ножык лужи'
 Set @countrOfElements2 = 1
 while @countrOfElements2 <= Len(@stringThirdTry)
 begin 
 if SUBSTRING(@stringThirdTry,@countrOfElements2, 1) like '% %'
 begin  
 Set @word2 = SUBSTRING(@stringThirdTry, @pastElement, @countrOfElements2 - @pastElement)
 Set @pastElement = CHARINDEX(' ', @stringThirdTry, @countrOfElements2)
	if @word2 like '%ши%' or @word2 like '%жи%'
	begin
	print @word2 + ' - правильно'
	end
	if @word2 like '%шы%' or @word2 like '%жы%'
	begin
	print @word2 + ' - неправильно'
	end
 end
 Set @countrOfElements2 = @countrOfElements2 + 1
 end
if SUBSTRING(@stringThirdTry, @pastElement, @countrOfElements2 - @pastElement) like '%ши%' or SUBSTRING(@stringThirdTry,@pastElement, @countrOfElements2 - @pastElement) like '%жи%'
begin
print SUBSTRING(@stringThirdTry, @pastElement, @countrOfElements2 - @pastElement) + ' - правильно'
end
if SUBSTRING(@stringThirdTry, @pastElement, @countrOfElements2 - @pastElement) like '%шы%' or SUBSTRING(@stringThirdTry,@pastElement, @countrOfElements2 - @pastElement) like '%жы%'
begin
print SUBSTRING(@stringThirdTry, @pastElement, @countrOfElements2 - @pastElement) + ' - неправильно'
end



 -- Табличный 
DECLARE @stringToSplit2 NVARCHAR(max), @name2 NVARCHAR(255), @pos3 INT
DECLARE @table3 table(word nvarchar(max)) 
SET @stringToSplit2 = 'ежик камышы лыжи уши широкий дружить шить кружыть ножык лужи'
Insert @table3 (word)
Select value from string_split (@stringToSplit2,' ')
SELECT CONCAT(word, ' - неправильно') FROM @table3 WHERE word like '%жы%' or word like '%шы%'
union
SELECT CONCAT(word, ' - правильно') FROM @table3 where word like '%жи%' or word like '%ши%'