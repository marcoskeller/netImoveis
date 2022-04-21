using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netImoveis.Shared
{
    public class ApplicationConfig
    {
        public class ConnectionStrings
        {
            public string DefaultConnection { get; set; } = null!;
        }

        public ImoveisConfig ImoveisBase { get; set; } = null!;
        public object Logging { get; internal set; }

        public class ImoveisConfig
        {
            public string BaseUrl { get; set; } = null!;
        }

    }
}
