use rental_property

GO
CREATE OR ALTER PROCEDURE AvgForSurname
	(@tenantCode INT)
	AS
	BEGIN
	SELECT * FROM dbo.Real_estate WHERE dbo.Real_estate.total_area 
	BETWEEN (
		SELECT ROUND(AVG(total_area),0) - (ROUND(AVG(total_area),0)/COUNT(*))/2  FROM dbo.Real_estate INNER JOIN 
		dbo.lease_agreements ON dbo.Real_estate.number_of_object = dbo.lease_agreements.number_of_object
		WHERE YEAR(dbo.lease_agreements.rental_start_date) > YEAR(DATEADD(YEAR, -5,GETDATE())) AND dbo.lease_agreements.tenant_code = @tenantCode) 
			AND (  
				SELECT ROUND(AVG(total_area),0) + (ROUND(AVG(total_area),0)/COUNT(*))/2 FROM dbo.Real_estate INNER JOIN 
				dbo.lease_agreements ON dbo.Real_estate.number_of_object = dbo.lease_agreements.number_of_object
					WHERE YEAR(dbo.lease_agreements.rental_start_date) > YEAR(DATEADD(YEAR, -5,GETDATE())) AND dbo.lease_agreements.tenant_code = @tenantCode)
	END
GO

EXECUTE dbo.AvgForSurname 3


go
SELECT ROUND(AVG(total_area),0) FROM dbo.Real_estate INNER JOIN dbo.lease_agreements ON dbo.Real_estate.number_of_object = dbo.lease_agreements.number_of_object
		WHERE YEAR(dbo.lease_agreements.rental_start_date) > YEAR(DATEADD(YEAR, -5,GETDATE())) AND dbo.lease_agreements.tenant_code = 3