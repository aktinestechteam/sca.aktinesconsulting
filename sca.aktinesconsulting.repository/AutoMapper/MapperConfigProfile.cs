using AutoMapper;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.entitiy.QueryParameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace sca.aktinesconsulting.repository.AutoMapper
{
    public class MapperConfigProfile :  Profile
    {
        public MapperConfigProfile()
        {
            CreateMap<SCAException, SCAExceptionAdd>();
            CreateMap<SCAException, SCAExceptionUpdate>();
        }
    }

}
