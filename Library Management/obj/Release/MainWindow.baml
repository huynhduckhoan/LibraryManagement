   M S B A M L   `   `   `  ���� M  ILibrary Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Library_ManagementLibrary_Management  H DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 7 clr-namespace:Library_ManagementLibrary_Management  #    Library_Management.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:Library_Management     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     S OMahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  )uc clr-namespace:Library_Management  (  "MahApps.Metro.Controls.MetroWindow    ShowIconOnTitleBar  .  � Icon$ ./Resource/icon.png�� � Title$" Quản Lý Sách Thư Viện��$	��600��$
��1000��   RightWindowCommands +  %MahApps.Metro.Controls.WindowCommands  .@��� .��.  (MahApps.Metro.IconPacks.PackIconMaterial  E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null�  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ExitToApp=��� .����  �� Orientation$ 
Horizontal=�.+�1  +MahApps.Metro.IconPacks.PackIconFontAwesome  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]   Kind$ 
UsersSolid=��� $��4 0 0 0q�$��Center=�$��THÀNH VIÊN���� .���� $ 
Horizontal=�.+�,  &MahApps.Metro.IconPacks.PackIconModern  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconModernKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]   Kind$ Settings=��� $��4 0 0 0q�$��Center=�$��CÀI ĐẶT���� -    ��Name$ github��.��1	  +MahApps.Metro.IconPacks.PackIconSimpleIcons	  �
  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconSimpleIconsKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]	 
  Kind$	 GitHub=�.��� 
 � RowDefinitions
 �� $
��auto ��� �� $
��auto �.+�� $��0�� � 	Resources  �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�   'd�       �� " d�.���  � ��$ 86����  � ��$ 86����  � ��$ 7q���  � �� �#3498db��  � �� �#3498db P�  �@d�	IsChecked$
 TrueY�. ���  � �� �#2980b9 � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� .+�� $��0��.+�d� -    d�Name$ tgbBorrowBook�� d� 	IsChecked �� *IsBorrowBook+.���� .+�.  (MahApps.Metro.IconPacks.PackIconOcticons  $��54��$��54��$��Center=�$��Center=��  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconOcticonsKind, MahApps.Metro.IconPacks, Version=2.2.0.12, Culture=neutral, PublicKeyToken=null]]   Kind$ 
CreditCard=�
��������� $��Mượn Sách��$��12(�$��Center=�
�������� $��1��.+�d� -   $ tgbBooks�� �� *IsBook+.���� .+�  $��54��$��54��$��Center=�$��Center=�$ BookHardcoverOpen=�
��������� $��Sách��$��12(�$��Center=�
�������� $��2��.+�d� -   $ tgbStudents�� �� *	IsStudent+.���� .+�  $��54��$��54��$��Center=�$��Center=�$ AccountEdit=�
��������� $��
Sinh Viên��$��12(�$��Center=�
�������� $��1��.+�#   Library_Management.BorrowBook  -     Name$ ucBorrowBook��   Library_Management.Books  -     Name$ ucBooks��$y�Hidden=�!   Library_Management.Students  -     Name$ 
ucStudents��$y�Hidden=