   M S B A M L   `   `   `  ����L  HDesktop-Bartender, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Desktop_Bartender.PropertiesDesktop_Bartender.Properties  5      )    #Desktop_Bartender.Views.Ingredients   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1.command http://www.galasoft.ch/mvvmlight  5      5resx*clr-namespace:Desktop_Bartender.Properties  5      ���#2A3950  � DataContext  5      �� *IngredientsViewModel+   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   � $��4��6   $��0��6#   ���#2A3950 5      �� 5      $
��0.2* �6#   �� 5      �� 5      $
��0.2* �6$   .+�5      �� $��0��6   
������ $��0q�6x   $��Comic Sans MS)�6�   $��14(�6�   
���������6%   �� ,   &Desktop_Bartender.Properties.Resources   User# Z ��6�   �� *ChangeViewToUser+�� 5      $��1��6   $��Comic Sans MS)�6b   $��20(�6~   $��Center=�6�   $��Center=�6�   
���������6$   ��    TitleBig# Z 6�   �� 5       $��2��6   
������ $��0q�6z   $��Comic Sans MS)�6�   $��14(�6�   
���������6%   ��    Logout# Z ��6�   �� *ChangeViewToLogin+5!      � 5#   
   $��0��6   $��1��6   $��10q�6,    5$      �� 5%      $��40 �6    �� 5&      .+�5(      �� $��0q�6   $��0��6)   ���#EBEBD366   �� 5)      $��0��6   $��Center=�6_   $��Center=�6�   $��Stretch=�6�   $��Stretch=�6�   $��Comic Sans MS)�6�   $��20(�6�   ��6!   ��    Category# Z 6�   �� 5*      $��1��6d   ��6   ��  �� Path$ 
Categories�	 �� SelectedItem	 6=   �� $ Category�*  $Microsoft.Xaml.Behaviors.Interaction
   Triggers
 5+      +  %Microsoft.Xaml.Behaviors.EventTrigger  5,         	EventName$ MouseDoubleClick��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5-      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6(   �� *ClickCategories+5.      50      51      � 53   
   $��1��6   $��1��6   $��10q�6,    54      �� 55      $��40 �6    �� 56      .+�58      �� $��0q�6   $��0��6)   ���#FF967866   �� 59      $��0��6   $��Center=�6b   $��Center=�6�   $��Stretch=�6�   $��Stretch=�6�   $��Comic Sans MS)�6�   $��20(�6�   ��6!   ��    Ingredients# Z 6�   �� 5:      $��1��6�   ��6   �� $ Ingredients� �� UpdateSourceTrigger$ PropertyChanged=�	 6e   �� $ 
Ingredient�
 5;        5<      $ MouseDoubleClick��6%   . 5=         60   �� *ClickIngredients+5>      5@      5A      � 5C   
   $��2��6   $��1��6   $��10q�6,    5D      �� 5E      $��40 �6    �� 5F      �� 5G      $
��0.2* �6     5I      �� 5J      �� 5K      $
��0.4* �6#   .+�5O      �� $��0��6   $��2��6"   $��0q�66   ���#EBEBD36J   �� 5P      $��0��6   $��2��6!   $��Center=�6s   $��Center=�6�   $��Stretch=�6�   $��Stretch=�6�   $��Comic Sans MS)�6�   $��20(�6  ��65   ��    yourList# Z 6  �� 5Q      $��1��6   $��2��6$   ��68   �� $ Items� �� Mode$ TwoWay=�$ PropertyChanged=� �� SelectedIndex 6�   �� $ Index�$ TwoWay=�$ PropertyChanged=�5S      �� 5U      $��2��6   $��0��6"   $��0, 10, 5, 0q�6n   ���#4097AA
�������$��Comic Sans MS)�6�   $��20(�6�   ��62   ��    Create# Z ��6�   �� *
CreateList+ � 	Resources 5V       �� 
TargetType �� Property �� Value��%^   '��       �� 5W      " ��6   .�5X      ��  �@��CornerRadius$ 5��69   5Y      5Z      5[      �� 5]      $��2��6   $��1��6"   $��5, 10, 0, 0q�6n   ���#974063$��Comic Sans MS)�6�   $��20(�6�   ��62   ��    Delete# Z ��6�   �� *DeleteIngredient+ 5^      ��%^   '��       �� 5_      " ��6   .�5`      ��  �@��CornerRadius$ 5��69   5a      5b      5c      5d      � 5f      $��3��6   $��1��6   $��10q�6*    5g   
   �� 5h      $��40 �6   �� 5i      .+�5k      �� $��0q�6   $��0��6)   ���#FF967866   �� 5l   
   $��0��6   $��Center=�6]   $��Center=�6   $��Stretch=�6�   $��Stretch=�6�   $��Comic Sans MS)�6�   $��20(�6�   ��6   ��    
YourDrinks# Z 6�   �� 5m   
   $��1��6�   ��6   �� $ Drinks�$ PropertyChanged=�	 6\   �� $ Drink�
 5n        5o      $ MouseDoubleClick��6   . 5p         6&   �� *
ClickDrink+5q      5s      5t   	   5u      5v      