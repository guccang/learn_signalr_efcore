using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_signalR_efcore.Datas
{

    // 测试controller传参数为json格式的数据
    /*
     {
	"key":"20",
	"value":"v300",
	"a_list":
	[
		{"a_int":"1","a_str":"str"},
		{"a_int":"2","a_Str":"str2"}
	]
      }
   */
    public class a
    {
        public int a_int { get; set; }
        public string a_str { get; set; }
    }

    [Serializable]
    public class JsonData
    {
        public int key { get; set; }
        public string value { get; set; }

        public List<a> a_list { get; set; }
    }

}
