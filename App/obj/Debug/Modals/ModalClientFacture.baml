   M S B A M L   `   `   `  ????H  DMaVideotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MaVideotheque.ModalsMaVideotheque.Modals  5      C&clr-namespace:MaVideotheque.ComponentsMaVideotheque.Components  5      -    'MaVideotheque.Modals.ModalClientFacture   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:MaVideotheque.Modals     5      7comp&clr-namespace:MaVideotheque.Components     5      .??5	      ? .+?5
   
   ?? -   5        
???   ?  J? Opacity$	  0.2Q?5
   !   6/   ?? 5   
    ?? CornerRadius$ 10??6   
???????$	??350??66   $	??800??6C   ._?5      ? $
??10 0q?6    ? RowDefinitions 5      ?? 5      $??* ?6$   ?? 5      $??58 ?6$   .+?5      ?? -   5        $??	mainStack??5   *   $??0??6   .+?5      ?? $??36(?66   $??Calibri)?6D   ??6   ?? *Titre+6D   ?? 5      $??Historique des location??6   $??20(?6>   $??Calibri)?6L   ? 5      $??50 0 0 0q?6    ? ColumnDefinitions 5      ?? 5      $??1* ?6/   ?? 5      $??1* ?6/   ?? 5      $??1* ?6/   ?? 5      $??1* ?6/   ?? 5      $??1* ?6/   .+?5      ?? $??0??6    $
??Bold"?60   $??Film id??6B   ?? 5      $??1??6    $
??Bold"?60   $??
Titre film??6B   ?? 5      $??2??6    $
??Bold"?60   $??Date début location??6B   ?? 5       $??3??6    $
??Bold"?60   $??Date fin location??6B   ?? 5!      $??4??6    $
??Bold"?60   $??Rendu??6B   5#      ?? 5$      $	??180??6#   .??5%      ?? -   5         ??Name$ myStack??5%   %    ?? Orientation$ 
Horizontal=?66   .+?5&      ?? -   5        $??myCheckBoxes??5&   )   $ Vertical=?6>   5(      ?? 5)      -   5        $??myClientLocationItems??5)   )   $ Vertical=?6G   5+      5,      5-      5.      ?? 50      $??1??6   $
??Left=?6*   $ 
Horizontal=?6E   $??0,0,20,0q?6^   .+?51      *   $MaVideotheque.Components.BasicBouton  *   $MaVideotheque.Components.BasicBouton!   PreviewMouseLeftButtonDown$) #Afficher_PreviewMouseLeftButtonDown??6B      Contenu$ Afficher facture??6'   6B     52      $) #Imprimer_PreviewMouseLeftButtonDown??6B   $ Imprimer facture??6'   6B     53      $( "Envoyer_PreviewMouseLeftButtonDown??6J   $ Envoyer facture par mail??6'   6J   +   %MaVideotheque.Components.CancelButton  54      +   %MaVideotheque.Components.CancelButton!   PreviewMouseLeftButtonDown$- 'CancelButton_PreviewMouseLeftButtonDown??66   
	   Msg$	 Annuler??6(   66   55      56      57      58      59      