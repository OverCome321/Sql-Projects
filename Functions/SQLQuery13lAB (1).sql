USE rental_property
-- Function 1
go
CREATE OR ALTER function [dbo].[User_Surname] 
(@mont int)
	returns nvarchar(50)
	begin
		Declare @surname nvarchar(50)
		Set @surname = (Select top(1)  surname from dbo.Tenants 
			inner join dbo.lease_agreements on Tenants.tenant_code = lease_agreements.tenant_code  
				where MONTH(lease_agreements.rental_start_date) = @mont)
		return @surname
	end
go
select dbo.User_Surname (1)
go


-- Function 2
CREATE OR ALTER FUNCTION Real_estate_is_null
()
RETURNS TABLE 
AS
RETURN 
(SELECT number_of_object, type_of_object, adress_of_object, total_area, living_space, rent_amount, owner_code FROM 
	[dbo].[Real_estate] 
		WHERE NOT EXISTS 
		(SELECT * 
			FROM lease_agreements 
				WHERE dbo.Real_estate.number_of_object = dbo.lease_agreements.number_of_object))

go





select * from Real_estate_is_null()
go
-- Function 3
-- Выводить одинаковые 
go
create or alter function Raiting()
returns @t table(total_area int, количество_сданных_в_аренду int, raiting decimal(10,2))
as
begin
Declare @allCount decimal(10,2)
Set @allCount = (Select Count(number_of_object) from lease_agreements)
insert @t SELECT  REA.total_area, COUNT(*) AS Количество_сданных_в_аренду, ((COUNT(*)/@allCount) * 100) AS Raiting
	FROM (SELECT  RE.number_of_object, RE.type_of_object, RE.adress_of_object, RE.total_area, RE.living_space, RE.rent_amount, RE.owner_code FROM Real_estate AS RE INNER JOIN lease_agreements AS LA ON RE.number_of_object = LA.number_of_object) AS REA
		GROUP BY REA.total_area
HAVING COUNT(*) > 1
return 
end
go

select * from dbo.Raiting()
 ------------------------------------------------------------------- Попытки сделать рандом
go
create or alter view randNumber as 
Select RAND() as RND 

go
CREATE OR ALTER FUNCTION rndResult()
RETURNS DECIMAL(18,18)
AS
BEGIN
DECLARE @RNDVALUE DECIMAL(18,18)
SELECT @RNDVALUE = RND
FROM randNumber
RETURN @RNDVALUE
END
go



CREATE OR ALTER function [dbo].[User_Surname] 
(@mont int)
	returns nvarchar(50)
	begin
		Declare @surname nvarchar(50)
		Set @surname = (Select top(1)  surname from dbo.Tenants 
			inner join dbo.lease_agreements on Tenants.tenant_code = lease_agreements.tenant_code  
				where MONTH(lease_agreements.rental_start_date) = @mont 
				order by [dbo].[rndResult]()
				)
		return @surname
	end
go



select dbo.User_Surname (2)


Select surname from dbo.Tenants 
			inner join dbo.lease_agreements on Tenants.tenant_code = lease_agreements.tenant_code  
				where MONTH(lease_agreements.rental_start_date) = 2