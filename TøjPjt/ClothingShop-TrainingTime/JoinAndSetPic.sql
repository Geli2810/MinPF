use ChlothingDatabase;

SELECT * 
FROM Produkter
JOIN Kategorier ON Produkter.KategoriID = Kategorier.KategoriID
WHERE Kategorier.Navn = 'Sko';

UPDATE Produkter 
SET BilledeUrl = 'Images/ProductImages/AirMax.jpg'
WHERE ProduktID = 1;


select * from Kategorier