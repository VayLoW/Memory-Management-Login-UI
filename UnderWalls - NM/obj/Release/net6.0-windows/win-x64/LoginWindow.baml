   M S B A M L   `   `   `  ����   UnderWalls - NM    UnderWalls_NM.LoginWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  UnderWalls - Nexmod Login��$	��320��$	��400�� � WindowStartupLocation$ CenterScreen=�
������  � WindowStyle$
 None=� � AllowsTransparency$
 True�� � Icon$ logo/Nexmodlogo.png�� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value ��Name��%S  '��       '�� `    �� " ��.���  � ��	 �#2d2d2d��  � ��
	 �������  � ��$
	 10,5q���  � ��$
	 15,8q���  � ��$	 0q���  � ��	 �� "
 ��.R��� #��z��$ 5��$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#404040P�  � ��$
 True��. ���  � ��	 �#505050�� " ��.���  � ��	 �#2d2d2d��  � ��
	 �������  � ��$	 0q���  � ��$
	 10,5q���  � ��$
	 10,5q���  � ��	 �� "
 ��.R��� #��z��$ 5��$��0q�._��� $ PART_ContentHost��.���� -   ���#1a1a1a$ 10��._��  � RowDefinitions �� $��30 ��� $��* �.+�� $��0�����#2d2d2d � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��logo/Nexmodlogo.png��$��20��$��20��$��5,0,0,0q��� $��UnderWalls - Nexmod Login��$��1��
�������$��14(�$��10,0,0,0q�$��Center=��� -    ��Name$ CloseButton��$��2��$	��✕��$��30��$��30��$��0q�
������ 
�������$��0q����� " ��.���  � ��	 �� "
 ��.R��� #��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#c42b1c�� $��1��$��20q�.+��� $ ��Entrez votre code d'accès��
�������$��16(�$��0,0,0,20q�$��Center=��� -    ��Name$ CodeTextBox��$
��0,10q�$��16(��� -   $ LoginButton��$��Se connecter��$��40��$��14(�$
��0,20q��� -   $ DiscordButton��$��Rejoindre Discord��$��40��$��14(����#5865F2$	��0,5q����� " ��.���  � ��	 �� "
 ��.R��� #��z��$ 5��$��0q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#4752C4�� -    ��Name$ 
StatusText�����#c42b1c �� TextAlignment$ Center=�$
��Wrap=