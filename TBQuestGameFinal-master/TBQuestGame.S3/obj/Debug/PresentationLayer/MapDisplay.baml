   M S B A M L   `   `   `  ����F  BTBQuestGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:TBQuestGame.PresentationLayerTBQuestGame.PresentationLayer  5   	   .    (TBQuestGame.PresentationLayer.MapDisplay   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:TBQuestGame.PresentationLayer     5   	   -   5        
�������  � Title$  
MapDisplay��5       $��500.382��63   $	��550��6D    � 
ResizeMode$ NoResize=�6P    � 	Resources 5	         statBarLabels �� 
TargetType �� Property �� Value  ButtonStyle  CommandBoxStyle  sectionLabel  HeaderStyle��%�  &	        &	 (    &	 (    &	 /    &	 �    �� 5
   
   " ��6&   .�5      ��  � ��
 �   �6,   �� 5       � ��$ 3q�60   �� 5       � ��$
 bold"�6+   �� 5       � ��$ 13(�6)   �� 5       � ��$ Center=�6;   �� 5       � ��$	 100��6&   �� 5       � ��$ 40��6'   5      �� 5   
   " ��6$   .�5      ��  � ��
 �   �6,   �� 5       � ��$ 3q�60   �� 5       � ��$	 120��6&   �� 5       � ��$ 50��6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 16(�6)   5      �� 5   
   " ��6(   .�5      ��  � ��$ 13(�6)   �� 5       � ��
 �   �6,   �� 5       � ��$ 3q�60   �� 5       � ��$	 550��6&   �� 5        � ��$ Center=�64   �� 5!       � ��$ 5,5,5,5q�6'   5"      �� 5#   
   " ��6%   .�5$      ��  � ��$
 Bold"�6+   �� 5%       � ��$ 14(�6)   5&      �� 5'   
   " ��6$   .�5(      ��  � ��$
 Bold"�6+   �� 5)       � ��$ 16(�6)   �� 5*       � ��$ Center=�64   �� 5+       � ��$ Center=�62   5,      5-      .��5.      �  � ColumnDefinitions 5/   
   �� 50      $	��200 �6   �� 51      $��* �6    � RowDefinitions 53   
   �� 54      $��* �6   �� 55      $��* �6   �� 56      $��* �6   �� 57      $��* �6   .+�59   
   �� $��Current Location:��6   $��0��6,   $��0��6<   #��[ 6I   $��Center=�6n   $��Center=�6�   �� 5:   
   -   5         ��Name$ CurrentLocationDisplay��5:      $��Center=�62   $��Center=�6V   	 �� 
IsReadOnly	 . $��1��6�   $��0��6�   $��Center=�6�   $��Center=�6�   $	��200��6�   $��35��6�   ��6�   �� *GameMap.CurrentLocation.Name+�� 5<   
   $��Location Warning:��6   $��0��6,   $��1��6<   $��Center=�6I   $��Center=�6f   #��[ 6�   �� 5>   
   
 �� Orientation$
 
Horizontal=�6   $��1��6.   $��1��6;   $��Center=�6K   .+�5?      �� $$��/Images/grayswordiconblack.png��6   $��32��6<   $��32��6G   $��0,0,10,0q�6S   �� 5@      -   5        $ WarningDisplay��5@      	 . $��1��6@   $��1��6P   $��Center=�6]   $��Center=�6z   $
��Bold"�6�   $��14(�6�   $��Center=�6�   $��Center=�6�   $	��200��6�   $��40��6  5A      �� 5B   
   $��Location Description:��6   $��0��60   $��2��6@   #��[ 6M   $��Center=�6r   $��Center=�6�   �� 5C   
   -   5        $  LocationDescriptionDisplay��5C      $��Center=�66   $��Center=�6Z   	 . $��1��6�   $��2��6�   $��Center=�6�   $��Center=�6�   $	��325��6�    �� TextWrapping$ WrapWithOverflow=�6�   $	��100��6  ��6  �� *%#GameMap.CurrentLocation.Description+5F      5G      