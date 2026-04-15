using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;
        private const double LAP_LENGTH_METERS = 50;
        private const double METERS_TO_MILES = 0.000621371;

        public Swimming(DateTime date, int lengthInMinutes, int laps) 
            : base(date, lengthInMinutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            // Distance (miles) = swimming laps * 50 / 1000 * 0.62
            double distanceKm = (_laps * LAP_LENGTH_METERS) / 1000;
            return distanceKm * METERS_TO_MILES;
        }

        public override double GetSpeed()
        {
            // Speed = (distance / minutes) * 60
            return (GetDistance() / GetLengthInMinutes()) * 60;
        }

        public override double GetPace()
        {
            // Pace = minutes / distance
            return GetLengthInMinutes() / GetDistance();
        }
    }
}