   M S B A M L   `   `   `  ����F  BTBQuestGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TBQuestGameTBQuestGame  5   	       TBQuestGame.EnemyStats   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TBQuestGame     5   	   -   5          � Title$  
EnemyStats��5   	   $	��450��6   $	��400��6)    � 
ResizeMode$ NoResize=�65    � Icon$ /Images/sword-icon.png��6d    � 	Resources 5	         	TextLabel �� 
TargetType �� Property �� Value  TextBoxValue��%t  &	        &	 �     �� 5
   
   " ��6"   .�5      ��  � ��$
 Bold"�6+   �� 5       � ��$
 Left=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 15(�6)   �� 5       � ��$ 15q�6(   5      �� 5   
   " ��6%   .�5      ��  � ��$	 200��6&   �� 5       � ��$ 40��6'   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 0,5,0,0q�6(   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 13(�6)   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��40* �6   �� 5       $	��40* �6   �� 5!      $	��40* �6   �� 5"      $	��40* �6   �� 5#      $	��40* �6   �� 5$      $	��40* �6   .+�5&   
   �� 
���   �$��3q�6%   $��65��69   $��65��6D   ._�5'      �� -   5         ��Name$ EnemyStatsPicture��5'      $��64��6/   $��64��6:   $��Center=�6F   $��Center=�6c   5(      �� 5)   
   -   5        	 ��Name$	 EnemyNameLabel��5)      #��[  6(   $��Name: ��6K   $��1��6\   �� 5*   
   -   5        
 ��Name$
 	EnemyName��5*      #��[ 6%   $��1��6�   ��6K   �� *	EnemyName+ �� FallbackValue$ Currently Not Fighting��6�   �� 5+   
   -   5        $	 EnemyLevelLabel��5+      #��[  6)   $��Level: ��6L   $��2��6^   �� 5,   
   -   5        $
 
EnemyLevel��5,      #��[ 6&   $��2��6�   ��6L   �� *
EnemyLevel+$ Currently Not Fighting��6�   �� 5-   
   -   5        $	 EnemyBaseDamageLabel��5-      #��[  6.   $��
Base DMG: ��6Q   $��3��6f   �� 5.   
   -   5        $
 EnemyBaseDamage��5.      #��[ 6+   $��3��6�   ��6Q   �� *EnemyDamage+$ Currently Not Fighting��6�   5/      50      