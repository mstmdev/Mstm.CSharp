using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.QQ
{
    /// <summary>
    /// QQ用户信息
    /// </summary>
    public class QQUserInfo : QQAPIResponseBase
    {

        [JsonProperty("is_lost")]
        public string IsLost { get; set; }


        /// <summary>
        /// 用户在QQ空间的昵称。
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }


        /// <summary>
        /// 性别。 如果获取不到则默认返回"男"
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 生日年份
        /// </summary>
        [JsonProperty("year")]
        public string Year { get; set; }

        /// <summary>
        /// 大小为30×30像素的QQ空间头像URL。
        /// </summary>
        [JsonProperty("figureurl")]
        public string FigureUrl { get; set; }

        /// <summary>
        /// 大小为50×50像素的QQ空间头像URL。
        /// </summary>
        [JsonProperty("figureurl_1")]
        public string FigureUrl_1 { get; set; }

        /// <summary>
        /// 大小为100×100像素的QQ空间头像URL。
        /// </summary>
        [JsonProperty("figureurl_2")]
        public string FigureUrl_2 { get; set; }

        /// <summary>
        /// 大小为40×40像素的QQ头像URL。
        /// </summary>
        [JsonProperty("figureurl_qq_1")]
        public string FigureUrlQQ_1 { get; set; }


        /// <summary>
        /// 大小为100×100像素的QQ头像URL。需要注意，不是所有的用户都拥有QQ的100x100的头像，但40x40像素则是一定会有。
        /// </summary>
        [JsonProperty("figureurl_qq_2")]
        public string FigureUrlQQ_2 { get; set; }


        /// <summary>
        /// 标识用户是否为黄钻用户（0：不是；1：是）。
        /// </summary>
        [JsonProperty("is_yellow_vip")]
        public string IsYellowVip { get; set; }

        /// <summary>
        /// 标识用户是否为黄钻用户（0：不是；1：是）
        /// </summary>
        [JsonProperty("vip")]
        public string Vip { get; set; }

        /// <summary>
        /// 黄钻等级
        /// </summary>
        [JsonProperty("yellow_vip_level")]
        public string YellowVipLevel { get; set; }

        /// <summary>
        /// 黄钻等级
        /// </summary>
        [JsonProperty("level")]
        public string Level { get; set; }

        /// <summary>
        /// 标识是否为年费黄钻用户（0：不是； 1：是）
        /// </summary>
        [JsonProperty("is_yellow_year_vip")]
        public string IsYelloYearVip { get; set; }

    }
}
