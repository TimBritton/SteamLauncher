   M S B A M L   `   `   `  ����  SteamLauncher    SteamLauncher.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F     � Title$  SteamLauncher��5   	   $	��400��6   $��400   ��6,    � 
ResizeMode$ CanMinimize=�5       � WindowStyle$
 None=�6    � AllowsTransparency .  � Icon$ Icon.png��6K    � 	Resources 5         app��%   &	        �� 5   
   6   5	       � Triggers 5
      :� 5   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� #��[  6   5       � ContextMenu 5      �� 5   
   .��5      � -   5        	 �Name$	 border_grid��5      $��	0,0,0,-30q�6V   ��5   
   �� 5      
 �� EndPoint$
 -2.565,0.948&�6"    �� 
StartPoint$ 0.607,0.253&�6:   .��5      �  � Color$ Black��6   � 5      $ White��6    � Offset$ 1Q�6-   5      .+�5   
   �� -   5        $
��Left=�5      $��23��6-   $��	25,32,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $	��340��6x   ���	#FF9C9EA4���	#FF959191 J� Opacity$
 0.25Q�6�   6�   �� 5   
   -   5        $��X��5      $��381,0,0,412.04q�6     SimpleButton#���  65   $��Bottom=�6\   
���   ����	#FF5D5D5D6�   �� 5   
   -   5        $��-��5      $
��Left=�6   $��	362,0,0,0q�68   #���  6K   $	��Top=�6r   $��18.75��6�   
���   ����	#FF5D5D5D6�   A� 5   
   $��25,65,35,25q�6   $	��340��6+   $	��340��68   $��Center=�6D   .+�5      �� $
��Left=�6   $	��340��6,   $	��340��69   ��.  � Cursor$  ��6]    K� ZIndex$ 1��6g   $��Bottom=�6x   $	��340��6�   $
��Auto=�6�   .��5      � -   5         �Name$ buttonHolder��5      $	��Top=�62   5       5!      5#      5$      