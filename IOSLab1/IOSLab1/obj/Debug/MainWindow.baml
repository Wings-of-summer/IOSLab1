   M S B A M L   `   `   `  ����  IOSLab1    IOSLab1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$	  IOS��5   	   $	��310��6   $	��600��6"   .��5      � .+�5   
   �� $
��Left=�6   $	��280��60   $	��Top=�6=   $	��592��6U   .@�5      �� $��Create test��6   .��5      � 
�������$��0,0,0,0q�6.    � ColumnDefinitions 5	      �� 5
      $	��89* �6+   �� 5      $
��493* �6+   .+�5      �� $
��Name��6   $
��Left=�6+   $��
45,104,0,0q�6F   $	��Top=�6Z   $
��Bold"�6r   
����  �$��26��6�   $��43��6�   �� 5      -   5         ��Name$ testName��5      $
��Left=�60   $��23��6K   $��
10,107,0,0q�6W    �� TextWrapping$
 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��160��6�   $��1��6�   �� 5      $��Description��6   $
��Left=�62   $��
14,161,0,0q�6M   $	��Top=�6a   $
��Bold"�6y   
����  � J� RenderTransformOrigin$ 0.479,0.462&�6�   $��26��6�   $��75��6�   �� 5      -   5        $ testDescription��5      $
��Left=�67   $��46��6R   $��
10,151,0,0q�6^   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��464��6�   $��1��6�   �� 5      -   5         ��Name$ 
createTest��5      $��Create��61   $
��Left=�6B   $��154,213,0,0q�6]   $	��Top=�6r   $��75��6�   
�������
�������$��1��6�   $��22��6�   �� 5      $��	Test type��6   $
��Left=�60   $��	26,33,0,0q�6K   $	��Top=�6^   $
��Bold"�6v   
����  �$��26��6�   $��62��6�   �� 5      -   5         ��Name$ testTypesComboBox��5      $��1��6:   $
��Left=�6J   $��	10,37,0,0q�6e   $	��Top=�6x   $	��160��6�   $��22��6�   5   A   �� 5      $��1��6    
�������$
��Left=�6=   $��93��6X   $��
187,37,0,0q�6d   
�������$	��Top=�6�   $	��287��6�   �� 5      $��Test type description��6   $
��Left=�6<   $��
187,10,0,0q�6W   $	��Top=�6k   $
��Bold"�6�   
����  �$��1��6�   $��26��6�   $	��128��6�   �� 5      -   5        $ fullDescriptionButton��5      $��Full description��6<   $��1��6W   $
��Left=�6g   $��
384,10,0,0q�6�   $	��Top=�6�   $��90��6�   
�������
�������$��22��6�   6�   �� 5      $��1��6   $
��Left=�6,   $��
191,41,0,0q�6G   $	��Top=�6[   $��89��6s   $	��283��6   .��5      �� $
��Wrap=�6$   $��79��68   $	��273��6D   �� 6Q   -   5         ��Name$ descriptionTypeLabel��5   U   $� ��6s   6~   5      5      5      �� 5      $��
View tests��6   .��5      � 
�������.+�5      �� $��Tests��6   $
��Left=�6,   $��	26,19,0,0q�6G   $	��Top=�6Z   $
��Bold"�6r   
����  �6�   �� 5       -   5        $ testsComboBox��5       $
��Left=�66   $��	10,50,0,0q�6Q   $	��Top=�6d   $	��220��5!      6I   �� 5"      $��Description��6   $
��Left=�62   $��
263,19,0,0q�6M   $	��Top=�6a   $
��Bold"�6y   
����  �6�   �� 5#      $
��Left=�6   $��
263,50,0,0q�67   $	��Top=�6K   .��5$      �� $
��Wrap=�6$   $��30��68   $	��300��6D   �� 6Q   -   5        $ descriptionLabel��5$   U   $� ��6o   6z   5%      �� 5&      -	   5        $ executeTestButton��5&      $��Execute test��68   $
��Left=�6O   
�������
�������$��248,189,0,0q�5'      $	��Top=�62   $��75��6J   6U   �� 5(      $��	Test type��6   $
��Left=�60   $��
263,95,0,0q�6K   $	��Top=�6_   $
��Bold"�6w   
����  �6�   �� 5)      -
   5         ��Name$ viewTestTypeLabel��5)      $�� ��67   $
��Left=�6B   $��263,126,0,0q�6]   $	��Top=�6r   5*      5+      �� 5,      -   5        	 ��Name$	 	resultTab��5,      $��Results��6)   $��-2,-2,-2,-1q�6:   .��5-      � 
�������.+�5.      �� $��Results:��6   $
��Left=�6/   $��	19,20,0,0q�6J   $	��Top=�6]   $
��Bold"�6u   
����  �6�   �� 5/      -   5        $ resultLabel��5/      $�� ��61   $
��Left=�6<   $��	19,51,0,0q�6W   $	��Top=�6j   50      51      52      54      55      