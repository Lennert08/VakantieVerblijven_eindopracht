   M S B A M L   `   `   `  ����Z  VVakantieVerblijven.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:VakantieVerblijven.Presentation.Windows'VakantieVerblijven.Presentation.Windows  5   	   H    BVakantieVerblijven.Presentation.Windows.ReservatieAanmaakOverzicht   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:VakantieVerblijven.Presentation.Windows     5   	     � Title$   ReservatieAanmaakOverzicht��5   	   $	��450��6,   $	��800��69   $	��430��6E   $	��680��6U   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $	��90* �6   .+�5   
   �� 
���p� �� Orientation$ 
Horizontal=�6/   .+�5      �� -   5        $
��Home��5      
�������$	��100��67   $��0q�6C   $��15(�6X   
 � Tag$
 Home��6f   6q   �� 5      -   5        $��Reservaties��5      $	��100��6,   $��0q�68   $��15(�6M   $ 
Reservatie��6x   �� 5      -   5        $��Huizen��5      $	��100��6&   $��0q�62   $��15(�6G   $ Huizen��6U   6b   5      � 5   
   $��1��6    5      �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $
��auto �6     � ColumnDefinitions 5$      �� 5%      $
��auto �6#   �� 5&      $��2 �6#   �� 5'      $��* �6#   .+�5+      �� $��Reservatie Overzicht��6   $��Center=�64   $��15q�6Q   $
��Bold"�6]   $��25(�6o   $��3��6}   �� 5,      $��5q�6   $��Bottom=�6,   
�������$��3��6Z   � 5/      
�������$��1��6*   $��1��6:   $��5��6G   �� 50      $��2q�6   $��Bottom=�6,   
�������$��1��6Z   $��3��6g   �� 51      $��2q�6   $��Bottom=�6,   
�������$��2��6Z   $��3��6g   �� 52      $��2q�6   $��Bottom=�6,   
�������$��3��6Z   $��3��6g   �� 53      $��2q�6   $��Bottom=�6,   
�������$��4��6Z   $��3��6g   �� 54      $��2q�6   $��Bottom=�6,   
�������$��5��6Z   $��3��6g   �� 57      $��Klant:��6   $��1��6&   $��Center=�63   $��23(�6N   $��10q�6\   $
��Bold"�6h   �� 58      $��Park:��6   $��2��6%   $��Center=�62   $��23(�6M   $��10q�6[   $
��Bold"�6g   �� 59      $��Huis:��6   $��3��6%   $��Center=�62   $��23(�6M   $��10q�6[   $
��Bold"�6g   �� 5:      $��	Personen:��6   $��4��6)   $��Center=�66   $��23(�6Q   $��10q�6_   $
��Bold"�6k   �� 5;      $��Periode:��6   $��5��6(   $��Center=�65   $��23(�6P   $��10q�6^   $
��Bold"�6j   �� 5>      -   5        $��klantInfoText��5>   *   $��
Klant info��6   $��1��6?   $��2��6L   $��Center=�6\   $��23(�6w   $��10q�6�   �� 5?      -   5        $��parkInfoText��5?   )   $��	Park info��6   $��2��6=   $��2��6J   $��Center=�6Z   $��23(�6u   $��10q�6�   �� 5@      -   5        $��huisInfoText��5@   )   $��	Huis info��6   $��3��6=   $��2��6J   $��Center=�6Z   $��23(�6u   $��10q�6�   �� 5A      -   5        $��persoonInfoText��5A   /   $��Aantal personen��6   $��4��6F   $��2��6S   $��Center=�6c   $��23(�6~   $��10q�6�   �� 5B      -   5        $��periodeInfoText��5B   ,   $��Periode info��6   $��5��6C   $��2��6P   $��Center=�6`   $��23(�6{   $��10q�6�   �� 5E      -	   5        $��6��5E      $��Reservatie vastleggen��6"   $��15q�6B   $��10q�6O   $��3��6[   6o   5F      5G      5H      