   M S B A M L   `   `   `  ����V  RCielo.Sirius.Foundation.USD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Wclr-namespace:Cielo.Sirius.Foundation.USD.Controls;assembly=Cielo.Sirius.Foundation.USD$Cielo.Sirius.Foundation.USD.Controls  5      �Yclr-namespace:Cielo.Sirius.Foundation.USD.Converters;assembly=Cielo.Sirius.Foundation.USD&Cielo.Sirius.Foundation.USD.Converters  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089    BooleanToVisibilityConverterU    OCielo.Sirius.Foundation.USD.Converters.SelectedItemBoolNotToVisibilityConverter , (SelectedItemBoolNotToVisibilityConverter 0 ,TabulationComboBoxTemplate.ToggleButtonStyle  �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� CornerRadius � Cursor �� Color	 F�Name  TabulationComboBoxTemplate=   7Cielo.Sirius.Foundation.USD.Controls.TabulationComboBox
 �Name � ColumnDefinitions �� ElementName �� 	Converter �Name � AllowsTransparency �� Mode �� RelativeSource & "TabulationComboBox.PopupBackground �� Padding ��Name �� MaxDropDownHeight �� ClearTypeHint ��Name ��Name ��Name-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation d�Name d� 	IsChecked ��Name �� SelectionBoxItemTemplate �� SelectionBoxItem# �� SelectionBoxItemStringFormat  �� ContentStringFormat! J� IsHitTestVisible" ��Name# �� AncestorType$ �� Triggers% P� Property& P� Value' �� 
TargetName( P� 
SourceName) �� Value* �� Binding  TransferColor2  ConferenceColor2 ) %TabulationComboBox.ItemContainerStyle  ForegroundLight2 .	 *TabulationComboBox.SelectedItem.Background /
 +TabulationComboBox.MouseOver.ItemBackground+ ^� 
Conditions, �� Binding- �� Value  TransferColor3  ConferenceColor3 ! TabulationComboBox.Background ! TabulationComboBox.Foreground. �� Triggers  TransferColor  ConferenceColor  Disabled.Background  Disabled.Foreground & "OfferTabulation.ItemContainerStyle/ ]� 
Conditions0 �� Property  ComboBoxToggleButton  OfferTabulationBorderBrush  FilterTabulation  WaterMarkFilterTabulation  ComboBoxClientDataTemplate1 ��Name  ImgContactName2 �� BitmapScalingMode3 �� EdgeMode  BaseText  
DetailText & "ComboBoxSelectedClientDataTemplate  ImgContactBaloon4 �� Triggers % !SearchComboBox.ItemContainerStyle # SearchComboBox.SeparadoresBrush +  'SearchComboBox.MouseOver.ItemBackground ,! (SearchComboBoxTemplate.ToggleButtonStyle " SearchComboBox.PathsFill # SearchComboTemplate9   3Cielo.Sirius.Foundation.USD.Controls.SearchComboBox9   3Cielo.Sirius.Foundation.USD.Controls.LabeledTextBox5  Name6   	WaterMark7 ��Name $ RectangularButtonStyle8 �� TextAlignment % SearchComboBoxStyle & SearchComboBox.Background $'  SearchComboBox.IsOpen.Background�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      e	controlesWclr-namespace:Cielo.Sirius.Foundation.USD.Controls;assembly=Cielo.Sirius.Foundation.USD  5      h
convertersYclr-namespace:Cielo.Sirius.Foundation.USD.Converters;assembly=Cielo.Sirius.Foundation.USD  5      %�K  &	        &	      &	 &     &	 �    7   7  &	 �    '  �    &	 �    &	 9#    &	 �&    &	 �2    &	 #5    &	 �8    &	! <    &	# �?    &	% �G    �� 5      6#      5      6:   �� 5      "  d�6A   .�5   
   ��  �@�OverridesDefaultStyle . 62   �� 5   
    � �� .  6&   �� 5   
    � |� .  6&   �� 5   
    �@��	ClickMode$ Press=�6&   �� 5   
    � �� 5      �� 5      " d�6"   .R�5      �� $ templateRoot��6   #��z��5      #��z��5       . $ 5��5      ._�5      �� $ splitBorder��6!   $��Right=�5   !    . $
 Hand��5   !   $��32��5   !   ��5      �� 5   "   $ Transparent��62   ._�5       F� $	 arrow��6#   "����        р��     �@KL ��[ 	#��z��5!   %   $��Center=�5"   %   $��Center=�5#   %   5$      5%      5&      5(      5)      �� 5+      "  69   .R�5,   
   � $
 templateRoot��6    .  5-      �� 5.      $��* �6#   �� 5/      #��� r�6#   $��0 �6v   .+�51      �� $��0,2,0,0q�52      $��2��53      $ 8,8,0,0��54      ��55      �� *
Background+$ dropDownBorder��y�56      �� *IsOpen+8   $ 
PART_Popup��� 58      $ 
PART_Popup��6   $��2��59       . #��� .�5<      $��Bottom=�5=      ��5;      �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5?      �� $ dropDownBorder��6   #��� ��5@      #���  5A      $ 0,0,5,5��5C      $ 0,0,0,5q�5D      ��5B      �� *ActualWidth+$ templateRoot��._�5E      �� $ DropDownScrollViewer��6#   #��z 6A   .��5F      � $

 grid��6   $ Enabled=�6-   .+�5G      �� $ canvas��6%   .+�5H   "   �� $ 
opaqueRect��6,   ��5I   )   �� *
Background+$ dropDownBorder����5J   )   �� *ActualHeight+$ dropDownBorder����5K   )   �� *ActualWidth+$ dropDownBorder��5L      �� 5M      $ ItemsPresenter��6-   $ 	Contained=�5N   %   # z 5O   %   5P      5Q      5R      5S      d� 5T      $ toggleButton��6   $��2��5U      #��z��5V      #��z��5W      #��z��5X      #���  5Z       5Y      �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+5Z      �� 5[      $ contentPresenter��6   #��z 5\      #��z��5]      #��z 5^      #  z 5_      #��z��5`      ! .  #��z��5b      # z 5c      #��z��5d      �� 5e      $" 	WaterMark��6   $��Center=�5f      $
��Left=�5g      $
��10,0q�63   ��5h      �� *WaterMarkTabulation+ �� "#  y�5i      �� *SelectedItem+ �� "#  8  5j      $ 5k   
   P� 5l      % �@��HasItems& .  . �5m      �� $' dropDownBorder��6+    � ��$ 95��6G   5n      P� 5o      $( DropDownScrollViewer��6?   % � ��& .  . �5p      �� $' 
