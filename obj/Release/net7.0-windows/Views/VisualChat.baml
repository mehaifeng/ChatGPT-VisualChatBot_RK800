   M S B A M L   `   `   `  ???? H  DVisualChatBot, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:VisualChatBot.ViewModelsVisualChatBot.ViewModels      VisualChatBot.VisualChat   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <	viewmodel&clr-namespace:VisualChatBot.ViewModels       ? 
ResizeMode$  CanMinimize=? ? WindowStyle$
 None=? ? AllowsTransparency$
 True??
??????  ? WindowStartupLocation$ CenterScreen=?$	??800??$	??450?? ? 	Resources  ?? Source?? $) #../Assets/Styles/DefaultStyles.xaml??%    .???? $??7q? J? Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$
 Gray??   
BlurRadius$ 10Q?	   Opacity$		 0.7Q?
   	Direction$	
 320Q?   ShadowDepth$ 5Q?._?? $??3?? ? RowDefinitions ?? $??30 ??? ?? $	??110 ?.+??? -   $??0?? ?? CornerRadius$ 5,5,0,0??
???????._??? $??Right=? ?? Orientation$ 
Horizontal=?.+??? -   $	????$??20(?$??0,0,5,0q?   WindowControlButtomTemplate#??[  ?? -   $	????$??30(?$??0,0,5,0q?#??[  ?? -   
???????$??1??$ Vertical=?.+?? .+?d? -    d?Name$ MenuToggleBtn?? ? Cursor$
 Hand??$??28(?
???   ?$??10,0,0,0q?$
??Left=?  ToggleButtonTemplate#??[ ????  ?? 
TargetType" d?.???  ?? Property ? ?? ?? Value$	 ?? ?? Triggers ??  ?? Binding ??  ?? ElementName$ 	MenuPopup?? ?? Path$ IsOpen? ?? Value true.a???  ? ??$	 ??? -    ?Name$ 	MenuPopup?? ? 	StaysOpen$ False?? ? AllowsTransparency$
 True??$??Bottom=????? $ MenuToggleBtn??$ 	IsChecked? ? PlacementTarget ?? $ MenuToggleBtn??.???? $??10q?
???????$??80??$??80??$ 7??   $
 Gray??$
 0Q?$ 10Q?$		 0.7Q?$ 1Q?._??? $??5q?$ Vertical=?.+??? $??打开存档??  MenuBtnTemplate#??[ $??12(?$??0,0,0,8q??? $??OpenAI门户??$??12(?#??[ $??0,0,0,8q??? $??关于??$??12(?#??[ ???? *ClickAboutCommand+?? -    ??Name$ OpenSettingBtn??$
 Hand??$??Center=?$??28(?#??[  ???? *SettingBtnContent+???? *OpenOrCloseConfigCommand+???? $ 
ConfigGrid???? -    ??Name$ ConfigBorder??
???????$??1q?$??5,0,5,5q?$	??420?????? *ConfigGridHeight+._?? -	    ?Name$ 
ConfigGrid??.+??? $ 
Horizontal=?.+??? $??模型??
???????$??Center=?$??10,0,5,0q??? -
     ??Name$  OptionalModelsComboBox??$??0q?$??Center=?$??0,0,0,0q?$??20??$	??140??! ?? SelectedValue! ?? *
Modelstype+" ?? Mode$" TwoWay=?# ?? UpdateSourceTrigger$# PropertyChanged=??? $??	主客观??
???????$??Center=?$??5,0,5,0q??? -   $  ObjectDegreeCombobox??$??0q?$??Center=?$??0,0,0,0q?$??20??$??45??! ?? *ObjectDegree+$" TwoWay=?$# PropertyChanged=??? $??	MaxTokens??
???????$??Center=?$??5,0,5,0q??? -   $ ??Name$$ MaxTokensTextbox??$??1q?$??Center=?$??0,0,0,0q?$??20??$??60?????? *
MaxToken+?? % J? IsHitTestVisible$% False??$??RK800??
???????$??Center=?$??28(??? ???#F5F5F5$??1q?
???????$ 7??$??5,15,5,0q?._??? -   $$ 	OutputBox??& ?? TextWrapping$& WrapWithOverflow=????#F5F5F5' ?? AcceptsReturn$
' True??( ?? 
IsReadOnly$
( True??$??0q?$??2,2,2,2q?$	??400?????? *
ShowOutput+$" OneWay=?$# PropertyChanged=??? -   ) ??Name$) loadingSignal??$??//////??
???????$??Center=?$??0,2,0,5q??? ???#F5F5F5$??1q?
???????$ 7??$??5,0,5,0q?._??? -   ???#F5F5F5$& WrapWithOverflow=?$
' True??$??0q?$??2,2,2,2q?$	??120?????? *	MyInput+$" TwoWay=?$# PropertyChanged=?? $??2????Z? .+??? $ 0,0,5,5??
???????._??? -   $ 
confirmBtn??$??80??$??30??$??0,0,5,0q?$??Right=?$	??Top=?
???????$??发送??  ConfirmButtonTemplate#??[ ???? *SendCommand+???? $ 	OutputBox??