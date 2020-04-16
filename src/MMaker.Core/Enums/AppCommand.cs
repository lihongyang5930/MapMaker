namespace MMaker.Core.Enums
{
    public enum AppCommand
    {
        None                = 0,
        NewProject          = 1000,
        OpenProject,
        SaveProject,
        SaveProjectAs,
        SetProjection,
        AddVector,                  //관리 -> 레이어 불러오기
        AddRaster,
        AddDatabase,
        CreateLayer,
        RemoveLayer,
        CloseApp,
        EditStart           = 2000,
        EditStop,
        Pan,
        ZoomIn,
        ZoomOut,
        ZoomMax,
        ZoomToLayer,
        ZoomToSelected,
        Grid                = 3000, //관망모델 -> GRID생성
        InValidate,                 //관망모델 -> 검증/보정
        UsageFlow,                  //관망모델 -> 사용량 등록
        MakeINP,                    //관망모델 -> 수리모델 생성
        Attribute,
        Epanet,
        MergeINP,
        SaveDpf,
        Select              = 4000,
        SelectByPolygon,
        ClearSelection,
        Identify,
        Measure,
        MeasureArea,
        Search,
        HighlightShapes,
        Snapshot,
    }
}