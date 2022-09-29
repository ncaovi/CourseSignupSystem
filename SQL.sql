
CREATE FUNCTION func_AutoNextCode(@lastUserId varchar(6), @prefix varchar(3), @size int)
 returns varchar(6)
 as
	Begin 
		if(@lastUserId = '')
			set @lastUserId = @prefix + REPLICATE (0, @size - LEN(@prefix))
		declare @num_nextUserId int, @nextUserId varchar(6)
		set @lastUserId = LTRIM(RTRIM(@lastUserId))
		set @num_nextUserId = REPLACE(@lastUserId, @prefix, '') + 1
		set @size = @size - LEN(@prefix)
		set @nextUserId = @prefix + REPLICATE (0,@size - len(@prefix))
		set @nextUserId = @prefix + RIGHT(REPLICATE(0, @size) + CONVERT (VARCHAR(MAX), @num_nextUserId), @size)
		return @nextUserId
END
go


Create trigger tr_MaSinhVien on [User]
for insert
as
 begin
		DECLARE @lastUserId varchar(6)
		SET @lastUserId = (SELECT TOP 1 UserStudentCode from [User] order by UserStudentCode desc)
		UPDATE [User] SET UserStudentCode = dbo.func_AutoNextCode(@lastUserId,'SV',6) WHERE UserStudentCode = ''
end
go

Create trigger tr_MaGiaoVien on [User]
for insert
as
 begin
		DECLARE @lastUserId varchar(6)
		SET @lastUserId = (SELECT TOP 1 UserTeacherCode from [User] order by UserTeacherCode desc)
		UPDATE [User] SET UserTeacherCode = dbo.func_AutoNextCode(@lastUserId,'GV',6) WHERE UserTeacherCode = ''
end

go

CREATE TRIGGER trg_TotalTuition
   ON  [Turnover]
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
    UPDATE dbo.Turnover SET TurnoverTotalTuition=(SELECT SUM(TurnoverTuition) FROM dbo.Turnover)
END
GO