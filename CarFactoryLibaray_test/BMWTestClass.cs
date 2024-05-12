using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibaray_test
{
    public  class BMWTestClass
    {

        ///Boolean Assert///
        [Fact]
       public void TwoCarsEqualsTest()
       {
            //Arrange
            BMW bMW1 = new BMW { velocity = 20 };
            BMW bMW2 = new BMW{ velocity = 40 };
            //Act 
           bool result=bMW1.Equals(bMW2);
            //Assert
            Assert.False(result);
       }


        ///Numeric Assert(1) 
        [Fact]
        public void StopVelocityEqual_0()
        {
            //Arrange
            BMW bMW = new BMW ();
            //Act
            double StoppedVelocity=bMW.velocity;
            bMW.Stop();
            //Assert
            Assert.Equal(0, StoppedVelocity);
        }

        ///Numeric Assert(2)
        [Fact]
        public void TimeToCoverDistanceTest()
        {
            //Arrange
            BMW bMW=new BMW { velocity = 20 };
            
            //Act
            double Time = bMW.TimeToCoverDistance(100);
            //Assert
            Assert.Equal(5, Time);
        }
        ///String Assert(1)
        [Fact]
        public void StopDrivingMode()
        {
            //Arrange
            BMW bMW= new BMW ();
            //Act
            bMW.Stop();
            string driving_mode = bMW.drivingMode.ToString();
            //Assert
            Assert.Matches("Stopped", driving_mode);
        }

        ///String Assert(2)
        [Fact]
        public void CheckDrivingMode()
        {
            //Arrange
            BMW bMW = new BMW();
            //Act
            bMW.drivingMode = DrivingMode.Backward;
            string driving_mode = bMW.drivingMode.ToString();
            //Assert
            Assert.StartsWith("B", driving_mode);
        }

        ///String Assert(3)
        [Fact]
        public void IncreaseVelocityDrivingMode()
        {
            //Arrange
            BMW bMW = new BMW();
            //Act
            bMW.IncreaseVelocity(100);
            string driving_mode = bMW.drivingMode.ToString();
            //Assert
            Assert.Contains("r", driving_mode);
        }

        ///String Assert(4)
        [Fact]
        public void GetDirectionTest()
        {
            //Arrange
            BMW bMW = new BMW { drivingMode = DrivingMode.Forward };
            //Act
            string direction = bMW.GetDirection();
            //Assert
            Assert.NotEqual("Stopped", direction);
        }


        ///String Assert(5)
        [Fact]
        public void GetDirectionTest2()
        {
            //Arrange
            BMW bMW = new BMW { drivingMode = DrivingMode.Backward };
            //Act
            string direction = bMW.GetDirection();
            //Assert
            Assert.EndsWith("d", direction);
        }

     
        /// Refrence Assert ///
  
        [Fact]
        public void GetMyCar_callFunction_SameCar()
        {
            // Arrange
            BMW bMW1=new BMW();
            BMW bMW2=new BMW(); 

            // Act
           
            Car myCar = bMW1.GetMyCar();  
            
            //Assert
            Assert.Same(bMW1, myCar);
        }


        /// Type Assert///
        [Fact]
        public void NewCar_CarTypeToyota()
        {
            // Arrange

            // Act
            Car? car = CarFactory.NewCar(CarTypes.Toyota);

                    
            Assert.IsType<Toyota>(car);
            Assert.IsNotType<BMW>(car);
        }



        /// Exception Assert///
        [Fact]
        public void NewCar_CarTypeHonda_Exception()
        {
            // Arrange

            // Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                Car? result = CarFactory.NewCar(CarTypes.Honda);
            });
        }

    }
}
