   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   RepeatButtonTransparent  �� 
TargetType �� Property �� Value �� 
TargetType  ScrollBarThumbVertical ��Name  ScrollBar.Static.Thumb J� SnapsToDevicePixels �� Triggers P� Property P� Value	 �� 
TargetName  ScrollBar.MouseOver.Thumb  ScrollBar.Pressed.Thumb  VerticalThinScrollBarStyle  ScrollBar.Static.Background  ScrollBar.Static.Border
 �Name ]�Name J� IsMouseOver ]� DecreaseRepeatButton �� PageUpCommand ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb  ThinScrollViewerStyle � ColumnDefinitions � RowDefinitions ��Name �� CanContentScroll �� CanHorizontallyScroll �� CanVerticallyScroll ��Name4   .System.Windows.Automation.AutomationProperties    AutomationId � Cursor �� ScrollableHeight � Maximum � Minimum* �� #ComputedVerticalScrollBarVisibility �� ViewportHeight  �� ViewportSize! � Value" �� Mode# �� RelativeSource$ �� ScrollableWidth% �� Orientation,& �� %ComputedHorizontalScrollBarVisibility' �� ViewportWidth�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      8d2http://schemas.microsoft.com/expression/blend/2008  5      %#  &	        &	 H    &	 T    7   7   7  &	 E    �� 5      "  ��6,   .�5   
   ��  �@�OverridesDefaultStyle . 62   �� 5   
    � ��
 ���� 6'   �� 5	   
    � |� .  6&   �� 5
   
    � �� .  6&   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� #��z��6    #��z��6D   #��z��6f   5      5      5      �� 5      "  n�6+   .�5   
   ��  �@�OverridesDefaultStyle . 62   �� 5   
    � �� .  6&   �� 5   
    � �� 5      �� 5      " n�6"   .R�5      �� $ RootRectangle��6    #���  67   #��z��6g    . #��z��6�    5      P� 5       �@J�IsMouseOver . . �5      �� $	 RootRectangle��65   # �  6P    � ��5      P� 5       �@n�
IsDragging . . �5       �� $	 RootRectangle��65   # �  6P    � ��5!      5#      5%      5&      �� 5(      "  ��6/   .�5)   
   ��  �@��IsPressAndHoldEnabled .  69   �� 5*   
    �@��IsFlicksEnabled .  63   �� 5+   
    � ��# �  6'   �� 5,   
    � ��# �  6(   �� 5-   
    � ��# � ��6'   �� 5.   
    � ��$	 1,0q�6,   �� 5/   
    � ��$ 5��6"   �� 50   
    � ��$ 5��6%   �� 51   
    � �� 52      �� 53      " ��6"   .R�54      � $
 Bg��6    . .+�55      �� #��z��6!   #��z��6M   #��z��6�   $��1��6�   ]� 56      $ 
PART_Track��6    ��. #{�z 6O   $��1��6y    57      �� 58   "   #��Z 6/   8��  6\    5:      �� 5;   "   #��Z 6/   8�� 6^    5=      n� 5>   "   8�� 6(   5@      5A      5B      5D      5E      �� 5G      "  ��6*   .�5H   
   ��  � ��$
 Auto=�68   �� 5I   
    � ��$ Disabled=�6:   �� 5J   
    � �� 5K      �� 5L      " ��6"   .R�5M      � $

 Grid��6   #��z��6)    5N      �� 5O      $��* �6/   �� 5P      $
��Auto �6/    5R      �� 5S      $��* �6,   �� 5T      $
��Auto �6,   .+�5V      �� $ Corner��6$   $��1��64   #��� ��6D   $��1��6�   �� 5W      $! PART_ScrollContentPresenter��61   # z��6V    .   .  #��z��6�   #��z��6�   $��0��6  #��z��6.  $��0��6Q  �� 5X      $ PART_VerticalScrollBar��6$   $��1��5Y   $   $��0��64   $	��0,5q�5Z   $   #���  5[   $   $ VerticalScrollBar��5\   $   $ Arrow��5]   $   # z 5^   $   $ 0Q�6Q   #y�z 5_   $   #  z 5`   $   ! 5_   g   �� *VerticalOffset+$" OneWay=�# �� *TemplatedParent+5`   $   �� 5a      $ PART_HorizontalScrollBar��6$   $ HorizontalScrollBar��6F   $ Arrow��6~   $��0��6�   # z$ 6�   $ 0Q�6�   $% 
Horizontal=�6�   $��1��6�   #y�z& 6�   #  z' 6�  ! 6@  �� *HorizontalOffset+$" OneWay=�# �� *TemplatedParent+6�  5b      5c      5e      5f      5h      