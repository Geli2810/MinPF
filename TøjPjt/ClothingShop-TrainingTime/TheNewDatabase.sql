Create table Bukser
(
Id int primary key identity (1,1),
Navn nvarchar(50),
Størrelse nvarchar(60),
Farve nvarchar(50),
Mærke nvarchar(50),
pris decimal not null,
tilsalg bit not null,
BilledeUrl nvarchar(max),
ProduktId int,
Foreign key (ProduktId) references Produkter(ProduktId),

)

create table Sko
(
Id int primary key identity (1,1),
Navn nvarchar(50),
Størrelse nvarchar(60),
Farve nvarchar(50),
Mærke nvarchar(50),
pris decimal not null,
tilsalg bit not null,
BilledeUrl nvarchar(max),
ProduktId int,
Foreign key (ProduktId) references Produkter(ProduktId),
);





INSERT INTO [dbo].Sko ([Navn], [Beskrivelse], [Pris], [Størrelse], [Farve], [LagerAntal], [KategoriID], [BilledeUrl])
VALUES
('Vans Old Skool', 'Klassiske skatersko', 649.00, '41', 'Sort/Hvid', 30, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '42', 'Sort/Hvid', 25, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '43', 'Sort/Hvid', 20, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '44', 'Sort/Hvid', 15, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '41', 'Blå/Hvid', 30, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '42', 'Blå/Hvid', 25, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '43', 'Blå/Hvid', 20, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '44', 'Blå/Hvid', 15, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '41', 'Rød/Hvid', 30, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '42', 'Rød/Hvid', 25, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '43', 'Rød/Hvid', 20, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '44', 'Rød/Hvid', 15, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '41', 'Grå/Sort', 30, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '42', 'Grå/Sort', 25, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '43', 'Grå/Sort', 20, 1, '/Images/ProductImages/Shoes/vans1.jpg'),
('Vans Old Skool', 'Klassiske skatersko', 649.00, '44', 'Grå/Sort', 15, 1, '/Images/ProductImages/Shoes/vans1.jpg');
