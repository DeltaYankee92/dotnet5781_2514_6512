using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet5781_00_2514_6512
{
    class Main_new1
    {
        LineCollecton Lines;
        static Random rand = new Random();
        static List<LineStation> Stops1 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 945156, Latitude = 33.4563, Longitude = 120.3454, adress = "עוזיאל 131, ירושלים" },
            new LineStation{BusStationKey = 999404, Latitude = 33.3563, Longitude = 121.3344, adress = "עוזיאל 42, ירושלים" },
            new LineStation{BusStationKey = 962404, Latitude = 33.3512, Longitude = 121.3352, adress = "עוזיאל 31, ירושלים" },
            new LineStation{BusStationKey = 329404, Latitude = 33.3552, Longitude = 121.3341, adress = "עוזיאל 25, ירושלים" },
            new LineStation{BusStationKey = 962403, Latitude = 33.3565, Longitude = 121.3361, adress = "עוזיאל 17, ירושלים" },
            new LineStation{BusStationKey = 999472, Latitude = 33.3515, Longitude = 121.3371, adress = "אינו שאקי 6, ירושלים" },
        };
        static List<LineStation> Stops2 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 945233, Latitude = 33.3651, Longitude = 121.3367, adress = "בית וגן 13, ירושלים" },
            new LineStation{BusStationKey = 944326, Latitude = 33.1421, Longitude = 121.6421, adress = "בית וגן 14, ירושלים" },
            new LineStation{BusStationKey = 634443, Latitude = 33.5231, Longitude = 121.3634, adress = "בית וגן 15, ירושלים" },
            new LineStation{BusStationKey = 949443, Latitude = 33.7341, Longitude = 121.9561, adress = "בית וגן 16, ירושלים" },
            new LineStation{BusStationKey = 634613, Latitude = 33.7462, Longitude = 121.0524, adress = "בית וגן 17, ירושלים" },
            new LineStation{BusStationKey = 329404, Latitude = 33.3552, Longitude = 121.3341, adress = "עוזיאל 25, ירושלים" },
            new LineStation{BusStationKey = 999472, Latitude = 33.3515, Longitude = 121.3371, adress = "אינו שאקי 6, ירושלים" },
            new LineStation{BusStationKey = 962404, Latitude = 33.3512, Longitude = 121.3352, adress = "עוזיאל 31, ירושלים" },
        };
        static List<LineStation> Stops3 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 949823, Latitude = 33.8342, Longitude = 121.0452, adress = "התירוש 1, אפרת" },
            new LineStation{BusStationKey = 949945, Latitude = 33.0951, Longitude = 121.0361, adress = "התירוש 2, אפרת" },
            new LineStation{BusStationKey = 867323, Latitude = 33.7455, Longitude = 121.6111, adress = "התירוש 3, אפרת" },
            new LineStation{BusStationKey = 972364, Latitude = 33.3098, Longitude = 121.0912, adress = "התירוש 4, אפרת" },
            new LineStation{BusStationKey = 940913, Latitude = 33.3652, Longitude = 121.9152, adress = "התירוש 5, אפרת" },
            new LineStation{BusStationKey = 835125, Latitude = 33.0912, Longitude = 121.8761, adress = "התירוש 6, אפרת" },
            new LineStation{BusStationKey = 091235, Latitude = 33.8713, Longitude = 121.8721, adress = "התירוש 7, אפרת" },
            new LineStation{BusStationKey = 976443, Latitude = 33.6121, Longitude = 121.9571, adress = "התירוש 8, אפרת" },
        };
        static List<LineStation> Stops4 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 948453, Latitude = 33.7364, Longitude = 121.0465, adress = "יצחק מן 23, ירושלים" },
            new LineStation{BusStationKey = 683443, Latitude = 33.8345, Longitude = 121.0465, adress = "יצחק מן 24, ירושלים" },
            new LineStation{BusStationKey = 906743, Latitude = 33.3583, Longitude = 121.0342, adress = "יצחק מן 25, ירושלים" },
        };
        static List<LineStation> Stops5 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 949653, Latitude = 33.6531, Longitude = 121.6541, adress = "זרובבל 10, אלעזר" },
            new LineStation{BusStationKey = 946521, Latitude = 33.5421, Longitude = 121.7641, adress = "זרובבל 11, אלעזר" },
            new LineStation{BusStationKey = 946531, Latitude = 33.6512, Longitude = 121.6512, adress = "זרובבל 12, אלעזר" },
            new LineStation{BusStationKey = 949651, Latitude = 33.5411, Longitude = 121.6531, adress = "זרובבל 13, אלעזר" },
            new LineStation{BusStationKey = 949823, Latitude = 33.8342, Longitude = 121.0452, adress = "התירוש 1, אפרת" },
        };
        static List<LineStation> Stops6 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 162542, Latitude = 33.3856, Longitude = 121.7421, adress = "הפסגה 18, ירושלים" },
            new LineStation{BusStationKey = 946351, Latitude = 33.7462, Longitude = 121.7415, adress = "הפסגה 19, ירושלים" },
            new LineStation{BusStationKey = 949522, Latitude = 33.3612, Longitude = 121.6161, adress = "הפסגה 20, ירושלים" },
            new LineStation{BusStationKey = 952343, Latitude = 33.4251, Longitude = 121.6761, adress = "הפסגה 21, ירושלים" },
            new LineStation{BusStationKey = 745443, Latitude = 33.3723, Longitude = 121.7451, adress = "הפסגה 22, ירושלים" },
            new LineStation{BusStationKey = 962404, Latitude = 33.3512, Longitude = 121.3352, adress = "עוזיאל 31, ירושלים" },
            new LineStation{BusStationKey = 999472, Latitude = 33.3515, Longitude = 121.3371, adress = "אינו שאקי 6, ירושלים" },
        };
        static List<LineStation> Stops7 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 995123, Latitude = 33.3551, Longitude = 121.3374, adress = "רינה ניקובה 11, ירושלים" },
            new LineStation{BusStationKey = 949443, Latitude = 33.3551, Longitude = 121.3361, adress = "רינה ניקובה 12, ירושלים" },
            new LineStation{BusStationKey = 999472, Latitude = 33.3515, Longitude = 121.3371, adress = "אינו שאקי 6, ירושלים" },
        };
        static List<LineStation> Stops8 = new List<LineStation>()
        {
            new LineStation{BusStationKey = 949745, Latitude = 33.3651, Longitude = 121.3371, adress = "מעלה משואות יצחק 1, אפרת" },
            new LineStation{BusStationKey = 947613, Latitude = 33.6231, Longitude = 121.8231, adress = "מעלה משואות יצחק 2, אפרת" },
            new LineStation{BusStationKey = 652443, Latitude = 33.6551, Longitude = 121.9861, adress = "מעלה משואות יצחק 3, אפרת" },
            new LineStation{BusStationKey = 949542, Latitude = 33.7321, Longitude = 121.3661, adress = "מעלה משואות יצחק 4, אפרת" },
            new LineStation{BusStationKey = 652645, Latitude = 33.7621, Longitude = 121.7661, adress = "מעלה משואות יצחק 5, אפרת" },
            new LineStation{BusStationKey = 947643, Latitude = 33.6551, Longitude = 121.3641, adress = "מעלה משואות יצחק 6, אפרת" },
            new LineStation{BusStationKey = 949653, Latitude = 33.6531, Longitude = 121.7651, adress = "מעלה משואות יצחק 7, אפרת" },
            new LineStation{BusStationKey = 835125, Latitude = 33.0912, Longitude = 121.8761, adress = "התירוש 6, אפרת" },
            new LineStation{BusStationKey = 091235, Latitude = 33.8713, Longitude = 121.8721, adress = "התירוש 7, אפרת" },
            new LineStation{BusStationKey = 949823, Latitude = 33.8342, Longitude = 121.0452, adress = "התירוש 1, אפרת" },
        };
        BusLine b1 = new BusLine(Stops1, Stops1.First(), Stops1.Last(), 1, "עוזיאל" );
        BusLine b2 = new BusLine(Stops2, Stops2.First(), Stops2.Last(), 2, "בית וגן");
        BusLine b3 = new BusLine(Stops3, Stops3.First(), Stops3.Last(), 3, "אפרת");
        BusLine b4 = new BusLine(Stops4, Stops1.First(), Stops4.Last(), 4, "גבעת מרדכי");
        BusLine b5 = new BusLine(Stops5, Stops5.First(), Stops5.Last(), 5, "אפרת");
        BusLine b6 = new BusLine(Stops6, Stops6.First(), Stops6.Last(), 6, "בית וגן");
        BusLine b7 = new BusLine(Stops7, Stops7.First(), Stops7.Last(), 7, "פסגת זאב");
        BusLine b8 = new BusLine(Stops8, Stops8.First(), Stops8.Last(), 8, "אפרת");






    }




}
