   M S B A M L   `   `   `  ����C  ?BadPaint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BadPaintBadPaint  5   	   9!clr-namespace:BadPaint.PropertiesBadPaint.Properties  5	   	       BadPaint.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:BadPaint     5   	   2resx!clr-namespace:BadPaint.Properties     5	   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xctk1)http://schemas.xceed.com/wpf/xaml/toolkit  5
   	     � Title$  BadPaint - Ver 1.0��5   	   $	��450��6$   $	��800��61   $
��True��6=   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.1* �6   6,   �� 5      $��5* �6   6*   �� 5      $��1* �6   6*   .+�5   
   �� $
��Auto��6   .+�5      o� .@�5      m� &    BadPaint.Properties.TextResource   FileMenu#��Z 6   .@�5      m�    NewFile#��Z 6    m� Command 6M   �� *	NewFile+5      m� 5         SaveFile#��Z 6    6N   �� *
SaveFile+5      m� 5         OpenFile#��Z 6    6N   �� *
OpenFile+5      �� 5      6"   m� 5         Export#��Z 6    6L   �� *
ExportFile+5      5      m� 5         Edit#��Z 6   .@�5       m� 	   ResizeCanvas#��Z	 6    6R   �� *CanvasScale+5!      5$      5%      5&      �� 5(   
   -   5        $��scrollViewer��5(   `   $
��Auto=�6   $
��Auto=�6<   $��1��6t   .��5*      �� -   5        
 ��Name$
 PaintCanvasBorder��5*   b   
���   �$��2q�6)   $��10q�6=   $	��600��6I   $	��300��6U    � LayoutTransform 5+      �� 5,       �� ScaleX 6%   ��  �� ElementName$ 
zoomSlider�� �� Path$ Value� �� ScaleY 6[   �� $ 
zoomSlider��$ Value�._�5.      (�  (� Stretch$
 Fill=�6   .��5/      �� -   5         ��Name$ PaintingCanvas��5/       .H�50      �� -   5         ��Name$ CanvasImage��50       67   51      52      53      54      ]� 56   
   $��False��6   $��Bottom=�6*   $��3��6E   .+�57      `� $��Bottom=�6   .�58      c� $��65��6   $��50��6&   .@�59      �� $��Bottom=�6!   .@�5:      �� $��Brush��6"   .��5;      � .+�5<   "   ��    	BrushSize#��Z 6(   6\   �� 5=   "   -   5        $��1��5=   *   $��50��63   
������� �� 	MaxLength$ 3��6�   �� 5>   "      
BrushColor#��Z 6(   6^   #  Xceed.Wpf.Toolkit.ColorPicker  5?   "   -   5        $��cp��5?   4   $��1��6>      DisplayColorAndName$
 True��6N   !   AvailableColorsSortingMode$ HueSaturationBrightness=�6�   $��50��6�   
�������6�   5B      5C      �� 5D      $��
Brush mode��6"   .��5E      � $��2q�6(   .+�5F   "   �� $��Normal brush��6)   $��Normal��6e   ��6@   �� *ChangeBrushType+6�   �� 5G   "   $��Eraser brush��6)   $��Erase��6d   ��6@   �� *ChangeBrushType+6�   5H      5I      5K      5L      c� 5M      $��50��6   .@�5N      ��    
ZoomAmount#��Z 6   $��28��6P   6^   �� 5O      -   5        $��
zoomSlider��5O   A    � Value$ 1Q�6    � Minimum$	 0.2Q�6'    � Maximum$ 5Q�65    � SmallChange$	 0.1Q�6S    � LargeChange$	 0.3Q�6e    �� IsSnapToTickEnabled$
 True��6w    �� TickFrequency$	 0.1Q�6�   $	��350��6�   $��18��6�   6�   �� 5P      $��Center=�6S   $	��100��6p   ��6   �� $ 
zoomSlider��$ Value�6�   5R      5S      5V      5X        J� InputBindings  5Y      d� 5[   
   ! d� MouseAction$! 
RightClicke�6   " �� CommandParameter$"  ��5]      # �� Command# 5\      �� *	PanCamera+5]      5b      