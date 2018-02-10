object MainForm: TMainForm
  Left = 212
  Top = 246
  Caption = 
    #1055#1088#1080#1084#1077#1088' '#1080#1089#1087#1086#1083#1100#1079#1086#1074#1072#1085#1080#1103' '#1103#1076#1088#1072' '#1088#1072#1089#1087#1086#1079#1085#1072#1074#1072#1085#1080#1103' '#1085#1086#1084#1077#1088#1086#1074' '#1072#1074#1090#1086#1084#1086#1073#1080#1083#1077#1081' Reca' +
    'r2'
  ClientHeight = 409
  ClientWidth = 1050
  Color = clBtnFace
  Font.Charset = RUSSIAN_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'Segoe UI'
  Font.Style = []
  OldCreateOrder = False
  OnClose = FormClose
  OnCreate = FormCreate
  DesignSize = (
    1050
    409)
  PixelsPerInch = 96
  TextHeight = 15
  object Image1: TImage
    Left = 648
    Top = 28
    Width = 384
    Height = 288
    Anchors = [akTop, akRight]
  end
  object Label1: TLabel
    Left = 260
    Top = 12
    Width = 151
    Height = 15
    Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090#1099' '#1088#1072#1089#1087#1086#1079#1085#1072#1074#1072#1085#1080#1103':'
  end
  object Label2: TLabel
    Left = 648
    Top = 8
    Width = 304
    Height = 15
    Anchors = [akTop, akRight]
    Caption = #1048#1079#1086#1073#1088#1072#1078#1077#1085#1080#1077' '#1087#1086#1089#1083#1077#1076#1085#1077#1075#1086' '#1086#1073#1085#1072#1088#1091#1078#1077#1085#1085#1086#1075#1086' '#1072#1074#1090#1086#1084#1086#1073#1080#1083#1103
  end
  object ButtonCreate: TButton
    Left = 24
    Top = 8
    Width = 217
    Height = 25
    Caption = #1057#1086#1079#1076#1072#1090#1100' '#1103#1076#1088#1086
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Segoe UI'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 0
    OnClick = ButtonCreateClick
  end
  object ButtonDeinit: TButton
    Left = 24
    Top = 39
    Width = 217
    Height = 25
    Caption = #1042#1099#1075#1088#1091#1079#1080#1090#1100' '#1103#1076#1088#1086
    Enabled = False
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Segoe UI'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 1
    OnClick = ButtonDeinitClick
  end
  object StringGrid1: TStringGrid
    Left = 260
    Top = 29
    Width = 382
    Height = 373
    Anchors = [akLeft, akTop, akRight, akBottom]
    FixedCols = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goColSizing, goEditing]
    TabOrder = 2
    OnSelectCell = StringGrid1SelectCell
    ColWidths = (
      54
      37
      110
      52
      89)
    RowHeights = (
      24
      24
      24
      24
      24)
  end
  object ButtonSetup: TButton
    Left = 24
    Top = 162
    Width = 217
    Height = 25
    Caption = #1053#1072#1089#1090#1088#1086#1080#1090#1100
    Enabled = False
    TabOrder = 3
    OnClick = ButtonSetupClick
  end
  object ButtonStart: TButton
    Left = 24
    Top = 271
    Width = 93
    Height = 25
    Caption = #1057#1090#1072#1088#1090
    Enabled = False
    TabOrder = 4
    OnClick = ButtonStartClick
  end
  object ButtonStop: TButton
    Left = 148
    Top = 271
    Width = 93
    Height = 25
    Caption = #1057#1090#1086#1087
    Enabled = False
    TabOrder = 5
    OnClick = ButtonStopClick
  end
  object CheckBoxShowLog: TCheckBox
    Left = 32
    Top = 70
    Width = 137
    Height = 17
    Caption = #1055#1086#1082#1072#1079#1099#1074#1072#1090#1100' '#1083#1086#1075
    Enabled = False
    TabOrder = 6
    OnClick = CheckBoxShowLogClick
  end
  object CheckBoxShowVideo: TCheckBox
    Left = 32
    Top = 93
    Width = 137
    Height = 17
    Caption = #1055#1086#1082#1072#1079#1099#1074#1072#1090#1100' '#1074#1080#1076#1077#1086
    Enabled = False
    TabOrder = 7
    OnClick = CheckBoxShowVideoClick
  end
  object ButtonSetupCamera1: TButton
    Left = 24
    Top = 223
    Width = 217
    Height = 26
    Caption = #1053#1072#1089#1090#1088#1086#1080#1090#1100' '#1072#1083#1075#1086#1088#1080#1090#1084#1099' '#1076#1083#1103' '#1082#1072#1085#1072#1083#1072' #2'
    Enabled = False
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Segoe UI'
    Font.Style = []
    ParentFont = False
    TabOrder = 8
    WordWrap = True
    OnClick = ButtonSetupCamera1Сlick
  end
  object CheckBoxCamera1Motion: TCheckBox
    Left = 24
    Top = 372
    Width = 137
    Height = 17
    Caption = #1044#1074#1080#1078#1077#1085#1080#1077' '#1087#1086' '#1082#1072#1084#1077#1088#1077' 1'
    Enabled = False
    TabOrder = 9
    OnClick = CheckBoxCamera1MotionClick
  end
  object CheckBoxSaveImages: TCheckBox
    Left = 24
    Top = 316
    Width = 205
    Height = 17
    Caption = #1057#1086#1093#1088#1072#1085#1103#1090#1100' '#1080#1079#1086#1073#1088#1072#1078#1077#1085#1080#1103' '#1074' '#1082#1072#1090#1072#1083#1086#1075':'
    Enabled = False
    TabOrder = 10
    OnClick = CheckBoxSaveImagesClick
  end
  object EditImagesPath: TEdit
    Left = 24
    Top = 340
    Width = 178
    Height = 23
    Enabled = False
    TabOrder = 11
  end
  object ButtonOK: TBitBtn
    Left = 208
    Top = 339
    Width = 33
    Height = 24
    Caption = 'OK'
    Enabled = False
    TabOrder = 12
    OnClick = ButtonOKClick
  end
  object ButtonSetupCamera0: TButton
    Left = 24
    Top = 191
    Width = 217
    Height = 26
    Caption = #1053#1072#1089#1090#1088#1086#1080#1090#1100' '#1072#1083#1075#1086#1088#1080#1090#1084#1099' '#1076#1083#1103' '#1082#1072#1085#1072#1083#1072' #1'
    Enabled = False
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Segoe UI'
    Font.Style = []
    ParentFont = False
    TabOrder = 13
    WordWrap = True
    OnClick = ButtonSetupCamera0Click
  end
  object ButtonInitialize: TButton
    Left = 24
    Top = 116
    Width = 217
    Height = 25
    Caption = #1048#1085#1080#1094#1080#1072#1083#1080#1079#1080#1088#1086#1074#1072#1090#1100' '#1103#1076#1088#1086
    Enabled = False
    TabOrder = 14
    OnClick = ButtonInitializeClick
  end
end
