﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Adnc.Application.Dtos
{
    /// <summary>
    /// 用户检索条件
    /// </summary>
    public class UserSearchDto : BaseSearchDto
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name
        { 
            get;
            set;
        }

        /// <summary>
        /// 用户账户
        /// </summary>
        public string Account
        {
            get;
            set;
        }
    }
}