opaqueRect��6/    6G   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5q      $' 
opaqueRect��60    6H   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5r      �� 5s      $) TransferenceRequested��68   * 6   �� *	CallState+.a�5t      �� $' dropDownBorder��6   # �  6K    � ��5u      �� 5v      $) ConferenceRequested��68   * 6   �� *	CallState+.a�5w      �� $' dropDownBorder��6   # �  6K    � ��5x      5z      �� 5|      "  ��6:   .�5}   
   ��  �@�FocusVisualStyle 6-   Z� �� 5~   
    � ��$ 0q�6,   �� 5   
    �@�Cursor$
 Hand��6#   �� 5�   
    � ��$ 30��6#   �� 5�   
    � ��$ Center=�65   �� 5�   
    � ��# �  6'   �� 5�   
    � ��$ Normal"�6'   �� 5�   
    � ��$ 10,0,0,0q�6$   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� $ Bd��6   #��z��5�   !   #��z��5�   !   #��z��5�   !   # z��5�   !    . ._�5�      �� #��z��5�   !   # z 5�   !   #��z��5�   !   5�      $ 5�      P� 5�      % �@��
IsSelected& . . �5�      �� $' Bd��6;   # � 	 6K    � ��5�      P� 5�      % �@J�IsMouseOver& . . �5�      �� $' Bd��6;   # � 
 6K    � ��5�      ^� 5�      + 5�      �� 5�   "   , 6,   �� *
