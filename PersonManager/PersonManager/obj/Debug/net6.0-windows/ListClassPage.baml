   M S B A M L   `   `   `  ����H  DPersonManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PersonManagerPersonManager  5   	   !    PersonManager.ListClassPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PersonManager     5   	     N� Title$  ListClassPage��5   	   $	��450��6   $	��600��6,   .��5	      �    GradientBackgroundClass#��[  6   .+�5
   
   �� -   5         ��Name$ BtnBack��5      
������ 
������ $
��Left=�5      $��	76,39,0,0q�6(   $	��Top=�6;   $��30��6S   $��48��6_   .��5      �� -   5         ��Name$ btniBack��5      $��/Assets/back.png��6&   5      �� 5   
   $��40(�5      
�������$
��Bold"�5      $��CLASSES��6    $
��Left=�62   $��
129,21,0,0q�6M   $	��Top=�6a   $��84��6y   $	��180��6�   �� 5   
   -   5         ��Name$ lbClassesOfTitle��5      $��30(�5      
�������$
��Bold"�5      $��(JuanManuelUr)��6    $
��Left=�69   $��
309,26,0,0q�6T   $	��Top=�6h   $��84��6�   $	��234��6�   �� 5   
   -   5         ��Name$ 	lvClasses��5      $	��550��5      $	��275��5      $��25,89,25,86q�5       �� AlternationCount$ 2��5       ��5!      �� 5"       �� 
TargetType" ��6   .�5#      -   5        �� 5$       �� Property � �� �� Value
 ��ح�63   	 �� Triggers	 5%      P� 5&      
 P� Property
 �@��AlternationIndex P� Value$ 1��6G   . �5'      ��  � ��
 �����6;   5(      ]� 5)       ]� 
Conditions 5*      �� 5+   "    �� Property �@��
IsSelected �� Value$
 True��6B   ./�5-      ��  � ��
 ���_�6;   5.      50       �� View 52      �� 53      .P�54      ��  �� Width$	 100��6%   $
��Name��61    �� DisplayMemberBinding 6?   �� *SubjectName+�� 55      $	 100��6%   $��
Start Time��61    6E   �� *	StartTime+�� 56      $	 100��6%   $��End Time��61    6C   �� *	EndTime+�� 57      $	 100��6%   $
��Room��61    6?   �� *Room+58      5:      �� 5;   
   -   5        $ BtnAdd��5=      $��Create Class��5<      
�������
��� � �$
��Left=�5A      $��
25,370,0,0q�6(   $	��Top=�6<   $	��256��6T   $��35��6`   �� 5B   
   -   5        $ 	btnDelete��5D      $��Delete��5C      
�������
����  �$
��Left=�5I   	   $��327,370,0,0q�6$   $	��Top=�69   $	��248��6Q   $��35��6]    J� RenderTransformOrigin$ 	0.5,-0.12&�6i   �� 5J   
   -   5        $ btnAdd_Existing��5L      $��Add Existing��5K      
�������
�������$
��Left=�5P      $��
25,370,0,0q�6(   $	��Top=�6<   $	��256��6T   $��35��6`   5R      5S      