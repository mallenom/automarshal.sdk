unit SampleUnit;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, Grids, StdCtrls, Buttons, recar2_com_TLB;

type
  TMainForm = class(TForm)
    ButtonCreate: TButton;
    ButtonDeinit: TButton;
    StringGrid1: TStringGrid;
    Image1: TImage;
    ButtonSetup: TButton;
    ButtonStart: TButton;
    ButtonStop: TButton;
    CheckBoxShowLog: TCheckBox;
    CheckBoxShowVideo: TCheckBox;
    ButtonSetupCamera0: TButton;
    ButtonSetupCamera1: TButton;
    CheckBoxCamera1Motion: TCheckBox;
    CheckBoxSaveImages: TCheckBox;
    EditImagesPath: TEdit;
    ButtonOK: TBitBtn;
    Label1: TLabel;
    Label2: TLabel;
    ButtonInitialize: TButton;
    procedure ButtonCreateClick(Sender: TObject);
    procedure ButtonDeinitClick(Sender: TObject);
    procedure ButtonSetupClick(Sender: TObject);
    procedure ButtonStartClick(Sender: TObject);
    procedure ButtonStopClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure FormCreate(Sender: TObject);
    procedure EnableAll(enabled: Boolean);
    procedure Dispose(withError: Boolean);
    procedure CheckBoxShowLogClick(Sender: TObject);
    procedure CheckBoxShowVideoClick(Sender: TObject);
    procedure ButtonSetupCamera0Click(Sender: TObject);
    procedure ButtonSetupCamera1Сlick(Sender: TObject);
    procedure CheckBoxSaveImagesClick(Sender: TObject);
    procedure ButtonOKClick(Sender: TObject);
    procedure CheckBoxCamera1MotionClick(Sender: TObject);
    procedure StringGrid1SelectCell(Sender: TObject; ACol, ARow: Integer;
      var CanSelect: Boolean);
    procedure ButtonInitializeClick(Sender: TObject);
  private
    { Private declarations }
    procedure OnNumberRecognized(ASender: TObject; const solution: IRecarSolution);
  public
    { Public declarations }
  end;

var
  MainForm: TMainForm;
  _core: TVideoCoreCom;

implementation

uses ComObj;

{$R *.dfm}

procedure TMainForm.FormCreate(Sender: TObject);
begin
  Application.Title := 'Recar2: ядро распознавания номеров автомобилей';
  _core := nil;
  StringGrid1.Rows[0][0] := 'Номер';
  StringGrid1.Rows[0][1] := 'Кам.';
  StringGrid1.Rows[0][2] := 'Дата';
  StringGrid1.Rows[0][3] := 'Направ.';
  StringGrid1.Rows[0][4] := 'Файл';
  StringGrid1.RowCount := 2;
  EnableAll(false);
  CheckBoxShowLog.Enabled := False;
  CheckBoxShowVideo.Enabled := False;
end;

{* Создает ядро *}
procedure TMainForm.ButtonCreateClick(Sender: TObject);
begin
  try
    _core := TVideoCoreCom.Create(Self);
    _core.VideoProcessChannelCount := 2; { Количество видеоканалов распознавания }

    CheckBoxShowVideo.Checked := true;
    CheckBoxShowLog.Checked := false;
    ButtonCreate.Enabled := False;
    ButtonDeinit.Enabled := True;
    ButtonInitialize.Enabled := True;
    CheckBoxShowLog.Enabled := True;
    CheckBoxShowVideo.Enabled := True;

  except
    on E : EOleSysError do
    begin
      ShowMessage('Невозможно создать ядро. ' + E.Message + '. ErorrCode: ' +  String.Parse(E.ErrorCode) + '.');
      Dispose(False);
      _core.Destroy;
      _core := nil;
    end;
    on E : Exception do
    begin
      ShowMessage('Невозможно инициализировать ядро. ' + E.Message + '.');
      Dispose(False);
      _core.Destroy;
      _core := nil;
    end;
  end;
end;

{* Инициализириует ядро *}
procedure TMainForm.ButtonInitializeClick(Sender: TObject);
begin
  try
    _core.Initialize; { Инициализируем ядро распознавания }
    _core.LoadSettings; { Загружаем настройки из файла конфигурации }
    _core.OnNumberRecognized := Self.OnNumberRecognized; { Подписываемся на событие распознавания номера }

    EditImagesPath.Text := _core.ImageStoragePath;
    CheckBoxSaveImages.Checked := _core.ImageStorageEnabled;
    EnableAll(true);
  except
    on E : EOleSysError do
    begin
      ShowMessage('Невозможно инициализировать ядро. ' + E.Message + '. ErorrCode: ' +  String.Parse(E.ErrorCode) + '.');
      Dispose(False);
    end;
    on E : Exception do
    begin
      ShowMessage('Невозможно инициализировать ядро. ' + E.Message + '.');
      Dispose(False);
    end;
  end;

end;

procedure TMainForm.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  Dispose(False);
end;

procedure TMainForm.Dispose(withError: Boolean);
begin
  if (withError) then ShowMessage('Произошла ошибка. Ядро будет деинициализировано.');

  try
  if (_core <> nil) then
  begin
    if (_core.IsInitialized) then
      begin
        _core.SaveSettings; { Сохраняем настройки в файл конфигурации }
        _core.Dispose;
      end;
     _core.Destroy;
      _core := nil;
      EnableAll(false);
      ButtonCreate.Enabled := True;
      CheckBoxShowLog.Enabled := False;
      CheckBoxShowVideo.Enabled := False;
      ButtonInitialize.Enabled := False;
    end;
  except
  end;
