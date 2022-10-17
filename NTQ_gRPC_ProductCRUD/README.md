## Overview
1. Connect db bằng EF Core, gRPC
2. Dựng UI: Table cha => Detail table con => Detail table cháu
3. Binding data lên view (ReactJS, WPF, Winform, MVC)
4. CRUD (Transaction)

## Create DB
<pre>create table Category (
Id int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(255),
TagName varchar(15),
Active bit Not null default 1,
CreatedDate Datetime Not null,
UpdatedDate Datetime Not null
);

create table Product (
Id int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(255),
TagName varchar(15),
Active bit Not null default 1,
CategoryId int Not null,
CreatedDate Datetime Not null,
UpdatedDate Datetime Not null,
FOREIGN KEY (CategoryId) REFERENCES Category(Id)
);

create table ProductDetail (
Id int IDENTITY(1,1) PRIMARY KEY,
Price varchar(15), – Giá sản phẩm
Color varchar(20), – Màu sắc
StartingDate Datetime, – Ngày sản xuất
ClosingDate Datetime, – Hạn SD
MadeBy nvarchar(50), – Nơi SX (quốc gia)
ProductId int Not null,
CreatedDate Datetime Not null,
UpdatedDate Datetime Not null,
FOREIGN KEY (ProductId) REFERENCES Product(Id)
);
</pre>

