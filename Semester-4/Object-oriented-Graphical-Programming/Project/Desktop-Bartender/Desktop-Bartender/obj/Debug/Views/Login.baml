   M S B A M L   `   `   `  ����L  HDesktop-Bartender, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Desktop_Bartender.ViewsDesktop_Bartender.Views  5      E'clr-namespace:Desktop_Bartender.HelpersDesktop_Bartender.Helpers  5      K*clr-namespace:Desktop_Bartender.ViewmodelsDesktop_Bartender.Viewmodels  5      K*clr-namespace:Desktop_Bartender.PropertiesDesktop_Bartender.Properties  5	      #    Desktop_Bartender.Views.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Desktop_Bartender.Views     5      ;helpers'clr-namespace:Desktop_Bartender.Helpers     5      A
viewmodels*clr-namespace:Desktop_Bartender.Viewmodels     5      ;resx*clr-namespace:Desktop_Bartender.Properties     5	        � DataContext  5      �� *LoginViewModel+   Locator �� Source# [  .��5      � 
������ � ColumnDefinitions 5   
   �� 5      �� 5      $
��1.7* �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $
��1.7* �6   �� 5      .+�5   
   �� $��1q�6   $��1��6%   $��1��62    �� CornerRadius$ 25��6B   
�������6T   � 5   
   $��1��6   $��1��6    5      �� 5      �� 5      �� 5      $
��0.2* �6    �� 5       �� 5!      $
��0.2* �6    �� 5"      �� 5#      .+�5&      �� $��0��6   $��Center=�6G   $��Center=�6i   $��18(�6�   
���  ����6!   ��  �� Path$ ErrorMessage�6�   � 5'      $��1��6   $
��5, 0q�6     5(      �� 5)      �� 5*      $
��2.6* �6'   .+�5,      �� $��0��6   $��Center=�6c   $��Center=�6�   $��18(�6�   ��6(   �� ,   &Desktop_Bartender.Properties.Resources   Login# Z 6�   �� 5-      $��1��6   $��Stretch=�6x   $��18(�6�   $��Center=�6�   $��0,0,10,0q�6�   ��6*   �� $ Login� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5.      � 50      $��3��6   $
��5, 0q�6     51      �� 52      �� 53      $
��2.6* �6'   .+�55      �� $��0��6   $��Center=�6f   $��Center=�6�   $��18(�6�   ��6(   �� 	   Password# Z	 6�   G� 56      -   5        $��NetworkPassword��56      4   .Desktop_Bartender.Helpers.PasswordBoxAssistant
   BindPassword
 . $��1��6�   $��Stretch=�6�   $��18(�6  $��Center=�6  $��0,0,10,0q�6;   G� PasswordChar$	 •��6M     BoundPassword 6f   �� $ Password�$ TwoWay=�$ PropertyChanged=�6M  57      � 59      $��5��6   $��10, 0q�6     5:      �� 5;      �� 5<      $
��0.7* �6'   �� 5=      .+�5@      �� $��1��6   $��14(�6j   
���2�2�
���������6)   ��    LoginButton# Z ��6�   �� *ChangeViewToIngredients+ � 	Resources 5A       �� 
TargetType �� Property �� Value��%^   '��       �� 5B      " ��6    .�5C      ��  �@��CornerRadius$ 5��6=   5D      5E      5F      5H      � 5I      $��7��6    5J      �� 5K      $	��15* �6'   �� 5L      $	��72* �6'   �� 5M      $
��120* �6'   �� 5N      $	��24* �6'   �� 5O      $
��130* �6'   �� 5P      $��7* �6'   .+�5S      �� $��1��6   $��10, 5q�6k   
������ $��0q�6�   ��6)   ��    SignUpButton# Z ��6�   �� *ChangeViewToRegister+ 5T      ��%^   '��       �� 5U      " ��6    .�5V      ��  �@��CornerRadius$ 5��6=   5W      5X      5Y      �� 5[      $��4��6   $��10, 5q�6g   
������ $��0q�6�   ��6)   ��    FPButton# Z ��6�   �� *ChangeViewToForgotPassword+ 5\      ��%^   '��       �� 5]      " ��6    .�5^      ��  �@��CornerRadius$ 5��6=   5_      5`      5a      5c      5d      5e      5f      