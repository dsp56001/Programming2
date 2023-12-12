using Microsoft.VisualStudio.TestTools.UnitTesting;
using DogLibrary;

namespace UnitTestProjectMammal
{
    [TestClass]
    public class DogTests
    {
        Dog TestDog;
        

        public DogTests()
        {
            TestDog = new Dog();
        }


        [TestMethod]
        public void DogConstructor_DefaultValues()
        {
            //Arrange 
            Dog d = TestDog;


            //Act

            //Assert
            Assert.IsNotNull(d);
            Assert.AreEqual(d.Name, "fido");
            Assert.AreEqual(d.Weight, 2);
            Assert.AreEqual(d.Age, 1);
            Assert.AreEqual(d.BarkSound, "woof!");
        }

        [TestMethod]
        public void DogConstructor_WithValues()
        {
            //Arrange 
            string DFullName = "DFullName";
            string DFullNameArf = "DFullNameArf";
            string DName = "DName";
            string DNameArf = "DNameArf";
            Dog dFull = new Dog(DFullName, 99, 98, DFullNameArf);
            Dog dName = new Dog(DName, 97, 96, DNameArf);

            //Act
            Assert.IsNotNull(dFull);

            //Assert
            Assert.AreEqual(dFull.Name, DFullName);
            Assert.AreEqual(dFull.Weight, 98);
            Assert.AreEqual(dFull.Age, 99);
            Assert.AreEqual(dFull.BarkSound, DFullNameArf);

            Assert.AreEqual(dName.Name, DName);
            Assert.AreEqual(dName.Weight, 96);
            Assert.AreEqual(dName.Age, 97);
            Assert.AreEqual(dName.BarkSound, DNameArf);
        }

        [TestMethod]
        public void DogCount()
        {
            //Arrange 
            int InitialDogCount = Dog.DogCount;

            //Act 
            Dog d = new Dog();
            int CountAfterAddingDog = Dog.DogCount;
            for (int i = 0; i < 10; i++)
            {
                d = new Dog();
            }
            int AfterTenMOreDogs = Dog.DogCount;
            //Assert
            Assert.AreEqual(InitialDogCount, CountAfterAddingDog - 1);
            Assert.AreEqual(InitialDogCount, AfterTenMOreDogs - 1 - 10);
        }

        [TestMethod]
        public void DogAge()
        {
            //arrange
            int age = TestDog.Age;

            //act
            TestDog.HappyBirthday();
            
            int AgePlusOne = age + 1;

            //assert
            Assert.AreEqual(age + 1, AgePlusOne);
        }

        [TestMethod]
        public void DogBarkSingle()
        {
            //arrange
            string barkNoSapces = "BarkNOSpaces";
            string testBark = string.Empty;
            Dog dTestBark = new Dog() { BarkSound = barkNoSapces };
            //act
            testBark = dTestBark.Bark();

            //assert
            Assert.AreEqual(testBark, barkNoSapces);
        }

        [TestMethod]
        public void DogBarkMultiple()
        {
            //arrange
            string barkNoSapces = "BarkNOSpaces";
            string testBark = string.Empty;
            int barktimes = 3;  //shouldn't matter how many times it barks
            Dog dTestBark = new Dog() { BarkSound = barkNoSapces };
            string[] barkAry;
            //act
            testBark = dTestBark.Bark(barktimes);
            barkAry = testBark.Split(barkNoSapces, System.StringSplitOptions.None);

            //assert
            Assert.AreEqual(barkAry.Length -1, barktimes);
        }
    }
}
