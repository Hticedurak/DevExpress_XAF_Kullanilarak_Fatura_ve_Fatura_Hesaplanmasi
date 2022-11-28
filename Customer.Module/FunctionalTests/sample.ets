;#DropDB CustomerEasyTest

#Application CustomerWin
;#Application CustomerWeb
#IfDef CustomerWin

*Action About...
 
*Action OK

#EndIf

#IfDef CustomerWeb
!Action Navigation(My Details)
#EndIf
