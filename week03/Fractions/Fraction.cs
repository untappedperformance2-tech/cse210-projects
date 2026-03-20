using System;

namespace Fractions
{
    public class Fraction
    {
        // Private attributes (encapsulation)
        private int _top;
        private int _bottom;

        // Constructor #1: No parameters - initializes to 1/1
        public Fraction()
        {
            _top = 1;
            _bottom = 1;
        }

        // Constructor #2: One parameter - initializes top to value, bottom to 1
        public Fraction(int top)
        {
            _top = top;
            _bottom = 1;
        }

        // Constructor #3: Two parameters - initializes both top and bottom
        public Fraction(int top, int bottom)
        {
            _top = top;
            _bottom = bottom;
        }

        // Getter for top
        public int GetTop()
        {
            return _top;
        }

        // Setter for top
        public void SetTop(int top)
        {
            _top = top;
        }

        // Getter for bottom
        public int GetBottom()
        {
            return _bottom;
        }

        // Setter for bottom
        public void SetBottom(int bottom)
        {
            _bottom = bottom;
        }

        // Returns fraction as string (e.g., "3/4")
        public string GetFractionString()
        {
            return $"{_top}/{_bottom}";
        }

        // Returns decimal value (e.g., 0.75)
        public double GetDecimalValue()
        {
            return (double)_top / (double)_bottom;
        }
    }
}