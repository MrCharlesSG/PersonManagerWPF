   M S B A M L   `   `   `  ����H  DPersonManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PersonManagerPersonManager  5   	   $    PersonManager.StudentClassPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PersonManager     5   	     N� Title$  StudentClassPage��5   	   $	��450��6"   $	��600��6/   .��5	      � -   5         �Name$
 grid��5	   A      GradientBackgroundClass#��[  6   .+�5
   
   �� -   5         ��Name$ 	lvClasses��5      $	��275��5      $��97,88,98,88q�5       �� AlternationCount$ 2��5      ��5      �� 5       �� 
TargetType" ��6   .�5      -   5        �� 5       �� Property � �� �� Value
 ��ح�63    �� Triggers 5      P� 5       P� Property �@��AlternationIndex	 P� Value$	 1��6G   . �5      ��  � ��
 �����6;   5      ]� 5      
 ]� 
Conditions
 5      �� 5   "    �� Property �@��
IsSelected �� Value$
 True��6B   ./�5      ��  � ��
 ���_�6;   5      5       �� View 5       �� 5!      .P�5"      �� -   5        gvcFirst�� �� Width$	 100��5"   7   $
��Name��6C    �� DisplayMemberBinding 6Q   �� *SubjectName+�� 5#      -   5        	gvcSecond��$	 100��5#   8   $��
Start Time��6D   �� 5$      -   5        gvcThird��$	 100��5$   7   $��End Time��6C   �� 5%      -   5        	gvcFourth��$	 100��5%   8   $
��Room��6D   5&      5(      �� 5)   
   -   5         ��Name$ lbTitle��5*      $��30(�5+      
�������$
��Bold"�5-      $��CLASSES��6   $
��Left=�6*   $��
124,28,0,0q�6E   $	��Top=�6Y   $��52��6q   $	��373��6}   �� 50   
   -	   5         ��Name$ BtnBack��53      
������ 
������ $
��Left=�55      $��	76,39,0,0q�6    $	��Top=�63   $��30��6K   $��48��6W   .��56      �� $��/Assets/back.png��6   57      �� 58   
   -
   5        $ btnAdd��58      $	��Add��6   
�������$��Center=�6^   $��	0,368,0,0q�6{   $	��Top=�6�   $��27��6�   $	��402��6�   59      5:      