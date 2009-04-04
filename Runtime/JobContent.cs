using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg.Runtime
{
    /// <summary>
    /// Job情報を保持するコンテントクラス
    /// </summary>
    public class JobContent
    {
        public string Name;
        public string CommandName;
        public int MaxHp;
        public int MaxMp;
        public int Exp;
        public bool HasSexTexture;
    }

}
