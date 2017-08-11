using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{

    /// <summary>
    /// Abstract definition of any type of car
    /// </summary>
    public abstract class Car
    {
        #region Public Properties

        /// <summary>
        /// The cars wheel diameter as it is unknown
        /// </summary>
        public abstract int WheelDiameterInches { get; }


        /// <summary>
        /// Indicates if the handbrake is released
        /// </summary>

        public bool HandBrakeReleased { get; set; } = false;

        #endregion
        #region Public Methods
        public virtual void RadioOn()
        {
            Console.WriteLine("Turn the radio on");
        }

        /// <summary>
        /// Attempts to release the cars handbrake
        /// </summary>
        public virtual void ReleaseHandbrake()
        {
            // Release the handbrake
            HandBrakeReleased = true;

            Console.WriteLine("Sucessfully release the handbrake");
        }

        /// <summary>
        /// Apply gas to drive the car
        /// </summary>

        public virtual void Drive()
        {
            ReleaseHandbrake();
            if (HandBrakeReleased)
                Console.WriteLine("Pressed the gas peddle");
            else
                Console.WriteLine("Cannot move handbrake jammed");

        }

        public float GearboxOutputSpeedRpm()
        {
            return 1000;
        }
        public float CalculateSpeedMph()
        {
            //if handbrake on we aren't moving
            if (!HandBrakeReleased)
                return 0;

            var InchesPerRev = (float)(Math.PI * WheelDiameterInches);
            var InchesPerMinute = InchesPerRev * GearboxOutputSpeedRpm();
            var mph = InchesPerMinute * 60 * 0.0000157828;

            return (float)mph;
        }

        #endregion

        /// <summary>
        /// This will wind the car window down
        /// </summary>

        public abstract void WindWindowDown();


        /// <summary>
        /// Moves the seat forward
        /// </summary>
        public abstract void MoveSeatForward();

    }
    public class BudgetCar : Car
    {
        public override int WheelDiameterInches => 16;

        public override void MoveSeatForward()
        {
            Console.WriteLine("Move seat forward using hand lever");
        }

        public override void WindWindowDown()
        {
            Console.WriteLine("Wound window down slowly using winder");
        }
    }

    public class SportsCar : Car
    {
        public override int WheelDiameterInches => 22;

        public override void MoveSeatForward()
        {
            Console.WriteLine("Move seat forward using button");
        }

        public override void WindWindowDown()
        {
            Console.WriteLine("Pressed button to adjust window");
        }
    }

    public class BrokenBudgetCar : BudgetCar
    {
        public override void ReleaseHandbrake()
        {
            //Handbrake stuck always on
            HandBrakeReleased = false;

            Console.WriteLine("!! Handbrake failed to release !!");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Budget car");
            Console.WriteLine("----------------");
            var budgetCar = new BudgetCar();
            doStuffToCar(budgetCar);
            Console.WriteLine("\n");

            Console.WriteLine("Sports car");
            Console.WriteLine("----------------");
            var sportsCar = new SportsCar();
            doStuffToCar(sportsCar);
            Console.WriteLine("\n");

            Console.WriteLine("Budget car");
            Console.WriteLine("----------------");
            var budgetCar2 = new BrokenBudgetCar();
            doStuffToCar(budgetCar2);
            Console.WriteLine("\n");


            Console.ReadLine();
        }

        private static void doStuffToCar(Car car)
        {
            car.MoveSeatForward();
            car.RadioOn();
            car.WindWindowDown();
            car.Drive();

            Console.WriteLine($"Driving at {car.CalculateSpeedMph()}mph with {car.WheelDiameterInches}\" rims");
        }
    }
}
