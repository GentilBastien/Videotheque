delete from Roles --ok
delete from Classifications --ok
delete from Locations --ok
delete from [Sous_titrages] --ok
delete from Voix --ok
delete from Acteurs --ok
delete From Realisateurs --ok
delete from Clients --ok
delete from Langues --ok
delete from Genres --ok
delete from Films --ok
 

insert into Realisateurs values
('358530F1-4EFD-48AB-AD6F-1FBD8598DEA6', 'John Carpenter'),
('653D798B-0FDC-4A9B-8151-09966C3EF3A5', 'Martin Scorsese'),
('768F8455-A473-447E-9C02-0A0BEBBBBA1D', 'Peter Weir'),
('A7C9836C-9DFD-4DED-B3AA-13F3ADD17836', 'Michael Bay'),
('358530F1-4EFD-4600-960C-1FBD8598DEA0', 'David Fincher'),
('062BDFCC-DFFD-45B9-8F14-219E373DC9E6', 'George Lucas'),
('8EF4CE87-BCD5-4913-94FE-318E4B85165B', 'Chris Columbus'),
('E7C383FE-5E23-4600-960C-60558AF2E1DA', 'Vera Chytilova'),
('9A49D8B0-0AA7-480C-A01A-61C21CC3F8EA', 'Robin Hardy'),
('39BA6E60-B6EA-44F9-8480-82C372B86C21', 'James Cameron'),
('CCB240E8-D4AB-4DEE-9AE0-AF1708E2A9DA', 'Jean Cocteau'),
('E0531EBC-C748-46D1-96EF-C57403314B5F', 'James Whale'),
('00A023DD-A1A6-4F65-A0FB-D2E7CCF792F6', 'Stanley Kubrick'),
('4DD386EC-5876-4717-9D07-D31DB83FB922', 'Charlie Chaplin'),
('5853CBFF-B310-4DC3-8442-FE0236EAD37C', 'Bertrand Blier'),
('53DA2BB4-C381-4D83-8FCB-B7C9F1164801', 'David Yates');
--select * from Realisateurs;



