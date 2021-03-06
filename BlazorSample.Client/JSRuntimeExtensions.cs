﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSample.Client
{
    public static class JSRuntimeExtensions
    {
        public static Task<bool> Confirm(this IJSRuntime jsRuntime, string message)
        {
            return jsRuntime.InvokeAsync<bool>("confirm", message);
        }
    }
}
