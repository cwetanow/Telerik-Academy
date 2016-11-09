USE Computers  
GO  

CREATE PROCEDURE usp_GetGpusForComputerType
   @ComputerType nvarchar(50)
AS   
   SELECT g.Model, g.Type, g.GpuId, g.MemoryInGb
   FROM Computers c
   JOIN Computers_Gpus cg
   ON cg.ComputerId=c.ComputerId
   JOIN Gpus g
   ON cg.GpuId=g.GpuId
   WHERE c.Type=@ComputerType
GO  
