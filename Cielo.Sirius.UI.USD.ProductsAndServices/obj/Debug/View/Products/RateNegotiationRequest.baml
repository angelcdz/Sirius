   M S B A M L   `   `   `  ����V  RCielo.Sirius.Foundation.USD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Wclr-namespace:Cielo.Sirius.Foundation.USD.Controls;assembly=Cielo.Sirius.Foundation.USD$Cielo.Sirius.Foundation.USD.Controls  5      �Yclr-namespace:Cielo.Sirius.Foundation.USD.Converters;assembly=Cielo.Sirius.Foundation.USD&Cielo.Sirius.Foundation.USD.Converters  5      b ^Cielo.Sirius.UI.USD.ProductsAndServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Cielo.Sirius.UI.USD.ProductsAndServices.View,Cielo.Sirius.UI.USD.ProductsAndServices.View 5      nNclr-namespace:Cielo.Sirius.Foundation.USD;assembly=Cielo.Sirius.Foundation.USDCielo.Sirius.Foundation.USD  5      �Xclr-namespace:Cielo.Sirius.Foundation.USD.Behaviors;assembly=Cielo.Sirius.Foundation.USD%Cielo.Sirius.Foundation.USD.Behaviors  5	      I   CCielo.Sirius.UI.USD.ProductsAndServices.View.RateNegotiationRequest   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      lcontrolsWclr-namespace:Cielo.Sirius.Foundation.USD.Controls;assembly=Cielo.Sirius.Foundation.USD     5      p
convertersYclr-namespace:Cielo.Sirius.Foundation.USD.Converters;assembly=Cielo.Sirius.Foundation.USD     5      Kview:clr-namespace:Cielo.Sirius.UI.USD.ProductsAndServices.View     5      _baseNclr-namespace:Cielo.Sirius.Foundation.USD;assembly=Cielo.Sirius.Foundation.USD     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h	behaviorsXclr-namespace:Cielo.Sirius.Foundation.USD.Behaviors;assembly=Cielo.Sirius.Foundation.USD  5	      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5
         ViewBaseControlStyle#���   5      $	��565��5      $	��376��6     � 	Resources  5      F   @Cielo.Sirius.Foundation.USD.Converters.BoolToVisibilityConverter  BoolToVisibilityConverter��%   &	         5   
   6/   5      .��5      � .+�5   
   �� .+�5      ��   DetailTextDark#���  5      $
��Auto��5      $
��Auto��6"   $
��Left=�6/   $	��Top=�6J   ��5      �� *SolutionEstimatedDate+.  (System.Windows.Interactivity.Interaction   Triggers 5      9  3Microsoft.Expression.Interactivity.Core.DataTrigger  5         Value$
 true��6>   D  >Microsoft.Expression.Interactivity.Core.PropertyChangedTrigger   Binding 6!   �� *
HasError+.  (System.Windows.Interactivity.TriggerBase   Actions. 5      B  <Microsoft.Expression.Interactivity.Core.ChangePropertyAction     PropertyName$ Style��6.     ErrorTextDetail   Value# �  6C   5        5      $ false��6?    6"   �� *
HasError+. 5        $ Style��6.   # �  6C   5      5      �� 5      $��0,30,0,0q�6   $��Taxa desejada:��6*   $
��Left=�6@   $	��100��6[   �� 5      $��0,5,0,0q�6   $
��Left=�6'   $	��300��6B   ��6N   �� *TaxaDesejada+.��6l      	Behaviors 5       B   <Cielo.Sirius.Foundation.USD.Behaviors.NumericTextBoxBehavior  5!      .��5"   +   5#      5$      �� 5&   
    �� Orientation$ Vertical=�6   $��	0,248,0,0q�6,   $	��Top=�6?   $
��Left=�6W   .+�5'      �� $��Motivo��6     ScreenSubtitle#���  6&   =   7Cielo.Sirius.Foundation.USD.Controls.TabulationComboBox  5(      $	��290��6*   $��20��5)   *   $��0,10,0,0q�5*   *   $
��Left=�5+   *   $	��Top=�5,   *   	   WaterMarkTabulation$	 Selecione o motivo��5-   *   
 �� DisplayMemberPath$
 
NomeMotivo��5/   *     FilterTabulation#���  51   *    � Cursor$
 Hand��6U   ��5.   *   �� *
ReasonList+ �� SelectedItem 50   *   �� *SelectedReason+51   U   �� 53      $��0,10,0,0q�54   -   $
��Auto��6?   $	��Top=�6M   $
��Left=�6e   $
��Auto��6�   y�53      �� *HasRatesErros+ �� 	Converter# [ .+�55      �� $��	Atenção��6     ErrorLabelText#���  6*   �� 56        ErrorLabelTextDetail#���  69   ��6   �� *ErrorMessage+69   57      �� 59      $��ENVIAR��6   $	��111��6&   $��25��62   $��0,15,0,0q�6>     MainActionButtonStyle#���  6P   $	��Top=�6�   $
��Left=�6�   ��6�   �� *
SendDemand+5:      5;      5<      