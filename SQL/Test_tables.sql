select titre, code_barre from Films where Films.titre like '%Harry%';
--tous les titres de films contenant "Harry"
select titre, code_barre,annee from Films where annee = 1999;
--tous les films sortis en 1999
select titre, code_barre, annee, Genres.nom, Realisateurs.nom  from (Films inner join Realisateurs on Films.realisateur = Realisateurs.id) inner join (Genres inner join Classifications on Genres.Id = Classifications.id_genre) on Classifications.id_film = code_barre where annee = 1999 and titre like 'Star%' and Genres.nom Like 'Sci%';
--tous les films  de science-fiction contenant 'Star' réalisés par george lucas, sortis en 1999
select titre, code_barre, Genres.nom from Films inner join (Classifications inner join Genres on Genres.Id = Classifications.id_genre) on Classifications.id_film = Films.code_barre where Genres.nom like '%policier%';
--tous les films du genre policier
select titre, code_barre from Films inner join (Classifications inner join Genres on Genres.Id = Classifications.id_genre) on Classifications.id_film = Films.code_barre where Films.titre like '%Harry%' and Genres.nom like 'Fantastique';
--tous les films contenant "Harry" du genre fantastique
select titre, code_barre from Films inner join Realisateurs on Films.realisateur = Realisateurs.id where Realisateurs.nom like 'Martin Scorsese';
--tous les films de Scorsese;
select titre, code_barre from (Films inner join Roles on Films.code_barre = Roles.id_film) inner join Acteurs on Acteurs.id = Roles.id_acteur where Acteurs.nom like '%Leonardo%'; 
--tous les films avec Di Caprio
select titre, code_barre from (Films inner join (Classifications inner join Genres on Classifications.id_genre = Genres.Id) on Films.code_barre = Classifications.id_film) inner join Realisateurs on Realisateurs.Id = Films.realisateur where Realisateurs.nom like '%Martin Scorsese%' and Genres.nom like 'policier';
--les films policiers de Scorsese
select titre, code_barre from (Films inner join (Classifications inner join Genres on Classifications.id_genre = Genres.Id) on Films.code_barre = Classifications.id_film) inner join (Acteurs inner join Roles on Roles.id_acteur = Acteurs.Id) on Roles.id_film = code_barre where Acteurs.nom like '%Leonardo%' and Genres.nom like 'Romance'; 
--les films romance avec di caprio
select titre, code_barre from ((Films inner join (Classifications inner join Genres on Classifications.id_genre = Genres.Id) on Films.code_barre = Classifications.id_film) inner join Realisateurs on Realisateurs.Id = Films.realisateur) inner join (Acteurs inner join Roles on Roles.id_acteur = Acteurs.Id) on Roles.id_film = code_barre where Realisateurs.nom like '%Martin Scorsese%' and Genres.nom like 'policier' and Acteurs.nom like '%Leonardo%'; 
--les films policiers de Scorsese avec di caprio
select titre, code_barre from Films inner join (Acteurs inner join Roles on Roles.id_acteur = Acteurs.Id) on Roles.id_film = code_barre where Films.titre like '%Star%' and Acteurs.nom like '%Harrison Ford%'; 
--les films contenant 'Star' avec harrison ford
select titre, code_barre from (Films  inner join Realisateurs on Realisateurs.Id = Films.realisateur) inner join (Acteurs inner join Roles on Roles.id_acteur = Acteurs.Id) on Roles.id_film = code_barre where Realisateurs.nom like '%George Lucas%' and Films.titre like '%Star%' and Acteurs.nom like '%Harrison Ford%'; 
--les films contenant 'Star' de george lucas avec harrison ford
select titre, code_barre from ((select code_barre as 'dummy' from Films inner join (Classifications inner join Genres on Classifications.id_genre = Genres.id) on Classifications.id_film = Films.code_barre where Genres.nom like 'com%') intersect (select code_barre from Films inner join (Classifications inner join Genres on Classifications.id_genre = Genres.id) on Classifications.id_film = Films.code_barre where Genres.nom like 'policier')) as C inner join Films on Films.code_barre = C.dummy; 
--les films du genre policier et comédie (pas facile, surtout que text est quasi-obsolète -> privilégier nvarchar(max)
select titre, code_barre from Films inner join (Locations inner join Clients on Locations.id_client = Clients.Id) on Locations.id_film = Films.code_barre where Clients.nom like '%Gaudiche%' and Clients.prenom like 'Gi%'; ;
-- tous les films empruntés par Gisèle Gaudiche

--select
--liste des films non rendus avec les infos du film et des clients et la date de fin
select nom,prenom,mail from Clients inner join (Films inner join Locations on Locations.id_film = Films.code_barre) on Locations.id_client = Clients.Id where Films.titre like 'Titanic' and Locations.rendu = 0;
--liste des clients qui ont loué Titanic et ne l'ont pas rendu