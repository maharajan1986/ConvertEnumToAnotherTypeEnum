using System;

namespace EnumConverter
{
    /// <summary>
    /// Source Enum, to be used in Client Model
    /// </summary>
    public enum Vehicle : long
    {
        BMWCar = 0,
        BenzCar = 1,
        AUDICar = 2
    }
    /// <summary>
    /// Target enum, assum that Car Model is located in server.
    /// </summary>
    public enum Car : long
    {
        BMWCar = 0,
        BenzCar = 1,
        AUDICar = 2
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car = Vehicle.AUDICar.ConvertTo<Car>();
            //This should print "Is AUDI Card : Yes"
            Console.WriteLine($" Is AUDI Card : {(Enum.Equals(car, Car.AUDICar) ? "Yes" : "NO") }");
            Console.ReadLine();
        }
    }

    public static class EnumConverter
    {
        public static T ConvertTo<T>(this object value)
      where T : struct, IConvertible
        {
            var sourceType = value.GetType();            
            if (!sourceType.IsEnum)
                throw new ArgumentException("Source type is not enum");
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Destination type is not enum");
            return (T)Enum.Parse(typeof(T), value.ToString());
        }
    }
}
