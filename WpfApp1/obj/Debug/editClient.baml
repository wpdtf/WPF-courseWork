   M S B A M L   `   `   `  ????C  ?NevaLink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.editClient   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     ? Title$1  +Редактирование клиента??5   	   $	??650??6(   $	??800??65   $	??650??6A   $	??800??6Q   $	??650??6`   $	??800??6p    ? 	Resources 5	         FocusVisual ?? Property ?? Value ?? StrokeDashArray J? SnapsToDevicePixels  Button.Static.Background ?? Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground ?? 
TargetType ?? 
TargetType	 ??Name
 ?? CornerRadius ??Name ?? Triggers P? Property P? Value 
 TextBox.MouseOver.Border  TextBox.Focus.Border  TextBoxTemplate1 ??Name ?? 
TargetName??%  &	        &	 ?     &	 ?     &	 ?     &	     &	 6    &	 Y    &	 |    &	 ?    &		 ?    '?? ?    7   7  7  &	
     &	 /    &	 R    7 
 7  ?? 5
   
   .?5      ??  ? ?? 5      ?? 5      .R?5      ?? $??2q?6$   $	 1 2R?6/   #??? ??6E    . $??1??6?   5      5      5      ?? 5   
   $ 	#FFDDDDDD??6;   ?? 5   
   $ 	#FF707070??67   ?? 5   
   $ 	#FFBEE6FD??6>   ?? 5   
   $ 	#FF3C7FB1??6:   ?? 5   
   $ 	#FFC4E5F6??6<   ?? 5   
   $ 	#FF2C628B??68   ?? 5   
   $ 	#FFF4F4F4??6=   ?? 5   
   $ 	#FFADB2B5??69   ?? 5   
   $ 	#FF838383??6=   ?? 5   
   " ??6   .?5      ??  ?@?FocusVisualStyle8   61   ?? 5       ? ??8  6+   ?? 5       ? ??8  6,   ?? 5        ? ??# ? ??6+   ?? 5!       ? ??$ 1q?60   ?? 5"       ? ??$ Center=?6;   ?? 5#       ? ??$ Center=?69   ?? 5$       ? ??$ 1q?6(   ?? 5%       ? ?? 5&      ?? 5'      " ??6&   .R?5(      ?? $	 border??6!   $
 10??61   #??z??6C   #??z??6m   #??z??6?    . ._?5)      ?? $ contentPresenter??6/   |?.  #??z??6[   #??z??6?   ??. # z 6?   #??z??6  5*       5+      P? 5,       ?@??IsDefaulted . 5-      P? 5.       ?@J?IsMouseOver . 5/      P? 50       ? ?? . 51      P? 52       ? {? .  53      55      57      58      ?? 59   
   $ 	#FF7EB4EA??6;   ?? 5:   
   $ 	#FF569DE5??67   ?? 5;   
   " ??63   .R?5<      ?? $	 border??6   $
 10??6%   #??z??67   #??z??6a   #??z??6?    . ._?5=      ?? $ PART_ContentHost??6   |?.  $??Hidden=?6K   $??Hidden=?6r   5>       5?      P? 5@       ? {? .  . ?5A      ?? $ border??60    ?@J?Opacity$
 0.56Q?6D   5B      P? 5C       ?@J?IsMouseOver . . ?5D      ?? $ border??64   8    ? ??6H   5E      P? 5F       ?@J?IsKeyboardFocused . . ?5G      ?? $ border??64   8   ? ??6H   5H      5J      5K      .??5L      ? 
??????? ? RowDefinitions 5M   
   ?? 5N      $??60 ?6   ?? 5O      $??1 ?6   ?? 5P      $??* ?6    ? ColumnDefinitions 5R   
   ?? 5S      $
??750* ?6   ?? 5T      $??1 ?6   ?? 5U      $
??250* ?6   .+?5X   
   ?? -   5        $??b3??5X   H   $??1??6   $??5??6   $??30, 0, 30, 0q?62   $??2q?6R   
