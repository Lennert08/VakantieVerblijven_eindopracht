   M S B A M L   `   `   `  ����Z  VVakantieVerblijven.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:VakantieVerblijven.Presentation.Windows'VakantieVerblijven.Presentation.Windows  5   	   A    ;VakantieVerblijven.Presentation.Windows.KlantSelectieScherm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:VakantieVerblijven.Presentation.Windows     5   	     � Title$  Klant selecteren��5   	   $	��450��6"   $	��800��6/   $	��430��6;   $	��680��6K   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $	��90* �6   .+�5   
   �� 
���p� �� Orientation$ 
Horizontal=�6/   .+�5      �� -   5        $
��Home��5      $	��100��6$   $��0q�60   $��15(�6E   
 � Tag$
 Home��6p   �� 5      -   5        $��Reservaties��5      $	��100��6,   $��0q�68   $��15(�6M   $ 
Reservatie��6x   �� 5      -   5        $��Huizen��5      
�������$	��100��69   $��0q�6E   $��15(�6Y   $ Huizen��6�   5      � 5   
   $��1��6    5      �� 5      $	��10* �6    �� 5      $	��12* �6    �� 5      $	��78* �6    .+�5      �� $:��4Op welke naam moet deze reservatie worden geplaatst?��6   $��Center=�6T   $��20(�6q   $��5q�6   $
��Bold"�6�   � 5"      $��1��6    � ColumnDefinitions 5#      �� 5$      $��* �6'   �� 5%      $
��auto �6'   �� 5&      $
��auto �6'   .+�5(      �� -   5        $��klantTextBox��5(   T   $��1��6   $��	15,0,15,0q�6'   $��30��6:   $��20(�6F   6T   �� 5)      -   5        $��
zoekButton��5)   b   $
��Zoek��6   $��1��6(   $	��200��68   $��30��6D   $��0,0,20,0q�6P   6t   �� 5*      -   5        $��volgendeButton��5*   f   $��Volgende��6   $��2��6,   $	��200��6<   $��30��6H   $��0,0,20,0q�6T   ${�False��6}   $ ParkSelectie��6�   5,      �� 50      
���   �$��2q�6)    �� CornerRadius$ 5��6=   $��20q�6N   $��1��6Z   $��2��6j   ._�51      �� -   5        $��klantListBox��51      $��2��6.   $��20(�6;   $��0q�6I   6T   52      53      55      56      