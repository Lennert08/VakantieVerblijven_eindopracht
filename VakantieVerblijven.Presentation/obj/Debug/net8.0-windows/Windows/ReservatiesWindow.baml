   M S B A M L   `   `   `  ����Z  VVakantieVerblijven.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:VakantieVerblijven.Presentation.Windows'VakantieVerblijven.Presentation.Windows  5   	   ?    9VakantieVerblijven.Presentation.Windows.ReservatiesWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:VakantieVerblijven.Presentation.Windows     5   	     � Title$  Reservaties��5   	   $	��450��6   $	��800��6*   $	��430��66   $	��680��6F   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $	��90* �6   .+�5   
   �� 
���p� �� Orientation$ 
Horizontal=�6/   .+�5      �� -   5        $
��Home��5      $	��100��6$   $��0q�60   $��15(�6D   
 � Tag$
 Home��6o   �� 5      $��Reservaties��6   
����·�$	��100��6A   $��0q�6M   $��15(�6a   �� 5      -   5        $��Huizen��5      $	��100��6&   $��0q�62   $��15(�6F   $ Huizen��6q   5      � 5   
   $��1��6    5      �� 5      $	��15* �6    �� 5      $	��85* �6    .+�5      �  � ColumnDefinitions 5      �� 5      $	��25* �6'   �� 5       $	��25* �6'   �� 5!      $	��25* �6'   �� 5"      $	��25* �6'   �� 5#      $	��25* �6'    5&      �� 5'      $
��auto �6$   �� 5(      $��* �6$   .+�5+      �� $
��Park��6   $��Center=�6(   $��0��6C   $��0��6S   $��15,0,0,0q�6`   $��Verdana)�6r   �� 5,      $	��Van��6   $��Center=�6'   $��1��6B   $��0��6R   $��15,0,0,0q�6_   $��Verdana)�6q   �� 5-      $	��Tot��6   $��Center=�6'   $��2��6B   $��0��6R   $��15,0,0,0q�6_   $��Verdana)�6q   �� 5.      $��Klant��6   $��Center=�6)   $��3��6D   $��0��6T   $��15,0,0,0q�6a   $��Verdana)�6s   �� 50      -   5        $��parkComboBox��50      $��
15,5,15,10q�60   $��1��6D    �� SelectedIndex$ 0��6Q   (  "System.Windows.Controls.DatePicker  52      -   5        $��beginDatumBox��52   c   $��
15,5,15,10q�6   $��1��61   $��1��6A   $��Verdana)�6N   6c     53      -   5        $��EinDatumBox��53   c   $��
15,5,15,10q�6   $��2��61   $��1��6A   $��Verdana)�6N   6c   �� 54      -   5        $��KlantZoekBox��54   `   $��3��6   $��
15,5,15,10q�6*   $��1��6>   $��Verdana)�6K   6`   �� 55      -   5        $
��Zoek��55      $��4��6(   $��
15,5,15,10q�69   $��1��6M   $
��Bold"�6Z   6l   56      �� 5:      
�������$��2q�6-    �� CornerRadius$ 5��6A   $��13q�6R   $��1��6^   $��2��6n   ._�5;      &   System.Windows.Controls.DataGrid  -   5        $��ReservatieLijst��5;   L   $��1��6?      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 150 6c   ��6   �� *Reservaties+   Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn	   Header$		 Van��6-   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6:   �� *FormattedStartDatum+  5>      $		 Tot��6-   
 6:   �� *FormattedEindDatum+  5?      $	 Klant��6-   
 6<   �� *
Klant.Naam+  5@      $
	 Huis��6-   
 6;   �� *Huis.VolledigAdres+5B      5C      5E      5F      5G      