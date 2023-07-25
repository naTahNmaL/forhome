using AutoMapper;
using Moq;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Models;
using PTP.BusinessService.Services;
using PTP.DAL.Domains;
using PTP.DAL.Interfaces;

namespace PTP.IntegrationTest.TestServices;

[TestFixture]
public class TestJourney
{
        private IJourneyServices _journeyService;
        private Mock<IJourneyRepository> _journeyRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            // Set up mock objects and mapper before each test.
            _journeyRepositoryMock = new Mock<IJourneyRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            // You can configure the mapper based on your actual mappings.
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Journey, JourneyModel>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        // [Test]
        // public async Task GetAllAsync_ShouldReturnListOfJourneyModels()
        // {
        //     // Arrange
        //     var journeysFromDb = new List<Journey>
        //     {
        //         new Journey { Id = 1, Name = "Journey 1" },
        //         new Journey { Id = 2, Name = "Journey 2" },
        //     };
        //
        //     _journeyRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(journeysFromDb);
        //
        //     // Act
        //     var result = await _journeyService.GetAllAsync();
        //
        //     // Assert
        //     Assert.NotNull(result);
        //     Assert.AreEqual(journeysFromDb.Count, result.Count);
        //     Assert.IsTrue(result.All(journey => journeysFromDb.Any(j => j.Id == journey.Id && j.Name == journey.Name)));
        // }
        //
        // [Test]
        // public async Task GetByIdAsync_ExistingId_ShouldReturnJourneyModel()
        // {
        //     // Arrange
        //     int journeyId = 1;
        //     var journeyFromDb = new Journey { Id = journeyId, Name = "Journey 1" };
        //
        //     _journeyRepositoryMock.Setup(repo => repo.GetByIdAsync(journeyId)).ReturnsAsync(journeyFromDb);
        //
        //     // Act
        //     var result = await _journeyService.GetByIdAsync(journeyId);
        //
        //     // Assert
        //     Assert.NotNull(result);
        //     Assert.AreEqual(journeyFromDb.Id, result.Id);
        //     Assert.AreEqual(journeyFromDb.Name, result.Name);
        // }
}