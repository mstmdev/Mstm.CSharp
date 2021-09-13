using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.Weibo
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class WeiboUserInfo
    {

        /// <summary>
        /// 用户UID
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// 字符串型的用户UID
        /// </summary>
        [JsonProperty("idstr")]
        public long Idstr { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        /// <summary>
        /// 友好显示名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }


        /// <summary>
        /// 用户所在省级ID
        /// </summary>
        [JsonProperty("province")]
        public int Province { get; set; }


        /// <summary>
        /// 用户所在城市ID
        /// </summary>
        [JsonProperty("city")]
        public int City { get; set; }


        /// <summary>
        /// 用户所在地
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }


        /// <summary>
        /// 用户个人描述
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }


        /// <summary>
        /// 用户博客地址
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }


        /// <summary>
        /// 用户头像地址（中图），50×50像素
        /// </summary>
        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }


        /// <summary>
        /// 用户的微博统一URL地址
        /// </summary>
        [JsonProperty("profile_url")]
        public string ProfileUrl { get; set; }

        /// <summary>
        /// 用户的个性化域名
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; }


        /// <summary>
        /// 用户的微号
        /// </summary>
        [JsonProperty("weihao")]
        public string Weihao { get; set; }


        /// <summary>
        /// 性别，m：男、f：女、n：未知
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// 粉丝数
        /// </summary>
        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        /// <summary>
        /// 关注数
        /// </summary>
        [JsonProperty("friends_count")]
        public int FriendsCount { get; set; }

        /// <summary>
        /// 微博数
        /// </summary>
        [JsonProperty("statuses_count")]
        public int StatusesCount { get; set; }

        /// <summary>
        /// 收藏数
        /// </summary>
        [JsonProperty("favourites_count")]
        public int FavouritesCount { get; set; }

        /// <summary>
        /// 用户创建（注册）时间
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 暂未支持
        /// </summary>
        [JsonProperty("following")]
        public bool Following { get; set; }

        /// <summary>
        /// 是否允许所有人给我发私信，true：是，false：否
        /// </summary>
        [JsonProperty("allow_all_act_msg")]
        public bool AllowAllActMsg { get; set; }

        /// <summary>
        /// 是否允许标识用户的地理位置，true：是，false：否
        /// </summary>
        [JsonProperty("geo_enabled")]
        public bool GeoEnabled { get; set; }

        /// <summary>
        /// 是否是微博认证用户，即加V用户，true：是，false：否
        /// </summary>
        [JsonProperty("verified")]
        public bool Verified { get; set; }

        /// <summary>
        /// 暂未支持
        /// </summary>
        [JsonProperty("verified_type")]
        public int VerifiedType { get; set; }

        /// <summary>
        /// 用户备注信息，只有在查询用户关系时才返回此字段
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 用户的最近一条微博信息字段
        /// </summary>
        [JsonProperty("status")]
        public WeiboStatus Status { get; set; }

        /// <summary>
        /// 是否允许所有人对我的微博进行评论，true：是，false：否
        /// </summary>
        [JsonProperty("allow_all_comment")]
        public bool AllowAllComment { get; set; }

        /// <summary>
        /// 用户头像地址（大图），180×180像素
        /// </summary>
        [JsonProperty("avatar_large")]
        public string AvatarLarge { get; set; }


        /// <summary>
        ///用户头像地址（高清），高清头像原图
        /// </summary>
        [JsonProperty("avatar_hd")]
        public string AvatarHd { get; set; }

        /// <summary>
        /// 认证原因
        /// </summary>
        [JsonProperty("verified_reason")]
        public string VerifiedReason { get; set; }

        /// <summary>
        /// 该用户是否关注当前登录用户，true：是，false：否
        /// </summary>
        [JsonProperty("follow_me")]
        public bool FollowMe { get; set; }

        /// <summary>
        /// 用户的在线状态，0：不在线、1：在线
        /// </summary>
        [JsonProperty("online_status")]
        public int OnlineStatus { get; set; }

        /// <summary>
        /// 用户的互粉数
        /// </summary>
        [JsonProperty("bi_followers_count")]
        public int BiFollowersCount { get; set; }

        /// <summary>
        /// 用户当前的语言版本，zh-cn：简体中文，zh-tw：繁体中文，en：英语
        /// </summary>
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    /// <summary>
    /// 微博信息
    /// </summary>
    public class WeiboStatus
    {
        /// <summary>
        /// 微博创建时间
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 微博ID
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// 微博MID
        /// </summary>
        [JsonProperty("mid")]
        public long Mid { get; set; }

        /// <summary>
        /// 字符串型的微博ID
        /// </summary>
        [JsonProperty("idstr")]
        public string Idstr { get; set; }

        /// <summary>
        /// 微博信息内容
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }


        /// <summary>
        /// 微博来源
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }


        /// <summary>
        /// 是否已收藏，true：是，false：否
        /// </summary>
        [JsonProperty("favorited")]
        public bool Favorited { get; set; }

        /// <summary>
        /// 是否被截断，true：是，false：否
        /// </summary>
        [JsonProperty("truncated")]
        public bool Truncated { get; set; }


        /// <summary>
        /// （暂未支持）回复ID
        /// </summary>
        [JsonProperty("in_reply_to_status_id")]
        public string InReplyToStatusId { get; set; }


        /// <summary>
        /// （暂未支持）回复人UID
        /// </summary>
        [JsonProperty("in_reply_to_user_id")]
        public string InReplyToUserId { get; set; }


        /// <summary>
        /// （暂未支持）回复人昵称
        /// </summary>
        [JsonProperty("in_reply_to_screen_name")]
        public string InReplyToScreenName { get; set; }


        /// <summary>
        /// 缩略图片地址，没有时不返回此字段
        /// </summary>
        [JsonProperty("thumbnail_pic")]
        public string ThumbnailPic { get; set; }


        /// <summary>
        /// 中等尺寸图片地址，没有时不返回此字段
        /// </summary>
        [JsonProperty("bmiddle_pic")]
        public string BmiddlePic { get; set; }


        /// <summary>
        /// 原始图片地址，没有时不返回此字段
        /// </summary>
        [JsonProperty("original_pic")]
        public string OriginalPic { get; set; }

        /// <summary>
        /// 地理信息字段
        /// </summary>
        [JsonProperty("geo")]
        public Geo Geo { get; set; }

        /// </summary>
        [JsonProperty("annotations")]
        public string Annotations { get; set; }

        /// <summary>
        /// 转发数
        /// </summary>
        [JsonProperty("reposts_count")]
        public int RepostsCount { get; set; }

        /// <summary>
        /// 评论数
        /// </summary>
        [JsonProperty("comments_count")]
        public int CommentsCount { get; set; }

        /// <summary>
        /// 表态数
        /// </summary>
        [JsonProperty("attitudes_count")]
        public int AttitudesCount { get; set; }


        /// <summary>
        /// 暂未支持
        /// </summary>
        [JsonProperty("mlevel")]
        public int Mlevel { get; set; }


        /// <summary>
        /// 微博的可见性及指定可见分组信息。该object中type取值，0：普通微博，1：私密微博，3：指定分组微博，4：密友微博；list_id为分组的组号
        /// </summary>
        [JsonProperty("visible")]
        public object Visible { get; set; }

        /// <summary>
        /// 微博配图ID。多图时返回多图ID，用来拼接图片url。用返回字段thumbnail_pic的地址配上该返回字段的图片ID，即可得到多个图片url。
        /// </summary>
        [JsonProperty("pic_ids")]
        public object PicIds { get; set; }

        /// <summary>
        /// 微博流内的推广微博ID
        /// </summary>
        [JsonProperty("ad")]
        public object[] Ad { get; set; }


    }

    /// <summary>
    /// 地理位置信息
    /// </summary>
    public class Geo
    {
        /// <summary>
        /// 经度坐标
        /// </summary>
        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// 维度坐标
        /// </summary>
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// 所在城市的城市代码
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 所在省份的省份代码
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }


        /// <summary>
        /// 所在城市的城市名称
        /// </summary>
        [JsonProperty("city_name")]
        public string CityName { get; set; }


        /// <summary>
        /// 所在省份的省份名称
        /// </summary>
        [JsonProperty("province_name")]
        public string ProvinceName { get; set; }


        /// <summary>
        /// 所在的实际地址，可以为空
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }


        /// <summary>
        /// 地址的汉语拼音，不是所有情况都会返回该字段
        /// </summary>
        [JsonProperty("pinyin")]
        public string Pinyin { get; set; }

        /// <summary>
        /// 更多信息，不是所有情况都会返回该字段
        /// </summary>
        [JsonProperty("more")]
        public string More { get; set; }
    }
}
