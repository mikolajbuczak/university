   M S B A M L   `   `   `  ����J  FWeatherForecast, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WeatherForecastWeatherForecast  5   	        WeatherForecast.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WeatherForecast     5   	   -   5          � Title$  WeatherForecast��5   	   $	��300��6!   $	��420��6.    � WindowStartupLocation$ CenterScreen=�6:   .��5	      � ��5   
   �� 5       �� ImageSource$ 
spodek.png��6    j� Stretch$ UniformToFill=�62    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �  � RowDefinitions 5      �� 5      �� 5      $��2* �6    �� 5      �� 5      .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ 	Date_pick��5      $��0��6,   $��10q�69   $��Center=�6E   |�.  6�   �� 5      -   5         ��Name$ Start_button��5      $��3��6+   $	��100��68   {�.  $��10q�6V   $��Show forecast��6b   6z   �� 5      -   5        $ 
Api_button��5      $��2��6)   $	��100��66   {�. $��10q�6S   $��Use API data��6_   6v   �� 5      -   5        $ Reverse_button��5      $��2��6-   $y�Hidden=�6:   {�.  $��158,10,10,10q�6`   .��5       �� $��reverse.png��6   6/   5!      5#      �� 5%   
    �� Orientation$ Vertical=�6   $��1��6,   .+�5'      �� -   5        	 ��Name$	 Temperature_tb��5'      $��10q�60   $y�Hidden=�6<   
��������� 5(      $�Temperature: ��6    �� 5)      -   5        
 ��Name$
 Temperature_run��5)      $	�100��6/    �� 5*      $	�°C��6   5+      �� 5-      -   5        $	 Pressure_tb��5-      $��10q�6-   $y�Hidden=�69   
��������� 5.      $�
Pressure: ��6    �� 5/      -	   5        $
 Pressure_run��5/      $
�1013��6,    �� 50      $	�hPa��6   51      �� 53      -
   5        $	 Humidity_tb��53      $��10q�6-   $y�Hidden=�69   
��������� 54      $�
Humidity: ��6    �� 55      -   5        $
 Humidity_run��55      $�20��6,    �� 56      $�%��6   57      �� 59      -   5        $	 Wind_tb��59      $��10q�6)   $y�Hidden=�65   
��������� 5:      $�Wind: ��6    �� 5;      -   5        $
 Wind_run��5;      $�20��6(    �� 5<      $
�km/h��6   5=      �� 5?      -   5        $	 Cloud_tb��5?      $��10q�6*   $y�Hidden=�66   
��������� 5@      $�Cloud cover: ��6    �� 5A      -   5        $
 	Cloud_run��5A      $�20��6)    �� 5B      $�%��6   5C      5E      5G      5H      