CREATE UNIQUE INDEX IDX_tbl_HSCODE_ID ON tbl_HSCODE(ID);
CREATE FULLTEXT CATALOG ftCatalog_HSCODE AS DEFAULT;
CREATE FULLTEXT INDEX ON tbl_HSCODE (
	Mo_ta_khong_dau LANGUAGE 1066,
	Ghi_chu_khong_dau LANGUAGE 1066,
	Mo_ta_hang_hoaE LANGUAGE 1033
)
KEY INDEX IDX_tbl_HSCODE_ID
ON ftCatalog_HSCODE;

CREATE FUNCTION dbo.RemoveVietnameseAccents (@str NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @result NVARCHAR(MAX)
    SET @result = @str

    SET @result = REPLACE(@result, N'Đ', N'D')
    SET @result = REPLACE(@result, N'đ', N'd')

    -- Chuyển từng nguyên âm có dấu sang không dấu
    SET @result = REPLACE(@result, N'à', N'a')
    SET @result = REPLACE(@result, N'á', N'a')
    SET @result = REPLACE(@result, N'ạ', N'a')
    SET @result = REPLACE(@result, N'ả', N'a')
    SET @result = REPLACE(@result, N'ã', N'a')
    SET @result = REPLACE(@result, N'â', N'a')
    SET @result = REPLACE(@result, N'ầ', N'a')
    SET @result = REPLACE(@result, N'ấ', N'a')
    SET @result = REPLACE(@result, N'ậ', N'a')
    SET @result = REPLACE(@result, N'ẩ', N'a')
    SET @result = REPLACE(@result, N'ẫ', N'a')
    SET @result = REPLACE(@result, N'ă', N'a')
    SET @result = REPLACE(@result, N'ằ', N'a')
    SET @result = REPLACE(@result, N'ắ', N'a')
    SET @result = REPLACE(@result, N'ặ', N'a')
    SET @result = REPLACE(@result, N'ẳ', N'a')
    SET @result = REPLACE(@result, N'ẵ', N'a')

    SET @result = REPLACE(@result, N'è', N'e')
    SET @result = REPLACE(@result, N'é', N'e')
    SET @result = REPLACE(@result, N'ẹ', N'e')
    SET @result = REPLACE(@result, N'ẻ', N'e')
    SET @result = REPLACE(@result, N'ẽ', N'e')
    SET @result = REPLACE(@result, N'ê', N'e')
    SET @result = REPLACE(@result, N'ề', N'e')
    SET @result = REPLACE(@result, N'ế', N'e')
    SET @result = REPLACE(@result, N'ệ', N'e')
    SET @result = REPLACE(@result, N'ể', N'e')
    SET @result = REPLACE(@result, N'ễ', N'e')

    SET @result = REPLACE(@result, N'ì', N'i')
    SET @result = REPLACE(@result, N'í', N'i')
    SET @result = REPLACE(@result, N'ị', N'i')
    SET @result = REPLACE(@result, N'ỉ', N'i')
    SET @result = REPLACE(@result, N'ĩ', N'i')

    SET @result = REPLACE(@result, N'ò', N'o')
    SET @result = REPLACE(@result, N'ó', N'o')
    SET @result = REPLACE(@result, N'ọ', N'o')
    SET @result = REPLACE(@result, N'ỏ', N'o')
    SET @result = REPLACE(@result, N'õ', N'o')
    SET @result = REPLACE(@result, N'ô', N'o')
    SET @result = REPLACE(@result, N'ồ', N'o')
    SET @result = REPLACE(@result, N'ố', N'o')
    SET @result = REPLACE(@result, N'ộ', N'o')
    SET @result = REPLACE(@result, N'ổ', N'o')
    SET @result = REPLACE(@result, N'ỗ', N'o')
    SET @result = REPLACE(@result, N'ơ', N'o')
    SET @result = REPLACE(@result, N'ờ', N'o')
    SET @result = REPLACE(@result, N'ớ', N'o')
    SET @result = REPLACE(@result, N'ợ', N'o')
    SET @result = REPLACE(@result, N'ở', N'o')
    SET @result = REPLACE(@result, N'ỡ', N'o')

    SET @result = REPLACE(@result, N'ù', N'u')
    SET @result = REPLACE(@result, N'ú', N'u')
    SET @result = REPLACE(@result, N'ụ', N'u')
    SET @result = REPLACE(@result, N'ủ', N'u')
    SET @result = REPLACE(@result, N'ũ', N'u')
    SET @result = REPLACE(@result, N'ư', N'u')
    SET @result = REPLACE(@result, N'ừ', N'u')
    SET @result = REPLACE(@result, N'ứ', N'u')
    SET @result = REPLACE(@result, N'ự', N'u')
    SET @result = REPLACE(@result, N'ử', N'u')
    SET @result = REPLACE(@result, N'ữ', N'u')

    SET @result = REPLACE(@result, N'ỳ', N'y')
    SET @result = REPLACE(@result, N'ý', N'y')
    SET @result = REPLACE(@result, N'ỵ', N'y')
    SET @result = REPLACE(@result, N'ỷ', N'y')
    SET @result = REPLACE(@result, N'ỹ', N'y')

    RETURN @result
END
UPDATE tbl_Hscode
SET Mo_ta_khong_dau = dbo.RemoveVietnameseAccents(Mo_ta_hang_hoaV);
