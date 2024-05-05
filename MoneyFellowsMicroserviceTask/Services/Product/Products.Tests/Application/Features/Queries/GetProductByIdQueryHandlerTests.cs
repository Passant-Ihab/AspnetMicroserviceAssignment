using AutoMapper;
using Moq;
using Products.Application.Contracts.Infrastructure;
using Products.Application.Features.Queries.GetProduct;
using Products.Core.Entities;

namespace Products.Tests.Application.Features.Queries
{
    [TestClass]
    public class GetProductByIdQueryHandlerTests
    {
        [TestMethod]
        public async Task Should_Return_ProductDTO_When_Given_Valid_Query()
        {
            // Arrange
            var query = new GetProductByIdQuery(1);
            var product = new Product { Id = 1, Name = "Test Product" };
            var productDTO = new ProductDTO { Id = 1, Name = "Test Product" };

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetByIdAsync(query.Id)).ReturnsAsync(product);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<ProductDTO>(product)).Returns(productDTO);

            var handler = new GetProductByIdQueryHandler(productRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(productDTO, result);
        }


        [TestMethod]
        public void should_throw_argumentNullException_when_IMapper_is_null()
        {
            // Arrange
            IProductRepository productRepository = new Mock<IProductRepository>().Object;
            IMapper mapper = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new GetProductByIdQueryHandler(productRepository, mapper));
        }
    }
}
