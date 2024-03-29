use StoreIBoard

CREATE TABLE Category
(
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(500)
)

CREATE TABLE GroupGoods
(
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    GroupName NVARCHAR(500),
    CategoryRef BIGINT FOREIGN KEY REFERENCES Category(Id)
)

CREATE TABLE Goods
(
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    GoodName NVARCHAR(650),
    GoodDescription NVARCHAR(MAX),
    GoodPrice BIGINT
)

CREATE TABLE BasColor
(
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    PersianColorName NVARCHAR(220),
    EnglishColorName NVARCHAR(220),
    ColorCode INT
)

CREATE TABLE GoodsColors
(
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    ColorRef BIGINT FOREIGN KEY REFERENCES BasColor(Id),
    GoodRef BIGINT FOREIGN KEY REFERENCES Goods(Id)
)