???  ??6z   ?? 5Z   
   -   5        $??up??5Z      $??0??6   $??0??6/   $??Center=?6<   $
??Left=?6W   .+?5[      ?? -   5        $??20(?5[      $??2q?6$   $
??auto??60   $	??300??6>   $??\source\bold.otf)?6J   $?? ??6h   6p   5\      ?? 5_   
   $??3??6   $??0??6%   $	??Top=?62   $??Right=?6J   .+?5`      ?? -   5        $??BtnOut??5`   ?   $??10q?6+   $??3q?6O   ???#0085bc
??????????#0085bc$??Закрыть??6?   $??40??6?   $	??100??6?   $??20(?6?   $??5q?6?   $??\source\bold.otf)?6  5a      ?? 5c   
   -   5        $??	stackEdit??5c      $??10q?6'   $	??Top=?63   $??2??6K   $??3??6X   $	??700??6l   .+?5d      ??  ?? Orientation$ 
Horizontal=?6   $	??400??62   .+?5e      ?? $??Image/people.png??6   $??30, 10, 30, 30q?62    ?? BitmapScalingMode$ HighQuality=?6J   $	??Top=?6x   $	??120??6?   ?? 5f      $??Center=?6   .+?5g      ?? $??15(?6   $??Имя??6*   $??\source\bold.otf)?68   $
??auto??6V   ?? 5h      -   5        $
??name??5h   ?   $??20(?6   $
??auto??6,   #???  6:   $??\source\bold.otf)?6h   $??0q?6?   $	??190??6?   6?   ?? 5i      $??15(?6   $??Фамилия??6*   $??\source\bold.otf)?6<   $
??auto??6Z   ?? 5j      -   5        $??family??5j   ?   $??20(?6   $
??auto??6,   #???  6:   $??\source\bold.otf)?6h   $??0q?6?   $	??190??6?   6?   ?? 5k      $??15(?6   $??Отчество??6*   $??\source\bold.otf)?6=   $
??auto??6[   ?? 5l      -   5        $??
MiddleName??5l   ?   $??20(?6   $
??auto??6,   #???  6:   $??\source\bold.otf)?6h   $??0q?6?   $	??190??6?   6?   5m      5n      ?? 5o      $	??350??6   .+?5p      ?? $??15(?6   $??
Логин??6&   $??\source\bold.otf)?66   ?? 5q      -	   5        $??login??5q   ?   $??20(?6   $
??auto??6(   #???  66   $	??330??6d   $
??Left=?6p   $??\source\bold.otf)?6?   ?? 5r      -
   5        $??txPass??5r   m   $??15(?6   $=??7Пароль (укажите для изменения)??6&   $??\source\bold.otf)?6O   6m   ?? 5s      -   5        $??password??5s   ?   $??20(?6   $
??auto??6(   #???  66   $	??330??6d   $
??Left=?6p   $??\source\bold.otf)?6?   ?? 5t      $??15(?6   $??
Тариф??6&   $??\source\bold.otf)?66   ?? 5u      -   5        $??	comboRate??5u   R   $??20(?6   $
??auto??6)   $
??Left=?67   $	??330??6c   $??10q?6o   5v      ?? 5w      -   5        $
??city??5w      .+?5x      ?? $??15(?6   $??
Адрес??6*   $??\source\bold.otf)?6:   ?? 5y      -   5        $??	comboCity??5y   X   $??20(?6   $
??auto??6-   $??Center=?6;   $	??330??6i   $??10q?6u   5z      5{      5|      ?? 5}      -   5        $??BtnEdit??5}   v   $	??200??6   $??3q?6b   $??Сохранить??6?   $??40??6?   $??15(?6?   $??40, 10, 40, 10q?6?   $??5q?6?   $??\source\bold.otf)?6?   5~      5?      5?      