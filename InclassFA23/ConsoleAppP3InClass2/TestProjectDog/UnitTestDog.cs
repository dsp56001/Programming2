using DogLibrary;

namespace TestProjectDog
{
    
    
    [TestClass]
    public class UnitTestDog
    {

        Dog dog;

        public UnitTestDog() 
        {
            dog = new Dog();
        }

        [TestMethod]
        public void DogConstructorDefaults()
        {

            //Arrange
            
            //Act 
            
            //Assert
            Assert.IsNotNull(dog);
            Assert.AreEqual(dog.Name, "fido");
            Assert.AreEqual(dog.Age,1 );
            Assert.AreEqual(dog.Weight,2 );
            Assert.AreEqual(dog.BarkSound, "woof");
        }

        [TestMethod]
        public void DogBarkTest() {
        
            //Arrange
            
            //Act
            string barkExpected = "woof";
            string barkResult = dog.Bark();
            //Assert
            Assert.AreEqual(barkExpected, barkResult);
        }

        [TestMethod]
        public void DogBarkMultipleTimesTest()
        {

            //Arrange
            
            //Act
            string bark2Expected = "woof woof";
            string bark2Result = dog.Bark(2);

            string bark3Expected = "woof woof woof";
            string bark3Result = dog.Bark(3);

            //Assert
            Assert.AreEqual(bark2Expected, bark2Result);
            Assert.AreEqual(bark3Expected, bark3Result);
        }

        [TestMethod]
        public void DogHappyBrithday()
        {
            //
        }
    }
}