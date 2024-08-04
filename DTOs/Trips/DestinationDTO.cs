using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.Models;

namespace dotnet_webapi.DTOs.Trips
{
    public class DestinationDTO
    {
        public int Idx { get; set; }
        public string Zone { get; set; } = null!;

    }
}
