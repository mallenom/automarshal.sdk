PUBLIC RecarEvents
RecarEvents = NEWOBJECT("RecarKernelEvents")

DO FORM "form1.scx"
READ EVENTS

DEFINE CLASS RecarKernelEvents AS session OLEPUBLIC

	* отредактировать путь к tlb файлу в случае необходимости
	IMPLEMENTS _IRecarKernelCOMEvents IN "RecarKernelCOMInterop.tlb"

	PROCEDURE _IRecarKernelCOMEvents_NumberRecognized(solution AS RecarCOM.IRecarSolution) AS VOID
	* событие - на камере solution.CamId распознан номер solution.Number
	
	form1.List1.AddItem(solution.Number)

	ENDPROC

ENDDEFINE

