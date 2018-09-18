using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace manage_kiosk
{
    public class messageList
    {
        public static string getMessage(int integer)
        {
            string str;
            if (integer == int.MinValue)
                str = "오프라인";
            else if ((uint)(integer & 65536) > 0U)
            {
                switch (integer)
                {
                    case 65537:
                        str = "대기중";
                        break;
                    case 65538:
                        str = "인쇄중";
                        break;
                    case 65544:
                        str = "용지 끝";
                        break;
                    case 65552:
                        str = "리본 끝";
                        break;
                    case 65568:
                        str = "헤드 냉각 중";
                        break;
                    case 65600:
                        str = "모터 냉각 중";
                        break;
                    default:
                        str = "---";
                        break;
                }
            }
            else if ((uint)(integer & 131072) > 0U)
            {
                switch (integer)
                {
                    case 131073:
                        str = "도어 열림";
                        break;
                    case 131074:
                        str = "용지 걸림";
                        break;
                    case 131076:
                        str = "리본 오류";
                        break;
                    case 131080:
                        str = "용지 크기 설정 오류";
                        break;
                    case 131088:
                        str = "데이터 에러";
                        break;
                    case 131104:
                        str = "휴지통 에러";
                        break;
                    default:
                        str = "---";
                        break;
                }
            }
            else if ((uint)(integer & 262144) > 0U)
            {
                switch (integer)
                {
                    case 262145:
                        str = "헤드 전압 이상";
                        break;
                    case 262146:
                        str = "헤드 위치 이상";
                        break;
                    case 262148:
                        str = "팬 정지 이상";
                        break;
                    case 262152:
                        str = "커터 이상";
                        break;
                    case 262160:
                        str = "Pinch Roller Position Error";
                        break;
                    case 262176:
                        str = "헤드 온도 이상";
                        break;
                    case 262208:
                        str = "미디어 온도 이상";
                        break;
                    case 262272:
                        str = "리본 텐션 이상";
                        break;
                    case 262400:
                        str = "RF-ID 모듈 이상";
                        break;
                    case 262656:
                        str = "모터 온도 이상";
                        break;
                    default:
                        str = "---";
                        break;
                }
            }
            else
                str = (uint)(integer & 524288) <= 0U ? ((uint)(integer & 1048576) <= 0U ? "---" : "펌웨어 업데이트 모드") : "시스템 오류";

            return str;
        }
    }
}