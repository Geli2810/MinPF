select * from Produkter where Navn like '%Air%';

UPDATE Produkter 
SET BilledeUrl = '/Images/ProductImages/Shoes/AirMax1.jpg' 
WHERE ProduktID IN (
  3002, 3003, 3004, 3005, 3006, 3007, 3008, 3009,
  3018, 3019, 3020, 3021, 3022, 3023, 3024, 3025, 3026, 3027, 3028
);