   M S B A M L   `   `   `  ����L  Hpetshopmanagament, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:petshopmanagamentpetshopmanagament  5   	   !    petshopmanagament.SalesPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:petshopmanagament     5   	     � Title$  	SalesPage��5   	   $	��600��6   $	��800��6(   .��5	      �� .+�5
   
   �� -   5         ��Name$ cbCustomers��5
       �� SelectedValuePath$ Id��6(   $��10q�6?   $	��200��6K   ��5      �� 5      .R�5      �� ��6    �� *Name+5      5      �� 5   
   $��Select items to purchase��6   $��16(�63   $��10q�6A   �� 5   
   $
��Auto=�6   $	��200��6:   .��5      �� -   5         ��Name$ listItemsToPurchase��5      $��5q�64   ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6%   $��5q�6>   .+�5      �� $	��100��6$   $	��100��60   ��6=   �� *
ImageUrl+�� 5      $��10q�6)   .+�5   "   �� $
��Bold"�6B   ��6,   �� *Name+6B   �� 5   "   ��6,   �� *Price+ �� StringFormat$ Price: {0:C}���� 5   "   $ 
Horizontal=�6-   .+�5   &   �� -   5        $��Add to Cart��5   -   ��6C   �� 6`   �� 5   &   $��40��6.   ��69   �� *
Quantity+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5   #   5      5       5!      5#      5$      �� 5%   
   $��Shopping Cart��6   $��16(�6(   $��10q�66   �� 5&   
   $
��Auto=�6   $	��200��6:   .��5'      �� -   5        $ 	cartItems��5'      $��5q�6*   ��5(      �� 5)      .R�5*      �� $ 
Horizontal=�6%   $��5q�6>   .+�5+      �� $��50��6$   $��50��6/   ��6;   �� *
ImageUrl+�� 5,      $��10q�6)   .+�5-   "   �� $
��Bold"�6B   ��6,   �� *Name+6B   �� 5.   "   ��6,   �� *Price+$ Price: {0:C}���� 5/   "   ��6,   �� *
Quantity+$ Quantity: {0}���� 50   "   -   5        $��Remove��50   )   ��6:   �� 6W   51      52      53      55      56      �� 57   
   -   5         ��Name$ txtTotal��57      $��16(�6&   $
��Bold"�64   $��10q�6F   �� 58   
   -   5        $��Complete Purchase��58      $��10q�6L   59      5:      