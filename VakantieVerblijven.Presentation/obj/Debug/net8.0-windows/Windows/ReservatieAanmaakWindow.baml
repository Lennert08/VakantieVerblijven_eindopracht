   M S B A M L   `   `   `  ����Z  VVakantieVerblijven.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:VakantieVerblijven.Presentation.Windows'VakantieVerblijven.Presentation.Windows  5   	   E    ?VakantieVerblijven.Presentation.Windows.ReservatieAanmaakWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:VakantieVerblijven.Presentation.Windows     5   	     � Title$  ReservatieAanmaakWindow��5   	   $	��450��6)   $	��800��66   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $	��90* �6   .+�5   
   �� 
���p� �� Orientation$ 
Horizontal=�6/   .+�5      �� -   5        $
��Home��5      $	��100��6$   $��0q�60   $��15(�6D   
 � Tag$
 Home��6o   �� 5      -   5        $��Reservaties��5      
�������$	��100��6?   $��0q�6K   $��15(�6_   $ 
Reservatie��6�   �� 5      -   5        $��Huizen��5      $	��100��6&   $��0q�62   $��15(�6F   $ Huizen��6q   5      � 5   
   $��1��6    5      �� 5      $	��11* �6    �� 5      $	��15* �6    �� 5      $	��74* �6    .+�5      �� $��Huis Reserveren��6   $��Center=�6/   $��Center=�6L   $��22(�6h   $
��Bold"�6v   � 5"      $��1��6    � ColumnDefinitions 5#      �� 5$      $	��25* �6'   �� 5%      $	��25* �6'   �� 5&      $	��25* �6'   �� 5'      $	��25* �6'   �� 5(      $	��25* �6'    5+      �� 5,      $
��auto �6$   �� 5-      $��* �6$   .+�50      �� $��Aantal personen��6   $��Center=�63   $��0��6N   $��0��6^   $��15,0,0,0q�6k   $��Verdana)�6}   �� 51      $	��Van��6   $��Center=�6'   $��1��6B   $��0��6R   $��15,0,0,0q�6_   $��Verdana)�6q   �� 52      $	��Tot��6   $��Center=�6'   $��2��6B   $��0��6R   $��15,0,0,0q�6_   $��Verdana)�6q   �� 55      -   5        $��PersonenComboBox��55      $��
15,5,15,10q�64   $��1��6H   (  "System.Windows.Controls.DatePicker  57      -   5        $��BeginDatumBox��57   c   $��
15,5,15,10q�6   $��1��61   $��1��6A   $��Verdana)�6N   6c     58      -   5        $��EindDatumBox��58   c   $��
15,5,15,10q�6   $��2��61   $��1��6A   $��Verdana)�6N   6c   �� 59      -   5        $
��Zoek��59      $��3��6(   $��
15,5,15,10q�69   $��1��6M   $
��Bold"�6Z   6l   �� 5:      -   5        $��volgendeKnop��5:   ,   $��Volgende��6   $��4��6@   $��
15,5,15,10q�6l   $��1��6�   $
��Bold"�6�   ${�False��6�   5;      �� 5>      
���   �$��2q�6)    �� CornerRadius$ 5��6=   $��20q�6N   $��1��6Z   $��2��6j   ._�5?      �� -	   5        $��	HuisLijst��5?      $��2��6+   $��20(�6f   $��0q�6t   5@      5B      5C      5D      