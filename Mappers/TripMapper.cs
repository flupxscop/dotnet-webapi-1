using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.DTOs;
using dotnet_webapi.Models;

namespace dotnet_webapi.Mappers
{
    public static class TripMapper
    {
        //mapper model to dtos
        public static TripDTOs ToTripDTOs(this Trip trip)
        {
            return new TripDTOs
            {
                Idx = trip.Idx,
                Name = trip.Name,
                Country = trip.Country,
                Destinationid = trip.Destinationid,
                Coverimage = trip.Coverimage,
                Detail = trip.Detail,
                Price = trip.Price,
                Duration = trip.Duration,
                Destination = trip.Destination.ToDestinationDTO()
            };
        }
    }
}