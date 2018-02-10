program recar2_sample_x86;

uses
  Forms,
  SampleUnit in 'SampleUnit.pas' {MainForm};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TMainForm, MainForm);
  Application.Run;
end.
