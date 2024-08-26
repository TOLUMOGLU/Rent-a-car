--create table arabalar(
--	id int not null unique,
--	plaka nvarchar(50) not null unique,
--	marka nvarchar(50) not null,
--	model nvarchar(50) not null,
--	renk nvarchar(50) not null,
--	aracSinifID int not null unique,
--	aracSinifAdi nvarchar(50) not null,
--	aracUcret nvarchar(50) not null
--)

--insert into arabalar(id,plaka,marka,model,renk,aracSinifID,aracSinifAdi,aracUcret) values
--(1,'34ABC123','Mercedes Benz','E320','Beyaz',1,'Sedan',100),
--(2,'34ABC456','Audi','A6','Siyah',2,'Hatchback',200),
--(3,'34ABC789','Audi','RS6','Kırmızı',3,'SUV',300),
--(4,'34XYZC123','BMW','M5','Gri',4,'Station Wagon',400)


----create table musteri(
----	tck nvarchar(50) not null unique,
----	ad nvarchar(50) not null,
----	adres nvarchar(50) not null,
----	telefon nvarchar(50) not null,
----)

----insert into musteri(tck,ad,adres,telefon) values
----('11111111111','Adem','Adres ABC','5333333333')

--create table kira(
--	tarih nvarchar(50) not null,
--	ucret int not null
--)
Select * from araba