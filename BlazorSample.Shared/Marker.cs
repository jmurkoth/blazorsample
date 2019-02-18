using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorSample.Shared
{
    public class Marker
    {
        public string Description { get; internal set; }
        public double X { get; internal set; }
        public double Y { get; internal set; }
        public bool ShowPopup { get; internal set; }
    }
}
