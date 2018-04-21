#define Scenes4
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
            xiaoming.Setup(fake => fake.Age).Returns(3);
            //Act
            var result = FamilyGathering.AskAge(xiaoming.Object);
            //Assert
            Assert.AreEqual("哟，3岁了，几年不见都长这么大了？", result);
        }

        [TestMethod]
        public void 小红30岁_问年龄_找对象()
        {
            //Arrange
            var xiaohon = new Mock<IMan>();
            xiaohon.Setup(fake => fake.Age).Returns(30);
            //Act
            var result = FamilyGathering.AskAge(xiaohon.Object);
            //Assert
            Assert.AreEqual("哟，30岁了，该去找个对象了吧。", result);
        }

        [TestMethod]
        public void 老王儿子3岁_问儿子年龄_长大了()
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.Setup(fake => fake.Age).Returns(3);
            var laowang = new Mock<IMan>();
            laowang.Setup(fake => fake.Child).Returns(xiaoming.Object);
            //Act
            var result = FamilyGathering.AskChildAge(laowang.Object);
            //Assert
            Assert.AreEqual("哟，3岁了，几年不见都长这么大了？", result);
        }

        [TestMethod]
        public void 老王儿子3岁_问儿子年龄_长大了2()
        {
            //Arrange
            var laowang = new Mock<IMan>();
            laowang.Setup(fake => fake.Child.Age).Returns(3);
            //Act
            var result = FamilyGathering.AskChildAge(laowang.Object);
            //Assert
            Assert.AreEqual("哟，3岁了，几年不见都长这么大了？", result);
        }

        [TestMethod]
        public void 小明3岁_问年龄_长大了2()
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.Object.Age = 3;
            //Act
            var result = FamilyGathering.AskAge(xiaoming.Object);
            //Assert
            Assert.AreEqual("哟，3岁了，几年不见都长这么大了？", result);
        }

        [TestMethod]
        public void 小明3岁_问年龄_长大了3()
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.SetupProperty(fake => fake.Age, 3);
            //Act
            var result = FamilyGathering.AskAge(xiaoming.Object);
            //Assert
            Assert.AreEqual("哟，3岁了，几年不见都长这么大了？", result);
        }

        [TestMethod]
        public void 小明3岁_问年龄_长大了4()
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.SetupAllProperties();
            var @object = xiaoming.Object;
            @object.Name = "李小明";
            @object.Age = 3;
            @object.Occupation = "学生";
            @object.Weight = 30;
            @object.Account = 100;

            //Act
            //Assert
            Assert.AreEqual("李小明", xiaoming.Object.Name);
            Assert.AreEqual(3, xiaoming.Object.Age);
            Assert.AreEqual("学生", xiaoming.Object.Occupation);
            Assert.AreEqual(30, xiaoming.Object.Weight);
            Assert.AreEqual(100, xiaoming.Object.Account);
        }

        [TestMethod]
        public void 小明3岁_过年_4岁()
        {
            //Arrange
            var xiaoming = new Mock<IMan>();
            xiaoming.SetupSet(fake=>fake.Age++);
            //Act
            FamilyGathering.HappyNewYear(xiaoming.Object);
            //Assert
            xiaoming.VerifyAll();
        }

#endif

        #endregion

        #region 场景3

#if Scenes3
        [TestMethod]
        public void 张小红100斤_吃了20斤西瓜_体重120斤名字叫不减肥就不改名的张小红()
        {
            //Arrange
            var xiaohong = new Mock<IMan>();
            xiaohong.SetupProperty(fake => fake.Name, "张小红");
            xiaohong.SetupProperty(fake => fake.Weight, 100);
            xiaohong.Setup(fake => fake.Eat(20))
                    .Callback<int>(num =>
                     {
                         xiaohong.Object.Weight += num;
                         xiaohong.Raise(fake1 => fake1.ImFull += null, new EventArgs());
                     });
            //Act
            FamilyGathering.HaveDinner(xiaohong.Object, "西瓜", 20);
            //Assert
            Assert.AreEqual(120, xiaohong.Object.Weight);
            Assert.AreEqual("不减肥就不改名的张小红", xiaohong.Object.Name);
        }


        [TestMethod]
        [DataRow(10,110, "张小红")]
        [DataRow(20,120, "不减肥就不改名的张小红")]
        public void 张小红100斤_吃西瓜_体重增加名字变化(int foodNum,int weight,string name)
        {
            //Arrange
            var xiaohong = new Mock<IMan>();
            xiaohong.SetupProperty(fake => fake.Name, "张小红");
            xiaohong.SetupProperty(fake => fake.Weight, 100);
            xiaohong.Setup(fake => fake.Eat(It.IsInRange(0,15,Range.Exclusive)))
                    .Callback<int>(num =>
                     {
                         xiaohong.Object.Weight += num;
                     });
            xiaohong.Setup(fake => fake.Eat(It.IsInRange(15, int.MaxValue, Range.Inclusive)))
                    .Callback<int>(num =>
                     {
                         xiaohong.Object.Weight += num;
                         xiaohong.Raise(fake1 => fake1.ImFull += null, new EventArgs());
                     });
            //Act
            FamilyGathering.HaveDinner(xiaohong.Object, "西瓜", foodNum);
            //Assert
            Assert.AreEqual(weight, xiaohong.Object.Weight);
            Assert.AreEqual(name, xiaohong.Object.Name);
        }
#endif

        #endregion

        #region 场景4

#if Scenes4
        [TestMethod]
        [DataRow(1, 100, "咱有钱")]
        [DataRow(5, 500, "要吃土")]
        public void 老王有存款1000块_发红包(int number, int account, string lastWord)
        {
            //Arrange
            var laowang = new Mock<IMan>();
            laowang.SetupProperty(fake => fake.Account, 1000);
            laowang.Setup(fake => fake.DoSomething<int>("发红包", It.IsAny<int>()))
                   .Callback<string, int>(
                        (something, num) => { laowang.Object.Account = laowang.Object.Account - num; })
                   .Returns(() => laowang.Object.Account > 0 ? "咱有钱" : "要吃土");
            //Act
            var result = FamilyGathering.FaHongbao(laowang.Object, number, account);
            //Assert
            laowang.VerifyGet(fake => fake.Account, Times.Exactly(number * 2));
            laowang.VerifyGet(fake => fake.Name);
            laowang.Verify(fake => fake.DoSomething<int>("发红包", It.IsAny<int>()), Times.Exactly(number));
            Assert.AreEqual(lastWord, result);
        }

#endif

        #endregion
    }
}