insert into Films values
(5301241626163,'358530F1-4EFD-48AB-AD6F-1FBD8598DEA6','Invasion Los Angeles','Venu a Los Angeles pour trouver du travail, John Nada tombe par hasard sur un trafic de lunettes très spéciales. Elles permettent de visualiser un monde parallèle peuple d''extra-terrestres qui prennent peu a peu le contrôle de la planète. Déclaré hors-la-loi avec son ami Frank, John engage une lutte sans merci.',1988,93,'invasion_los_angeles.png',10,0,0,7),
(3177395706277,'358530F1-4EFD-48AB-AD6F-1FBD8598DEA6','The thing','Hiver 1982 au coeur de l''Antarctique. Une équipe de chercheurs composée de 12 hommes découvre un corps enfoui sous la neige depuis plus de 100 000 ans. Décongelée, la créature retourne à la vie en prenant la forme de celui qu''elle veut; dès lors, le soupçon s''installe entre les hommes de l''équipe. Un véritable combat s''engage.',1982,109,'the_thing.png',10,0,0,7),
(6253659828850,'653D798B-0FDC-4A9B-8151-09966C3EF3A5','Casino','Las Vegas, années 70. Ace Rothstein dirige d''une main de fer le Tangiers, hôtel casino parmi les plus prospères de la ville, financé en sous main par le puissant syndicat des camionneurs. Ace est devenu le grand manitou de Las Vegas, secondé par son ami d''enfance, Nicky Santoro. Impitoyable avec les tricheurs, Rothstein se laisse un jour séduire par une virtuose de l''arnaque d''une insolente beauté, Ginger McKenna.',1995,178,'casino.png',10,0,0,7),
(4058244112342,'653D798B-0FDC-4A9B-8151-09966C3EF3A5','Les affranchis','Dans les années 1950, à Brooklyn, le jeune Henry Hill a l''occasion de réaliser son rêve : devenir gangster lorsqu''un caïd local l''intègre à son équipe. C''est alors qu''il rencontre James et Tommy, 2 truands d''une rare brutalité. Impressionné, Henry s''associe avec eux pour débuter un trafic très lucratif. Lorsqu''il séduit la ravissante Karen, le jeune mafieux s''imagine que plus rien ni personne ne pourra jamais lui résister.',1990,146,'les_affranchis.png',10,0,0,7),
(4228193053883,'653D798B-0FDC-4A9B-8151-09966C3EF3A5','Shutter Island','En 1954, une meurtrière, extrêmement dangereuse, placée en centre de détention psychiatrique disparaît sur l''île de Shutter Island. Deux officiers du corps fédéral des marshals, Teddy Daniels et Chuck Aule, sont envoyés sur place pour enquêter. Très vite, Teddy Daniels comprend que le personnel de l''établissement cache quelque chose. Seul indice dont il dispose : un bout de papier sur lequel est griffonnée une suite de chiffres entrecoupée de lettres.',2010,138,'shutter_island.png',2,0,0,7),
(8159960261656,'653D798B-0FDC-4A9B-8151-09966C3EF3A5','Taxi Driver','Travis Bickle, un jeune homme du Midwest et ancien marine, est chauffeur de taxi de nuit à New York. Insomniaque et solitaire, il rencontre Betsy, une assistante du sénateur Charles Palantine, candidat à la présidentielle, mais elle le repousse après qu''il l''a emmenée voir un film pornographique. Confronté à la violence et à la perversion de la nuit new-yorkaise, il achète des armes au marché noir et s''entraîne à les manier.',1976,114,'taxi_driver.png',10,0,0,7),
(9950310497012,'653D798B-0FDC-4A9B-8151-09966C3EF3A5','Le loup de Wall Street','Sa licence de courtier en poche, et les narines déjà pleines de cocaïne, Jordan Belfort est prêt à conquérir Wall Street. Ce jour d''octobre, un krach, le plus important depuis 1929, vient piétiner ses rêves de grandeur. C''est finalement à Long Island qu''il échoue et qu''il monte sa propre affaire de courtage. Son créneau : le hors-cote. Sa méthode : l''arnaque. Son équipe : des vendeurs ou des petits trafiquants.',2013,179,'le_loup_de_wall_street.png',10,0,0,7),
(4458950971412,'768F8455-A473-447E-9C02-0A0BEBBBBA1D','The Truman Show','Truman Burbank mène une vie calme et heureuse. Il habite dans un petit pavillon propret de la radieuse station balnéaire de Seahaven.',1998,103,'the_truman_show.png',10,0,0,7),
(8152471772151,'A7C9836C-9DFD-4DED-B3AA-13F3ADD17836','No pain no gain','Daniel Lugo est coach sportif à Miami. Mais ce bon patriote veut plus : le top du rêve américain, des maisons de luxe, des voitures de course et des filles divines. Pour y parvenir, il projette d''enlever l''un de ses riches clients et lui voler sa fortune, sa vie. Pour l''aider à monter son coup, il fait appel à deux culturistes qui partagent ses ambitions, l''un très pieux, Paul Doyle, l''autre obsédé par ses problèmes érectiles.',2013,129,'no_pain_no_gain.png',10,0,0,7),
(7426631819229,'358530F1-4EFD-4600-960C-1FBD8598DEA0','Seven','Peu avant sa retraite, l''inspecteur William Somerset, un flic désabusé, est chargé de faire équipe avec un jeune idéaliste, David Mills. Ils enquêtent tout d''abord sur le meurtre d''un homme obèse que son assassin a obligé à manger jusqu''à ce que mort s''ensuive. L''enquête vient à peine de commencer qu''un deuxième crime, tout aussi macabre, est commis, puis un troisième. Petit à petit, les deux policiers font le lien entre tous ces assassinats.',1995,127,'seven.png',10,0,0,7),
(2968563168925,'358530F1-4EFD-4600-960C-1FBD8598DEA0','Fight club','Pourvu d''une situation des plus enviable, un jeune homme à bout de nerfs retrouve un équilibre relatif en compagnie de Marla, rencontrée dans un groupe d''entraide. Il fait également la connaissance de Tyler Durden, personnage enthousiaste et charismatique. Ensemble, ils fondent le Fight Club, où ils organisent des combats clandestins et violents, destinés à évacuer l''énergie négative de chacun.',1999,139,'fight_club.png',10,0,0,7),
(2852087106482,'062BDFCC-DFFD-45B9-8F14-219E373DC9E6','Les Aventuriers de l''Arche Perdue','Professeur d''archéologie, Indiana Jones parcourt le monde à la recherche de trésors. Son rival, le Français René Belloq, travaille pour les nazis qui rêvent de retrouver l''Arche d''alliance contenant les Tables de la Loi. Or, feu le professeur Ravenwood, père de Marion, l''ex-petite amie d''Indiana Jones, détenait une médaille permettant de localiser l''arche. Jones part sur les traces de Marion au Népal.',1981,115,'les_aventuriers_de_larche_perdue.png',10,0,0,7),
(9728766184646,'062BDFCC-DFFD-45B9-8F14-219E373DC9E6','Star Wars 4 : La guerre des étoiles','La guerre civile fait rage entre l''Empire galactique et l''Alliance rebelle. Capturée par les troupes de choc de l''Empereur menées par le sombre et impitoyable Dark Vador, la princesse Leia Organa dissimule les plans de l''Etoile Noire.',1977,121,'star_wars_4.png',10,0,0,7),
(1078789698344,'062BDFCC-DFFD-45B9-8F14-219E373DC9E6','Star Wars 1 : La Menace fantôme','Avant de devenir un célèbre chevalier Jedi, et bien avant de se révéler l''âme la plus noire de la galaxie, Anakin Skywalker est un jeune esclave sur la planète Tatooine. La Force est déjà puissante en lui et il est un remarquable pilote de Podracer. Le maître Jedi Qui-Gon Jinn le découvre et entrevoit alors son immense potentiel. Pendant ce temps, l''armée de droïdes de l''insatiable Fédération du Commerce a envahi Naboo dans le cadre d''un plan secret des Sith visant à accroître leur pouvoir.',1999,136,'star_wars_1.png',10,0,0,7),
(3289748375461,'062BDFCC-DFFD-45B9-8F14-219E373DC9E6','Star Wars 2 : L''Attaque des clones','Depuis le blocus de la planète Naboo, la République, gouvernée par le Chancelier Palpatine, connaît une crise. Un groupe de dissidents, mené par le sombre Jedi comte Dooku, manifeste son mécontentement. Le Sénat et la population intergalactique se montrent pour leur part inquiets. Certains sénateurs demandent à ce que la République soit dotée d''une armée pour empêcher que la situation ne se détériore. Padmé Amidala, devenue sénatrice, est menacée par les séparatistes et échappe à un attentat.',2002,142,'star_wars_2.png',10,0,0,7),
(1364474126405,'062BDFCC-DFFD-45B9-8F14-219E373DC9E6','Star Wars 3 : La Revanche des Sith','La Guerre des Clones fait rage. Une franche hostilité oppose désormais le Chancelier Palpatine au Conseil Jedi. Anakin Skywalker, jeune Chevalier Jedi pris entre deux feux, hésite sur la conduite à tenir. Séduit par la promesse d''un pouvoir sans précédent, tenté par le côté obscur de la Force, il prête allégeance au maléfique Darth Sidious et devient Dark Vador.Les Seigneurs Sith s''unissent alors pour préparer leur revanche, qui commence par l''extermination des Jedi.',2005,140,'star_wars_3.png',10,0,0,7),
(3373036534305,'8EF4CE87-BCD5-4913-94FE-318E4B85165B','Harry Potter à l''école des sorciers','Harry Potter, un jeune orphelin, est élevé par son oncle et sa tante qui le détestent. Alors qu''il était haut comme trois pommes, ces derniers lui ont raconté que ses parents étaient morts dans un accident de voiture. Le jour de son onzième anniversaire, Harry reçoit la visite inattendue d''un homme gigantesque se nommant Rubeus Hagrid, et celui-ci lui révèle qu''il est en fait le fils de deux puissants magiciens et qu''il possède lui aussi d''extraordinaires pouvoirs.',2001,152,'harry_potter_a_lecole_des_sorciers.png',10,0,0,7),
(6101641603783,'E7C383FE-5E23-4600-960C-60558AF2E1DA','Les petites marguerites','Marie 1 et Marie 2 s''ennuient fermement. Leur occupation favorite consiste à se faire inviter au restaurant par des hommes d''âge mûr, puis à les éconduire prestement. Fatiguées de trouver le monde vide de sens, elles décident de jouer le jeu à fond, semant désordres et scandales, crescendo, dans des lieux publics.',1966,74,'les_petites_marguerites.png',10,0,0,7),
(1690342437471,'9A49D8B0-0AA7-480C-A01A-61C21CC3F8EA','The wicker man','Afin d''enquêter sur la disparition d''une jeune fille, le sergent Howie de la police écossaise se rend sur l''île ou vivait la disparue. Là, il découvre l''existence d''une société païenne aux moeurs libres qui pratique un culte étrange. Le policier commence à penser que cette disparition pourrait être liée à des rites sacrificiels.',1973,84,'the_wicker_man.png',10,0,0,7),
(1994269127125,'39BA6E60-B6EA-44F9-8480-82C372B86C21','Titanic','En 1997, l''épave du Titanic est l''objet d''une exploration fiévreuse, menée par des chercheurs de trésor en quête d''un diamant bleu qui se trouvait à bord. Frappée par un reportage télévisé, l''une des rescapées du naufrage, âgée de 102 ans, Rose DeWitt, se rend sur place et évoque ses souvenirs. 1912. Fiancée à un industriel arrogant, Rose croise sur le bateau un artiste sans le sou.',1997,194,'titanic.png',10,0,0,7),
(2956207260552,'CCB240E8-D4AB-4DEE-9AE0-AF1708E2A9DA','La Belle et la Bête','Fille cadette d''un riche marchand, Belle, une jeune fille harcelée par ses soeurs, demande à son père de lui rapporter une rose. Sur le chemin du retour, celui-ci s''égare dans la forêt. Le lendemain matin, il cueille une fleur, ce qui provoque la colère de la Bête, monstre à corps d''homme et tête de lion qui vit reclus dans son château. En compensation de la fleur cueillie, la Bête réclame le sacrifice du marchand ou de l''une de ses filles.',1946,96,'la_belle_et_la_bete.png',10,0,0,7),
(1150162999830,'E0531EBC-C748-46D1-96EF-C57403314B5F','Frankenstein','Henry Frankenstein est un jeune scientifique persuadé de pouvoir rivaliser avec la puissance divine. Il rêve ainsi de façonner une créature humaine. Aidé par son assistant bossu Fritz, il concrétise ce dessein en récupérant des organes et des membres de cadavres. Cependant, l''expérience tourne au cauchemar, son monstre ayant le cerveau d''un criminel. Il échappe au contrôle du savant fou pour commettre plusieurs meurtres.',1931,71,'frankenstein.png',10,0,0,7),
(5869401907294,'00A023DD-A1A6-4F65-A0FB-D2E7CCF792F6','Eyes Wide Shut','Un jeune couple bourgeois vivant à New-York, Bill Harford, médecin, et sa femme, Alice, commissaire d''exposition, se rend à une réception mondaine pour la fête de Noël donnée par un riche patient de Bill.',1999,159,'eyes_wide_shut.png',10,0,0,7),
(4750659889635,'4DD386EC-5876-4717-9D07-D31DB83FB922','Les temps modernes','Des troupeaux de moutons, puis des flots d''ouvriers sortent d''une usine. Charlot fait partie du nombre. Empêtré sur un tapis roulant, il est happé par les rouages d''une énorme machine à manger'', à laquelle il sert de cobaye. Devenu fou, il court dans toute l''usine pour serrer tout ce qui ressemble à un écrou, y compris les boutons de la robe d''une femme.',1936,87,'les_temps_modernes.png',10,0,0,7),
(5022855169270,'4DD386EC-5876-4717-9D07-D31DB83FB922','Le dictateur','En 1918, un humble soldat de Tomania devient amnésique après avoir sauvé la vie de Schultz, un aviateur. Enfermé dans un hôpital psychiatrique, il s''enfuit et regagne sa boutique de barbier, dans le ghetto juif. Il ignore tout des événements politiques et s''en prend à des gardes de Hynkel, le dictateur au pouvoir. Hannah, une voisine, le tire d''affaire. Devenu un personnage puissant, Schultz le protège de l''antisémitisme.',1940,125,'le_dictateur.png',10,0,0,7),
(6044760207082,'4DD386EC-5876-4717-9D07-D31DB83FB922','Le Kid','La mère d''un jeune enfant, ne pouvant le faire vivre, décide de l''abandonner dans la voiture d''une famille fortunée. Deux voyous décident de voler cette voiture. Quelques rues plus loin, les voleurs entendent pleurer le bambin. Ils l''abandonnent dans une ruelle où passe un peu plus tard Charlot, un vitrier miséreux. Gêné par sa découverte, il tente d''abord de s''en défaire, avant de s''attacher à lui. Il l''éduque de son mieux mais les services sociaux s''en mêlent.',1921,68,'le kid.png',10,0,0,7),
(5224880166246,'5853CBFF-B310-4DC3-8442-FE0236EAD37C','Les valseuses','Jean-Claude et Pierrot, deux loubards blagueurs, féroces et désoeuvrés, passent leur temps à bousculer et à chahuter leurs contemporains. Ils prennent un malin plaisir à commettre toutes sortes de petits délits, qui vont du vol à la tire sur un parking de supermarché à celui de voitures. Ce soir-là, c''est précisément celle du coiffeur qui est l''objet de leurs soins malhonnêtes.',1974,125,'les_valseuses.png',10,0,0,7),
(3511159486227,'53DA2BB4-C381-4D83-8FCB-B7C9F1164801','Harry Potter et l''Ordre du Phénix','À sa cinquième année à l''école de sorcellerie de Poudlard, Harry Potter passe pour un illuminé, le ministre de la magie Cornelius Fudge ayant officiellement réfuté les révélations de l''adolescent et de son directeur, Dumbleore, disant que le terrifiant Lord Voldermort est de retour. Une nouvelle professeure à Poudlard refuse d''enseigner les techniques défensives magiques, et Harry crée donc un groupe de résistance clandestin, surnommé l''armée de Dumbledore, à l''image de l''Ordre du Phénix.',2007,138,'harry_potter_et_lordre_du_phenix.png',10,0,0,7),
(8889566740152,'53DA2BB4-C381-4D83-8FCB-B7C9F1164801','Harry Potter et le prince de sang-mêlé','Cette sixième année scolaire de Harry Potter à l''école de sorciers commence par une dispute avec son ennemi juré Draco Malfoy, en qui les forces des ténèbres placent désormais leurs espoirs. Accaparés par les émois et les malentendus amoureux, Hermione et Ron remarquent à peine que Harry enquête à la demande de Dumbledore sur le passé du professeur Slughorn. Entré dans le cercle des intimes de l''enseignant sur la foi de bonnes notes grâce à un manuel scolaire annoté, Harry se rapproche du but.',2009,153,'harry_potter_et_le_prince_de_sang_mele.png',10,0,0,7),
(3465143252644,'53DA2BB4-C381-4D83-8FCB-B7C9F1164801','Harry Potter et les reliques de la mort, partie 1','Sans les conseils et la protection de leurs professeurs, Harry, Ron et Hermione ont pour mission de détruire les horcruxes, les origines de l''immortalité de Voldemort. Bien que plus que jamais ils doivent compter l''un sur l''autre, les forces du mal menacent de les désunir. Les Death Eaters de Voldemort ont pris le contrôle du ministère de la Magie et de Hogwarts et ils recherchent Harry. Aussi Harry et ses amis se préparent pour la dernière confrontation.',2010,146,'harry_potter_et_les_reliques_de_la_mort_1.png',10,0,0,7),
(2404928238478,'53DA2BB4-C381-4D83-8FCB-B7C9F1164801','Harry Potter et les reliques de la mort, partie 2','Dans la deuxième partie de cette finale épique, la bataille entre les forces du bien et celles du mal du monde des magiciens dégénère en une guerre tous azimuts. Les enjeux n''ont jamais été si grands et personne n''est en sécurité. Mais c''est peut-être Harry Potter qui pourrait être appelé à faire le sacrifice ultime alors qu''il se rapproche de la confrontation tant attendue avec Lord Voldemort. Tout se termine ici.',2011,130,'harry_potter_et_les_reliques_de_la_mort_2.png',10,0,0,7);
--select * from Films;


