   M S B A M L   `   `   `  ����H  DPersonManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PersonManagerPersonManager  5      "    PersonManager.ListPeoplePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PersonManager     5        N� Title$  ListPeoplePage��5	      .��5      �    GradientBackground#��[  6   .+�5   
   �� -   5         ��Name$ lvPeople��5      $	��550��5      $	��275��5      $��25,45,25,130q�5       �� AlternationCount$ 2��5      ��5      �� 5       �� 
TargetType" ��6   .�5      -   5        �� 5       �� Property � �� �� Value
 ��ح�63    �� Triggers 5      P� 5       P� Property �@��AlternationIndex P� Value$ 1��6G   . �5      ��  � ��
 �����6;   5      ]� 5      	 ]� 
Conditions	 5      �� 5   "   
 �� Property
 �@��
IsSelected �� Value$
 True��6B   ./�5      ��  � ��
 ���_�6;   5      5!       �� View 5#      �� 5$      .P�5%      ��  �� Width$	 100��6%   $��
First name��61    �� DisplayMemberBinding 5&      �� *	FirstName+�� 5'      $	 100��6%   $��	Last name��61    5(      �� *
LastName+�� 5)      $ 50��6%   $	��Age��60    5*      �� *Age+�� 5+      $	 100��6%   $��Email��61    �� CellTemplate 5,      �� 5-      .R�5.   "   �� $��	Underline{�5/   ,   
���   ���5.   ,   �� *Email+ � ToolTip 51   &   �� 52   *    ��Name$ picture��60   $��60��53   0   $��60��54   0   ��55   0   �� *Image+57   #   58      5:      �� 5;      $	 100��6%   -   5        gvcAditional1��$��
Aditional1��5;   H   �� 5<      $	 100��6%   -   5        gvcAditional2��$��
Aditional2��5<   H   5=      5?      �� 5@   
   -   5         ��Name$ btnAdd��5B      $	��Add��5A      
�������
��� � �$
��Left=�5G      $��
25,370,0,0q�6,   $	��Top=�6@   $	��153��6X   $��35��6d   �� 5H   
   -   5        $ btnEdit��5K      $
��Edit��5J      
�������
���   �$��Center=�5Q      $��	0,370,0,0q�6.   $	��Top=�6A   $	��152��6Y   $��35��6e   �� 5R   
   -   5        $ 	btnDelete��5T      $��Delete��5S      
�������
����  �$
��Left=�5Y      $��422,370,0,0q�6,   $	��Top=�6A   $	��153��6Y   $��35��6e    J� RenderTransformOrigin$ 	0.5,-0.12&�6q   �� 5Z   
   -   5        $ btn_All��5Z      $	��All��6   $
��Left=�60   $��
168,20,0,0q�6K   $	��Top=�6_   $��66��6w   6�   �� 5[   
   -	   5        $ btn_Employees��5[   %   $��	Employees��6   $
��Left=�6<   $��
366,20,0,0q�6W   $	��Top=�6k   $��66��6�   6�   �� 5\   
   -
   5        $ btn_Teachers��5\   $   $��Teachers��6   $
��Left=�6:   $��
300,20,0,0q�6U   $	��Top=�6i   $��66��6�   6�   �� 5]   
   -   5        $ btn_Students��5]   $   $��Students��6   $
��Left=�6;   $��
234,20,0,0q�6V   $	��Top=�6j   $��66��6�   6�   �� 5^   
   -   5        $ btnClassesView��5`      $��Classes��5_      
���   �
�������$��Center=�5e      $��	0,325,0,0q�6*   $	��Top=�6=   $	��264��6U   $��25��6a   5g      5h      