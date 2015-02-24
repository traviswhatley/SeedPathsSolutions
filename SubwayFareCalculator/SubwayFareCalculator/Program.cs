using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace SubwayFareCalculator
{
    [TestFixture]
    class test
    {
        [Test]
        public void Boners()
        {
            var x = new Station("12", 1);
            var y = new Station("13", 15);
            var z = new Trip(x, y);
            Assert.That(z.CalculateFare() > 1);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            TripFareUI trip = new TripFareUI();
            trip.CreateTrip();
            trip.CollectFare();
            trip.CompleteTrip();
            Console.ReadKey();
        }
    }

    public class Station
    {
        public string Name { get; set; }
        public double MileMarker { get; set; }
        public Station(string name, double mileMarker) {
            this.Name = name;
            this.MileMarker = mileMarker;
        }

        /// <summary>
        /// A static method to return a list of Stations, in the real world this would come from a databasae
        /// </summary>
        /// <returns>A list of stations</returns>
        public static List<Station> GetStationList() {
            List<Station> list = new List<Station>();
            list.Add(new Station("Union Station", 0.0));
            list.Add(new Station("Pepsi Center", 1.3));
            list.Add(new Station("Sports Authority Field", 2.7));
            list.Add(new Station("Auroria West", 4.1));
            list.Add(new Station("Decatur & Federal", 5.3));
            list.Add(new Station("Knox", 7));
            list.Add(new Station("Perry", 9.3));
            list.Add(new Station("Sheridan", 10.3));
            list.Add(new Station("Lamar", 14.5));
            list.Add(new Station("Lakewood & Wadsworth", 18.3));
            list.Add(new Station("Garrison", 20.6));
            list.Add(new Station("Oak", 23.5));
            list.Add(new Station("Federal Center", 26.1));
            list.Add(new Station("Red Rocks College", 28.0));
            list.Add(new Station("Jeff Co Government Center", 30.2));
            
            return list;
        }
    }

    public class Trip
    {
        public Station StartingStation { get; set; }
        public Station DestinationStation { get; set; }
        public Station ExitStation { get; set; }
        public double FareCollected { get; set; }
        public double FarePerMile = .33;

        public Trip(Station startingStation, Station destinationStation)
        {
            this.StartingStation = startingStation;
            this.DestinationStation = destinationStation;
        }

        public double CalculateFare()
        {
            double distance;
            if (this.ExitStation == null)
            {
                distance = Math.Abs(this.StartingStation.MileMarker - this.DestinationStation.MileMarker);
            }
            else
            {
                distance = Math.Abs(this.StartingStation.MileMarker - this.ExitStation.MileMarker) ;
            }
            return GetFareBasedOnDistance(distance);
        }

        private double GetFareBasedOnDistance(double distance)
        {
            if (distance < 3)
            {
                return 1.5;
            }
            else if (distance < 5)
            {
                return 2;
            }
            else if (distance < 10)
            {
                return 2.5;
            }
            else if (distance < 20)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

    }

    public class TripFareUI
    {
        public List<Station> StationList = Station.GetStationList();
        public Trip Trip { get; set; }
        public TripFareUI()
        {
            
        }

        public void CreateTrip()
        {
            Station start;
            Station end;
            string input;

            Console.WriteLine("Select Starting Station:\n");
            PrintStationList();
            Console.Write("Enter Station Number: ");
            input = Console.ReadLine();
            start = StationList[int.Parse(input) - 1];
            Console.Clear();

            Console.WriteLine("Select Destination Station:\n");
            PrintStationList();
            Console.Write("Enter Station Number: ");
            input = Console.ReadLine();
            end = StationList[int.Parse(input) - 1];

            this.Trip = new Trip(start, end);
        }

        public void PrintStationList() 
        {
            for (int i = 0; i < StationList.Count; i++)
            {
                Console.WriteLine("{0, 2}. {1}", i +1, StationList[i].Name);
            }
            Console.WriteLine();
        }

        public void CollectFare()
        {
            double fareTotal = this.Trip.CalculateFare();
            if (this.Trip.ExitStation == null) { 
                Console.WriteLine("Going from {0} to {1}", this.Trip.StartingStation.Name, this.Trip.DestinationStation.Name);
            }
            else
            {
                Console.WriteLine("Going from {0} to {1}", this.Trip.StartingStation.Name, this.Trip.ExitStation.Name);
            }
        
            while (this.Trip.FareCollected < fareTotal)
            {
                Console.WriteLine("Fare: {0:C}", fareTotal);
                Console.WriteLine("Money Collected: {0:C}", this.Trip.FareCollected);
                Console.Write("Insert Money: $");
                this.Trip.FareCollected += double.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            Console.WriteLine("Fare: {0:C}", fareTotal);
            Console.WriteLine("Money Collected: {0:C}", this.Trip.FareCollected);
            Console.WriteLine("Change: {0:C}", this.Trip.FareCollected - fareTotal);
            //set the fare total equal to the amount paid, since we gave them the change.
            this.Trip.FareCollected = fareTotal;

            
        }

        public void CompleteTrip()
        {
            string input;
            Console.WriteLine("Select Exit Station: \n");
            PrintStationList();
            Console.Write("Enter Station Number: ");
            input = Console.ReadLine();
            this.Trip.ExitStation = StationList[int.Parse(input) - 1];

            if (this.Trip.ExitStation != this.Trip.DestinationStation)
            {
      
                if (this.Trip.CalculateFare() > this.Trip.FareCollected )
                {
                    Console.WriteLine("More money required!");
                    CollectFare();
                }
            }
            Console.WriteLine("Have a nice day!");
        }

    }
}