insert into Clients values
('6D75BF3A-E5DB-4345-9999-0112B307DC48','Petit','Michel','michel.petit22@gmail.com','0678349039','15 allée des champs 38400 Saint-Martin-d''Hères','19690812'),
('436ECEAA-5445-4CE4-BDEE-63913AB6637A','Yago','Kevin','kevya@hotmail.fr','0634344909','18 rue des jonquilles 38400 Saint-Martin-d''Hères','20001214'),
('0A7BA1D5-DC2B-44B8-BD75-6E18A63E4823','Jacob','André','jandre@protonmail.com','0633456029','510 rue de la fête 38000 Grenoble','19770104'),
('39157751-09E3-41F0-A24A-8AB4815AA9FA','Gaudiche','Gisèle','gg38000@free.fr','0612244896','1500 rue des prés 38320 Eybens','19951221'),
('BCC5C884-526B-4DB3-813F-923B60AD7615','Martin','Clarisse','clain12@yahoo.fr','0612569039','23 rue du mail 38240 Meylan','19981010'),
('6A01E6E7-1B30-4F43-8632-957822561447','Picault','Jérémy','jeremsco@aol.com','0603450986','12 route du pic 38240 Meylan','19970502'),
('90E4F760-9A40-4B40-89D2-BE76F313CEB2','Massal','Imad','imad.massal@outlook.com','0634093389','34 rue des bains 38400 Saint-Martin-d''Hères','19880808'),
('EEA9CD82-AED7-4865-91F7-CC52EA33BFA8','Alicante','Pedro','pedrito38@tempmail.com','0689431221','67 avenue Jean Jaurès 38000 Grenoble','19660129'),
('03FABC8A-4042-41AD-8554-D77CC0D0B7D2','Cadune','Jean','jeancadune@gmail.com','0600987721','90 rue de la paix 38400 Saint-Martin-d''Hères','19800915'),
('9BF6AA10-CCE2-45B5-8F44-F45D81571334','Cadune','Jeanne','jeannecadune@gmail.com','0723745678','90 rue de la paix 38400 Saint-Martin-d''Hères','19800328');
--select * from Clients;


insert into Langues values
('00E15D80-E027-4F27-8BB2-10C6F859695C','Français (FR)'),
('60A01296-CA9A-4766-88A4-149E19E332E3','Français (sourds et malentendents)'),
('4729E3E2-4B52-4FE3-9665-03898C6FBCC5','Français (québec)'),
('322849DF-AFD5-45AE-AECA-16900AB2F04E','Anglais (EN)'),
('9D961A31-5870-450F-8A64-1C82AC0623A2','Anglais (US)'),
('C26F7BC7-25E9-47A4-B710-635AED9466F6','Anglais'),
('E9DCE115-F917-4288-99E7-F2BFCB75E5C4','Tchèque');
--select * from Langues;


