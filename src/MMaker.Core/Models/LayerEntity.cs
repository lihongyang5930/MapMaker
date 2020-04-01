using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoAPI.Geometries;

namespace MMaker.Core.Models2
{
    /// <summary>
    /// 20200305 - fdragons
    /// 레이어 인터페이스
    /// </summary>
    public interface IWTL_Layer
    {
        string KorName();
        IEnumerable<string> EngName();
        IEnumerable<string> ColumnsDesc();
    }

    /// <summary>
    /// 대블록
    /// </summary>
    public class WTL_BLBG_AS : IWTL_Layer
    {
        public string KorName()
        {
            return "대블록";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_BLBG_AS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string> {
                "지자체코드",    // SGCCD     
                "지물부호",      // FTR_CDE   
                "관리번호",      // FTR_IDN   
                "블록명",        // BLK_NAM   
                "급수계통명",    // WSP_NAM   
                "최대급수량",    // WSP_BIG   
                "관리기관",      // MNG_CDE   
                "인구",          // PPL_NUM   
                "세대수",        // GNR_NUM   
                "변경일시",      // UPD_DTM   
            }).AsEnumerable();
        }

        public string   SGCCD     { get; set; }   
        public string   FTR_CDE   { get; set; } 
        public string   FTR_IDN   { get; set; } 
        public string   BLK_NAM   { get; set; } 
        public string   WSP_NAM   { get; set; }  
        public double   WSP_BIG   { get; set; }  
        public string   MNG_CDE   { get; set; } 
        public double   PPL_NUM   { get; set; } 
        public double   GNR_NUM   { get; set; } 
        public DateTime UPD_DTM   { get; set; } 
    }

    /// <summary>
    /// 중블록
    /// </summary>
    public class WTL_BLBM_AS : IWTL_Layer
    {
        public string KorName()
        {
            return "중블록";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_BLBM_AS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string> {
                "지자체코드",    // SGCCD   
                "지물부호",      // FTR_CDE 
                "관리번호",      // FTR_IDN 
                "블록명",        // BLK_NAM 
                "급수계통명",    // WSP_NAM 
                "최대급수량",    // WSP_BIG 
                "관리기관",      // MNG_CDE 
                "인구",          // PPL_NUM 
                "세대수",        // GNR_NUM 
                "대블록부호",    // UBL_CDE 
                "대블록번호",    // UBL_IDN 
                "변경일시",      // UPD_DTM 
            }).AsEnumerable();
        }

        public string   SGCCD   { get; set; }
        public string   FTR_CDE { get; set; }
        public string   FTR_IDN { get; set; }
        public string   BLK_NAM { get; set; }
        public string   WSP_NAM { get; set; }
        public double   WSP_BIG { get; set; }
        public string   MNG_CDE { get; set; }
        public double   PPL_NUM { get; set; }
        public double   GNR_NUM { get; set; }
        public string   UBL_CDE { get; set; }
        public string   UBL_IDN { get; set; }
        public DateTime UPD_DTM { get; set; }
    }

    /// <summary>
    /// 소블록
    /// </summary>
    public class WTL_BLSM_AS : IWTL_Layer
    {
        public string KorName()
        {
            return "소블록";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_BLSM_AS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string> {
                "지자체코드",   // SGCCD   
                "지물부호",     // FTR_CDE 
                "관리번호",     // FTR_IDN 
                "블록명",       // BLK_NAM 
                "급수시설명",   // WSP_NAM 
                "최대급수량",   // WSP_BIG 
                "관리기관",     // MNG_CDE 
                "인구",         // PPL_NUM 
                "세대수",       // GNR_NUM 
                "중블록부호",   // UBL_CDE 
                "중블록번호",   // UBL_IDN 
                "변경일시",     // UPD_DTM 
            }).AsEnumerable();
        }

        public string   SGCCD   { get; set; }
        public string   FTR_CDE { get; set; }
        public string   FTR_IDN { get; set; }
        public string   BLK_NAM { get; set; }
        public string   WSP_NAM { get; set; }
        public double   WSP_BIG { get; set; }
        public string   MNG_CDE { get; set; }
        public double   PPL_NUM { get; set; }
        public double   GNR_NUM { get; set; }
        public string   UBL_CDE { get; set; }
        public string   UBL_IDN { get; set; }
        public DateTime UPD_DTM { get; set; }
    }

    /// <summary>
    /// 소화전
    /// </summary>
    public class WTL_FIRE_PS : IWTL_Layer
    {
        public string KorName()
        {
            return "소화전";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_FIRE_PS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string> {
                "지자체코드",    // SGCCD   
                "지물부호",      // FTR_CDE 
                "관리번호",      // FTR_IDN 
                "행정구역",      // HJD_CDE 
                "관리기관",      // MNG_CDE 
                "설치일자",      // IST_YMD 
                "수용가번호",    // DMNO    
                "소화전형식",    // MOF_CDE 
                "소화전구경",    // FIR_DIP 
                "배수관구경",    // PIP_DIP 
                "급수탑높이",    // SUP_HIT 
                "방향각",        // ANG_DIR 
                "공사번호",      // CNT_NUM 
                "대장초기화",    // SYS_CHK 
                "블록부호",      // BSM_CDE 
                "블록번호",      // BSM_IDN 
                "광역구분",      // WID_CDE 
                "변경일시",      // UPD_DTM 
            }).AsEnumerable();
        }

        public string   SGCCD   { get; set; }
        public string   FTR_CDE { get; set; }
        public string   FTR_IDN { get; set; }
        public string   HJD_CDE { get; set; }
        public string   MNG_CDE { get; set; }
        public string   IST_YMD { get; set; }
        public string   DMNO    { get; set; }
        public string   MOF_CDE { get; set; }
        public double   FIR_DIP { get; set; }
        public double   PIP_DIP { get; set; }
        public double   SUP_HIT { get; set; }
        public double   ANG_DIR { get; set; }
        public string   CNT_NUM { get; set; }
        public string   SYS_CHK { get; set; }
        public string   BSM_CDE { get; set; }
        public string   BSM_IDN { get; set; }
        public string   WID_CDE { get; set; }
        public DateTime UPD_DTM { get; set; }
    }

    /// <summary>
    /// 유량계
    /// </summary>
    public class WTL_FLOW_PS : IWTL_Layer
    {
        public string KorName()
        {
            return "유량계";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_FLOW_PS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD   
                "지물부호",      // FTR_CDE 
                "관리번호",      // FTR_IDN 
                "행정구역",      // HJD_CDE 
                "관리기관",      // MNG_CDE 
                "설치일자",      // IST_YMD 
                "유량계용도",    // GAG_CDE 
                "유량계형식",    // MOF_CDE 
                "유량계명",      // FLO_NM  
                "구경",          // FLO_DIP 
                "제작회사명",    // PRD_NAM 
                "데이터처리",    // DAT_CDE 
                "방향각",        // ANG_DIR 
                "공사번호",      // CNT_NUM 
                "대장초기화",    // SYS_CHK 
                "상수관부호",    // PIP_CDE 
                "상수관번호",    // PIP_IDN 
                "밸브실부호",    // VAB_CDE 
                "밸브실번호",    // VAB_IDN 
                "블록부호",      // BSM_CDE 
                "블록번호",      // BSM_IDN 
                "위치",          // LOC_LOC 
                "광역구분",      // WID_CDE 
                "변경일시",      // UPD_DTM 
            }).AsEnumerable();
        }

        public string   SGCCD   { get; set; }
        public string   FTR_CDE { get; set; }
        public string   FTR_IDN { get; set; }
        public string   HJD_CDE { get; set; }
        public string   MNG_CDE { get; set; }
        public string   IST_YMD { get; set; }
        public string   GAG_CDE { get; set; }
        public string   MOF_CDE { get; set; }
        public string   FLO_NM  { get; set; }
        public double   FLO_DIP { get; set; }
        public string   PRD_NAM { get; set; }
        public string   DAT_CDE { get; set; }
        public double   ANG_DIR { get; set; }
        public string   CNT_NUM { get; set; }
        public string   SYS_CHK { get; set; }
        public string   PIP_CDE { get; set; }
        public string   PIP_IDN { get; set; }
        public string   VAB_CDE { get; set; }
        public string   VAB_IDN { get; set; }
        public string   BSM_CDE { get; set; }
        public string   BSM_IDN { get; set; }
        public string   LOC_LOC { get; set; }
        public string   WID_CDE { get; set; }
        public DateTime UPD_DTM { get; set; }
    }

    /// <summary>
    /// 취수장
    /// </summary>
    public class WTL_GAIN_AS : IWTL_Layer
    {
        public string KorName()
        {
            return "취수장";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_GAIN_AS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD   
                "지물부호",      // FTR_CDE 
                "관리번호",      // FTR_IDN 
                "행정구역",      // HJD_CDE 
                "관리기관",      // MNG_CDE 
                "준공일자",      // FNS_YMD 
                "취수장명",      // GAI_NAM 
                "상세주소",      // DLAD    
                "수원구분",      // WSR_CDE 
                "수계명",        // WSS_NAM 
                "평균취수량",    // AGA_VOL 
                "시설용량",      // HGA_VOL 
                "펌프대수",      // PMP_CNT 
                "펌프용량",      // PMP_VOL 
                "부지면적",      // GAI_ARA 
                "도수방법",      // WRW_CDE 
                "취수방법",      // WGW_CDE 
                "공사번호",      // CNT_NUM 
                "대장초기화",    // SYS_CHK 
                "블록부호",      // BSM_CDE 
                "블록번호",      // BSM_IDN 
                "시설물부호",    // HGH_CDE 
                "시설물번호",    // HGH_IDN 
                "광역구분",      // WID_CDE 
                "변경일시",      // UPD_DTM 
            }).AsEnumerable();
        }

        public string   SGCCD   { get; set; }
        public string   FTR_CDE { get; set; }
        public string   FTR_IDN { get; set; }
        public string   HJD_CDE { get; set; }
        public string   MNG_CDE { get; set; }
        public string   FNS_YMD { get; set; }
        public string   GAI_NAM { get; set; }
        public string   DLAD    { get; set; }
        public string   WSR_CDE { get; set; }
        public string   WSS_NAM { get; set; }
        public double   AGA_VOL { get; set; }
        public double   HGA_VOL { get; set; }
        public double   PMP_CNT { get; set; }
        public double   PMP_VOL { get; set; }
        public double   GAI_ARA { get; set; }
        public string   WRW_CDE { get; set; }
        public string   WGW_CDE { get; set; }
        public string   CNT_NUM { get; set; }
        public string   SYS_CHK { get; set; }
        public string   BSM_CDE { get; set; }
        public string   BSM_IDN { get; set; }
        public string   HGH_CDE { get; set; }
        public string   HGH_IDN { get; set; }
        public string   WID_CDE { get; set; }
        public DateTime UPD_DTM { get; set; }
    }

    /// <summary>
    /// 수원지
    /// </summary>
    public class WTL_HEAD_AS : IWTL_Layer
    {
        public string KorName()
        {
            return "수원지";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_HEAD_AS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD   
                "지물부호",      // FTR_CDE 
                "관리번호",      // FTR_IDN 
                "행정구역",      // HJD_CDE 
                "관리기관",      // MNG_CDE 
                "준공일자",      // FNS_YMD 
                "수원지명",      // HEA_NAM 
                "수원구분",      // WSR_CDE 
                "유입하천명",    // IRV_NAM 
                "유효저수량",    // RSV_VOL 
                "유역면적",      // RSV_ARA 
                "만수면적",      // FUL_ARA 
                "갈수위",        // THR_WAL 
                "최대갈수위",    // HTH_WAL 
                "평수위",        // AVG_WAL 
                "홍수위",        // DRA_WAL 
                "최대홍수위",    // HDR_WAL 
                "사수위",        // KEE_WAL 
                "구역면적",      // GUA_ARA 
                "구역인구",      // GUA_POP 
                "공사번호",      // CNT_NUM 
                "대장초기화",    // SYS_CHK 
                "블록부호",      // BSM_CDE 
                "블록번호",      // BSM_IDN 
                "광역구분",      // WID_CDE 
                "변경일시",      // UPD_DTM 
            }).AsEnumerable();
        }

        public string   SGCCD   { get; set; }
        public string   FTR_CDE { get; set; }
        public string   FTR_IDN { get; set; }
        public string   HJD_CDE { get; set; }
        public string   MNG_CDE { get; set; }
        public string   FNS_YMD { get; set; }
        public string   HEA_NAM { get; set; }
        public string   WSR_CDE { get; set; }
        public string   IRV_NAM { get; set; }
        public double   RSV_VOL { get; set; }
        public double   RSV_ARA { get; set; }
        public double   FUL_ARA { get; set; }
        public double   THR_WAL { get; set; }
        public double   HTH_WAL { get; set; }
        public double   AVG_WAL { get; set; }
        public double   DRA_WAL { get; set; }
        public double   HDR_WAL { get; set; }
        public double   KEE_WAL { get; set; }
        public double   GUA_ARA { get; set; }
        public double   GUA_POP { get; set; }
        public string   CNT_NUM { get; set; }
        public string   SYS_CHK { get; set; }
        public string   BSM_CDE { get; set; }
        public string   BSM_IDN { get; set; }
        public string   WID_CDE { get; set; }
        public DateTime UPD_DTM { get; set; }
    }

    /// <summary>
    /// 수도계량기
    /// </summary>
    public class WTL_META_PS : IWTL_Layer
    {
        public string KorName()
        {
            return "수도계량기";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_META_PS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD    
                "지물부호",      // FTR_CDE  
                "관리번호",      // FTR_IDN  
                "수용가번호",    // DMNO     
                "행정구역",      // HJD_CDE  
                "설치일자",      // IST_YMD  
                "기물번호",      // MET_NUM  
                "계량기구경",    // MET_DIP  
                "계량기형식",    // MET_MOF  
                "계량기감도",    // MET_STV  
                "제작회사명",    // PRD_NUM  
                "봉인",          // MET_STM  
                "계량기상태",    // MET_CST  
                "보호통위치",    // MTB_LOC  
                "보호통재질",    // MTB_MOP  
                "보호통상태",    // MTB_CST  
                "공사번호",      // CNT_NUM  
                "대장초기화",    // SYS_CHK  
                "계량기번호",    // MET_IDN  
                "급수관부호",    // PIP_CDE  
                "급수관번호",    // PIP_IDN  
                "블록부호",      // BSM_CDE  
                "블록번호",      // BSM_IDN  
                "광역구분",      // WID_CDE  
                "변경일시",      // UPD_DTM  
                "검정일자",      // CTF_YMD  
                "수전번호",      // MEA_NUM  
                "급수상태",      // MET_CDE  
                "관리기관",      // MNG_CDE  
                "수용가명",      // DMNM     
                "배수지부호",    // SRV_CDE  
                "배수지번호",    // SRV_IDN  
                "밸브실번호",    // VAB_IDN  
                "비고",          // DESCRIPT 
            }).AsEnumerable();

        }

        public string   SGCCD    { get; set; }
        public string   FTR_CDE  { get; set; }
        public string   FTR_IDN  { get; set; }
        public string   DMNO     { get; set; }
        public string   HJD_CDE  { get; set; }
        public string   IST_YMD  { get; set; }
        public string   MET_NUM  { get; set; }
        public double   MET_DIP  { get; set; }
        public string   MET_MOF  { get; set; }
        public string   MET_STV  { get; set; }
        public string   PRD_NUM  { get; set; }
        public string   MET_STM  { get; set; }
        public string   MET_CST  { get; set; }
        public string   MTB_LOC  { get; set; }
        public string   MTB_MOP  { get; set; }
        public string   MTB_CST  { get; set; }
        public string   CNT_NUM  { get; set; }
        public string   SYS_CHK  { get; set; }
        public string   MET_IDN  { get; set; }
        public string   PIP_CDE  { get; set; }
        public string   PIP_IDN  { get; set; }
        public string   BSM_CDE  { get; set; }
        public string   BSM_IDN  { get; set; }
        public string   WID_CDE  { get; set; }
        public DateTime UPD_DTM  { get; set; }
        public string   CTF_YMD  { get; set; }
        public string   MEA_NUM  { get; set; }
        public string   MET_CDE  { get; set; }
        public string   MNG_CDE  { get; set; }
        public string   DMNM     { get; set; }
        public string   SRV_CDE  { get; set; }
        public string   SRV_IDN  { get; set; }
        public string   VAB_IDN  { get; set; }
        public string   DESCRIPT { get; set; }
    }

    /// <summary>
    /// 상수관로
    /// </summary>
    public class WTL_PIPE_LS : IWTL_Layer
    {
        public string KorName()
        {
            return "상수관로";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_PIPE_LS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD     
                "지물부호",      // FTR_CDE   
                "관리번호",      // FTR_IDN   
                "행정구역",      // HJD_CDE   
                "관리기관",      // MNG_CDE   
                "설치일자",      // IST_YMD   
                "도로명",        // ROD_NAM   
                "상수관용도",    // SAA_CDE   
                "관재질",        // MOP_CDE   
                "구경",          // PIP_DIP   
                "접합종류",      // JHT_CDE   
                "매설환경",      // UTG_LOC   
                "관갱생공",      // PIP_RHB   
                "갱생일자",      // RHB_YMD   
                "대장초기화",    // SYS_CHK   
                "위치설명",      // LCEXP     
                "블록부호",      // BSM_CDE   
                "블록번호",      // BSM_IDN   
                "연장",          // PIP_LEN   
                "최저깊이",      // LOW_DEP   
                "최고깊이",      // HGH_DEP   
                "변경일시",      // UPD_DTM   
                "광역구분",      // WID_CDE   
                "유수방향",      // AWTR_DICD 
                "공사번호",      // CNT_NUM   
                "관라벨",        // PIP_LBL   
                "비고",          // DESCRIPT  
                "관유형",        // PPL_SVECD 
            }).AsEnumerable();

        }

        public string   SGCCD     { get; set; }
        public string   FTR_CDE   { get; set; }
        public string   FTR_IDN   { get; set; }
        public string   HJD_CDE   { get; set; }
        public string   MNG_CDE   { get; set; }
        public string   IST_YMD   { get; set; }
        public string   ROD_NAM   { get; set; }
        public string   SAA_CDE   { get; set; }
        public string   MOP_CDE   { get; set; }
        public double   PIP_DIP   { get; set; }
        public string   JHT_CDE   { get; set; }
        public string   UTG_LOC   { get; set; }
        public string   PIP_RHB   { get; set; }
        public string   RHB_YMD   { get; set; }
        public string   SYS_CHK   { get; set; }
        public string   LCEXP     { get; set; }
        public string   BSM_CDE   { get; set; }
        public string   BSM_IDN   { get; set; }
        public double   PIP_LEN   { get; set; }
        public double   LOW_DEP   { get; set; }
        public double   HGH_DEP   { get; set; }
        public DateTime UPD_DTM   { get; set; }
        public string   WID_CDE   { get; set; }
        public string   AWTR_DICD { get; set; }
        public string   CNT_NUM   { get; set; }
        public string   PIP_LBL   { get; set; }
        public string   DESCRIPT  { get; set; }
        public string   PPL_SVECD { get; set; }
    }

    /// <summary>
    /// 가압장
    /// </summary>
    public class WTL_PRES_AS : IWTL_Layer
    {
        public string KorName()
        {
            return "가압장";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_PRES_AS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD   
                "지물부호",      // FTR_CDE 
                "관리번호",      // FTR_IDN 
                "행정구역",      // HJD_CDE 
                "관리기관",      // MNG_CDE 
                "준공일자",      // FNS_YMD 
                "가압장명",      // PRS_NAM 
                "부지면적",      // PRS_ARA 
                "가압형식",      // PRS_CDE 
                "관리방법",      // SAG_CDE 
                "가압장표고",    // PRS_ALT 
                "시설용량",      // PRS_VOL 
                "펌프대수",      // PMP_CNT 
                "완화설비",      // WSL_CDE 
                "완화설비량",    // WSL_VOL 
                "완화설비형",    // WSL_MOF 
                "가압구역",      // PRS_ARE 
                "수혜가구",      // PRS_SAH 
                "공사번호",      // CNT_NUM 
                "대장초기화",    // SYS_CHK 
                "블록부호",      // BSM_CDE 
                "블록번호",      // BSM_IDN 
                "시설물부호",    // HGH_CDE 
                "시설물번호",    // HGH_IDN 
                "광역구분",      // WID_CDE 
                "변경일시",      // UPD_DTM 
            }).AsEnumerable();

        }

        public string   SGCCD   { get; set; }
        public string   FTR_CDE { get; set; }
        public string   FTR_IDN { get; set; }
        public string   HJD_CDE { get; set; }
        public string   MNG_CDE { get; set; }
        public string   FNS_YMD { get; set; }
        public string   PRS_NAM { get; set; }
        public double   PRS_ARA { get; set; }
        public string   PRS_CDE { get; set; }
        public string   SAG_CDE { get; set; }
        public double   PRS_ALT { get; set; }
        public double   PRS_VOL { get; set; }
        public double   PMP_CNT { get; set; }
        public string   WSL_CDE { get; set; }
        public double   WSL_VOL { get; set; }
        public string   WSL_MOF { get; set; }
        public string   PRS_ARE { get; set; }
        public double   PRS_SAH { get; set; }
        public string   CNT_NUM { get; set; }
        public string   SYS_CHK { get; set; }
        public string   BSM_CDE { get; set; }
        public string   BSM_IDN { get; set; }
        public string   HGH_CDE { get; set; }
        public string   HGH_IDN { get; set; }
        public string   WID_CDE { get; set; }
        public DateTime UPD_DTM { get; set; }
    }

    /// <summary>
    /// 수압계
    /// </summary>
    public class WTL_PRGA_PS : IWTL_Layer
    {
        public string KorName()
        {
            return "수압계";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_PRGA_PS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD   
                "지물부호",      // FTR_CDE 
                "관리번호",      // FTR_IDN 
                "행정구역",      // HJD_CDE 
                "관리기관",      // MNG_CDE 
                "설치일자",      // IST_YMD 
                "수압계형식",    // PGA_CDE 
                "수압계용도",    // MOF_CDE 
                "구경",          // PGA_DIP 
                "데이터처리",    // DAT_CDE 
                "측정범위",      // STD_SAF 
                "평균압력",      // AVG_SAF 
                "측정압력",      // MSR_SAF 
                "배수관구경",    // PIP_DIP 
                "제작회사명",    // PRD_NAM 
                "방향각",        // ANG_DIR 
                "공사번호",      // CNT_NUM 
                "대장초기화",    // SYS_CHK 
                "상수관부호",    // PIP_CDE 
                "상수관번호",    // PIP_IDN 
                "밸브실부호",    // VAB_CDE 
                "밸브실번호",    // VAB_IDN 
                "블록부호",      // BSM_CDE 
                "블록번호",      // BSM_IDN 
                "광역구분",      // WID_CDE 
                "변경일시",      // UPD_DTM 
            }).AsEnumerable();

        }

        public string   SGCCD   { get; set; }
        public string   FTR_CDE { get; set; }
        public string   FTR_IDN { get; set; }
        public string   HJD_CDE { get; set; }
        public string   MNG_CDE { get; set; }
        public string   IST_YMD { get; set; }
        public string   PGA_CDE { get; set; }
        public string   MOF_CDE { get; set; }
        public double   PGA_DIP { get; set; }
        public string   DAT_CDE { get; set; }
        public double   STD_SAF { get; set; }
        public double   AVG_SAF { get; set; }
        public double   MSR_SAF { get; set; }
        public double   PIP_DIP { get; set; }
        public string   PRD_NAM { get; set; }
        public double   ANG_DIR { get; set; }
        public string   CNT_NUM { get; set; }
        public string   SYS_CHK { get; set; }
        public string   PIP_CDE { get; set; }
        public string   PIP_IDN { get; set; }
        public string   VAB_CDE { get; set; }
        public string   VAB_IDN { get; set; }
        public string   BSM_CDE { get; set; }
        public string   BSM_IDN { get; set; }
        public string   WID_CDE { get; set; }
        public DateTime UPD_DTM { get; set; }
    }

    /// <summary>
    /// 정수장
    /// </summary>
    public class WTL_PURI_AS : IWTL_Layer
    {
        public string KorName()
        {
            return "정수장";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_PURI_AS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD   
                "지물부호",      // FTR_CDE 
                "관리번호",      // FTR_IDN 
                "행정구역",      // HJD_CDE 
                "관리기관",      // MNG_CDE 
                "준공일자",      // FNS_YMD 
                "정수장명",      // PUR_NAM 
                "수원구분",      // WSR_CDE 
                "관련취수장",    // GAI_NAM 
                "관련배수지",    // SRV_NAM 
                "시설용량",      // PUR_VOL 
                "계약전력",      // PWR_VOL 
                "부지면적",      // PUR_ARA 
                "여과방법",      // SAM_CDE 
                "배출수처리",    // DTF_CDE 
                "공사번호",      // CNT_NUM 
                "대장초기화",    // SYS_CHK 
                "블록부호",      // BSM_CDE 
                "블록번호",      // BSM_IDN 
                "시설물부호",    // HGH_CDE 
                "시설물번호",    // HGH_IDN 
                "광역구분",      // WID_CDE 
                "변경일시",      // UPD_DTM 
            }).AsEnumerable();
        }

        public string   SGCCD   { get; set; }
        public string   FTR_CDE { get; set; }
        public string   FTR_IDN { get; set; }
        public string   HJD_CDE { get; set; }
        public string   MNG_CDE { get; set; }
        public string   FNS_YMD { get; set; }
        public string   PUR_NAM { get; set; }
        public string   WSR_CDE { get; set; }
        public string   GAI_NAM { get; set; }
        public string   SRV_NAM { get; set; }
        public double   PUR_VOL { get; set; }
        public double   PWR_VOL { get; set; }
        public double   PUR_ARA { get; set; }
        public string   SAM_CDE { get; set; }
        public string   DTF_CDE { get; set; }
        public string   CNT_NUM { get; set; }
        public string   SYS_CHK { get; set; }
        public string   BSM_CDE { get; set; }
        public string   BSM_IDN { get; set; }
        public string   HGH_CDE { get; set; }
        public string   HGH_IDN { get; set; }
        public string   WID_CDE { get; set; }
        public DateTime UPD_DTM { get; set; }
    }

    /// <summary>
    /// 배수지
    /// </summary>
    public class WTL_SERV_AS : IWTL_Layer
    {
        public string KorName()
        {
            return "배수지";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_SERV_AS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",        // SGCCD  
                "지물부호",          // FTR_CDE
                "관리번호",          // FTR_IDN
                "행정구역",          // HJD_CDE
                "관리기관",          // MNG_CDE
                "준공일자",          // FNS_YMD
                "배수지명",          // SRV_NAM
                "관련정수장",        // PUR_NAM
                "부지면적",          // SRV_ARA
                "가동여부",          // SRV_CDE
                "관리방법",          // SAG_CDE
                "시설용량",          // SRV_VOL
                "배수지표고",        // SRV_ALT
                "최고수위",          // HGH_WAL
                "최저수위",          // LOW_WAL
                "유입량",            // ISR_VOL
                "급수지역",          // SUP_ARE
                "급수인구",          // SUP_POP
                "제어방법",          // SCW_CDE
                "공사번호",          // CNT_NUM
                "대장초기화",        // SYS_CHK
                "블록부호",          // BSM_CDE
                "블록번호",          // BSM_IDN
                "시설물부호",        // HGH_CDE
                "시설물번호",        // HGH_IDN
                "광역구분",          // WID_CDE
                "변경일시",          // UPD_DTM <- string
                //블록명, 상세주소 표준에서 제외
            }).AsEnumerable();
        }

        public string   SGCCD   { get; set; }
        public string   FTR_CDE { get; set; }
        public string   FTR_IDN { get; set; }
        public string   HJD_CDE { get; set; }
        public string   MNG_CDE { get; set; }
        public string   FNS_YMD { get; set; }
        public string   SRV_NAM { get; set; }
        public string   PUR_NAM { get; set; }
        public double   SRV_ARA { get; set; }
        public string   SRV_CDE { get; set; }
        public string   SAG_CDE { get; set; }
        public double   SRV_VOL { get; set; }
        public double   SRV_ALT { get; set; }
        public double   HGH_WAL { get; set; }
        public double   LOW_WAL { get; set; }
        public double   ISR_VOL { get; set; }
        public string   SUP_ARE { get; set; }
        public double   SUP_POP { get; set; }
        public string   SCW_CDE { get; set; }
        public string   CNT_NUM { get; set; }
        public string   SYS_CHK { get; set; }	
        public string   BSM_CDE { get; set; }
        public string   BSM_IDN { get; set; }
        public string   HGH_CDE { get; set; }
        public string   HGH_IDN { get; set; }
        public string   WID_CDE { get; set; }
        public DateTime UPD_DTM { get; set; }
    }

    /// <summary>
    /// 급수관로
    /// </summary>
    public class WTL_SPLY_LS : IWTL_Layer
    {
        public string KorName()
        {
            return "급수관로";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_SPLY_LS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD    
                "지물부호",      // FTR_CDE  
                "관리번호",      // FTR_IDN  
                "행정구역",      // HJD_CDE  
                "관리기관",      // MNG_CDE  
                "설치일자",      // IST_YMD  
                "관재질",        // MOP_CDE  
                "상수관용도",    // SAA_CDE  
                "구경",          // PIP_DIP  
                "연장",          // PIP_LEN  
                "접합종류",      // JHT_CDE  
                "최저깊이",      // LOW_DEP  
                "최고깊이",      // HGH_DEP  
                "공사번호",      // CNT_NUM  
                "관라벨",        // PIP_LBL  
                "대장초기화",    // SYS_CHK  
                "상수관부호",    // PIP_CDE  
                "상수관번호",    // PIP_IDN  
                "블록부호",      // BSM_CDE  
                "블록번호",      // BSM_IDN  
                "광역구분",      // WID_CDE  
                "변경일시",      // UPD_DTM  
                "DESCRIPT",      // DESCRIPT 
            }).AsEnumerable();
        }

        public string   SGCCD    { get; set; }
        public string   FTR_CDE  { get; set; }
        public string   FTR_IDN  { get; set; }
        public string   HJD_CDE  { get; set; }
        public string   MNG_CDE  { get; set; }
        public string   IST_YMD  { get; set; }
        public string   MOP_CDE  { get; set; }
        public string   SAA_CDE  { get; set; }
        public double   PIP_DIP  { get; set; }
        public double   PIP_LEN  { get; set; }
        public string   JHT_CDE  { get; set; }
        public double   LOW_DEP  { get; set; }
        public double   HGH_DEP  { get; set; }
        public string   CNT_NUM  { get; set; }
        public string   PIP_LBL  { get; set; }
        public string   SYS_CHK  { get; set; }
        public string   PIP_CDE  { get; set; }
        public string   PIP_IDN  { get; set; }
        public string   BSM_CDE  { get; set; }
        public string   BSM_IDN  { get; set; }
        public string   WID_CDE  { get; set; }
        public DateTime UPD_DTM  { get; set; }
        public string   DESCRIPT { get; set; }
    }

    /// <summary>
    /// 밸브실
    /// </summary>
    public class WTL_VALB_AS : IWTL_Layer
    {
        public string KorName()
        {
            return "밸브실";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_VALB_AS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD   
                "지물부호",      // FTR_CDE 
                "관리번호",      // FTR_IDN 
                "행정구역",      // HJD_CDE 
                "관리기관",      // MNG_CDE 
                "설치일자",      // IST_YMD 
                "규격",          // MAN_STD 
                "밸브실용도",    // SOM_CDE 
                "맨홀뚜껑수",    // MAN_CNT 
                "맨홀규격",      // MHS_STD 
                "매설환경",      // UTG_LOC 
                "키홀수량",      // KEY_CNT 
                "키홀규격",      // KEY_STD 
                "구조물재질",    // MAN_MOP 
                "맨홀형태",      // MHS_CDE 
                "공사번호",      // CNT_NUM 
                "대장초기화",    // SYS_CHK 
                "상수관부호",    // PIP_CDE 
                "상수관번호",    // PIP_IDN 
                "블록부호",      // BSM_CDE 
                "블록번호",      // BSM_IDN 
                "광역구분",      // WID_CDE 
                "변경일시",      // UPD_DTM 
            }).AsEnumerable();

        }

        public string   SGCCD   { get; set; }
        public string   FTR_CDE { get; set; }
        public string   FTR_IDN { get; set; }
        public string   HJD_CDE { get; set; }
        public string   MNG_CDE { get; set; }
        public string   IST_YMD { get; set; }
        public string   MAN_STD { get; set; }
        public string   SOM_CDE { get; set; }
        public double   MAN_CNT { get; set; }
        public string   MHS_STD { get; set; }
        public string   UTG_LOC { get; set; }
        public double   KEY_CNT { get; set; }
        public string   KEY_STD { get; set; }
        public string   MAN_MOP { get; set; }
        public string   MHS_CDE { get; set; }
        public string   CNT_NUM { get; set; }
        public string   SYS_CHK { get; set; }
        public string   PIP_CDE { get; set; }
        public string   PIP_IDN { get; set; }
        public string   BSM_CDE { get; set; }
        public string   BSM_IDN { get; set; }
        public string   WID_CDE { get; set; }
        public DateTime UPD_DTM { get; set; }
    }

    /// <summary>
    /// 밸브
    /// </summary>
    public class WTL_VALV_PS : IWTL_Layer
    {
        public string KorName()
        {
            return "밸브";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "WTL_VALV_PS" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD   
                "지물부호",      // FTR_CDE 
                "관리번호",      // FTR_IDN 
                "행정구역",      // HJD_CDE 
                "관리기관",      // MNG_CDE 
                "설치일자",      // IST_YMD 
                "밸브형식",      // VAL_MOF 
                "밸브재질",      // VAL_MOP 
                "구경",          // VAL_DIP 
                "회전방향",      // SAE_CDE 
                "총회전수",      // TRO_CNT 
                "현회전수",      // CRO_CNT 
                "구동방법",      // MTH_CDE 
                "보호시설",      // VAP_FOR 
                "보호통규격",    // VAL_STD 
                "설정압력",      // VAL_SAF 
                "제작회사명",    // PRD_NAM 
                "이상상태",      // CST_CDE 
                "개폐여부",      // OFF_CDE 
                "전기방식",      // EPI_CDE 
                "방향각",        // ANG_DIR 
                "공사번호",      // CNT_NUM 
                "대장초기화",    // SYS_CHK 
                "상수관부호",    // PIP_CDE 
                "상수관번호",    // PIP_IDN 
                "밸브실부호",    // VAB_CDE 
                "밸브실번호",    // VAB_IDN 
                "블록부호",      // BSM_CDE 
                "블록번호",      // BSM_IDN 
                "광역구분",      // WID_CDE 
                "변경일시",      // UPD_DTM 
            }).AsEnumerable();

        }

        public string   SGCCD   { get; set; }
        public string   FTR_CDE { get; set; }
        public string   FTR_IDN { get; set; }
        public string   HJD_CDE { get; set; }
        public string   MNG_CDE { get; set; }
        public string   IST_YMD { get; set; }
        public string   VAL_MOF { get; set; }
        public string   VAL_MOP { get; set; }
        public double   VAL_DIP { get; set; }
        public string   SAE_CDE { get; set; }
        public double   TRO_CNT { get; set; }
        public double   CRO_CNT { get; set; }
        public string   MTH_CDE { get; set; }
        public string   VAP_FOR { get; set; }
        public string   VAL_STD { get; set; }
        public double   VAL_SAF { get; set; }
        public string   PRD_NAM { get; set; }
        public string   CST_CDE { get; set; }
        public string   OFF_CDE { get; set; }
        public string   EPI_CDE { get; set; }
        public double   ANG_DIR { get; set; }
        public string   CNT_NUM { get; set; }
        public string   SYS_CHK { get; set; }
        public string   PIP_CDE { get; set; }
        public string   PIP_IDN { get; set; }
        public string   VAB_CDE { get; set; }
        public string   VAB_IDN { get; set; }
        public string   BSM_CDE { get; set; }
        public string   BSM_IDN { get; set; }
        public string   WID_CDE { get; set; }
        public DateTime UPD_DTM { get; set; }
    }

    /// <summary>
    /// 등고선
    /// </summary>
    public class WTL_CNTR_LS : IWTL_Layer
    {
        public string KorName()
        {
            return "등고선";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "CONTOUR", "등고선" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD     
                "지물부호",      // FTR_CDE   
                "등고선유형",    // CAA_CDE   
                "고도",          // ELEVATION 
            }).AsEnumerable();
        }

        public string SGCCD     { get; set; }
        public string FTR_CDE   { get; set; }
        public string CAA_CDE   { get; set; }
        public double ELEVATION { get; set; }
    }

    /// <summary>
    /// 표고점
    /// </summary>
    public class WTL_ELEV_PS : IWTL_Layer
    {
        public string KorName()
        {
            return "표고점";
        }
        public IEnumerable<string> EngName()
        {
            return (new List<string> { "ELEV", "표고점" }).AsEnumerable();
        }

        public IEnumerable<string> ColumnsDesc()
        {
            return (new List<string>
            {
                "지자체코드",    // SGCCD     
                "지물부호",      // FTR_CDE   
                "고도",          // ELEVATION 
            }).AsEnumerable();

        }

        public string SGCCD     { get; set; }
        public string FTR_CDE   { get; set; }
        public double ELEVATION { get; set; }
    }
}
