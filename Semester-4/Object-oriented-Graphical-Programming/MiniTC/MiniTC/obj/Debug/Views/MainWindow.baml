   M S B A M L   `   `   `  ����A  =MiniTC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MiniTC.ResourcesMiniTC.Resources  5   	   O,clr-namespace:MiniTC.CustomControls._PanelTCMiniTC.CustomControls._PanelTC  5   	   5clr-namespace:MiniTC.ViewModelsMiniTC.ViewModels  5	   	       MiniTC.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4	resourcesclr-namespace:MiniTC.Resources     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   ;controls,clr-namespace:MiniTC.CustomControls._PanelTC  5   	   (vmclr-namespace:MiniTC.ViewModels  5	   	       MiniTC.Resources.Resources    WindowTitle � Title# Z  5   	   $	��600��6<   $	��650��6I    � 
ResizeMode$ NoResize=�6U   ���	#FFF0F0F0 � 	Resources 5        MiniTC.ViewModels.MainVM 
  mainVM��%   &	          5   
   6   5      .��5      � -   5         �Name$ MainGrid��5       � DataContext# [  6    � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   ,   &MiniTC.CustomControls._PanelTC.PanelTC  $��0��6   $��0��6+   $��10, 0q�68      CurrentPath 6K   �� 	 �� Path$	 CurrentLeftPath�
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   AvailableDrives	 5   G   �� $	 Drives�$
 TwoWay=�$ PropertyChanged=�
   CurrentDrive 5   J   �� $	 CurrentLeftDriveIndex�$
 TwoWay=�$ PropertyChanged=�   CurrentPathContents	 5   C   �� $	 CurrentLeftContent�$
 TwoWay=�$ PropertyChanged=�
  5   
   $��1��6   $��0��6+   $��10, 0q�68    6K   �� $	 CurrentRightPath�$
 TwoWay=�$ PropertyChanged=�	 5   G   �� $	 Drives�$
 TwoWay=�$ PropertyChanged=�
 5    J   �� $	 CurrentRightDriveIndex�$
 TwoWay=�$ PropertyChanged=�	 5!   C   �� $	 CurrentRightContent�$
 TwoWay=�$ PropertyChanged=�
�� 5"   
   $��2��6   $��1��6%   $	��100��62   $��30��6>   $��5q�6J      CopyButtonContent#��Z 6U   5#      5$      