insert into Acteurs values
('AF313D8D-C458-49B0-A191-1C3A32D26D10','Keith David Williams'),
('4A92CB8A-63CD-4A6E-A18A-2269189913C0','Robert De Niro'),
('07E223D4-5838-470C-A74D-30C6C70ECAA1','Joe Pesci'),
('74C30906-6B6F-4248-9EF6-3F3258093A22','Leonardo Di Caprio'),
('2DCA2928-1461-4C06-9A4F-471CDE18AD45','Mark Wahlberg'),
('CF6B1122-22C5-42A9-A7AF-58416E42EF2E','Dwayne "The Rock" Johnson'),
('F0BA9963-8F6D-47B0-9891-5D0C08C5F651','Charlie Chaplin'),
('5E1D0566-E2C4-4E8B-8B4C-6E22DB095231','Tom Cruise'),
('B930F4E5-1CEF-41F3-AF4A-85D6D9714949','Brad Pitt'),
('C9AE4390-1709-4ABA-B18D-90635CB32910','Morgan Freeman'),
('2CE1A8C0-0EC3-41C5-9D6D-93D07914EE70','Kevin Spacey'),
('93CC78FA-27F0-4C08-858C-944663BD86DB','Jim Carrey'),
('F7EF2485-4F3B-4E8F-A644-AA72505339A3','Daniel Radcliff'),
('712485A3-1CF7-455A-9EA9-AAB293578005','Emma Watson'),
('4E2DBC19-5B8D-482A-8704-AF6A635A7648','Harrison Ford'),
('1225B334-A4B7-4082-AB6F-D4132B16235F','Gérard Depardieu'),
('CC628FCF-F860-480C-9FA1-D9D6B0DA6553','Patrick Dewaere'),
('52D38ABD-47AF-4EC8-AE65-E4F6C7873BB1','Christopher Lee'),
('961FF870-0A53-4169-8086-FC1C12E7A15D','Carrie Fisher');
--select * from Acteurs;


insert into Genres values
('EB7994D2-B65D-4E97-B9F3-0E0DFCADF00C','Aventure'),
('9452AED9-2F2B-4EA1-BB49-179BB48BF431','Guerre'),
('037DEAC7-3CD1-4D9C-B35F-2138B9246AD6','Thriller'),
('5DCAEA9C-FF5D-491A-B4D7-3F36D6DDF916','Action'),
('A39A4989-7267-4945-A44C-49EC801F18FB','Drame'),
('255E2464-ED43-40B0-9DC1-56891E9668BB','Comédie dramatique'),
('5903F3CA-C085-4970-A4AE-5F69519736FE','Fiction jeunesse'),
('C319323B-3D42-4996-82EC-615B2FA925FA','Film à énigme'),
('0778EBA7-117E-4B23-8C57-8064B6EC0A1D','Policier'),
('5BF1C284-AAB0-4A40-983D-C39A804579CF','Comedie'),
('86B2BD9E-A83C-4C86-A64C-CB8D85DFE4C9','Science-fiction'),
('BDEE8D4B-94A7-450E-900B-D4C17DF68E1B','Fantastique'),
('45B7540F-57B5-4078-B184-E4DFEB77A0F3','Horreur'),
('BF0CEC93-2D95-4417-AF1F-867253F08828','Romance');
--select * from Genres;


insert into Roles values
(NEWID(),5301241626163,'AF313D8D-C458-49B0-A191-1C3A32D26D10'), --keith david williams dans invasion los angeles
(NEWID(),3177395706277,'AF313D8D-C458-49B0-A191-1C3A32D26D10'), --keith david williams dans the thing
(NEWID(),6253659828850,'4A92CB8A-63CD-4A6E-A18A-2269189913C0'), --de niro dans casino
(NEWID(),6253659828850,'07E223D4-5838-470C-A74D-30C6C70ECAA1'), --joe pesci dans casino
(NEWID(),4058244112342,'4A92CB8A-63CD-4A6E-A18A-2269189913C0'), --de niro dans les affranchis
(NEWID(),4058244112342,'07E223D4-5838-470C-A74D-30C6C70ECAA1'), --joe pesci dans les affranchis
(NEWID(),4228193053883,'74C30906-6B6F-4248-9EF6-3F3258093A22'), --leonardo di caprio dans shutter island
(NEWID(),8159960261656,'4A92CB8A-63CD-4A6E-A18A-2269189913C0'), --de niro dans taxi driver
(NEWID(),9950310497012,'74C30906-6B6F-4248-9EF6-3F3258093A22'), --dicaprio dans le loup de wall street
(NEWID(),4458950971412,'93CC78FA-27F0-4C08-858C-944663BD86DB'), --jim carrey dans the truman show
(NEWID(),8152471772151,'2DCA2928-1461-4C06-9A4F-471CDE18AD45'), --mark wahlberg dans no pain no gain
(NEWID(),8152471772151,'CF6B1122-22C5-42A9-A7AF-58416E42EF2E'), --dwayne johnson dans no pain no gain
(NEWID(),7426631819229,'B930F4E5-1CEF-41F3-AF4A-85D6D9714949'), --brad pitt dans seven
(NEWID(),7426631819229,'C9AE4390-1709-4ABA-B18D-90635CB32910'), --morgan freeman dans seven
(NEWID(),7426631819229,'2CE1A8C0-0EC3-41C5-9D6D-93D07914EE70'), --kevin spacey dans seven
(NEWID(),2968563168925,'B930F4E5-1CEF-41F3-AF4A-85D6D9714949'), --brad pitt dans fight club
(NEWID(),2852087106482,'4E2DBC19-5B8D-482A-8704-AF6A635A7648'), --harisson ford dans les aventuriers de l'arche perdue
(NEWID(),9728766184646,'4E2DBC19-5B8D-482A-8704-AF6A635A7648'), --harisson ford dans star wars 4
(NEWID(),9728766184646,'961FF870-0A53-4169-8086-FC1C12E7A15D'), --carrie fisher dans star wars 4
(NEWID(),3373036534305,'F7EF2485-4F3B-4E8F-A644-AA72505339A3'), --daniel radcliff dans harry potter à l'école des sorciers
(NEWID(),3373036534305,'712485A3-1CF7-455A-9EA9-AAB293578005'), --emma watson dans harry potter à l'école des sorciers
(NEWID(),1690342437471,'52D38ABD-47AF-4EC8-AE65-E4F6C7873BB1'), --christopher lee dans the wicker man
(NEWID(),3289748375461,'52D38ABD-47AF-4EC8-AE65-E4F6C7873BB1'), --christopher lee dans star wars 2
(NEWID(),1364474126405,'52D38ABD-47AF-4EC8-AE65-E4F6C7873BB1'), --christopher lee dans star wars 3
(NEWID(),1994269127125,'74C30906-6B6F-4248-9EF6-3F3258093A22'), --dicaprio dans titanic
(NEWID(),5869401907294,'5E1D0566-E2C4-4E8B-8B4C-6E22DB095231'), --tom cruise dans eyes wide shut
(NEWID(),4750659889635,'F0BA9963-8F6D-47B0-9891-5D0C08C5F651'), --charlie chaplin dans les temps modernes
(NEWID(),5022855169270,'F0BA9963-8F6D-47B0-9891-5D0C08C5F651'), --charlie chaplin dans le dictateur
(NEWID(),6044760207082,'F0BA9963-8F6D-47B0-9891-5D0C08C5F651'), --charlie chaplin dans le kid
(NEWID(),5224880166246,'CC628FCF-F860-480C-9FA1-D9D6B0DA6553'), --patrick dewaere dans les valseuses
(NEWID(),5224880166246,'1225B334-A4B7-4082-AB6F-D4132B16235F'), --gérard depardieu dans les valseuses
(NEWID(),3511159486227,'F7EF2485-4F3B-4E8F-A644-AA72505339A3'), --daniel radcliff dans harry potter et l'ordre du phenix
(NEWID(),3511159486227,'712485A3-1CF7-455A-9EA9-AAB293578005'), --emma watson dans harry potter et l'ordre du phenix
(NEWID(),8889566740152,'F7EF2485-4F3B-4E8F-A644-AA72505339A3'), --daniel radcliff dans harry potter et le prince de sang mele
(NEWID(),8889566740152,'712485A3-1CF7-455A-9EA9-AAB293578005'), --emma watson dans harry potter et le prince de sang mele
(NEWID(),3465143252644,'F7EF2485-4F3B-4E8F-A644-AA72505339A3'), --daniel radcliff dans harry potter et les reliques de la mort pt1
(NEWID(),3465143252644,'712485A3-1CF7-455A-9EA9-AAB293578005'), --emma watson dans harry potter et les reliques de la mort pt1
(NEWID(),2404928238478,'F7EF2485-4F3B-4E8F-A644-AA72505339A3'), --daniel radcliff dans harry potter et les reliques de la mort pt2
(NEWID(),2404928238478,'712485A3-1CF7-455A-9EA9-AAB293578005'); --emma watson dans harry potter et les reliques de la mort pt2
--select * from Roles;


