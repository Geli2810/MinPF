use ChlothingDatabase;
select * from Produkter join Kategorier on Produkter.KategoriID = Kategorier.KategoriID where Kategorier.Navn = 'Kjoler';

select * from Kategorier;

Update Produkter
set BilledeUrl = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJCCzVK6by1Li1HXw-Tm2FmXr_DBGBJ56VUw&s/Images/ProjIMS'
where ProduktID = 10;


Update Produkter
set BilledeUrl = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRwmzSnlm_U1SlfOz2ej5qbk2ZS6dED5quY6g&s/Images/ProjIMS'
where ProduktID = 11;