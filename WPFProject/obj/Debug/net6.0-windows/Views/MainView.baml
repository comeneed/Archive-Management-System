   M S B A M L   `   `   `  ����E  AWPFProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPFProject.ViewsWPFProject.Views  5   	   ;"clr-namespace:WPFProject.ExtensionWPFProject.Extension  5          WPFProject.Views.MainView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WPFProject.Views     5   	   ] YPrism.DryIoc.Wpf, Version=9.0.401.20976, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59V RPrism.Wpf, Version=9.0.401.20976, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a;	behaviors+http://schemas.microsoft.com/xaml/behaviors  5	   	   ,ext"clr-namespace:WPFProject.Extension  5      _	 [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5   
   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5   	    � Title$ MainView��5   	   $	��780��6   $
��1080��6'      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	    � WindowStartupLocation$ CenterScreen=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      ) 	 #MaterialDesignThemes.Wpf.DialogHost     DialogTheme$ Inherit=�6       
Identifier$ 
RootDialog��5      .��5   
   ) 	 #MaterialDesignThemes.Wpf.DrawerHost  -   5          Name$ 
drawerHost��5   n      IsLeftDrawerOpen 6$   �� 	 �� ElementName$	 MenuToggleButton��
 �� Path$
 	IsChecked�   LeftDrawerContent 5      ]� 5       $	��220��6   .+�5!      �� .+�5"      �� $��50��6    $��50��5#       $!��../static/img/User/icon.png��5$        J� Clip 5%      @� 5&   "    @� Center$ 25,25&�62    @� RadiusX$ 25Q�5'   2    @� RadiusY$ 25Q�5(   2   5*      �� 5+      $��
Gclove2000��6%   $��Center=�67   �� 5/      -   5         ��Name$ menuBar��5/   F   ��6#   �� *
MenuBars+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 50      +  %Microsoft.Xaml.Behaviors.EventTrigger  52   "      	EventName$ SelectionChanged��6:   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 54   &   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6D   �� *NavigateCommand+   CommandParameter 6h   �� $	 menuBar��$
 SelectedItem�55   #   ��57      �� 58   "   .R�59   &   �� 
������  �� Orientation$ 
Horizontal=�6K   .+�5:   *   '	 	 !MaterialDesignThemes.Wpf.PackIcon	  $
��15,0q�6C    	  Kind 6R   �� *Icon+�� 5;   *   $
��10,0q�6K   ��64   �� *Title+6K   5<   '   5=   #   5?      5B      5C      .��5F      ]� .+�5G      (
 	 "MaterialDesignThemes.Wpf.ColorZone
  -   5         
 Name$ 	ColorZone��5H   +   $��16q�5G   +   . 	 (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp4=�5I   #   $	��Top=�5J   #    
  Mode$ 
PrimaryMid=�5K   #   .��5L      ]� $
��True��6    .+�5M      �� $��Right=�6%   $ 
Horizontal=�6<   .+�5N      �� $��/static/img/User/icon.png��6$   $��25��6G   $��25��6S    5O   "   @� 5Q   &   $ 	12.5,12.5&�66   $
 12.5Q�6I   $
 12.5Q�6X   5S      �� 5U      -   5         ��Name$ BtnMin��5U   %   $	��—��65    ! MaterialDesignFlatMidBgButton#��[ 6A   �� 5V      -   5        $ BtnMax��5V   %   $	��☐��65   #��[ 6A   �� 5W      -   5        $ BtnClose��5W   %   $	��✕��67   #��[ 6C   5X      �� 5Y      $ 
Horizontal=�6%   .+�5Z      d� -   5         d�Name$ MenuToggleButton��5Z   +   4  .System.Windows.Automation.AutomationProperties   Name$ HamburgerToggleButton��5[       d� 	IsChecked$ FalseY�5\       ' #MaterialDesignHamburgerToggleButton#��[ 5]      �� 5_      $��24,0,0,0q�6%     MaterialDesignToolButton#��[ 5e       � ToolTip$ Previous Item��5f      + 	 %MaterialDesignThemes.Wpf.RippleAssist    Feedback  5`      �� ! �� RelativeSource! �� *Self+$
 
Foreground�  BrushRoundConverter" �� 	Converter#" [ ��5a      �� *GoBackCommand+��5b      0 	 *MaterialDesignThemes.Wpf.PackIconExtension  #   Kind$# 	ArrowLeft=�$   Size$ 24��5d      �� ! �� % �� AncestorType"% �$
 (TextElement.Foreground)�5f      �� 5h      $��16,0,0,0q�6%   #��[ 5n      $ 	Next Item��5o        5i      �� ! �� *Self+$
 
Foreground�#" [ ��5j      �� *GoForwardCommand+��5k        $# 
ArrowRight=�$ 24��5m      �� ! �� "% �$
 (TextElement.Foreground)�5o      �� 5q      $
��16,0q�6(   $��Center=�5r      $��Center=�5s      $% Material Design In XAML Toolkit��5t      $��22(�5u      $��
WPFProject��5v      5w      5x      5y      �� 5{      '   !WPFProject.Extension.PrismManager&   MainViewRegionName,  &Prism.Navigation.Regions.RegionManager'   
RegionName#' Z& 6!   5|      5      5�      5�      