insert into Classifications values
(NEWID(),5301241626163,'86B2BD9E-A83C-4C86-A64C-CB8D85DFE4C9'),--science-fiction'Invasion Los Angeles
(NEWID(),3177395706277,'86B2BD9E-A83C-4C86-A64C-CB8D85DFE4C9'),--science-fiction,'The thing'
(NEWID(),3177395706277,'45B7540F-57B5-4078-B184-E4DFEB77A0F3'),--horreur,'The thing'
(NEWID(),6253659828850,'A39A4989-7267-4945-A44C-49EC801F18FB'),--drame,'Casino'
(NEWID(),4058244112342,'A39A4989-7267-4945-A44C-49EC801F18FB'),--drame,'Les affranchis'
(NEWID(),4228193053883,'037DEAC7-3CD1-4D9C-B35F-2138B9246AD6'),--thriller,'Shutter Island'
(NEWID(),4228193053883,'C319323B-3D42-4996-82EC-615B2FA925FA'),--film à enigme,'Shutter Island'
(NEWID(),8159960261656,'A39A4989-7267-4945-A44C-49EC801F18FB'),--drame,'Taxi Driver'
(NEWID(),8159960261656,'0778EBA7-117E-4B23-8C57-8064B6EC0A1D'),--policier,'Taxi Driver'
(NEWID(),9950310497012,'255E2464-ED43-40B0-9DC1-56891E9668BB'),--comedie dramatique 'Le loup de Wall Street'
(NEWID(),9950310497012,'0778EBA7-117E-4B23-8C57-8064B6EC0A1D'),--policier 'Le loup de Wall Street'
(NEWID(),4458950971412,'255E2464-ED43-40B0-9DC1-56891E9668BB'),--comedie dramatique,'The Truman Show'
(NEWID(),8152471772151,'5DCAEA9C-FF5D-491A-B4D7-3F36D6DDF916'),--action,'No pain no gain'
(NEWID(),8152471772151,'255E2464-ED43-40B0-9DC1-56891E9668BB'),--comedie dramatique,'No pain no gain'
(NEWID(),8152471772151,'0778EBA7-117E-4B23-8C57-8064B6EC0A1D'),--policier,'No pain no gain'
(NEWID(),7426631819229,'A39A4989-7267-4945-A44C-49EC801F18FB'),--drame,'Seven'
(NEWID(),7426631819229,'0778EBA7-117E-4B23-8C57-8064B6EC0A1D'),--policier,'Seven'
(NEWID(),7426631819229,'037DEAC7-3CD1-4D9C-B35F-2138B9246AD6'),--thriller,'Seven'
(NEWID(),7426631819229,'C319323B-3D42-4996-82EC-615B2FA925FA'),--film à énigme,'Seven'
(NEWID(),2968563168925,'5DCAEA9C-FF5D-491A-B4D7-3F36D6DDF916'),--action,'Fight club'
(NEWID(),2852087106482,'EB7994D2-B65D-4E97-B9F3-0E0DFCADF00C'),--aventure,'Les Aventuriers de l''Arche Perdue'
(NEWID(),2852087106482,'5DCAEA9C-FF5D-491A-B4D7-3F36D6DDF916'),--action,'Les Aventuriers de l''Arche Perdue'
(NEWID(),9728766184646,'86B2BD9E-A83C-4C86-A64C-CB8D85DFE4C9'),--science-fiction,'Star Wars 4 : La guerre des étoiles'
(NEWID(),9728766184646,'EB7994D2-B65D-4E97-B9F3-0E0DFCADF00C'),--aventure,'Star Wars 4 : La guerre des étoiles'
(NEWID(),9728766184646,'5DCAEA9C-FF5D-491A-B4D7-3F36D6DDF916'),--action,'Star Wars 4 : La guerre des étoiles'
(NEWID(),1078789698344,'86B2BD9E-A83C-4C86-A64C-CB8D85DFE4C9'),--science-fiction,'Star Wars 1 : La Menace fantôme'
(NEWID(),1078789698344,'EB7994D2-B65D-4E97-B9F3-0E0DFCADF00C'),--aventure,'Star Wars 1 : La Menace fantôme'
(NEWID(),1078789698344,'5DCAEA9C-FF5D-491A-B4D7-3F36D6DDF916'),--action,'Star Wars 1 : La Menace fantôme'
(NEWID(),3289748375461,'86B2BD9E-A83C-4C86-A64C-CB8D85DFE4C9'),--science-fiction,'Star Wars 2 : L''Attaque des clones'
(NEWID(),3289748375461,'EB7994D2-B65D-4E97-B9F3-0E0DFCADF00C'),--aventure,'Star Wars 2 : L''Attaque des clones'
(NEWID(),3289748375461,'5DCAEA9C-FF5D-491A-B4D7-3F36D6DDF916'),--action,'Star Wars 2 : L''Attaque des clones'
(NEWID(),1364474126405,'86B2BD9E-A83C-4C86-A64C-CB8D85DFE4C9'),--science-fiction,'Star Wars 3 : La Revanche des Sith'
(NEWID(),1364474126405,'EB7994D2-B65D-4E97-B9F3-0E0DFCADF00C'),--aventure,'Star Wars 3 : La Revanche des Sith'
(NEWID(),1364474126405,'5DCAEA9C-FF5D-491A-B4D7-3F36D6DDF916'),--action,'Star Wars 3 : La Revanche des Sith'
(NEWID(),3373036534305,'5903F3CA-C085-4970-A4AE-5F69519736FE'),--fiction jeunesse,'Harry Potter à l''école des sorciers'
(NEWID(),3373036534305,'EB7994D2-B65D-4E97-B9F3-0E0DFCADF00C'),--aventure,'Harry Potter à l''école des sorciers'
(NEWID(),3373036534305,'BDEE8D4B-94A7-450E-900B-D4C17DF68E1B'),--fantastique,'Harry Potter à l''école des sorciers'
(NEWID(),6101641603783,'255E2464-ED43-40B0-9DC1-56891E9668BB'),--comedie dramatique,'Les petites marguerites'
(NEWID(),1690342437471,'86B2BD9E-A83C-4C86-A64C-CB8D85DFE4C9'),--horreur,'The wicker man'
(NEWID(),1690342437471,'C319323B-3D42-4996-82EC-615B2FA925FA'),--film à énigme,'The wicker man'
(NEWID(),1994269127125,'A39A4989-7267-4945-A44C-49EC801F18FB'),--drame,'Titanic'
(NEWID(),1994269127125,'BF0CEC93-2D95-4417-AF1F-867253F08828'),--romance,'Titanic'
(NEWID(),2956207260552,'A39A4989-7267-4945-A44C-49EC801F18FB'),--drame,'La Belle et la Bête'
(NEWID(),1150162999830,'86B2BD9E-A83C-4C86-A64C-CB8D85DFE4C9'),--horreur,'Frankenstein'
(NEWID(),1150162999830,'86B2BD9E-A83C-4C86-A64C-CB8D85DFE4C9'),--science-fiction,'Frankenstein'
(NEWID(),5869401907294,'A39A4989-7267-4945-A44C-49EC801F18FB'),--drame,'Eyes Wide Shut'
(NEWID(),4750659889635,'5BF1C284-AAB0-4A40-983D-C39A804579CF'),--comedie ,'Les temps modernes'
(NEWID(),5022855169270,'9452AED9-2F2B-4EA1-BB49-179BB48BF431'),--guerre,'Le dictateur'
(NEWID(),5022855169270,'5BF1C284-AAB0-4A40-983D-C39A804579CF'),--comedie,'Le dictateur'
(NEWID(),6044760207082,'5BF1C284-AAB0-4A40-983D-C39A804579CF'),--comedie,'Le Kid'
(NEWID(),5224880166246,'5BF1C284-AAB0-4A40-983D-C39A804579CF'),--comedie,'Les valseuses'
(NEWID(),5224880166246,'0778EBA7-117E-4B23-8C57-8064B6EC0A1D'),--policier,'Les valseuses'
(NEWID(),3511159486227,'5903F3CA-C085-4970-A4AE-5F69519736FE'),--fiction jeunesse,'Harry Potter et l''Ordre du Phénix'
(NEWID(),3511159486227,'EB7994D2-B65D-4E97-B9F3-0E0DFCADF00C'),--aventure,'Harry Potter et l''Ordre du Phénix'
(NEWID(),3511159486227,'BDEE8D4B-94A7-450E-900B-D4C17DF68E1B'),--fantastique,'Harry Potter et l''Ordre du Phénix'
(NEWID(),8889566740152,'5903F3CA-C085-4970-A4AE-5F69519736FE'),--fiction jeunesse,'Harry Potter et le prince de sang-mêlé'
(NEWID(),8889566740152,'EB7994D2-B65D-4E97-B9F3-0E0DFCADF00C'),--aventure,'Harry Potter et le prince de sang-mêlé'
(NEWID(),8889566740152,'BDEE8D4B-94A7-450E-900B-D4C17DF68E1B'),--fantastique,'Harry Potter et le prince de sang-mêlé'
(NEWID(),3465143252644,'5903F3CA-C085-4970-A4AE-5F69519736FE'),--fiction jeunesse,'Harry Potter et les reliques de la mort, partie 1'
(NEWID(),3465143252644,'EB7994D2-B65D-4E97-B9F3-0E0DFCADF00C'),--aventure,'Harry Potter et les reliques de la mort, partie 1'
(NEWID(),3465143252644,'BDEE8D4B-94A7-450E-900B-D4C17DF68E1B'),--fantastique jeunesse,'Harry Potter et les reliques de la mort, partie 1'
(NEWID(),2404928238478,'5903F3CA-C085-4970-A4AE-5F69519736FE'),--fiction jeunesse,'Harry Potter et les reliques de la mort, partie 2'
(NEWID(),2404928238478,'EB7994D2-B65D-4E97-B9F3-0E0DFCADF00C'),--aventure,'Harry Potter et les reliques de la mort, partie 2'
(NEWID(),2404928238478,'BDEE8D4B-94A7-450E-900B-D4C17DF68E1B');--fantastique,'Harry Potter et les reliques de la mort, partie 2'
--select * from Classifications;


