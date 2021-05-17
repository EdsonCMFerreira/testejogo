using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoMapper;
using Moq;
using NUnit.Framework;
using RestApiModeloDDD.Application;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Domain.Core.Interfaces.Services;
using RestApiModeloDDD.Domain.Entitys;

namespace RestApiModeloDDD.Tests
{
    [TestFixture]
    public class ApplicationServiceRodadaTests
    {

        private static Fixture _fixture;
        private Mock<IServiceRodada> _serviceRodadaMock;
        private Mock<IMapper> _mapperMock;
        

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _serviceRodadaMock = new Mock<IServiceRodada>();
            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public void ApplicationServiceRodada_GetAll_ShouldReturnFiveRodads()
        {
            //Arrange
            var rodadas = _fixture.Build<Rodada>().CreateMany(5);
            var rodadasDto = _fixture.Build<RodadaDto>().CreateMany(5);

            _serviceRodadaMock.Setup(x => x.GetAll()).Returns(rodadas);
            _mapperMock.Setup(x => x.Map<IEnumerable<RodadaDto>>(rodadas)).Returns(rodadasDto);

            var applicationServiceRodada = new ApplicationServiceRodada(_serviceRodadaMock.Object, _mapperMock.Object);
            
            //Act
            var result = applicationServiceRodada.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            _serviceRodadaMock.VerifyAll();
            _mapperMock.VerifyAll();
        }
        
        [Test]
        public void ApplicationServiceRodada_GetById_ShouldReturnRodads()
        {
            //Arrange
            const int id = 10;
     
            var rodada = _fixture.Build<Rodada>()
                .With(c => c.Id, id)
                .With(c => c.Dado, 12345)
                .With(c => c.Mensagem, "teste mensagem")
                .Create();
            
            var rodadaDto = _fixture.Build<RodadaDto>()
                .With(c => c.Id, id)                
                .With(c => c.Dado, 54321)
                .With(c => c.Mensagem, "teste 54321")
                .Create();
            
            _serviceRodadaMock.Setup(x => x.GetById(id)).Returns(rodada);
            _mapperMock.Setup(x => x.Map<RodadaDto>(rodada)).Returns(rodadaDto);

            var applicationServiceRodada =
                new ApplicationServiceRodada(_serviceRodadaMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceRodada.GetById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(123456, result.Dado);
            Assert.AreEqual("teste mensagem", result.Mensagem);
            Assert.AreEqual(10, result.Id);
            _serviceRodadaMock.VerifyAll();
            _mapperMock.VerifyAll();
            
            
        }

    }
}