   M S B A M L   `   `   `  ����V  RCielo.Sirius.Foundation.USD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Wclr-namespace:Cielo.Sirius.Foundation.USD.Controls;assembly=Cielo.Sirius.Foundation.USD$Cielo.Sirius.Foundation.USD.Controls  5      �Yclr-namespace:Cielo.Sirius.Foundation.USD.Converters;assembly=Cielo.Sirius.Foundation.USD&Cielo.Sirius.Foundation.USD.Converters  5	      �Xclr-namespace:Cielo.Sirius.Foundation.USD.Behaviors;assembly=Cielo.Sirius.Foundation.USD%Cielo.Sirius.Foundation.USD.Behaviors  5
      nNclr-namespace:Cielo.Sirius.Foundation.USD;assembly=Cielo.Sirius.Foundation.USDCielo.Sirius.Foundation.USD  5      + 'Cielo.Sirius.UI.USD.ProductsAndServicesJ   DCielo.Sirius.UI.USD.ProductsAndServices.View.RateChangeCreditoAVista   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      fcontrolsWclr-namespace:Cielo.Sirius.Foundation.USD.Controls;assembly=Cielo.Sirius.Foundation.USD  5      j
convertersYclr-namespace:Cielo.Sirius.Foundation.USD.Converters;assembly=Cielo.Sirius.Foundation.USD  5	      h	behaviorsXclr-namespace:Cielo.Sirius.Foundation.USD.Behaviors;assembly=Cielo.Sirius.Foundation.USD  5
      YbaseNclr-namespace:Cielo.Sirius.Foundation.USD;assembly=Cielo.Sirius.Foundation.USD  5         ViewBaseControlStyle#���   5      $	��565��5        � 	Resources  5         BooleanToVisibilityConverterS   MCielo.Sirius.Foundation.USD.Converters.StringNullOrEmptyToVisibilityConverter * &StringNullOrEmptyToVisibilityConverter=   7Cielo.Sirius.Foundation.USD.Converters.BoolNotConverter  BoolNotConverter��%W   &	       &	      &	 &     �� 5   
   6'     5   
   6<     5   
   6&   5      .��5      � .+�5   
   ��   DetailTextDark#���  5      $
��Auto��5      $
��Auto��6"   $
��Left=�6/   $	��Top=�6J   ��5      �� *SolutionEstimatedDate+.  (System.Windows.Interactivity.Interaction   Triggers 5      9  3Microsoft.Expression.Interactivity.Core.DataTrigger  5         Value$
 true��6>   D  >Microsoft.Expression.Interactivity.Core.PropertyChangedTrigger   Binding 6!   �� *
HasError+.  (System.Windows.Interactivity.TriggerBase   Actions. 5      B  <Microsoft.Expression.Interactivity.Core.ChangePropertyAction     PropertyName$ Style��6.     ErrorTextDetail   Value# �  6C   5        5      $ false��6?    6"   �� *
HasError+. 5        $ Style��6.   # �  6C   5      5      �� 5    
   $��0,30,0,0q�6   $��Taxas��6&     ScreenSubtitle#���  63   &   System.Windows.Controls.DataGrid  5!   
   $��0,52,0,0q�6   $
��Left=�6%   $	��Top=�6@     DataGridDefault#���  5"        DataGridCheckRowStyle   RowStyle# �  5#      ��5$      �� *Rates+   	Behaviors 5%      I	   CCielo.Sirius.Foundation.USD.Behaviors.DataGridVerifyLoadRowBehavior	  5&      	   Columns	 5(      4
  .System.Windows.Controls.DataGridTemplateColumn
  5)      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Taxa Padrão��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6>    
  CellTemplate 5*      �� 5+      .R�5,      ��  	 BaseTextDark#��� 	 5-   4   ��5,   (   �� *DefaultValue+ �� StringFormat$ {0:N2}%��{�5.   4   �� *
IsSelected+ �� RelativeSource ��  �� AncestorType$ DataGridRowL�5/      51      
  52      $
 Taxa Contratada��6)   $	 100 6B    53      �� 54      .R�55      �� #��� 	 56   4   ��55   (   �� *ContractedValue+$ {0:N2}%��{�57   4   �� *
IsSelected+ �� $ DataGridRowL�58      5:      
  5;      $
 	Nova Taxa��6)   $	 180 6<    5<      �� 5=      .R�5>      � {�6#   �� *
IsSelected+ �� $ DataGridRowL� � ColumnDefinitions 5?   "   �� 5@   &   $
��Auto �67   �� 5A   &   $��* �67    � RowDefinitions 5C   "   �� 5D   &   $��22 �64   �� 5E   &   $��20 �64   .+�5H   "   �� $��16��6*   $	��100��66   $
��Left=�6B   $	��Top=�6]   $��2,5,2,0q�6u   $��10(�6�   ��5I   6   �� *NewCustomValue+ �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnValidationError .  �� ValidatesOnDataErrors . {�5J   6   �� *	IsChecked+ �� ElementName$ MatrixRateCheck�� �� 	Converter# [ .��6�    5K   &   /  )System.Windows.Interactivity.EventTrigger  5L   *      	EventName$ TextChanged��69   . 5M   .   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6D   �� *DataContext.CheckRatesErros+ �� $ DataGridL�5N   +   .��5O   >   5P   #   �� 5R   "   $��1��6-    �� Orientation$ 
Horizontal=�6:   $	��2,0q�6S   $	��Top=�6`   .+�5S   &   �� $	��Top=�6g   $
��Auto��6   #��� 	 5T   <   $��8(�6c   {�.  ��5S   0   �� *
MinValue+$ Min: {0:N2}%��5T   p   �� 5U   &   $	��Top=�6g   $
��Auto��6   $	��6,0q�6�   #��� 	 5V   <   $��8(�6c   {�.  ��5U   0   �� *
MaxValue+$ Max: {0:N2}%��5V   p   5W   #   �� 5Y   "    ��Name$ MatrixRateCheck��6+   $��1��6D   $��2��6T   $	��2,5q�6e    d� 	IsChecked 5Z   7   �� *UseMatrixValue+ �� Mode$ TwoWay=� 5[   &     5\   *   $ Checked��69   . 5]   .      6D   �� *DataContext.SelectMatrixValue+ �� $ DataGridL�   CommandParameter 6�   �� 5^   +   .��5a   &   ��  J� IsHitTestVisible .  #��� 	 6I   �� 5b   6   $�Utilizar taxa da��6:   �� 5c   6   �� 5d   6   $�matriz:��6:   �� 6K   �6O   �� *MatrixValue+$ {0:N2}%��5e   '   5f   #   5g      5h      5j      5l      �� 5n   
   $ Vertical=�6   $��	0,248,0,0q�6,   $	��Top=�6?   $
��Left=�6W   .+�5o      �� $��Motivo��6   #���  6&   =   7Cielo.Sirius.Foundation.USD.Controls.TabulationComboBox  5p      $	��290��6*   $��20��66   $��0,10,0,0q�6B   $
��Left=�6T   $	��Top=�6o      WaterMarkTabulation$ Selecione o motivo��5q   2    
 FilterTabulation#��� 
 5t   2     � Cursor$
  Hand��6]   ��5r   2   �� *
ReasonList+! �� SelectedItem! 5s   2   �� *ReasonSelected+5t   ]   �� 5v      $��0,10,0,0q�5w   -   $
��Auto��6?   $	��Top=�6M   $
��Left=�6e   $
��Auto��6�   y�5v      �� *HasRatesErros+# [ .+�5x      �� $��	Atenção��6     	ErrorText#���  6+   �� 5y      $R��L*Taxa inserida para a parcela está fora do intervalo de valores permitidos.��6     DetailTextDarkMessage#���  6o   5z      �� 5|      $��ENVIAR��6   $	��111��6&   $��25��62   $��0,15,0,0q�6>   $	��Top=�6P   $
��Left=�6h     MainActionButtonStyle#���  5}      ��5~      �� *SendChageRateRequestCommand+5      5�      5�      