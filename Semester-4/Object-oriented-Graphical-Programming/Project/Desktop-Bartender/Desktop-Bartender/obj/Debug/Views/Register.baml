   M S B A M L   `   `   `  ����L  HDesktop-Bartender, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Desktop_Bartender.ViewsDesktop_Bartender.Views  5      E'clr-namespace:Desktop_Bartender.HelpersDesktop_Bartender.Helpers  5      K*clr-namespace:Desktop_Bartender.PropertiesDesktop_Bartender.Properties  5      &     Desktop_Bartender.Views.Register   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Desktop_Bartender.Views     5      ;helpers'clr-namespace:Desktop_Bartender.Helpers     5      ;resx*clr-namespace:Desktop_Bartender.Properties     5        � DataContext  5      �� *RegisterViewModel+   Locator �� Source# [  .��5      � 
������ � ColumnDefinitions 5      �� 5      �� 5      $��3* �6   �� 5       � RowDefinitions 5      �� 5      $
��0.7* �6   �� 5      $
��2.5* �6   �� 5      $
��0.5* �6   .+�5      �� $��1q�6   $��1��6!   $��1��6.    �� CornerRadius$ 25��6>   
�������6P   � 5      $��1��6   $��1��6    5      �� 5   
   �� 5   
   �� 5   
   $
��0.2* �6   �� 5   
   �� 5    
   $
��0.2* �6   �� 5!   
   �� 5"   
   $
��0.2* �6   �� 5#   
   �� 5$   
   .+�5'      �� $��0��6   $��Center=�6@   $��Center=�6b   $��20(�6�   
���������6!   ��  �� Path$ Error�6�   � 5(      $��1��6   $
��5, 0q�6     5)   
   �� 5*      �� 5+      $
��1.6* �6   .+�5-   
   �� $��0��6   $��Center=�6[   $��Center=�6}   $��18(�6�   ��6    �� ,   &Desktop_Bartender.Properties.Resources   Login# Z 6�   �� 5.   
   $��1��6   $��Stretch=�6p   $��24(�6�   $��Center=�6�   $��0,0,10,0q�6�   ��6"   �� $ Login� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5/   	   � 51      $��3��6   $
��5, 0q�6    52   
   �� 53      �� 54      $
��1.6* �6   .+�56   
   �� $��0��6   $��Center=�6^   $��Center=�6�   $��18(�6�   ��6    �� 	   Password# Z	 6�   �� 57   
   $��1��6   
 � ToolTip
 6"   ��    PasswordTooltip# Z ._�58      G� -   5        $
��Pass��58      4   .Desktop_Bartender.Helpers.PasswordBoxAssistant   BindPassword . $��Stretch=�6�   $��18(�6�   $��Center=�6�   $��0,0,10,0q�6   G� PasswordChar$	 •��6,     BoundPassword 6U   �� $ Password�$ TwoWay=�$ PropertyChanged=�6,  59      5:   	   � 5<      $��5��6   $
��5, 0q�6    5=   
   �� 5>      �� 5?      $
��1.6* �6   .+�5A   
   �� $��0��6   $��Center=�6e   $��Center=�6�   $��18(�6�   ��6    ��    ConfirmPassword# Z 6�   G� 5B   
   -   5        $��ConfirmPass��5B       . $��1��6�   $��Stretch=�6�   $��18(�6  $��Center=�6  $��0,0,10,0q�66  $	 •��6H   6Z   �� $ ConfirmPassword�$ TwoWay=�$ PropertyChanged=�6H  5C   	   � 5E      $��7��6   $��10, 0q�6    5F   
   �� 5G      �� 5H      $
��0.7* �6   �� 5I      .+�5L   
   �� $��1��6   $��14(�6e   
���2�2�
���������6!   ��    RegisterButton# Z ��6�   �� *
Register+ � 	Resources 5M       �� 
TargetType �� Property �� Value��%^   '��       �� 5N      " ��6   .�5O      ��  �@��CornerRadius$ 5��6/   5P      5Q      5R      5T   	   � 5U      $��8��6    5V   
   �� 5W      �� 5X      $
��0.3* �6   �� 5Y      $��0.05* �6   .+�5\   
   �� $��1��6   $��10, 5q�6]   
������ $��0q�6�   ��6!   ��    GoBack# Z ��6�   �� *GoBack+ 5]      ��%^   '��       �� 5^      " ��6   .�5_      ��  �@��CornerRadius$ 5��6/   5`      5a      5b      5d   	   5e      5f      5g      