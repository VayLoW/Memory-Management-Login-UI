   M S B A M L   `   `   `  ����   UnderWalls - NM    UnderWalls_NM.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  UnderWalls - Nexmod��$	��500��$	��400�� � WindowStartupLocation$ CenterScreen=�
������  � WindowStyle$
 None=� � AllowsTransparency$
 True�� � Icon$ logo/Nexmodlogo.png�� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value ��Name ��Name �� Padding � ColumnDefinitions A�Name �� 
TargetName��%'  '��       '�� �    'd� �    �� " ��.���  � ��	 �#2d2d2d��  � ��
	 �������  � ��$
	 10,5q���  � ��$
	 15,8q���  � ��$	 0q���  � ��	 �� "
 ��.R��� #��z��$ 5��$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#404040P�  � ��$
 True��. ���  � ��	 �#505050P�  � {�$ False��. ���  � ��	 �#1a1a1a��  � ��	 �#404040�� " ��.���  � ��	 �#2d2d2d��  � ��
	 �������  � ��$	 0q���  � ��$
	 10,5q���  � ��$
	 10,5q���  � ��	 �� "
 ��.R��� #��z��$ 5��$��0q�._��� $ PART_ContentHost���� " d�.���  � ��	 �� "
 d�.R��� $ border�����#2d2d2d$ 5��$��0q�$
 15,8q�._��  �� $��* ��� $
��Auto �.+��� $��0��$
��Left=�$��Center=�A� $ 	statusDot��$��1��$��8��$��8��$��10,0,0,0q����#404040 P�  �@d�	IsChecked$
 TrueY�. ��� $ border�� � ��	 �#00a86b�� $ 	statusDot�� � ��
	 �����P�  �@J�IsMouseOver$
 True��. ��� $ border�� � ��	 �#404040P�  � {�$ False��. ��� $ border�� � ��	 �#1a1a1a��  � ��	 �#404040��  � ��
	 �������  � ��$
	 10,5q���  � ��$
	 Left=�.���� -   ���#1a1a1a$ 10��._��  � RowDefinitions �� $
��Auto ��� $��* �.+�� $��0��$��30�����#2d2d2d �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��logo/Nexmodlogo.png��$��20��$��20��$��5,0,0,0q��� $��UnderWalls - Nexmod��$��1��
�������$��14(�$��10,0,0,0q�$��Center=��� -    ��Name$ CloseButton��$��2��$	��✕��$��30��$��30��$��0q�
������ 
�������$��0q����� " ��.���  � ��	 �� "
 ��.R��� #��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#c42b1c� $��1��$��20q� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��.+��� -    ��Name$ 
StatusText��$��En attente du jeu...�����#00a86b$��16(�$��0,0,0,20q��� $��1��.+��� $��Argent��
�������$��14(�$
��10,5q��  �� $��* ��� $
��Auto �.+��� -    ��Name$ MoneyTextBox��$��0��${�False���� -   $ SetMoneyButton��$��Définir��$��30��$��70��$��12(�$��5,0,0,0q�$��1���� $��2��$��0,20,0,0q�.+�d� -    d�Name$ StaminaToggle��$��Stamina Infinie��${�False��d� -   $ GodModeToggle��$��God Mode��${�False���� -   $ DiscordButton��$��Rejoindre Discord��$��40��$��14(����#5865F2$
��0,20q����� " ��.���  � ��	 �� "
 ��.R��� #��z��$ 5��$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#4752C4�� $��3�����#2d2d2d$ 5��$��0,20,0,0q�$ 15q�._��� .+��� $��Informations�����#00a86b$��14(�$��0,0,0,10q��� -	   $ ProcessIdText��$��PID : -��
�������$	��0,2q��� -
   $ LastUpdateText��$ ��Dernière mise à jour : -��
�������$	��0,2q