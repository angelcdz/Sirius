   M S B A M L   `   `   `  ����V  RCielo.Sirius.Foundation.USD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Wclr-namespace:Cielo.Sirius.Foundation.USD.Controls;assembly=Cielo.Sirius.Foundation.USD$Cielo.Sirius.Foundation.USD.Controls  5      �Yclr-namespace:Cielo.Sirius.Foundation.USD.Converters;assembly=Cielo.Sirius.Foundation.USD&Cielo.Sirius.Foundation.USD.Converters  5	      b ^Cielo.Sirius.UI.USD.ProductsAndServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Cielo.Sirius.UI.USD.ProductsAndServices.View,Cielo.Sirius.UI.USD.ProductsAndServices.View 5
      nNclr-namespace:Cielo.Sirius.Foundation.USD;assembly=Cielo.Sirius.Foundation.USDCielo.Sirius.Foundation.USD  5      @   :Cielo.Sirius.UI.USD.ProductsAndServices.View.EnableService   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      fcontrolsWclr-namespace:Cielo.Sirius.Foundation.USD.Controls;assembly=Cielo.Sirius.Foundation.USD  5      j
convertersYclr-namespace:Cielo.Sirius.Foundation.USD.Converters;assembly=Cielo.Sirius.Foundation.USD  5	      Eview:clr-namespace:Cielo.Sirius.UI.USD.ProductsAndServices.View  5
      YbaseNclr-namespace:Cielo.Sirius.Foundation.USD;assembly=Cielo.Sirius.Foundation.USD  5         ViewBaseControlStyle#���   5      $	��565��5        � 	Resources  5         BooleanToVisibilityConverter��%   &	       �� 5   
   6'   5      .��5      � .+�5   
   ��   DetailTextDark#���  5      $
��Auto��5      $
��Auto��6"   $
��Left=�6/   $	��Top=�6J   ��5      �� *SolutionEstimatedDate+.  (System.Windows.Interactivity.Interaction   Triggers 5      9  3Microsoft.Expression.Interactivity.Core.DataTrigger  5         Value$
 true��6>   D  >Microsoft.Expression.Interactivity.Core.PropertyChangedTrigger   Binding 6!   �� *
HasError+.  (System.Windows.Interactivity.TriggerBase   Actions. 5      B  <Microsoft.Expression.Interactivity.Core.ChangePropertyAction     PropertyName$ Style��6.     ErrorTextDetail   Value# �  6C   5        5      $ false��6?    6"   �� *
HasError+. 5        $ Style��6.   # �  6C   5      5      �� 5    
   $��Confirmar Solicitação?��6     BaseTextDark#���  62   $��0,30,0,0q�6Y   �� 5!   
    �� Orientation$ Vertical=�6   $��	0,248,0,0q�6,   $	��Top=�6?   $
��Left=�6W   .+�5"      �� $��Motivo��6     ScreenSubtitle#���  6&   =   7Cielo.Sirius.Foundation.USD.Controls.TabulationComboBox  5#      $	��290��6*   $��20��5$   *   $��0,10,0,0q�5%   *   $
��Left=�5&   *   $	��Top=�5'   *      WaterMarkTabulation$ Selecione o motivo��5(   *   	 �� DisplayMemberPath$	 
NomeMotivo��5*   *     FilterTabulation#���  5,   *   
 � Cursor$

 Hand��6U   ��5)   *   �� *
ReasonList+ �� SelectedItem 5+   *   �� *SelectedReason+5,   U   �� 5.      $��0,10,0,0q�5/   -   $
��Auto��6?   $	��Top=�6M   $
��Left=�6e   $
��Auto��6�   y�5.      �� *HasInputError+ �� 	Converter# [ .+�50      �� $��	Atenção��6     ErrorLabelText#���  6*   �� 51        ErrorLabelTextDetail#���  69   ��6   �� *ErrorMessage+69   52      �� 54      $��ENVIAR��6   $	��111��6&   $��25��62   $��0,15,0,0q�6>   $	��Top=�6P   $
��Left=�6h    	 MainActionButtonStyle#��� 	 55      ��56      �� *EnableServiceCommand+57      58      59      