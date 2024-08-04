using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.DTOs.Trips;
using dotnet_webapi.Models;

namespace dotnet_webapi.Mappers
{
    public static class DestinationMapper
    {
        public static DestinationDTO ToDestinationDTO(this Destination destination){
            return new DestinationDTO{
                Idx=destination.Idx,
                Zone=destination.Zone
            };
        }
    }
}