   M S B A M L   `   `   `  ����M  ILibrary Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Library_ManagementLibrary_Management  5   	   H DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   7 clr-namespace:Library_ManagementLibrary_Management  5
   	   #    Library_Management.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Library_Management     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   S OMahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   )uc clr-namespace:Library_Management  5
   	   (  "MahApps.Metro.Controls.MetroWindow    ShowIconOnTitleBar  .  � Icon$ ./Resource/icon.png��5   	    � Title$" Quản Lý Sách Thư Viện��5   	   $	��600��6'   $
��1000��64      RightWindowCommands 5      +  %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� .��5      .  (MahApps.Metro.IconPacks.PackIconMaterial  E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null�  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ExitToApp=�6-   5      �� 5      .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      1  +MahApps.Metro.IconPacks.PackIconFontAwesome  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]   Kind$ 
UsersSolid=�64   �� 5      $��4 0 0 0q�6    $��Center=�5      $��THÀNH VIÊN��5      5      5      �� 5      .��5      �� $ 
Horizontal=�6   .+�5       ,  &MahApps.Metro.IconPacks.PackIconModern  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconModernKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]   Kind$ Settings=�6/   �� 5!      $��4 0 0 0q�6    $��Center=�5"      $��CÀI ĐẶT��5#      5$      5%      �� 5&      -   5         ��Name$ github��5&      .��5'      1	  +MahApps.Metro.IconPacks.PackIconSimpleIcons	  �
  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconSimpleIconsKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]	 
  Kind$	 GitHub=�60   5(      5)      .��5/      � 
 � RowDefinitions
 50   
   �� 51      $
��auto �6   6,   �� 52      6   �� 53      $
��auto �6   6,   .+�57   
   � $��0��6    � 	Resources 58       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%o  'd�       �� 59      " d�6   .�5:      ��  � ��$ 86��6.   6;   �� 5;       � ��$ 86��6/   6<   �� 5<       � ��$ 7q�6/   6;   �� 5=       � �� �#3498db6E   �� 5>       � �� �#3498db6F    5?      P� 5@       �@d�	IsChecked$
 TrueY�67   . �5A      ��  � �� �#2980b96;   5B      5D      5E       � ColumnDefinitions 5F      �� 5G      $
��auto �6#   62   �� 5H      $
��auto �6#   62   �� 5I      $
��auto �6#   62   �� 5J      $
��auto �6#   62   �� 5K      6%   .+�5M      � $��0��6   .+�5N      d� -   5         d�Name$ tgbBorrowBook��5N   C    d� 	IsChecked 6    �� *IsBorrowBook+.��5O      �� .+�5P      .  (MahApps.Metro.IconPacks.PackIconOcticons  $��54��65   $��54��5Q   -   $��Center=�5R   -   $��Center=�5S   -   �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconOcticonsKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]   Kind$ 
CreditCard=�5T   -   
�������6?   �� 5U      $��Mượn Sách��6    $��12(�64   $��Center=�6B   
�������6f   5V      5W      5X      � 5Y      $��1��6   .+�5Z      d� -   5        $ tgbBooks��5Z   <    6   �� *IsBook+.��5[      �� .+�5\        $��54��63   $��54��5]   -   $��Center=�5^   -   $��Center=�5_   -   $ BookHardcoverOpen=�5`   -   
�������6F   �� 5a      $��Sách��6    $��12(�6/   $��Center=�6=   
�������6a   5b      5c      5d      � 5e      $��2��6   .+�5f      d� -   5        $ tgbStudents��5f   ?    6   �� *	IsStudent+.��5g      �� .+�5h        $��54��65   $��54��5i   -   $��Center=�5j   -   $��Center=�5k   -   $ AccountEdit=�5l   -   
�������6@   �� 5m      $��
Sinh Viên��6    $��12(�64   $��Center=�6B   
�������6f   5n      5o      5p      5}      � 5�   
   $��1��6   .+�5�      #   Library_Management.BorrowBook  -   5          Name$ ucBorrowBook��5�      64      Library_Management.Books  5�      -   5          Name$ ucBooks��5�      $y�Hidden=�6(   6>   !   Library_Management.Students  5�      -   5          Name$ 
ucStudents��5�      $y�Hidden=�6.   6D   5�      5�      5�      