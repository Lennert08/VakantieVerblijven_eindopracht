   M S B A M L   `   `   `  ����Z  VVakantieVerblijven.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:VakantieVerblijven.Presentation.Windows'VakantieVerblijven.Presentation.Windows  5   	   C    =VakantieVerblijven.Presentation.Windows.HuizenOverzichtWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:VakantieVerblijven.Presentation.Windows     5   	     � Title$  Huizen overzicht��5   	   $	��450��6"   $	��800��6/   $	��430��6;   $	��680��6K   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $	��90* �6   .+�5   
   �� 
���p� �� Orientation$ 
Horizontal=�6/   .+�5      �� -   5        $
��Home��5      $	��100��6$   $��0q�60   $��15(�6E   
 � Tag$
 Home��6p   �� 5      -   5        $��Reservaties��5      $	��100��6,   $��0q�68   $��15(�6M   $ 
Reservatie��6x   �� 5      $��Huizen��6   
����·�$	��100��6;   $��0q�6G   $��15(�6[   5      � 5   
   $��1��6    5      �� 5      $	��15* �6    �� 5      $	��85* �6    .+�5      �� -   5        $��OnderhoudButton��5   ]   $��180,7,180,7q�6   $��Voeg toe aan onderhoud��6*   $
��Bold"�6K   ${�False��6t   6�   �� 5      
�������$��2q�6-    �� CornerRadius$ 5��6A   $��13q�6R   $��1��6^   $��2��6n   ._�5       &   System.Windows.Controls.DataGrid  -   5        $��HuisDataGrid��5       $��1��6/      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 150 6<      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Adres��6-      
IsReadOnly$
 True��6^   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6<   �� *VolledigAdres+6^     5#      $ Max personen��6-   $
 True��6f   	 6C   �� *AantalPersonen+6f     5$      $
 Park��6-   $
 True��6Y   	 6;   �� *	Park.Naam+6Y     5%      $ Status��6-   $
 True��6a   	 6=   �� *OnderhoudStatus+6a   5'      5(      5)      5+      5,      