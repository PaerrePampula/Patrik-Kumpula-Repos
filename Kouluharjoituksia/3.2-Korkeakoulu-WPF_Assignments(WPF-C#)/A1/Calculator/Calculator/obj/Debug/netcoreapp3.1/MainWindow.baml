   M S B A M L   `   `   `  ����E  ACalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Calculator
Calculator  5   	       Calculator.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Calculator     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ 
MainWindow��5   	   $	��450��6   $	��450��6)    � 	Resources 5
         	digital-7��%K   &	        *�5   
   -)pack://application:,,,/Folder1/#Digital-7)�6R   5      .��5      � .+�5   
   �� -   5        $��RESET��5      $��75,99,320,257q�6!   68   ]� 5   
   
���/���$
��Auto��6-   $
��Auto��6;   $��75,45,65,340q�6H   .+�5      �� 
���   �$��1q�6)   ._�5      �� -   5         ��Name$ 
OutputText��5   �   $��Fonts/#Digital-7)�6   $��24(�6;    �� TextAlignment$
 Left=�6I   $��25��6_   $��ENTER CALCULATION��6k   6�   5      5      � 5   
   -   5         �Name$ NumbersGrid��5      $
��Left=�6$   $	��Top=�6?   $	��156��6W   $	��170��6d   $��
130,99,0,0q�6p    � ColumnDefinitions 5      �� 5      $	��57* �6#   �� 5      $	��34* �6#   �� 5      $	��23* �6#   �� 5      $	��57* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5       $��* �6    �� 5!      $��* �6    �� 5"      $��* �6    .+�5$      �� $��0��6   $��1��6%   $��2��61   $��0,0,33,0q�6E   �� 5%      $��1��6   $��0��6%   $��2��62   $��2��6>   �� 5&      $��2��6   $��0��6%   $��3��62   $��2��6>   $��23,0,0,0q�6R   �� 5'      $��0��6   $��1��6%   $��4��62   $��2��6>   $��0,0,33,0q�6R   �� 5(      $��1��6   $��1��6%   $��5��62   $��2��6>   �� 5)      $��2��6   $��1��6%   $��6��62   $��2��6>   $��23,0,0,0q�6R   �� 5*      $��0��6   $��2��6%   $��7��62   $��2��6>   $��0,0,33,0q�6R   �� 5+      $��1��6   $��2��6%   $��8��62   $��2��6>   �� 5,      $��2��6   $��2��6%   $��9��62   $��2��6>   $��23,0,0,0q�6R   �� 5-      $��Fonts/#Digital-7)�6   $��0��66   $��3��6F   $
��Wrap=�6S   $
��10.5(�6g   $ Center=�6w   $��PärreTech Calculator 1.0��6�   $��2��6�   $��0,0,33,0q�6�   �� 5.      $��1��6   $��3��6%   $��0��62   $��2��6>   5/      � 50   
   -   5        $ OperationsGrid��50      $
��Left=�6'   $��
320,99,0,0q�6B   $	��Top=�6V   $	��156��6n   $��40��6{    51      �� 52      $��* �6#    54      �� 55      $��* �6    �� 56      $��* �6    �� 57      $��* �6    �� 58      $��* �6    .+�5:      �� $��0��6   $��+��6"   $��Stretch=�6.   $��Stretch=�6L   �� 5;      $��1��6   $��-��6"   $��Stretch=�6.   $��Stretch=�6L   �� 5<      $��2��6   $��*��6"   $��Stretch=�6.   $��Stretch=�6L   �� 5=      $��3��6   $��/��6"   $��Stretch=�6.   $��Stretch=�6L   5>      �� 5?   
   -   5        $��=��5?      $
��Left=�6   $��320,260,0,0q�68   $	��Top=�6M   $��40��6e   $��34��6p   6|   5B      5D      