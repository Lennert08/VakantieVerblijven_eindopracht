   M S B A M L   `   `   `  ����Z  VVakantieVerblijven.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:VakantieVerblijven.Presentation.Windows'VakantieVerblijven.Presentation.Windows  5   	   @    :VakantieVerblijven.Presentation.Windows.ParkSelectieScherm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:VakantieVerblijven.Presentation.Windows     5   	     � Title$  ParkSelectieScherm��5   	   $	��450��6$   $	��800��61   $	��430��6=   $	��680��6M   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $	��90* �6   .+�5   
   �� 
���p� �� Orientation$ 
Horizontal=�6/   .+�5      �� -   5        $
��Home��5      
�������$	��100��67   $��0q�6C   $��15(�6X   
 � Tag$
 Home��6�   �� 5      -   5        $��Reservaties��5      $	��100��6,   $��0q�68   $��15(�6M   $ 
Reservatie��6x   �� 5      -   5        $��Huizen��5      $	��100��6&   $��0q�62   $��15(�6G   $ Huizen��6U   6b   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      �� 5       5      �� 5      $	��12* �6    �� 5      $
��auto �6    �� 5       $	��88* �6    .+�5%      �� $��Selecteer een park��6   $��25(�62   $
��Bold"�6@   $��Center=�6R   $��20��6o   $��Center=�6�   �� 5&      -   5        $��volgendeKnop��5&      $ ReservatieAanmaak��6)   $��Volgende��6]   $��Right=�6p   $��1��6�   $��Center=�6�   $��0,0,20,0q�6�   $��90��6�   $��25��6�   ${�False��6�   �� 5)      $��Sorteer op faciliteiten��6   $
��Bold"�67   $��15(�6I   $��0��6W   $��1��6g   $��Center=�6t   $��Center=�6�   �� 5*      $��beschikbare parken��6   $
��Bold"�62   $��15(�6D   $��1��6R   $��1��6b   $��Center=�6o   $��Center=�6�   �� 5.      
���   �$��2q�6)    �� CornerRadius$ 5��6=   $��10q�6N   $��0��6Z   $��2��6j   ._�5/      � $��0��6   $��2��6'    50      �� 51      $
��auto �6+   �� 52      $��* �6+   .+�54      �� -   5        $��Geen voorkeur��54       d� 	IsChecked$
 TrueY�67   $��0��6H   6|   �� 56      $
��Auto=�6#   $��Disabled=�6F   $��1��6o   .��57      �� -   5        $��FaciliteitLijst��57   7   $��0��6'   ${�False��6N   ��58      �� 59   "   .R�5:   &   �� -   5        ��5:   /   �� *Beschrijving+6v   5;   #   5=      5>      5?      5@      �� 5C      
���   �$��2q�6)   $ 5��6=   $��10q�6N   $��1��6Z   $��2��6j   ._�5D      �� -   5        $��ParkenLijst��5D      $��1��6-   $��2��6=   $��23(�6J   $��0q�6X   6l   5E      5F      5G      5H      