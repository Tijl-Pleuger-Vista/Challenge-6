   M S B A M L   `   `   `  ���� >  :PVO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PVOPVO      PVO.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     #localclr-namespace:PVO     5ui&http://schemas.lepo.co/wpfui/2022/xaml     -     �Name$  FirstWindow�� � Title$ 1337 HandB00K�� � Icon$ img\favicon.ico������  �� ImageSource$ 
img\1.webp��.��(�  (� Stretch$ Uniform=�.��� $��	0,0,10,-6q� � RowDefinitions �� $	��10* ��� $
��143* � � ColumnDefinitions �� $��0* ��� .+�� -    �Name$
 Chat��$��1��$��1��.+��� $��1��$	��300��$	��300��$��1014,38,20,58q�$��1�� �� RadiusX$ 70.674��	 �� RadiusY$	 70.674�����#161616
 J� Effect
 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 85Q�   Opacity$
 0.95Q�   ShadowDepth$ 1Q�   	Direction$ 25Q��� -    ��Name$ 	UserInput��$��1��$��1045,557,52,103q� �� TextWrapping$
 Wrap=�$�� ��$	��230��$��70��$	��230��$��60��$��1��$��10,10,10,10q�.�� � 	Resources  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 20��.���� $��Hidden=�$
��True��$��2��$��1037,79,44,228q�$��2��$	��430��$	��263��.���� -    ��Name$ Chatbox��$
��Wrap=�$?��9Ask Me Anything!, I am Happy to Help With Your Questions!��
��������� -    ��Name$ MainWindowView��$��1��$	��300��$��158,38,366,58q�$��1��$ 70.674��$	 70.674�����#161616
   $ 85Q�$
 0.95Q�$ 1Q�$ 25Q�� -   $ Sidebar��$��1��$��1��.+��� $��1�� K� ZIndex$ -1��$��22,69,1230,99q�$��1��$ 56��$	 56�����#161616
   $ 85Q�$
 0.95Q�$ 1Q�$ 25Q�o� $��1��$��33,108,1239,567q�$��1��
������ .@�m� $��74������ -    ��Name$ 	FirstIcon��$��img\World.png��$��59��$��60�� J� RenderTransformOrigin$ 	0.5,0.508&�.@�m� -   $��SQL Injection��m� -	   $��	Data Base��o� $��1��$��33,253,1239,422q�$��1��
������ .@�m� $��74������ -
   $ 
SecondIcon��$#��\img\icons8-web-shield-48.png��$��59��$��60��.@�m� -   $��About your security��o� $��1��$��33,390,1239,285q�$��1��
������ .@�m� $��74������ -   $ 	ThirdIcon��$&�� \img\icons8-local-network-64.png��$��59��$��60��.@�m� $
��Open��.@�m� $��Open2��.@�m� $��Open3��o� $��1��$��33,534,1239,141q�$��1��
������ .@�m� $��74������ -   $ 
FourthIcon��$/��)\img\icons8-security-configuration-48.png��$��59��$��60��.@�m� $
��Open��.@�m� $��Open2��.@�m� $��Open3���� $��hidden=�$
��True��$��181,70,397,85q�$��2��$��1��$	��580��$	��757��.���� -   $ MainText�� �� TextAlignment$ Center=�$��20(�$
��Wrap=�
�������$��2��$��2���� .��� -    ��Name$ OpeningMessage��$�Welcome to the Leet Book���� $� ���� -   $ 	MainTitle��
���  ��$��25(�$
��Bold"�$� ���� �� -   $ MainTitleText��$� ���� �� �� -   $ 	InfoTitle��
���  ��$��25(�$
��Bold"�$� ���� �� -   $ InfoText��$� ���� �� �� -   $ ProblemTitle��
���  ��$��25(�$
��Bold"�$� ���� �� -   $ ProblemText��$� ���� �� �� -   $ SolutionTitle��
���  ��$��25(�$
��Bold"�$� ���� �� -   $ SolutionText��$� ���� �� �� -   $ ExamplesTitle��
���  ��$��25(�$
��Bold"�$� ���� �� -   $ ExamplesText��$� ���� �� �� -   $ ResourcesTitle��
���  ��$��25(�$
��Bold"�$� ���� �� -   $ ResourcesText��$� ��� -   $ login��$��1��$��1��$y�Visible=�.+��� -   $ MainWindowViewLogin��$��5��$	��300��$��158,38,366,58q�$��1��$ 70.674��$	 70.674�����#161616
   $ 85Q�$
 0.95Q�$ 1Q�$ 25Q��� -   $ UserInputLoginUser��$��5��$��378,390,586,334q�$��14(�$
 Wrap=� �� TextAlignment$ Center=�$�� ��$	��230��$��1��$��10,10,10,10q����#949494.�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��.��G� -    G�Name$ UserInputLoginPassword��   PasswordBoxStyle1#���   $��5��$��376,448,586,276q�$��14(�$	��230��$��1��$��10,10,10,10q�$ Center=����#949494�� -     ��Name$ loginBtn��  lvl1btn#���  $��Login��$��512,555,720,168q����#0C71E0
�������
������ �� -!   $ 	CreateBtn��#���  $��Create a Leet account��$��266,555,926,170q����#0C71E0
�������
������ �� -"   $ Offilinebtn��#���  $��Offline��$��705,555,487,169q����#0C71E0
�������
������ �� -#   $ 	LoginLogo��$��\img\original.png��$��353,120,566,438q�$��1��$��5��$	��200��$	��200��$	��200��$	��200��� -$   $ OfflineWarningGrid��$��1��$��1��$y�Hidden=�.+��� -%   $ OfflineWarningBox��$	��300��$��266,112,465,430q�$ 70.674��$	 70.674�����#161616
   $ 85Q�$
 0.95Q�$ 1Q�$ 25Q��� -&   $ OffilineOKbtn��#���  $��Ok��$��490,268,702,456q����#0C71E0
�������
������ �� $
��Left=�$��389,198,0,0q�$
��Wrap=�$!��User data will not be saved��$	��Top=�
�������$��30(��� $
��Left=�$��507,130,0,0q�$
��Wrap=�$��
Warning!!!��$	��Top=�
��� ���$��30(��� -'   $ Level1��#���  
lvlbtn��$��Level 1��$��1��$��1120,170,126,529q�$��1�����#0C71E0
�������
������ $y�Hidden=��� -(   $ Level2��#���  
lvlbtn��$��Level 2��$��1��$��1120,284,126,415q�$��1�����#0C71E0
�������
������ $y�Hidden=��� -)   $ Level3��#���  
lvlbtn��$��Level 3��$��1��$��1120,402,126,297q�$��1�����#0C71E0
�������
������ $y�Hidden=��� -*   $ UserIcon��$��1��$��35,675,1240,19q�$��1������  �� 
TargetType" ��.R�� .+�A� 
������ $��0������   j� Stretch$  Uniform=� �� *Source+! �� ElementName$! UserIMG���� $��Center=�$��Center=��� -+   $ UserIMG��$y�Hidden=�$��566,223,780,542q�$��1��$��1��$��0��$��0��