namespace MMaker.Core.Enums
{
    public enum AppCommand
    {
        None = 0,
        Open = 1,
        ZoomIn = 2,
        ZoomOut = 3,
        Pan = 4,
        Measure = 5,
        MeasureArea = 6,
        Select = 7,
        CloseProject = 8,
        SaveProject = 9,
        Identify = 10,
        RemoveLayer = 11,
        ZoomToLayer = 12,
        SetProjection = 13,
        AddVector = 14,         //관리 -> 레이어 불러오기
        AddRaster = 15,
        CreateLayer = 16,
        ZoomToSelected = 17,
        ClearSelection = 18,
        SaveProjectAs = 19,
        CloseApp = 20,
        LoadProject = 21,
        Search = 22,
        SelectByPolygon = 23,
        HighlightShapes = 24,
        AddDatabase = 25,
        Snapshot = 26,
        Grid = 27,              //관망모델 -> GRID생성
        InValidate = 28,        //관망모델 -> 검증/보정
        UsageFlow = 29,         //관망모델 -> 사용량 등록
        MakeINP = 30,           //관망모델 -> 수리모델 생성
        Attribute = 31,
        Epanet = 32,
        MergeINP = 33,
        SaveDpf = 34,
        Testdbf = 35,
        EditStart = 36,
        EditCancel = 37,
        EditSave = 38,
    }
}