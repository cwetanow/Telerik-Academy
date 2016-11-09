USE Computers  
GO  

CREATE PROCEDURE usp_GetComputersWithRamBetween
    @MinRam int,   
    @MaxRam int
AS   
    SELECT c.Model, c.ComputerId, v.Name
    FROM Computers c
	JOIN Vendors v
	ON c.VendorId=v.VendorId
	WHERE c.MemoryInGb BETWEEN @MinRam AND @MaxRam
GO  