insert into Locations values
(NEWID(),'6D75BF3A-E5DB-4345-9999-0112B307DC48',1994269127125,0,'20220107','20250107'),-- michel petit, Titanic, emprunt non rendu sur 3 ans
(NEWID(),'6D75BF3A-E5DB-4345-9999-0112B307DC48',5022855169270,1,'20220107','20220207'),-- michel petit, Le dictateur, emprunt rendu d'un mois
(NEWID(),'436ECEAA-5445-4CE4-BDEE-63913AB6637A',5301241626163,1,'20220107','20220114'),-- kevin yago, invasion Los Angeles, emprunt rendu d'une semaine
(NEWID(),'436ECEAA-5445-4CE4-BDEE-63913AB6637A',1078789698344,0,'20220107','20230107'),-- kevin yago, star wars 1, emprunt non rendu sur 1 an
(NEWID(),'436ECEAA-5445-4CE4-BDEE-63913AB6637A',2404928238478,1,'20220212','20220312'),-- kevin yago, harry potter et les reliques de la mort, emprunt rendu d'un mois
(NEWID(),'436ECEAA-5445-4CE4-BDEE-63913AB6637A',1994269127125,0,'20220901','20230901'),-- kevin yago, Titanic, emprunt non rendu d'un mois
(NEWID(),'436ECEAA-5445-4CE4-BDEE-63913AB6637A',1690342437471,0,'20220107','20250107'),-- kevin yago, the wicker man, emprunt non rendu sur 3 ans
(NEWID(),'436ECEAA-5445-4CE4-BDEE-63913AB6637A',5869401907294,1,'20220107','20220207'),-- kevin yago, eyes wide shut, emprunt rendu d'un mois
(NEWID(),'0A7BA1D5-DC2B-44B8-BD75-6E18A63E4823',4750659889635,1,'20221026','20221110'),-- jacob andre, les temps modernes, emprunt rendu de 2 semaines 
(NEWID(),'0A7BA1D5-DC2B-44B8-BD75-6E18A63E4823',5022855169270,1,'20221026','20221110'),-- jacob andre, le dictateur, emprunt rendu de 2 semaines
(NEWID(),'0A7BA1D5-DC2B-44B8-BD75-6E18A63E4823',6044760207082,1,'20221026','20221110'),-- jacob andre, le kid, emprunt rendu de 2 semaines
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',5301241626163,1,'20210929','20211113'),-- gisele gaudiche, invasion los angeles, emprunt rendu de 2 semaines 
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',1994269127125,1,'20210929','20211113'),-- gisele gaudiche, Titanic, emprunt rendu de 2 semaines
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',1994269127125,0,'20221126','20231126'),-- gisele gaudiche, Titanic, emprunt non rendu de 1 an
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',5224880166246,1,'20221026','20221110'),-- gisele gaudiche, les valseuses, emprunt rendu de 2 semaines 
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',7426631819229,1,'20221026','20221110'),-- gisele gaudiche, seven, emprunt rendu de 2 semaines
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',2968563168925,1,'20221026','20221110'),-- gisele gaudiche, fight club, emprunt rendu de 2 semaines mois
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',8159960261656,1,'20221026','20221110'),-- gisele gaudiche, taxi driver, emprunt rendu de 2 semaines
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',6044760207082,1,'20221026','20221110'),-- gisele gaudiche, le kid, emprunt rendu de 2 semaines
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',4750659889635,1,'20221026','20221110'),-- gisele gaudiche, les temps modernes, emprunt rendu de 2 semaines mois
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',1150162999830,1,'20221026','20221110'),-- gisele gaudiche, frankenstein, emprunt rendu de 2 semaines
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',2956207260552,1,'20221026','20221110'),-- gisele gaudiche, la belle et la bete, emprunt rendu de 2 semaines mois
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',6253659828850,1,'20221026','20221110'),-- gisele gaudiche, casino, emprunt rendu de 2 semaines
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',6253659828850,0,'20221126','20231126'),-- gisele gaudiche, casino, emprunt non rendu de 1 an
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',4458950971412,1,'20221026','20221110'),-- gisele gaudiche, the truman show, emprunt rendu de 2 semaines mois
(NEWID(),'39157751-09E3-41F0-A24A-8AB4815AA9FA',3177395706277,1,'20221026','20221110'),-- gisele gaudiche, the thing, emprunt rendu de 2 semaines
(NEWID(),'BCC5C884-526B-4DB3-813F-923B60AD7615',3177395706277,1,'20220107','20220114'),-- clarisse martin, the thing, emprunt rendu d'une semaine
(NEWID(),'BCC5C884-526B-4DB3-813F-923B60AD7615',5301241626163,0,'20220107','20230114'),-- clarisse martin, invasion Los Angeles, emprunt non rendu d'un an
(NEWID(),'BCC5C884-526B-4DB3-813F-923B60AD7615',1994269127125,0,'20220107','20230114'),-- clarisse martin, titanic, emprunt non rendu d'un an
(NEWID(),'BCC5C884-526B-4DB3-813F-923B60AD7615',6101641603783,0,'20220107','20230114'),-- clarisse martin, les petites marguerites, emprunt non rendu d'un an
(NEWID(),'BCC5C884-526B-4DB3-813F-923B60AD7615',4058244112342,0,'20220107','20230114'),-- clarisse martin, les affranchis, emprunt non rendu d'un an
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',9728766184646,1,'20210929','20211113'),-- jeremy picault, star wars 4, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',1078789698344,1,'20210929','20211113'),-- jeremy picault, star wars 1, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',3289748375461,1,'20210929','20211113'),-- jeremy picault, star wars 2, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',1364474126405,1,'20210929','20211113'),-- jeremy picault, star wars 3, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',9728766184646,0,'20210929','20231113'),-- jeremy picault, star wars 4, emprunt non rendu de 2 ans 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',1078789698344,0,'20210929','20231113'),-- jeremy picault, star wars 1, emprunt non rendu de 2 ans 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',3289748375461,0,'20210929','20231113'),-- jeremy picault, star wars 2, emprunt non rendu de 2 ans 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',1364474126405,0,'20210929','20231113'),-- jeremy picault, star wars 3, emprunt non rendu de 2 ans 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',3373036534305,1,'20210529','20210613'),-- jeremy picault, harry potter à l'école des sorciers, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',3511159486227,1,'20210529','20210613'),-- jeremy picault, harry potter et l'ordre du phenix, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',8889566740152,1,'20210529','20210613'),-- jeremy picault, harry potter et le prince de sang mele, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',3465143252644,1,'20210529','20210613'),-- jeremy picault, harry potter et les reliques de la mort pt1, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',2404928238478,1,'20210529','20210613'),-- jeremy picault, harry potter et les reliques de la mort pt2, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',3373036534305,0,'20210529','20230613'),-- jeremy picault, harry potter à l'école des sorciers, emprunt non rendu de 2 ans 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',3511159486227,0,'20210529','20230613'),-- jeremy picault, harry potter et l'ordre du phenix, emprunt  nonrendu de 2 ans 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',8889566740152,0,'20210529','20230613'),-- jeremy picault, harry potter et le prince de sang mele, emprunt non rendu de 2 ans 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',3465143252644,0,'20210529','20230613'),-- jeremy picault, harry potter et les reliques de la mort pt1, emprunt non rendu de 2 ans 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',2404928238478,0,'20210529','20230613'),-- jeremy picault, harry potter et les reliques de la mort pt2, emprunt non rendu de 2 ans 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',5301241626163,1,'20210929','20211013'),-- jeremy picault, invasion los angeles, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',4228193053883,1,'20220329','20220413'),-- jeremy picault, shutter island, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',8159960261656,1,'20220329','20220413'),-- jeremy picault, taxi driver, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',4458950971412,1,'20220329','20220413'),-- jeremy picault, the truman show, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',8152471772151,1,'20220329','20220413'),-- jeremy picault, no pain no gain, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',2968563168925,1,'20220329','20220413'),-- jeremy picault, fight club, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',9950310497012,1,'20220329','20220413'),-- jeremy picault, le loup de wall street, emprunt rendu de 2 semaines 
(NEWID(),'6A01E6E7-1B30-4F43-8632-957822561447',2852087106482,1,'20220329','20220413'),-- jeremy picault, les aventuriers de l'arche perdue, emprunt rendu de 2 semaines 
(NEWID(),'90E4F760-9A40-4B40-89D2-BE76F313CEB2',2852087106482,1,'20220329','20220413'),-- imad massal, les aventuriers de l'arche perdue, emprunt rendu de 2 semaines 
(NEWID(),'90E4F760-9A40-4B40-89D2-BE76F313CEB2',1994269127125,1,'20220329','20220413'),-- imad massal, titanic, emprunt rendu de 2 semaines 
(NEWID(),'90E4F760-9A40-4B40-89D2-BE76F313CEB2',2956207260552,1,'20220329','20220413'),-- imad massal, la belle et la bete, emprunt rendu de 2 semaines 
(NEWID(),'90E4F760-9A40-4B40-89D2-BE76F313CEB2',1150162999830,1,'20220329','20220413'),-- imad massal, frankenstein, emprunt rendu de 2 semaines 
(NEWID(),'90E4F760-9A40-4B40-89D2-BE76F313CEB2',4458950971412,1,'20220329','20220413'),-- imad massal, the truman show, emprunt rendu de 2 semaines 
(NEWID(),'90E4F760-9A40-4B40-89D2-BE76F313CEB2',6253659828850,1,'20220329','20220413'),-- imad massal, casino, emprunt rendu de 2 semaines 
(NEWID(),'90E4F760-9A40-4B40-89D2-BE76F313CEB2',3177395706277,1,'20220329','20220413'),-- imad massal, the thing, emprunt rendu de 2 semaines 
(NEWID(),'EEA9CD82-AED7-4865-91F7-CC52EA33BFA8',1364474126405,1,'20220107','20220207'),-- pedro alicante, star wars 3, emprunt rendu d'un mois
(NEWID(),'9BF6AA10-CCE2-45B5-8F44-F45D81571334',5301241626163,1,'20220107','20220207'),-- jeanne cadune, star wars 3, emprunt rendu d'un mois
(NEWID(),'9BF6AA10-CCE2-45B5-8F44-F45D81571334',1364474126405,1,'20220107','20220207'),-- jeanne cadune, invasion los angeles, emprunt rendu d'un mois
(NEWID(),'9BF6AA10-CCE2-45B5-8F44-F45D81571334',1994269127125,1,'20220107','20220207'),-- jeanne cadune, titanic, emprunt rendu d'un mois
(NEWID(),'9BF6AA10-CCE2-45B5-8F44-F45D81571334',3177395706277,1,'20220107','20220207');-- jeanne cadune, the thing, emprunt rendu d'un mois
--select * from Locations;


