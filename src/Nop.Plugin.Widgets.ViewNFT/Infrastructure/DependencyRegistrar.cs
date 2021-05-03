﻿using AceNFT.Services;
using AceNFT.Services.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Plugin.Misc.TransferNFT.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.ViewNFT.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="appSettings">App settings</param>
        public void Register(IServiceCollection services, ITypeFinder typeFinder, AppSettings appSettings)
        {
            services.AddHttpContextAccessor();
            string contractAbi = "[\r\n  {\r\n    \"inputs\": [],\r\n    \"stateMutability\": \"nonpayable\",\r\n    \"type\": \"constructor\"\r\n  },\r\n  {\r\n    \"anonymous\": false,\r\n    \"inputs\": [\r\n      {\r\n        \"indexed\": true,\r\n        \"internalType\": \"address\",\r\n        \"name\": \"owner\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"indexed\": true,\r\n        \"internalType\": \"address\",\r\n        \"name\": \"approved\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"indexed\": true,\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"tokenId\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"name\": \"Approval\",\r\n    \"type\": \"event\"\r\n  },\r\n  {\r\n    \"anonymous\": false,\r\n    \"inputs\": [\r\n      {\r\n        \"indexed\": true,\r\n        \"internalType\": \"address\",\r\n        \"name\": \"owner\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"indexed\": true,\r\n        \"internalType\": \"address\",\r\n        \"name\": \"operator\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"indexed\": false,\r\n        \"internalType\": \"bool\",\r\n        \"name\": \"approved\",\r\n        \"type\": \"bool\"\r\n      }\r\n    ],\r\n    \"name\": \"ApprovalForAll\",\r\n    \"type\": \"event\"\r\n  },\r\n  {\r\n    \"anonymous\": false,\r\n    \"inputs\": [\r\n      {\r\n        \"indexed\": true,\r\n        \"internalType\": \"address\",\r\n        \"name\": \"from\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"indexed\": true,\r\n        \"internalType\": \"address\",\r\n        \"name\": \"to\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"indexed\": true,\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"tokenId\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"name\": \"Transfer\",\r\n    \"type\": \"event\"\r\n  },\r\n  {\r\n    \"stateMutability\": \"payable\",\r\n    \"type\": \"fallback\",\r\n    \"payable\": true\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"to\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"tokenId\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"name\": \"approve\",\r\n    \"outputs\": [],\r\n    \"stateMutability\": \"nonpayable\",\r\n    \"type\": \"function\"\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"owner\",\r\n        \"type\": \"address\"\r\n      }\r\n    ],\r\n    \"name\": \"balanceOf\",\r\n    \"outputs\": [\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"stateMutability\": \"view\",\r\n    \"type\": \"function\",\r\n    \"constant\": true\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"tokenId\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"name\": \"getApproved\",\r\n    \"outputs\": [\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"\",\r\n        \"type\": \"address\"\r\n      }\r\n    ],\r\n    \"stateMutability\": \"view\",\r\n    \"type\": \"function\",\r\n    \"constant\": true\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"owner\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"operator\",\r\n        \"type\": \"address\"\r\n      }\r\n    ],\r\n    \"name\": \"isApprovedForAll\",\r\n    \"outputs\": [\r\n      {\r\n        \"internalType\": \"bool\",\r\n        \"name\": \"\",\r\n        \"type\": \"bool\"\r\n      }\r\n    ],\r\n    \"stateMutability\": \"view\",\r\n    \"type\": \"function\",\r\n    \"constant\": true\r\n  },\r\n  {\r\n    \"inputs\": [],\r\n    \"name\": \"name\",\r\n    \"outputs\": [\r\n      {\r\n        \"internalType\": \"string\",\r\n        \"name\": \"\",\r\n        \"type\": \"string\"\r\n      }\r\n    ],\r\n    \"stateMutability\": \"view\",\r\n    \"type\": \"function\",\r\n    \"constant\": true\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"tokenId\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"name\": \"ownerOf\",\r\n    \"outputs\": [\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"\",\r\n        \"type\": \"address\"\r\n      }\r\n    ],\r\n    \"stateMutability\": \"view\",\r\n    \"type\": \"function\",\r\n    \"constant\": true\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"from\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"to\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"tokenId\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"name\": \"safeTransferFrom\",\r\n    \"outputs\": [],\r\n    \"stateMutability\": \"nonpayable\",\r\n    \"type\": \"function\"\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"from\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"to\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"tokenId\",\r\n        \"type\": \"uint256\"\r\n      },\r\n      {\r\n        \"internalType\": \"bytes\",\r\n        \"name\": \"_data\",\r\n        \"type\": \"bytes\"\r\n      }\r\n    ],\r\n    \"name\": \"safeTransferFrom\",\r\n    \"outputs\": [],\r\n    \"stateMutability\": \"nonpayable\",\r\n    \"type\": \"function\"\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"operator\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"internalType\": \"bool\",\r\n        \"name\": \"approved\",\r\n        \"type\": \"bool\"\r\n      }\r\n    ],\r\n    \"name\": \"setApprovalForAll\",\r\n    \"outputs\": [],\r\n    \"stateMutability\": \"nonpayable\",\r\n    \"type\": \"function\"\r\n  },\r\n  {\r\n    \"inputs\": [],\r\n    \"name\": \"symbol\",\r\n    \"outputs\": [\r\n      {\r\n        \"internalType\": \"string\",\r\n        \"name\": \"\",\r\n        \"type\": \"string\"\r\n      }\r\n    ],\r\n    \"stateMutability\": \"view\",\r\n    \"type\": \"function\",\r\n    \"constant\": true\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"index\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"name\": \"tokenByIndex\",\r\n    \"outputs\": [\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"stateMutability\": \"view\",\r\n    \"type\": \"function\",\r\n    \"constant\": true\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"owner\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"index\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"name\": \"tokenOfOwnerByIndex\",\r\n    \"outputs\": [\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"stateMutability\": \"view\",\r\n    \"type\": \"function\",\r\n    \"constant\": true\r\n  },\r\n  {\r\n    \"inputs\": [],\r\n    \"name\": \"totalSupply\",\r\n    \"outputs\": [\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"stateMutability\": \"view\",\r\n    \"type\": \"function\",\r\n    \"constant\": true\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"from\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"to\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"tokenId\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"name\": \"transferFrom\",\r\n    \"outputs\": [],\r\n    \"stateMutability\": \"nonpayable\",\r\n    \"type\": \"function\"\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"address\",\r\n        \"name\": \"_to\",\r\n        \"type\": \"address\"\r\n      },\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"_id\",\r\n        \"type\": \"uint256\"\r\n      },\r\n      {\r\n        \"internalType\": \"string\",\r\n        \"name\": \"_url\",\r\n        \"type\": \"string\"\r\n      }\r\n    ],\r\n    \"name\": \"giveToken\",\r\n    \"outputs\": [\r\n      {\r\n        \"internalType\": \"string\",\r\n        \"name\": \"\",\r\n        \"type\": \"string\"\r\n      }\r\n    ],\r\n    \"stateMutability\": \"nonpayable\",\r\n    \"type\": \"function\"\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"uint256\",\r\n        \"name\": \"tokenId\",\r\n        \"type\": \"uint256\"\r\n      }\r\n    ],\r\n    \"name\": \"tokenURI\",\r\n    \"outputs\": [\r\n      {\r\n        \"internalType\": \"string\",\r\n        \"name\": \"tokenUri\",\r\n        \"type\": \"string\"\r\n      }\r\n    ],\r\n    \"stateMutability\": \"view\",\r\n    \"type\": \"function\",\r\n    \"constant\": true\r\n  },\r\n  {\r\n    \"inputs\": [\r\n      {\r\n        \"internalType\": \"bytes4\",\r\n        \"name\": \"interfaceId\",\r\n        \"type\": \"bytes4\"\r\n      }\r\n    ],\r\n    \"name\": \"supportsInterface\",\r\n    \"outputs\": [\r\n      {\r\n        \"internalType\": \"bool\",\r\n        \"name\": \"\",\r\n        \"type\": \"bool\"\r\n      }\r\n    ],\r\n    \"stateMutability\": \"view\",\r\n    \"type\": \"function\",\r\n    \"constant\": true\r\n  }\r\n]";
            string contractAddress = "0xbA40671e899D00c13f51Cbb25bCA3bB80cA6056A";
            string ownerAddress = "0x705046B9a610e06AD59c8ADB0017EE7B56Eb95C2";
            string url = "HTTP://127.0.0.1:7545";
            services.AddScoped<INFTContract>(x => new AceNFTContractService(contractAbi, url, contractAddress, ownerAddress));
            services.AddScoped<IPFSHelper>();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 2;
    }
}