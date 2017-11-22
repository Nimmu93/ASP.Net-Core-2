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
                    Description ="The tall guy."
                },
                new NameDto()
                {
                    Id=2,
                    Name="Tim",
                    Description ="The short guy."
                },
                new NameDto()
                {
                    Id=3,
                    Name="Michelle",
                    Description ="The fair girl."
                },
            };
        }
    }
}
