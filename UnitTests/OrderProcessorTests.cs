using FundapediaTechTest2;
using FundapediaTechTest2.OrderStatus.Enum;
using FundapediaTechTest2.OrderStatus.Interface;
using FundapediaTechTest2.OrderStatus.Strategy;
using Moq;

namespace UnitTests
{
    [TestFixture]
    public class OrderProcessorTests
    {
        private IOrderProcessor _orderProcessor;
        private Mock<IOrderStatusStrategyFactory> _strategyFactoryMock;

        [SetUp]
        public void Setup()
        {
            _strategyFactoryMock = new Mock<IOrderStatusStrategyFactory>();
            _orderProcessor = new OrderProcessor(_strategyFactoryMock.Object);
        }

        [Test]
        public void LargeRepairOrdersForNewCustomers_ShouldBeClosed_ReturnsClosed()
        {
            //Arrange
            _strategyFactoryMock.Setup(f => f.GetStrategy(OrderType.Repair)).Returns(new RepairOrderStatusStrategy());

            //Act
            var status = _orderProcessor.DetermineOrderStatus(false, OrderType.Repair, true, true);

            //Assert
            Assert.That(status, Is.EqualTo(Status.Closed));
        }

        [Test]
        public void LargeRushHireOrders_ShouldBeClosed_ReturnsClosed()
        {
            //Arrange
            _strategyFactoryMock.Setup(f => f.GetStrategy(OrderType.Hire)).Returns(new HireOrderStatusStrategy());

            //Act
            var status = _orderProcessor.DetermineOrderStatus(true, OrderType.Hire, false, true);

            //Assert
            Assert.That(status, Is.EqualTo(Status.Closed));
        }

        [Test]
        public void LargeRepairOrders_ShouldReturnRequiresAuthorisation_ReturnsRequiresAuthorisation()
        {
            //Arrange
            _strategyFactoryMock.Setup(f => f.GetStrategy(OrderType.Repair)).Returns(new RepairOrderStatusStrategy());

            //Act
            var status = _orderProcessor.DetermineOrderStatus(false, OrderType.Repair, false, true);

            //Assert
            Assert.That(status, Is.EqualTo(Status.AuthorisationRequired));
        }

        [Test]
        public void Repair_RushOrdersForNewCustomers_ShouldReturnRequiresAuthorisation_ReturnsRequiresAuthorisation()
        {
            //Arrange
            _strategyFactoryMock.Setup(f => f.GetStrategy(OrderType.Repair)).Returns(new RepairOrderStatusStrategy());

            //Act
            var status = _orderProcessor.DetermineOrderStatus(true, OrderType.Repair, true, false);

            //Assert
            Assert.That(status, Is.EqualTo(Status.AuthorisationRequired));
        }

        [Test]
        public void Hire_RushOrdersForNewCustomers_ShouldReturnRequiresAuthorisation_ReturnsRequiresAuthorisation()
        {
            //Arrange
            _strategyFactoryMock.Setup(f => f.GetStrategy(OrderType.Hire)).Returns(new HireOrderStatusStrategy());

            //Act
            var status = _orderProcessor.DetermineOrderStatus(true, OrderType.Hire, true, false);

            //Assert
            Assert.That(status, Is.EqualTo(Status.AuthorisationRequired));
        }

        [Test]
        public void Repair_OtherOrders_ShouldReturnConfirmed_ReturnsConfirmed()
        {
            //Arrange
            _strategyFactoryMock.Setup(f => f.GetStrategy(OrderType.Repair)).Returns(new RepairOrderStatusStrategy());

            //Act
            var status = _orderProcessor.DetermineOrderStatus(false, OrderType.Repair, false, false);

            //Assert
            Assert.That(status, Is.EqualTo(Status.Confirmed));
        }

        [Test]
        public void Hire_OtherOrders_ShouldReturnConfirmed_ReturnsConfirmed()
        {
            //Arrange
            _strategyFactoryMock.Setup(f => f.GetStrategy(OrderType.Hire)).Returns(new HireOrderStatusStrategy());

            //Act
            var status = _orderProcessor.DetermineOrderStatus(false, OrderType.Hire, false, false);

            //Assert
            Assert.That(status, Is.EqualTo(Status.Confirmed));
        }
    }
}