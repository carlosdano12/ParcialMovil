using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;
using SQLite.Net.Interop;

namespace registroNotas
{
    public interface Iconfig
    {
        string DirectorioDB { get; }

        ISQLitePlatform Plataforma { get; }
    }
}
