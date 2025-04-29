use ChlothingDatabase;

UPDATE Produkter
SET BilledeUrl = '/Images/ProductImages/T-Shirt.jpg'
WHERE ProduktID = 4;

SELECT ProduktID, Navn, BilledeUrl FROM Produkter;