insert into [Sous_titrages] values
(NEWID(),5301241626163,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,'Invasion Los Angeles
(NEWID(),5301241626163,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,'Invasion Los Angeles
(NEWID(),5301241626163,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,'Invasion Los Angeles
(NEWID(),3177395706277,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,'The thing'
(NEWID(),3177395706277,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,'The thing'
(NEWID(),3177395706277,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,'The thing'
(NEWID(),6253659828850,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Casino
(NEWID(),6253659828850,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Casino
(NEWID(),6253659828850,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Casino
(NEWID(),4058244112342,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Les affranchis
(NEWID(),4058244112342,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Les affranchis
(NEWID(),4058244112342,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Les affranchis
(NEWID(),4228193053883,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Shutter island
(NEWID(),4228193053883,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Shutter island
(NEWID(),4228193053883,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Shutter island
(NEWID(),8159960261656,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Taxi driver
(NEWID(),8159960261656,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Taxi driver
(NEWID(),8159960261656,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Taxi driver
(NEWID(),9950310497012,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Le loup de wall street
(NEWID(),9950310497012,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Le loup de wall street
(NEWID(),9950310497012,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Le loup de wall street
(NEWID(),4458950971412,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,The truman show
(NEWID(),4458950971412,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,The truman show
(NEWID(),4458950971412,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,The truman show
(NEWID(),8152471772151,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,'No pain no gain'
(NEWID(),8152471772151,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,'No pain no gain'
(NEWID(),8152471772151,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,'No pain no gain'
(NEWID(),7426631819229,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Seven
(NEWID(),7426631819229,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Seven
(NEWID(),7426631819229,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Seven
(NEWID(),2968563168925,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Fight club
(NEWID(),2968563168925,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Fight club
(NEWID(),2968563168925,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Fight club
(NEWID(),2852087106482,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,les aventuriers de l'arche perdue
(NEWID(),2852087106482,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,les aventuriers de l'arche perdue
(NEWID(),2852087106482,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,les aventuriers de l'arche perdue
(NEWID(),9728766184646,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,star wars 4
(NEWID(),9728766184646,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,star wars 4
(NEWID(),9728766184646,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,star wars 4
(NEWID(),1078789698344,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,star wars 1
(NEWID(),1078789698344,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,star wars 1
(NEWID(),1078789698344,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,star wars 1
(NEWID(),3289748375461,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,star wars 2
(NEWID(),3289748375461,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,star wars 2
(NEWID(),3289748375461,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,star wars 2
(NEWID(),1364474126405,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,star wars 3
(NEWID(),1364474126405,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,star wars 3
(NEWID(),1364474126405,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,star wars 3
(NEWID(),3373036534305,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,harry potter à l'école des sorciers
(NEWID(),3373036534305,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,harry potter à l'école des sorciers
(NEWID(),3373036534305,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,harry potter à l'école des sorciers
(NEWID(),3373036534305,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,harry potter à l'école des sorciers
(NEWID(),3373036534305,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,harry potter à l'école des sorciers
(NEWID(),3373036534305,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,harry potter à l'école des sorciers
(NEWID(),6101641603783,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Les petites marguerites
(NEWID(),6101641603783,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Les petites marguerites
(NEWID(),6101641603783,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Les petites marguerites
(NEWID(),6101641603783,'E9DCE115-F917-4288-99E7-F2BFCB75E5C4'),--CZ,Les petites marguerites
(NEWID(),1690342437471,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,The wicker man
(NEWID(),1690342437471,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,The wicker man
(NEWID(),1690342437471,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,The wicker man
(NEWID(),1994269127125,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Titanic
(NEWID(),1994269127125,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Titanic
(NEWID(),1994269127125,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Titanic
(NEWID(),2956207260552,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,La Belle et la Bête
(NEWID(),2956207260552,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,La Belle et la Bête
(NEWID(),1150162999830,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Frankenstein
(NEWID(),1150162999830,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Frankenstein
(NEWID(),1150162999830,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Frankenstein
(NEWID(),5869401907294,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Eyes Wide Shut
(NEWID(),5869401907294,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Eyes Wide Shut
(NEWID(),5869401907294,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Eyes Wide Shut
(NEWID(),4750659889635,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Les temps modernes
(NEWID(),4750659889635,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Les temps modernes
(NEWID(),4750659889635,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Les temps modernes
(NEWID(),5022855169270,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Le dictateur
(NEWID(),5022855169270,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Le dictateur
(NEWID(),5022855169270,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Le dictateur
(NEWID(),6044760207082,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Le kid
(NEWID(),6044760207082,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Le kid
(NEWID(),6044760207082,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Le kid
(NEWID(),5224880166246,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Les valseuses
(NEWID(),5224880166246,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Les valseuses
(NEWID(),3511159486227,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Harry Potter et l''Ordre du Phénix
(NEWID(),3511159486227,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Harry Potter et l''Ordre du Phénix
(NEWID(),3511159486227,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Harry Potter et l''Ordre du Phénix
(NEWID(),8889566740152,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Harry Potter et le prince de sang-mêlé
(NEWID(),8889566740152,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Harry Potter  et le prince de sang-mêlé
(NEWID(),8889566740152,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Harry Potter et le prince de sang-mêlé
(NEWID(),3465143252644,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Harry Potter et les reliques de la mort, partie 1
(NEWID(),3465143252644,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Harry Potter et les reliques de la mort, partie 1
(NEWID(),3465143252644,'C26F7BC7-25E9-47A4-B710-635AED9466F6'),--EN,Harry Potter et les reliques de la mort, partie 1
(NEWID(),2404928238478,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Harry Potter et les reliques de la mort, partie 2
(NEWID(),2404928238478,'60A01296-CA9A-4766-88A4-149E19E332E3'),--FRSM,Harry Potter et les reliques de la mort, partie 2
(NEWID(),2404928238478,'C26F7BC7-25E9-47A4-B710-635AED9466F6');--EN,Harry Potter et les reliques de la mort, partie 2
--select * from [Sous_titrages];

insert into Voix values
(NEWID(),5301241626163,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,'Invasion Los Angeles
(NEWID(),5301241626163,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,'Invasion Los Angeles
(NEWID(),3177395706277,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,'The thing'
(NEWID(),3177395706277,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,'The thing'
(NEWID(),6253659828850,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Casino
(NEWID(),6253659828850,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Casino
(NEWID(),4058244112342,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Les affranchis
(NEWID(),4058244112342,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Les affranchis
(NEWID(),4228193053883,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Shutter island
(NEWID(),4228193053883,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Shutter island
(NEWID(),8159960261656,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Taxi driver
(NEWID(),8159960261656,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Taxi driver
(NEWID(),9950310497012,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Le loup de wall street
(NEWID(),9950310497012,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Le loup de wall street
(NEWID(),4458950971412,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,The truman show
(NEWID(),4458950971412,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,The truman show
(NEWID(),8152471772151,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,'No pain no gain'
(NEWID(),8152471772151,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,'No pain no gain'
(NEWID(),7426631819229,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Seven
(NEWID(),7426631819229,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Seven
(NEWID(),2968563168925,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Fight club
(NEWID(),2968563168925,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Fight club
(NEWID(),2852087106482,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,les aventuriers de l'arche perdue
(NEWID(),2852087106482,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,les aventuriers de l'arche perdue
(NEWID(),9728766184646,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,star wars 4
(NEWID(),9728766184646,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,star wars 4
(NEWID(),1078789698344,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,star wars 1
(NEWID(),1078789698344,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,star wars 1
(NEWID(),3289748375461,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,star wars 2
(NEWID(),3289748375461,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,star wars 2
(NEWID(),1364474126405,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,star wars 3
(NEWID(),1364474126405,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,star wars 3
(NEWID(),3373036534305,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,harry potter à l'école des sorciers
(NEWID(),3373036534305,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,harry potter à l'école des sorciers
(NEWID(),3373036534305,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,harry potter à l'école des sorciers
(NEWID(),6101641603783,'E9DCE115-F917-4288-99E7-F2BFCB75E5C4'),--CZ,Les petites marguerites
(NEWID(),1690342437471,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,The wicker man
(NEWID(),1690342437471,'322849DF-AFD5-45AE-AECA-16900AB2F04E'),--ENEN,The wicker man
(NEWID(),1994269127125,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Titanic
(NEWID(),1994269127125,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Titanic
(NEWID(),1994269127125,'4729E3E2-4B52-4FE3-9665-03898C6FBCC5'),--FRQ,Titanic
(NEWID(),2956207260552,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,La Belle et la Bête
(NEWID(),1150162999830,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Frankenstein
(NEWID(),1150162999830,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Frankenstein
(NEWID(),5869401907294,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Eyes Wide Shut
(NEWID(),5869401907294,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Eyes Wide Shut
(NEWID(),4750659889635,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Les temps modernes
(NEWID(),5224880166246,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Les valseuses
(NEWID(),3511159486227,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Harry Potter et l''Ordre du Phénix
(NEWID(),3511159486227,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Harry Potter et l''Ordre du Phénix
(NEWID(),8889566740152,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Harry Potter et le prince de sang-mêlé
(NEWID(),8889566740152,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Harry Potter et le prince de sang-mêlé
(NEWID(),3465143252644,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Harry Potter et les reliques de la mort, partie 1
(NEWID(),3465143252644,'9D961A31-5870-450F-8A64-1C82AC0623A2'),--ENUS,Harry Potter et les reliques de la mort, partie 1
(NEWID(),2404928238478,'00E15D80-E027-4F27-8BB2-10C6F859695C'),--FR,Harry Potter et les reliques de la mort, partie 2
(NEWID(),2404928238478,'9D961A31-5870-450F-8A64-1C82AC0623A2');--ENUS,Harry Potter et les reliques de la mort, partie 2
--select * from Voix;

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
