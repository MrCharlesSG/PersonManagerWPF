   M S B A M L   `   `   `  ����H  DPersonManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PersonManagerPersonManager  5      "    PersonManager.EditPersonPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PersonManager     5        N� Title$  EditPersonPage��5	      .��5      � -   5         �Name$
 grid��5   <      GradientBackground#��[  6   .+�5   
   �� -   5         ��Name$ pictureBorder��5      $	��200��5      $	��300��5      
�������$��1q�5   !   $��350,39,50,111q�65   ._�5      �� -   5         ��Name$ picture��5      $��Uniform=�5      5      �� 5   
   $��
First Name��6   
�������$
��Left=�68   $��	76,81,0,0q�6S   $	��Top=�6f   �� 5   
   -   5         ��Name$ tbFirstName��5      $
��Left=�5      $��
185,85,0,0q�6(    �� TextWrapping$
 Wrap=�6<   $	��Top=�6Q   $	��115��6i   �� 5   
   $��	Last Name��6   
�������$
��Left=�67   $��
76,112,0,0q�6R   $	��Top=�6f   �� 5   
   -   5        $ 
tbLastName��5      $
��Left=�5      $��185,116,0,0q�6(   $
 Wrap=�6=   $	��Top=�6R   $	��115��6j   �� 5   
   $��Email��6   
�������$
��Left=�63   $��
77,146,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $ tbEmail��5      
 � Tag$ Email��5       $
��Left=�5!      $��185,150,0,0q�6(   $
 Wrap=�6=   $	��Top=�6R   $	��115��6j   �� 5"   
   $	��Age��6   
�������$
��Left=�61   $��
79,185,0,0q�6L   $	��Top=�6`   �� 5#   
   -   5        $ tbAge��5$      $	 Int��5%      $
��Left=�5&      $��185,189,0,0q�6(   $
 Wrap=�6=   $	��Top=�6R   $	��115��6j   �� 5'   
   -   5         ��Name$ 	BtnCommit��5+      $��Commit��5(      
�������
��� � �$
��Left=�5,   %   $��
76,370,0,0q�6@   $	��Top=�6T   $��30��6l   $��92��6x   �� 5-   
   -	   5        $ 	BtnUpload��51      $��Upload��5.      
�������
��� ���$
��Left=�52   %   $��208,370,0,0q�6@   $	��Top=�6U   $��30��6m   $��92��6y   �� 53   
   -
   5        $ BtnBack��56      
������ 
������ $
��Left=�58      $��	76,39,0,0q�6(   $	��Top=�6;   $��30��6S   $��48��6_   .��59      �� $��/Assets/back.png��6   5:      �� 5;   
   -   5         ��Name$ 
cb_Student��5=      
�������$��Student��5?      $
��Left=�6   $��
64,235,0,0q�6:   $	��Top=�6N   �� 5@   
   -   5        $ cb_Employee��5B      
�������$��Employee��5D      $
��Left=�6    $��241,235,0,0q�6;   $	��Top=�6P   �� 5E   
   -   5        $ 
cb_Teacher��5G      
�������$��Teacher��5I      $
��Left=�6   $��155,235,0,0q�6:   $	��Top=�6O   �� 5J   
   -   5        	 ��Name$	 lb_Additional1��5J      $	��GPA��6(   
�������$
��Left=�6I   $��
79,270,0,0q�6d   $	��Top=�6x   �� 5K   
   -   5        $ tb_Additional1��5L      $	 Int��5M      $
��Left=�5N      $��185,274,0,0q�6(   $
 Wrap=�6=   $	��Top=�6R   $	��115��6j   �� 5O   
   -   5        $	 lb_Additional2��5O      $��Subvención��6)   
�������$
��Left=�6Q   $��
79,317,0,0q�6l   $	��Top=�6�   �� 5P   
   -   5        $ tb_Additional2��5Q      $	 Int��5R      $
��Left=�5S      $��185,321,0,0q�6(   $
 Wrap=�6=   $	��Top=�6R   $	��115��6j   5U      5V      