end;

procedure TMainForm.OnNumberRecognized(ASender: TObject; const solution: IRecarSolution);
begin
  try
    if ((StringGrid1.RowCount >= 2) and (StringGrid1.Rows[1][0] <> '')) then StringGrid1.RowCount := StringGrid1.RowCount+1;

    StringGrid1.Rows[StringGrid1.RowCount-1][0] := solution.Number;
    StringGrid1.Rows[StringGrid1.RowCount-1][1] := IntToStr(solution.CameraId + 1);
    StringGrid1.Rows[StringGrid1.RowCount-1][2] := DateTimeToStr(Now);
    StringGrid1.Rows[StringGrid1.RowCount-1][3] := 'Направление';

    If (solution.MovementDirection = 1) Then StringGrid1.Rows[StringGrid1.RowCount-1][3] := 'вверх';
    If (solution.MovementDirection = 2) Then StringGrid1.Rows[StringGrid1.RowCount-1][3] := 'вниз';
    If (solution.MovementDirection = 0) Then StringGrid1.Rows[StringGrid1.RowCount-1][3] := 'неизв.';

    StringGrid1.Rows[StringGrid1.RowCount-1][4] := solution.ImageFileName;

    if (FileExists(solution.ImageFileName)) then Image1.Picture.LoadFromFile(solution.ImageFileName);
  except
    Dispose(true);
  end;
end;

procedure TMainForm.ButtonDeinitClick(Sender: TObject);
begin
  Dispose(False);
end;

procedure TMainForm.EnableAll(enabled: Boolean);
begin
  CheckBoxShowLog.Enabled := not enabled;
  CheckBoxShowVideo.Enabled := not enabled;
  CheckBoxCamera1Motion.Enabled := enabled;
  ButtonSetup.Enabled := enabled;
  ButtonDeinit.Enabled := enabled;
  ButtonStart.Enabled := enabled;
  ButtonStop.Enabled := enabled;
  ButtonSetupCamera0.Enabled := enabled;
  ButtonSetupCamera1.Enabled := enabled;
  ButtonOK.Enabled := enabled;
  CheckBoxSaveImages.Enabled := enabled;
  EditImagesPath.Enabled := enabled;
  ButtonCreate.Enabled := not enabled;
end;

procedure TMainForm.ButtonSetupClick(Sender: TObject);
begin
  try
    _core.ShowSetupForm; { Показываем форум настройки }
    _core.SaveSettings; { Сохраняем настройки в файл конфигурации }
  except
    Dispose(true);
  end;
end;

procedure TMainForm.ButtonStartClick(Sender: TObject);
begin
  try
    _core.Start;
  except
    Dispose(true);
  end;
end;

procedure TMainForm.ButtonStopClick(Sender: TObject);
begin
  try
    _core.Stop;
  except
    Dispose(true);
  end;
end;

procedure TMainForm.CheckBoxShowLogClick(Sender: TObject);
begin
  try
     if CheckBoxShowLog.Checked then
       _core.ShowLogForm
     else
       _core.HideLogForm;
  except
    Dispose(true);
  end;
end;

procedure TMainForm.CheckBoxShowVideoClick(Sender: TObject);
begin
  try
    _core.SetVideoFormsVisible(CheckBoxShowVideo.Checked);
    _core.SetVideoFormsLocked(false);
  except
    Dispose(true);
  end;
end;

procedure TMainForm.ButtonSetupCamera0Click(Sender: TObject);
begin
  try
    _core.ShowAlgSetupForm(0); { Показываем форму настройки алгоритмов для камеры 0 }
    _core.SaveSettings; { Сохраняем настройки  в файл конфигурации }
  except
    Dispose(true);
  end;
end;

procedure TMainForm.ButtonSetupCamera1Сlick(Sender: TObject);
begin
  try
    _core.ShowAlgSetupForm(1); { Показываем форму настройки алгоритмов для камеры 1 }
    _core.SaveSettings; { Сохраняем настройки  в файл конфигурации }
  except
    Dispose(true);
  end;
end;

procedure TMainForm.CheckBoxSaveImagesClick(Sender: TObject);
begin
  try
     _core.ImageStorageEnabled := CheckBoxSaveImages.Checked;
     _core.ImageStoragePath := EditImagesPath.Text;
  except
    Dispose(true);
  end;
end;

procedure TMainForm.ButtonOKClick(Sender: TObject);
begin
  try
     _core.ImageStorageEnabled := CheckBoxSaveImages.Checked;
     _core.ImageStoragePath := EditImagesPath.Text;
  except
    Dispose(true);
  end;
end;

procedure TMainForm.CheckBoxCamera1MotionClick(Sender: TObject);
begin
  try
     _core.SetMotionState(0, CheckBoxCamera1Motion.Checked);
  except
    Dispose(true);
  end;
end;

procedure TMainForm.StringGrid1SelectCell(Sender: TObject; ACol,
  ARow: Integer; var CanSelect: Boolean);
begin
  if (FileExists(StringGrid1.Rows[ARow][4])) then Image1.Picture.LoadFromFile(StringGrid1.Rows[ARow][4]);
end;

end.
