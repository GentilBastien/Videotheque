   M S B A M L   `   `   `  ????H  DMaVideotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MaVideotheque.ComponentsMaVideotheque.Components  5      9!clr-namespace:MaVideotheque.ViewsMaVideotheque.Views  5      ;"clr-namespace:MaVideotheque.ModalsMaVideotheque.Modals  5      &     MaVideotheque.Views.LocationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7comp&clr-namespace:MaVideotheque.Components     5      3local!clr-namespace:MaVideotheque.Views     5      5modals"clr-namespace:MaVideotheque.Modals     5      .??5      ? -   5          ?Name$  LocationMainContainer??5      .+?5   
   ?  ? RowDefinitions 5      ?? 5      $
??Auto ?6    ?? 5      $
??Auto ?6    ?? 5      $??* ?6    .+?5      ]? $??0??6   .+?5      ?? $	??Top=?6   $??Détail de location??6-   $??36(?6J   ?? 5      $??Bottom=?6    ?? Orientation$ 
Horizontal=?65   .+?5      *   $MaVideotheque.Components.BasicBouton  -   5          Name$ BtnCancelLocation??5   '   *   $MaVideotheque.Components.BasicBouton!   PreviewMouseLeftButtonDown$2 ,BtnCancelLocation_PreviewMouseLeftButtonDown??6]      Contenu$ Annuler location??6B   6]     5      -   5        $ BtnEditLocation??5   '   $0 *BtnEditLocation_PreviewMouseLeftButtonDown??6Z   $ Éditer location??6@   6Z     5      -   5        $ BtnMajLocation??5   '   $/ )BtnMajLocation_PreviewMouseLeftButtonDown??6`   $ Mettre à jour location??6?   6`     5      -   5        $ BtnActualiser??5   '   $. (BtnActualiser_PreviewMouseLeftButtonDown??6[   $ Actualiser la page??6>   6[   5      ? 5      $??0,0,0,0q?6    ? ColumnDefinitions 5      ?? 5       $??4* ?6+   ?? 5!      $??4* ?6+   .+?5#      ?? $??0??6!   .+?5$      ?? $??Num. location ??6    $??20(?69   $
??Bold"?6G   ?? 5%      -   5        $??TopIdLoc??5%       $??4896321??60   $??12(?6B   $??	0,-10,0,0q?6P   ?? 5&      $??Code barre film??6    $??20(?6:   $
??Bold"?6H   ?? 5'      -   5        $??TopCodeBarre??5'       $??CNDSJ2DDFFCLO??64   $??12(?6L   $??	0,-10,0,0q?6Z   ?? 5(      $??
Titre film??6    $??20(?65   $
??Bold"?6C   ?? 5)      -   5        $??TopTitreFilm??5)       $:??4Le Seigneur des Anneaux : La communauté de l'anneau??64   $??12(?6r   $??	0,-10,0,0q?6?   ?? 5*      $??
Id client ??6    $??20(?65   $
??Bold"?6C   ?? 5+      -	   5        $??TopIdClient??5+       $??489528??64   $??12(?6E   $??	0,-10,0,0q?6S   ?? 5,      $??
Nom client??6    $??20(?65   $
??Bold"?6C   ?? 5-      -
   5        $??TopNomClient??5-       $??Roissy Pierre??65   $??12(?6M   $??	0,-10,0,0q?6[   5.      ?? 5/      $??1??6!   .+?50      ?? $??Date début location??6    $??20(?6>   $
??Bold"?6L   ?? 51      -   5        $??TopDateDebut??51       $??
12/05/2010??64   $??12(?6I   ?? 52      $??Date fin location??6    $??20(?6<   $
??Bold"?6J   ?? 53      -   5        $??
TopDateFin??53       $??
12/05/2010??62   $??12(?6G   ?? 54      $??
Prix payé??6    $??20(?64   $
??Bold"?6B   ?? 55      -   5        $??TopPrix??55       $??13€??6/   $??12(?6=   ?? 56      $??État de la location??6    $??20(?6>   $
??Bold"?6L   ?? 57      -   5        $??myState??57   %   58      59      5:      ?? 5=      $??1??6   $??Stretch=?6(   $??Center=?6F   
??????? ?? ShowsPreview .  ?? ResizeDirection$
 Rows=?6?   $??2??6?   ? 5>      $??1??6   $??	0,30,18,0q?6     5?      ?? 5@      $??0.45* ?6'   ?? 5A      $
??1.7* ?6'   ?? 5B      $
??0.8* ?6'   ?? 5C      $??1* ?6'   ?? 5D      $??1* ?6'   ?? 5E      $
??0.5* ?6'   ?? 5F      $??1* ?6'   .+?5H      ?? $??0??6   $
??Bold"?6(   $??Num. Location??6:   ?? 5I      $??1??6   $
??Bold"?6(   $??
Titre film??6:   ?? 5J      $??2??6   $
??Bold"?6(   $??
Nom client??6:   ?? 5K      $??3??6   $
??Bold"?6(   $??Date début??6:   ?? 5L      $??4??6   $
??Bold"?6(   $??Date fin??6:   ?? 5M      $??5??6   $
??Bold"?6(   $
??Prix??6:   ?? 5N      $??6??6   $
??Bold"?6(   $??État??6:   5O      ?? 5P      $??2??6   .??5Q      ?? -   5        $??
MyStackLoc??5Q      5R      5S      5T      5U      5V      