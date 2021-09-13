using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.QQ
{
    /// <summary>
    /// QQAPI列表
    /// </summary>
    class QQAPIList
    {

        /// <summary>
        /// 获取登录用户的昵称、头像、性别
        /// http://wiki.connect.qq.com/get_user_info
        /// </summary>
        public const string GetUserInfoApi = "get_user_info";


        /// <summary>
        /// 获取QQ会员的基本信息
        /// http://wiki.connect.qq.com/get_vip_info
        /// </summary>
        public const string GetVipInfoApi = "get_vip_info";


        /// <summary>
        /// 获取QQ会员的高级信息
        /// http://wiki.connect.qq.com/get_vip_rich_info
        /// </summary>
        public const string GetVipRichInfoApi = "get_vip_rich_info";

        /// <summary>
        /// 获取用户QQ空间相册列表
        /// http://wiki.connect.qq.com/list_album
        /// </summary>
        public const string ListAlbumApi = "list_album";


        /// <summary>
        /// 上传一张照片到QQ空间相册
        /// http://wiki.connect.qq.com/upload_pic
        /// </summary>
        public const string UploadPicApi = "upload_pic";


        /// <summary>
        /// 在用户的空间相册里，创建一个新的个人相册
        /// http://wiki.connect.qq.com/add_album
        /// </summary>
        public const string AddAlbumApi = "add_album";


        /// <summary>
        /// 获取用户QQ空间相册中的照片列表
        /// http://wiki.connect.qq.com/list_photo
        /// </summary>
        public const string ListPhotoApi = "list_photo";

        /// <summary>
        /// 获取登录用户在腾讯微博详细资料
        /// http://wiki.connect.qq.com/get_info
        /// </summary>
        public const string GetInfoApi = "get_info";


        /// <summary>
        /// 发表一条微博
        /// http://wiki.connect.qq.com/add_t
        /// </summary>
        public const string AddTApi = "add_t";


        /// <summary>
        /// 删除一条微博
        /// http://wiki.connect.qq.com/del_t
        /// </summary>
        public const string DelTApi = "del_t";

        /// <summary>
        /// 发表一条带图片的微博
        /// http://wiki.connect.qq.com/add_pic_t
        /// </summary>
        public const string AddPicTApi = "add_pic_t";


        /// <summary>
        /// 获取单条微博的转发或点评列表
        /// http://wiki.connect.qq.com/get_repost_list
        /// </summary>
        public const string GetRepostListApi = "get_repost_list";


        /// <summary>
        /// 获取他人微博资料
        /// http://wiki.connect.qq.com/get_other_info
        /// </summary>
        public const string GetOtherInfoApi = "get_other_info";


        /// <summary>
        /// 我的微博粉丝列表
        /// http://wiki.connect.qq.com/get_fanslist
        /// </summary>
        public const string GetFanslistApi = "get_fanslist";


        /// <summary>
        /// 我的微博偶像列表
        /// http://wiki.connect.qq.com/get_idollist
        /// </summary>
        public const string GetIdollistApi = "get_idollist";


        /// <summary>
        /// 收听某个微博用户
        /// http://wiki.connect.qq.com/add_idol
        /// </summary>
        public const string AddIdolApi = "add_idol";


        /// <summary>
        /// 取消收听某个微博用户
        /// http://wiki.connect.qq.com/del_idol
        /// </summary>
        public const string DelIdolApi = "del_idol";


        /// <summary>
        /// 在这个网站上将展现您财付通登记的收货地址
        /// http://wiki.connect.qq.com/get_tenpay_addr
        /// </summary>
        public const string GetTenpayAddrApi = "get_tenpay_addr";

    }
}
