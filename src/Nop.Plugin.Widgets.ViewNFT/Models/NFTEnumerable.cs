﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AceNFT.Services.Structs.AceNFTStructs;

namespace Nop.Plugin.Widget.ViewNFT.Models
{
    public class NFTEnumerable
    {
        public IEnumerable<TokenInfo> OwnedTokens { get; set; }
    }
}
