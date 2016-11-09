USE Computers  
GO  

CREATE PROCEDURE usp_GetComputersWithGpuAndRamBetween
    @CpuId int,
    @MinRam int,   
    @MaxRam int
AS   
   SELECT c.Model, c.ComputerId, v.Name
    FROM Computers c
	JOIN Vendors v
	ON c.VendorId=v.VendorId
	WHERE (c.MemoryInGb BETWEEN @MinRam AND @MaxRam) AND c.CpuId=@CpuId
GO  
