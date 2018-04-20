#define Scenes1
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq_Trainning_Demo;

namespace Moq_Trainning_DemoTests
{
    [TestClass]
    public class ManTest
    {
        #region 场景1

#if Scenes1
        [TestMethod]
        public void 小明_问叔叔好_叔叔好()
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.Setup(fake => fake.SayHi("叔叔")).Returns("叔叔好");
            //Act
            var result = FamilyGathering.SayHi(xiaoming.Object, "叔叔");
            //Assert
            Assert.AreEqual("叔叔好", result);
        }

        [TestMethod]
        public void 小明_问叔叔好_叔叔好2()
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.Setup(fake => fake.SayHi("叔叔")).Returns((string value) => $"{value}好");
            //Act
            var result = FamilyGathering.SayHi(xiaoming.Object, "叔叔");
            //Assert
            Assert.AreEqual("叔叔好", result);
        }

        [TestMethod]
        [DataRow("叔叔")]
        [DataRow("阿姨")]
        public void 小明_问亲戚好_亲戚好(string relativeName)
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.Setup(fake => fake.SayHi("叔叔")).Returns((string value) => $"{value}好");
            xiaoming.Setup(fake => fake.SayHi("阿姨")).Returns((string value) => $"{value}好");
            //Act
            var result = FamilyGathering.SayHi(xiaoming.Object, relativeName);
            //Assert
            Assert.AreEqual($"{relativeName}好", result);
        }

        [TestMethod]
        [DataRow("叔叔")]
        [DataRow("阿姨")]
        public void 小明_问亲戚好_亲戚好2(string relativeName)
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.Setup(fake => fake.SayHi(It.IsAny<string>())).Returns((string value) => $"{value}好");
            //Act
            var result = FamilyGathering.SayHi(xiaoming.Object, relativeName);
            //Assert
            Assert.AreEqual($"{relativeName}好", result);
        }

        [TestMethod]
        public void 小明_问stringEmpty好_抛ArgumentException()
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.Setup(fake => fake.SayHi(String.Empty)).Throws(new ArgumentException());
            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => FamilyGathering.SayHi(xiaoming.Object, ""));
        }

        [TestMethod]
        public void 小明_第二次问叔叔好_叔叔好加2()
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            var count = 1;
            xiaoming.Setup(fake => fake.SayHi("叔叔")).Returns((string value) => $"{value}好+{count}")
                    .Callback(() => count++);
            //Act
            FamilyGathering.SayHi(xiaoming.Object, "叔叔");
            var result = FamilyGathering.SayHi(xiaoming.Object, "叔叔");
            //Assert
            Assert.AreEqual("叔叔好+2", result);
        }

        [TestMethod]
        public void 小明_连续问叔叔好_叔叔好恭喜发财万事如意身体健康扎西德勒()
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.SetupSequence(fake => fake.SayHi("叔叔"))
                    .Returns("叔叔好")
                    .Returns("恭喜发财")
                    .Returns("万事如意")
                    .Returns("身体健康")
                    .Returns("扎西德勒");
                    
            //Act
            var result1 = FamilyGathering.SayHi(xiaoming.Object, "叔叔");
            var result2 = FamilyGathering.SayHi(xiaoming.Object, "叔叔");
            var result3 = FamilyGathering.SayHi(xiaoming.Object, "叔叔");
            var result4 = FamilyGathering.SayHi(xiaoming.Object, "叔叔");
            var result5 = FamilyGathering.SayHi(xiaoming.Object, "叔叔");
            //Assert
            Assert.AreEqual("叔叔好", result1);
            Assert.AreEqual("恭喜发财", result2);
            Assert.AreEqual("万事如意", result3);
            Assert.AreEqual("身体健康", result4);
            Assert.AreEqual("扎西德勒", result5);
        }


#endif

        #endregion

        #region 场景2

#if Scenes2
        [TestMethod]
        public void 小明3岁_问年龄_长大了()
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.Setup(fake => fake.GetAge()).Returns(3);
            //Act
            var result = FamilyGathering.AskAge(xiaoming.Object);
            //Assert
            Assert.AreEqual("哟，几年不见都长这么大了？", result);
        }

        [TestMethod]
        public void 小红30岁_问年龄_找对象()
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.Setup(fake => fake.GetAge()).Returns(30);
            //Act
            var result = FamilyGathering.AskAge(xiaoming.Object);
            //Assert
            Assert.AreEqual("哟，几年不见都长这么大了？该去找个对象了吧。", result);
        }
#endif

        #endregion
    }
}
