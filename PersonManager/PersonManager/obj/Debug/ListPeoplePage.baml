   M S B A M L   `   `   `  ????H  DPersonManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PersonManagerPersonManager  5      "    PersonManager.ListPeoplePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PersonManager     5        N? Title$  ListPeoplePage??5	      .??5      ?    GradientBackground#??[  6   .+?5   
   ?? -   5         ??Name$ LvUsers??5       ?? AlternationCount$ 2??5      $??28,24,28,135q?5       J? RenderTransformOrigin$ 0.495,0.506&?6#   ??5      ?? 5       ?? 
TargetType" ??6   .?5      -   5        ?? 5       ?? Property ? ?? ?? Value
 ??ح?63    ?? Triggers 5      P? 5       P? Property ?@??AlternationIndex	 P? Value$	 1??6G   . ?5      ??  ? ??
 ?????6;   5      ]? 5      
 ]? 
Conditions
 5      ?? 5   "    ?? Property ?@??
IsSelected ?? Value . 5   #   ./?5      ??  ? ??
 ???_?6;   5      5!       ?? View 5$      ?? 5%      .P?5&      ??  ?? Width$	 180??5'      $??
First Name??5(       ?? DisplayMemberBinding 5)      ?? *	FirstName+?? 5*      $	 180??5+      $??	Last Name??5,       5-      ?? *
LastName+?? 5.      $	 180??5/      $	??Age??50       51      ?? *Age+?? 52      $	 200??53      $??Email??54       ?? CellTemplate 56      ?? 57      .R?58   "   ?? $??	Underline{?59   ,   
???   ? ? Cursor$
 Hand??5;   ,   ??58   ,   ?? *Email+ ? ToolTip 5<   &   ?? 5=   *    ??Name$ Picture??5>   -   $??60??5@   -   $??60??5A   -   ??5?   -   ?? *Image+5A   -   5C   #   5E      5H      5K      5M      ?? 5N   
   -   5        $??BtnEdit??5P      $
??Edit??5O      
???????
???   ?$
??Left=?5T      $??331,336,0,0q?6(   $	??Top=?6=   $ 0.568,0.606&?6U   $??30??6y   $	??110??6?   ?? 5U   
   -   5        $??	BtnDelete??5W      $??Delete??5V      
???????
???  ??$
??Left=?5[      $??499,336,0,0q?6(   $	??Top=?6=   $ 0.568,0.606&?6U   $??30??6y   $	??110??6?   ?? 5\   
   -   5        $??BtnAdd??5^      $	??Add??5]      
???????
??? ? ?$
??Left=?5b      $??662,336,0,0q?6(   $	??Top=?6=   $ 
0.495,0.55&?6U   $??30??6x   $	??110??6?   5d      5e      