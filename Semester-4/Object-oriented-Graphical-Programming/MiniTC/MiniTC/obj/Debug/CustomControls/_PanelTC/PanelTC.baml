   M S B A M L   `   `   `  ����A  =MiniTC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:MiniTC.CustomControls._PanelTCMiniTC.CustomControls._PanelTC  5      c6clr-namespace:MiniTC.CustomControls._PanelTC.Resources(MiniTC.CustomControls._PanelTC.Resources  5      ,    &MiniTC.CustomControls._PanelTC.PanelTC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:MiniTC.CustomControls._PanelTC     5      L	resources6clr-namespace:MiniTC.CustomControls._PanelTC.Resources     5      -   5          >�Name$  Panel��5	   7   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��RightToLeft=�6;   $
��0, 5q�6W   .+�5      �� {�.   �� 
IsReadOnly . $	��200��6:   $��Center=�6F   $��LeftToRight=�6h   ��6�   ��  �� ElementName$ Panel�� �� Path$ CurrentPath� �� Mode$ TwoWay=��� 5      8   2MiniTC.CustomControls._PanelTC.Resources.Resources   PathLabelContent#��Z 6   $��LeftToRight=�6N   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��RightToLeft=�6;   $
��0, 5q�6W   .+�5      �� $��60��6   $��Center=�6"   $��LeftToRight=�6�    �� SelectedIndex 6D   �� $ Panel��$ CurrentDrive�$ TwoWay=���6�   �� $ Panel��$ AvailableDrives�$ TwoWay=�6�   �� 5      	   DriveLabelContent#��Z	 6   $��LeftToRight=�6O   5      �� 5   
   $��2��6�   $��Stretch=�6�   $��Stretch=�6�   ��6   �� $ Panel��$ CurrentPathContents�$ TwoWay=�
 �� SelectedItem
 6c   �� $ Panel��$ SelectedEntry�$ TwoWay=�6�   5      5      