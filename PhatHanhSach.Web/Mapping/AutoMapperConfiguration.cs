using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
        }

    }
}