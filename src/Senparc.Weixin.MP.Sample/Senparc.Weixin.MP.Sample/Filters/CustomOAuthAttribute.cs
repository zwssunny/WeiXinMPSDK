﻿using Senparc.Weixin.MP.MvcExtension;
using Senparc.Weixin.MP.TenPayLibV3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Senparc.Weixin.MP.Sample.Filters
{
    /// <summary>
    /// OAuth自动验证，可以加在Action或整个Controller上
    /// </summary>
    public class CustomOAuthAttribute : SenparcOAuthAttribute
    {
        public CustomOAuthAttribute(string appId, string oauthCallbackUrl)
            : base(appId, oauthCallbackUrl)
        {
            base._appId = base._appId ?? System.Configuration.ConfigurationManager.AppSettings["TenPayV3_AppId"];
        }

        public override bool IsLogined(HttpContextBase httpContext)
        {
            //也可以使用其他方法如Session验证用户登录
            return httpContext != null && httpContext.User.Identity.IsAuthenticated;
        }
    }
}