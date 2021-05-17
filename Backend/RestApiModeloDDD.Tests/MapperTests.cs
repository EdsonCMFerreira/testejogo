using AutoMapper;
using NUnit.Framework;
using RestApiModeloDDD.Application.Mappers;

namespace RestApiModeloDDD.Tests
{
    [TestFixture]
    public class MapperTests
    {
        
        [Test]
        public void AutoMapperDtoToModelRodada_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DtoToModelMappingRodada>());
            config.AssertConfigurationIsValid();
        }
        
   
    }
}