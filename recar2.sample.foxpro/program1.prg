PUBLIC RecarEvents
RecarEvents = NEWOBJECT("RecarKernelEvents")

DO FORM "form1.scx"
READ EVENTS

DEFINE CLASS RecarKernelEvents AS session OLEPUBLIC

	* ��������������� ���� � tlb ����� � ������ �������������
	IMPLEMENTS _IRecarKernelCOMEvents IN "RecarKernelCOMInterop.tlb"

	PROCEDURE _IRecarKernelCOMEvents_NumberRecognized(solution AS RecarCOM.IRecarSolution) AS VOID
	* ������� - �� ������ solution.CamId ��������� ����� solution.Number
	
	form1.List1.AddItem(solution.Number)

	ENDPROC

ENDDEFINE

