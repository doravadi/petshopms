   M S B A M L   `   `   `  ����L  Hpetshopmanagament, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:petshopmanagamentpetshopmanagament  5   	   %    petshopmanagament.AddSaleWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:petshopmanagament     5   	     � Title$  AddSaleWindow��5   	   $	��300��6   $	��400��6,   .��5	      �� $��10q�6   .+�5
   
   �� .��6   	Customer:6   �� 5   
   -   5         ��Name$ cbCustomers��5       �� DisplayMemberPath$
 Name��6(   �� 5   
   .��6   Pet:6   �� 5   
   -   5        $ cbPets��5      $
 Name��6#   �� 5   
   .��6   
Sale Date:6   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
dpSaleDate��5      �� 5   
   .��6   Sale Amount:6   �� 5   
   -   5         ��Name$ txtSaleAmount��5      �� 5   
   -   5        $��Add Sale��5      6$   5      5      