   M S B A M L   `   `   `  ����L  HDesktop-Bartender, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Desktop_Bartender.PropertiesDesktop_Bartender.Properties  5      ,    &Desktop_Bartender.Views.ForgotPassword   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;resx*clr-namespace:Desktop_Bartender.Properties     5        � DataContext  5	      �� *ForgotPasswordViewModel+   Locator �� Source# [  .��5
      � 
������ � ColumnDefinitions 5   
   �� 5      �� 5      $
��1.7* �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $
��1.7* �6   �� 5      .+�5   
   �� $��1q�6   $��1��6%   $��1��62    �� CornerRadius$ 25��6B   
�������6T   � 5   
   $��1��6   $��1��6    5      �� 5      �� 5      �� 5      $
��0.2* �6    �� 5      �� 5      $
��0.2* �6    �� 5      �� 5       .+�5#      �� $��0��6   $��Center=�6@   $��Center=�6b   $��20(�6�   
���  ����6!   ��  �� Path$ Error�6�   � 5$      $��1��6   $
��5, 0q�6     5%      �� 5&      �� 5'      $
��2.6* �6'   .+�5)      �� $��0��6   $��Center=�6c   $��Center=�6�   $��18(�6�   ��6(   �� ,   &Desktop_Bartender.Properties.Resources   Login# Z 6�   �� 5*      $��1��6   $��Stretch=�6x   $��18(�6�   $��Center=�6�   $��0,0,10,0q�6�   ��6*   �� $ Login� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5+      � 5-      $��3��6   $
��5, 0q�6     5.      �� 5/      .+�51      �� $��2��6   $��Center=�6S   $��Center=�6p   $��Center=�6�   $��18(�6�   ��6(   �� $ ForgottenPassword�6�   52      � 54      $��5��6   $��10, 0q�6     55      �� 56      �� 57      $
��1.5* �6'   �� 58      .+�5;      �� $��1��6   $��14(�6k   
���2�2�
���������6)   �� 	   RemindButton# Z	 ��6�   �� *RemindPassword+
 � 	Resources
 5<       �� 
TargetType �� Property �� Value��%^   '��       �� 5=      " ��6    .�5>      ��  �@��CornerRadius$ 5��6=   5?      5@      5A      5C      � 5D      $��7��6    5E      �� 5F      $
��0.1* �6'   �� 5G      $
��0.5* �6'   �� 5H      �� 5I      $
��0.9* �6'   �� 5J      $��0.05* �6'   .+�5M      �� $��3��6   $��10, 5q�6e   
������ $��0q�6�   ��6)   ��    GoBack# Z ��6�   �� *ChangeViewToLogin+
 5N      ��%^   '��       �� 5O      " ��6    .�5P      ��  �@��CornerRadius$ 5��6=   5Q      5R      5S      5U      5V      5W      5X      