using DotnetCore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.API
{
    public class NamesDataStore
    {
        public static NamesDataStore Current { get; } = new NamesDataStore();
        public List<NameDto> Names { get; set; }
        public NamesDataStore()
        {
            //Dummy Data
            Names = new List<NameDto>()
            {
                new NameDto()
                {
                    Id=1,
                    Name="Mike",
                    Description ="The tall guy.",
                    PointOfInterest =new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name="Shen",
                            Description ="The a young guy."
                        },
                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name="Kelly",
                            Description ="The a girl."
                        },
                    }
                },
                new NameDto()
                {
                    Id=2,
                    Name="Tim",
                    Description ="The short guy.",
                    PointOfInterest =new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name="Ricky",
                            Description ="The mad guy."
                        },
                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name="fredy",
                            Description ="The little boy."
                        },
                    }
                },
                new NameDto()
                {
                    Id=3,
                    Name="Michelle",
                    Description ="The fair girl.",
                    PointOfInterest =new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name="Sundar",
                            Description ="The Google CEO."
                        },
                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name="Mark",
                            Description ="The FB CEO."
                        },
                    }
                },
            };
        }
    }
}
