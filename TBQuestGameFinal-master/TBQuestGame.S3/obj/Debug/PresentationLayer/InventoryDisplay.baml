   M S B A M L   `   `   `  ����F  BTBQuestGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:TBQuestGame.PresentationLayerTBQuestGame.PresentationLayer  5   	   4    .TBQuestGame.PresentationLayer.InventoryDisplay   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:TBQuestGame.PresentationLayer     5   	   -   5          � Title$  InventoryDisplay��5   	    � 
ResizeMode$ NoResize=�6"   $	��250��68   $	��350��6E    � Icon$ /Images/sword-icon.png��6j   .��5	      �  � RowDefinitions 5
   
   �� 5      $��35 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   �� $!��Inventory and Vicinity Loot��6   $
��Bold"�66   $��20(�6H   $��Center=�6V   $��Center=�6s   $��0��6�   $��cambria)�6�   �� 5   
   $��1��6   
�������.@�5      �� -   5         ��Name$ PlayerInventoryTab��5      
����ح���5      �� 5      -   5        $��	Inventory��5      60   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ playerInventoryGrid��5         AutoGenerateColumns .  ��68   �� *PlayerInventory+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        
ItemsNames��,  &System.Windows.Controls.DataGridColumn   
IsReadOnly . 	   Header$	 	Item Name��5   !   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 5   !   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      `� 5   "    �� StringFormat$	 {0}��6/   .1�5   &   ��  �� Path$
 Name�6.   5   #   5         5!      -   5        
ItemsStack�� . $	 Stack Count��5"   !   $	
 100 5#   !    5$      `� 5%   "   $	 {0}��6/   .1�5&   &   �� $ ItemStackCount�6.   5'   #   5)        5*      -   5        LevelRequirement�� . $	 Required Level��5+   !   $	
 100 5,   !    5-      `� 5.   "   $	 {0}��6/   .1�5/   &   �� $ LevelRequirement�6.   50   #   52      55      59      �� 5:      -   5        $ EquippedTab��5:      
����ح���5;      �� 5<      -	   5        $��Equipped��5<      6/   .��5>        -
   5        $ playerEquippedGrid��5>       .  ��67   �� *Player.EquippedItems+ 5?        5@      -   5        EquippedName�� . $	 Equipped Item��5A   !   $
 * 5B   !    5C      `� 5D   "   $	 {0}��6/   .1�5E   &   �� $
 Name�6.   5F   #   5H      5J      5N      �� 5O      -   5        $ LocationLootTab��5O      
����ح���5P      �� 5Q      -   5        $��Location's Loot��5Q      66   .��5S        -   5        $ locationLootGrid��5S       .  ��65   �� *LocationLootableItems+ 5T        5U      -   5        LootItemName�� . $	 	Item Name��5V   !   $
 * 5W   !    5X      `� 5Y   "   $	 {0}��6/   .1�5Z   &   �� $
 Name�6.   5[   #   5]        5^      -   5        LootableItemStack�� . $	 Stack Count��5_   !   $	
 100 5`   !    5a      `� 5b   "   $	 {0}��6/   .1�5c   &   �� $ ItemStackCount�6.   5d   #   5f      5i      5n      5o      �� 5p   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6K   $��2��6f   .+�5q   
   �� -   5         ��Name$ DropItem��5q      $
��Drop��6#   $��75��62   $��25��6=   $��0,0,10,0q�6I   6[   �� 5r   
   -   5        $ DropAll��5r      $��Drop All��6"   $��75��65   $��25��6@   6L   5s      5t      5u      