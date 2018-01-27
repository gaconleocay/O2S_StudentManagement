﻿using System;
using System.Collections.Generic;
using System.Web;

namespace O2S_StudentManagement.Common.WebApiClient
{
    /// <summary>
    /// Tham so truyen vao API
    /// </summary>
    public class ApiParam
    {
        /// <summary>
        /// ParamCommon
        /// </summary>
        public object CommonParam { get; set; }
        /// <summary>
        /// Du lieu kem theo
        /// </summary>
        public object ApiData { get; set; }
    }
}