IsSelected+ �� *Self+- true6q   �� 5�   "   , 6,   �� *DataContext.CallState+ �� $# ComboBoxL�- TransferenceRequested6�   .0�5�      �� $' Bd��6;   # �  6K    � ��5�      ^� 5�      + 5�      �� 5�   "   , 6,   �� *IsMouseOver+ �� *Self+- true6r   �� 5�   "   , 6,   �� *DataContext.CallState+ �� $# ComboBoxL�- TransferenceRequested6�   .0�5�      �� $' Bd��6;   # �  6K    � ��5�      ^� 5�      + 5�      �� 5�   "   , 6,   �� *
IsSelected+ �� *Self+- true6q   �� 5�   "   , 6,   �� *DataContext.CallState+ �� $# ComboBoxL�- ConferenceRequested6�   .0�5�      �� $' Bd��6;   # �  6K    � ��5�      ^� 5�      + 5�      �� 5�   "   , 6,   �� *IsMouseOver+ �� *Self+- true6r   �� 5�   "   , 6,   �� *DataContext.CallState+ �� $# ComboBoxL�- ConferenceRequested6�   .0�5�      �� $' Bd��6;   # �  6K    � ��5�      5�      5�      5�      �� 5�      "   6   .�5�   
   ��  �@�FocusVisualStyle 6-   Z� �� 5�   
    � ��$ 22��6#   �� 5�   
    � ��$ Segoe UI)�6'   �� 5�   
    � ��$ SemiBold"�6'   �� 5�   
    � ��$ 10(�6%   �� 5�   
    � ��# �  6'   �� 5�   
    � ��
 ���� 6(   �� 5�   
    � ��# �  6'   �� 5�   
    � ��$
 Auto=�6G   �� 5�   
    � ��$
 Auto=�6E   �� 5�   
    � ��$ 12,2,5,3q�6$   �� 5�   
    � �� . 6:   �� 5�   
    �@��PanningMode$
 Both=�65   �� 5�   
    �@��IsFlicksEnabled .  63   �� 5�   
    � ��# �  6%   �� 5�   
    � ��# �  6/   . 5�   
   �� 5�      * 6   �� *	CallState+) TransferenceRequested68   .a�5�      ��  � ��# �  6/   5�      �� 5�      * 6   �� *	CallState+) ConferenceRequested68   .a�5�      ��  � ��# �  6/   5�      �� 5�      * 6   �� *	CallState+) InConference68   .a�5�      ��  � {� .  6.   5�      �� 5�      * 6   �� *	CallState+) InTransference68   .a�5�      ��  � {� .  6.   5�      �� 5�      * 6   �� *	CallState+) Inactive68   .a�5�      ��  � {� .  6.   5�      P� 5�      % � ��& 6-   Z� . �5�      ��  � y�$ 	Collapsed=�6/   5�      P� 5�      % � {�& .  . �5�      ��  � ��# �  6/   �� 5�       � ��# �  6/   5�      5�      �� 5�      "  ��67   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    � ��$	 4,1q�6$   �� 5�   
    � �� 67   �� *HorizontalContentAlignment+ �� "# ���� 5�   
    � �� 65   �� *VerticalContentAlignment+ �� "# ���� 5�   
    � ��
 ���� 6'   �� 5�   
    � ��
 ���� 6(   �� 5�   
    � ��$ 1q�6,   �� 5�   
    �@�FocusVisualStyle 6-   Z� �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� $ Bd��6   #��z��6)   #��z��6U   #��z��6�   # z��6�    . ._�5�      �� #��z��6+   # z 6n   #��z��6�   5�      $ 5�      P� 5�      % � {�& .  . �5�      �� $' Bd��6G   # � ��6W    � ��5�      ]� 5�      / 5�      �� 5�   "   0 �@��
IsSelected- .  6B   �� 5�   "   0 �@J�IsMouseOver- . 6C   �� 5�   "   0 �@J�IsKeyboardFocused- .  6I   ./�5     �� $' Bd��6;    � �� �	#FFBBD8E46K   �� 5     $' Bd��6<    � �� �	#FFBBD8E46L   5     ]� 5     / 5     �� 5  "   0 �@��
IsSelected- . 6B   �� 5  "   0 �@J�IsMouseOver- .  6C   �� 5  "   0 �@J�IsKeyboardFocused- . 6I   ./�5
     �� $' Bd��6;    � �� �	#FFBBD8E46K   �� 5     $' Bd��6<    � �� �	#FFBBD8E46L   5     ]� 5     / 5     �� 5  "   0 �@��
IsSelected- . 6B   �� 5  "   0 �@J�IsMouseOver- . 6C   ./�5     �� $' Bd��6;    � �� �	#FFBBD8E46K   �� 5     $' Bd��6<    � �� �	#FFBBD8E46L   5     ]� 5     / 5     �� 5  "   0 �@��
IsSelected- . 6B   �� 5  "   0 �@J�IsMouseOver- .  6C   �� 5  "   0 �@J�IsKeyboardFocused- .  6I   ./�5     �� $' Bd��6;    � �� �	#FFBBD8E46K   �� 5     $' Bd��6<    � �� �	#FFBBD8E46L   5     ]� 5     / 5     �� 5   "   0 �@��
IsSelected- .  6B   �� 5!  "   0 �@J�IsMouseOver- .  6C   �� 5"  "   0 �@J�IsKeyboardFocused- . 6I   ./�5$     �� $' Bd��6<    � �� �	#FFBBD8E46L   5%     ]� 5&     / 5'     �� 5(  "   0 �@��
IsSelected- .  6B   �� 5)  "   0 �@J�IsMouseOver- . 6C   �� 5*  "   0 �@J�IsKeyboardFocused- . 6I   ./�5,     �� $' Bd��6;    � �� �	#FFBBD8E46K   �� 5-     $' Bd��6<    � �� �	#FFBBD8E46L   5.     50     52     53     �� 55     "  d�6)   .�56  
   ��  �@�OverridesDefaultStyle . 62   �� 57  
    � �� .  6&   �� 58  
    � |� .  6&   �� 59  
    �@��	ClickMode$ Press=�6&   �� 5:  
    � �� 5;     �� 5<     " d�6"   .R�5=     �� $ templateRoot��6    . 
�������#��z��6a   #���  6�   ._�5>     �� $ splitBorder��6!   #��� r�66    . $��0q�6�   $��Right=�6�   $��1q�6�   
������ ._�5?     F� $	 arrow��6#   $��Center=�62   $��0q�6M   $��Center=�6X   
���   �F����        ���( ��( јaQ     јaQ P����̰( � �    P����        6�   5@     5A     $ 5B     ^� 5C     + 5D     �� 5E  "   , 6,   �� *IsMouseOver+ �� *Self+- true6r   �� 5F  "   , 6,   �� *
IsEditable+ �� "# ��	- false6�   .0�5H     ��  �@�Cursor$
 Hand��67   5I     5K     5M     5N     �� 5P     "   6%   .�5Q  
   ��  �@�FocusVisualStyle 6-   Z� �� 5R  
    � ��
 �����6'   �� 5S  
    � ��
 �����6(   �� 5T  
    � ��
 �   �6'   �� 5U  
    � ��$ Segoe UI)�6'   �� 5V  
    � ��$ 11(�6%   �� 5W  
    � ��$ 1q�6,   �� 5X  
    � ��$
 Auto=�6G   �� 5Y  
    � ��$
 Auto=�6E   �� 5Z  
    � ��$ 6,3,5,3q�6$   �� 5[  
    � �� . 6:   �� 5\  
    �@��PanningMode$
 Both=�65   �� 5]  
    �@��IsFlicksEnabled .  63   �� 5^  
    � ��# �  6/   �� 5_  
    � �� 5`     �� 5a     "  6"   .R�5b     � $
 templateRoot��6    .  5c     �� 5d     $��* �6/   �� 5e     #��� r�6/   $��0 �6�   .+�5g     � $ 
PART_Popup��6     . $��2��6N   $��1q�6�   #��� .�6�   $��Bottom=�6&  ��6b   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5h     �� $ dropDownBorder��6%   #��� ��6=   $��1q�6�   #��� ��6�   #��z 6�   ��6  �� *ActualWidth+$ templateRoot��._�5i  "   �� $ DropDownScrollViewer��6/   .��5j  &   � $

 grid��6+   $ Enabled=�69   .+�5k  *   �� $ canvas��61   $
��Left=�6A   $��0��6\   $	��Top=�6g   $��0��6   .+�5l  .   �� $ 
opaqueRect��68   ��6L   �� *
Background+$ dropDownBorder����6�   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5m  +   �� 5n  *   $ ItemsPresenter��69   $ 	Contained=�6Q   # z 6�   5o  '   5p  #   5q     5r     d� 5s     $ toggleButton��6'   #��z��5t  '   #��z��5u  '   #��z��5v  '   $��2��5w  '   #���  5y  '    5x  '   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+5y  '   �� 5z     $ contentPresenter��6+   #��z 5{  +   #��z��5|  +   #��z 5}  +   #  z 5~  +   #��z��5  +   ! .  #��z��5�  +   # z 5�  +   #��z��5�  +   �� 5�     $" 	WaterMark��6$   $��Center=�5�  $   $
��Left=�5�  $   $	��5,0q�5�  $   $y�	Collapsed=�5�  $   #���  5�  $   ��5�  $   �� *WaterMarkTabulation+ �� "#  5�  $   5�     $ 5�     P� 5�     % �@��HasItems& .  . �5�     �� $' dropDownBorder��67    � ��$ 95��6S   5�     ]� 5�     / 5�     �� 5�  "   0 �@��
IsGrouping- . 6B   ./�5�     ��  � �� .  6N   5�     P� 5�     $( DropDownScrollViewer��6K   % � ��& .  . �5�     �� $' 
opaqueRect��6;    6S   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5�     $' 
opaqueRect��6<    6T   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5�     P� 5�     % �@��SelectedItem$&  ��6:   . �5�     �� $' 	WaterMark��6;    � y�$ Visible=�6R   5�     P� 5�     & 6:   Z� % �@��SelectedItem. �5�     �� $' 	WaterMark��6;    � y�$ Visible=�6R   5�     5�     5�     5�     �� 5�     .R�5�  
   � $��85��6   .+�5�     �� $1 
ImgCliente��6   #���  6(   $2 HighQuality=�6R   $3 Aliased=�6�   $��30��6�   $��7,17,0,0q�6�   $	��Top=�6�   $
��Left=�6�   �� 5�     #���  6   $��11(�6;   $��	50,17,0,0q�6_   $	��Top=�6r   $
��Left=�6�   ��6I   �� *Name+6�   �� 5�     #���  6   $��	50,31,0,0q�6Z   $	��Top=�6m   $
��Left=�6�   ��6=   �� *ContactType+6�   �� 5�     #���  6   $��	50,50,0,0q�6T   $	��Top=�6g   $
��Left=�6   ��6=   �� *Phone+6   �� 5�     #���  6   $��	50,0,0,13q�6T   $��Bottom=�6g   $
��Left=�6�   ��6=   �� *Email+6�   5�     5�     �� 5�     .R�5�  
   � $	
 grd��6   $��93��6   .+�5�     �� $1 
ImgCliente��6   #���  6(   $2 HighQuality=�6T   $3 Aliased=�6�   $��36��6�   $��2,12,0,0q�6�   $	��Top=�6�   $
��Left=�6�   �� 5�     #���  6   $��11(�6;   $��	48,13,0,0q�6_   $	��Top=�6r   $
��Left=�6�   ��6I   �� *Name+6�   �� 5�     #���  6   $��	48,30,0,0q�6Z   $	��Top=�6m   $
��Left=�6�   ��6=   �� *ContactType+6�   �� 5�     #���  6   $��	48,50,0,0q�6T   $	��Top=�6g   $
��Left=�6   ��6=   �� *Phone+6   �� 5�     #���  6   $��	48,0,0,20q�6T   $��Bottom=�6g   $
��Left=�6�   ��6=   �� *Email+6�   5�     4 5�  
   �� 5�     * 6   �� *Name+) 63   Z� .a�5�     �� $' 
ImgCliente��6    � y�$ 	Collapsed=�6G   5�     �� 5�     $)  ��63   * 6   �� *Name+.a�5�     �� $' 
ImgCliente��6    � y�$ 	Collapsed=�6G   5�     5�     �� 5�     "  ��66   .�5�  
   ��  �@�FocusVisualStyle 6-   Z� �� 5�  
    �@�Cursor$
 Hand��6#   �� 5�  
    � ��$ 85��6#   �� 5�  
    � ��$ Center=�65   �� 5�  
    � �� 5�     �� 5�     " ��6"   .R�5�     � .+�5�     �� $ Bd��6!   #���  5�  !   $��0,1,0,0q�5�  !   
������ # z��5�  !    . 5�  !   �� 5�     #��z��5�  !   # z 5�  !   #��z��5�  !   5�     $ 5�     P� 5�     % �@��
IsSelected& . . �5�     ��  � �� .  6:   �� 5�      � ��$ 0��67   5�     P� 5�     % �@J�IsMouseOver& . . �5�     �� $' Bd��6;   # �   6K    � ��5�     P� 5�     % �@J�IsKeyboardFocusWithin& . . �5�     �� $' Bd��6;   # �   6K    � ��5�     5�     5�     5�     �� 5�     "  d�6=   .�5�  
   ��  �@�OverridesDefaultStyle . 62   �� 5�  
    � �� .  6&   �� 5�  
    � |� .  6&   �� 5�  
    �@��	ClickMode$ Press=�6&   �� 5�  
    � �� 5�     �� 5�     " d�6"   .R�5�     �� $ templateRoot��6   #��z��5�      . ��5�     �� *
Background+ �� $# ComboBoxL�._�5�     � .+�5�     �� $ splitBorder��6%   $��Right=�5�  !    . $
 Hand��5�  !   $��32��5�  !   ��5�  "   �� 5�  &   $ Transparent��66   ._�5�  "   F� $	 arrow��6'   "����        р��     �@KL ��[ 	#��� " 5   %   $��Center=�5  %   $��Center=�5  %   5     �� 5     $��Right=�6%   $��32��6A   $��1,0,0,0q�5  )   $
��0,10q�5  )   #���  5  )   5     5	     $ 5
     P� 5     % �@d�	IsChecked$
& trueY�67   . �5     �� $' arrow��6%    � ��" ��    ��[ р�� ��[ �@KL     	6H   5     5     5     5     �� 5     "  62   .R�5  
   � $
 templateRoot��6    .  5     �� 5     $��* �6#   �� 5     #��� r�6#   $��0 �6v   .+�5     � $ 
PART_Popup��6   $��2��5      . #��� .�5     $��Bottom=�5      ��5     �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5!     � #��z��6   ��5"     �� *ActualWidth+$ templateRoot��.+�5#     �� .+�5$     �� $��0q�6!   $��1��65   #���  6@     5%     $5 PART_SearchTextBox��63   $��20��6O   $	��275��6[   $	��0,4q�6g   $��Stretch=�6t   $6 Buscar contato por nome��5&  &   �� 5'     $��0q�6!   $��1��65   #���  6@   �� 5(     $ DropDownScrollViewer��6'   $��0q�6E   $��0q�6Q   $��0q�6e   #��z 5)  '   #��z��5*  '   .��5+     �� $ PART_ItemsPresenter��6-   $ 	Contained=�5,  %   # z 5-  %   5.     �� 50     $7 PART_ButtonAdd��6!   $��30��69   #��� $ 51  %   $��[+] Criar Novo Contato��53  %   ��52  %   �� *
NewContact+53  %   54     �� 56     $" TxtNoContacts��6    $	��Top=�57      $��Center=�68   $8 Center=�6U   $
��0,40q�6l   $y�	Collapsed=�58      #���  59      $��12(�6C   $��Nenhum contato encontrado��5:      5;     5<     d� 5=     $ toggleButton��6   $��2��5>     #��z��5?     #��z��5@     #��z��5A     #��� ! 5C      5B     �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+5C     �� 5D     $ contentPresenter��6   #���  5E     #��z��5F     #��z 5G     #  z 5H     #��z��5I     ! .  #��z��5K     # z 5L     #��z��5M     5N     $ 5O  
   �� 5P     $) 0��6`   * 6   �� *Items.Count+ �� *Self+.a�5Q     �� $' TxtNoContacts��6    � y�$ Visible=�6J   5R     �� 5S     $) 1��6`   * 6   �� *Items.Count+ �� *Self+.a�5T     �� $' TxtNoContacts��6    � y�$ Visible=�6J   5U     5W     �� 5Y     "  ��6(   .�5Z  
   ��  �@��MaxDropDownHeight$	 256��6.   �� 5[  
    �@�FocusVisualStyle 6-   Z� �� 5\  
    � ��$ 93��6#   �� 5]  
    � ��$ Segoe UI)�6'   �� 5^  
    � ��# � & 6'   �� 5_  
    � ��
 ���� 6(   �� 5`  
    � ��$
 Auto=�6G   �� 5a  
    � ��$
 Auto=�6E   �� 5b  
    � �� . 6:   �� 5c  
    �@��PanningMode$
 Both=�65   �� 5d  
    �@��IsFlicksEnabled .  63   �� 5e  
    � ��$
 Left=�67   �� 5f  
    � ��$ Center=�65   �� 5g  
   % �@��IsSynchronizedWithCurrentItem$
 TrueY�6:   �� 5h  
    � ��# � # 6%   �� 5i  
    � ��# �  6)   �� 5j  
    � ��# �  6/   . 5k  
   P� 5l     % �@��IsDropDownOpen& . . �5m     ��  � ��# � ' 6/   5n     5p     5r     