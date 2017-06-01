using linear_mathematics.Algebra_objects.Enums;

namespace linear_mathematics.Algebra_objects.Real_space.Extra_objects
{
    public class SimpleAction
    {
        #region Private

        private SimpleActionType _type;

        private int _firstVector;

        private int _secondVector;

        private double _coefficient;

        #endregion

        public SimpleActionType Type { get => _type; }

        public int FirstVector { get => _firstVector; }

        public int SecondVector { get => _secondVector; }

        public double Coefficient { get => _coefficient; }

        public SimpleAction(SimpleActionType type, int firstVector, int secondVector)
        {
            _type = type;
            _firstVector = firstVector;
            _secondVector = secondVector;
            _coefficient = 0;
        }

        public SimpleAction(SimpleActionType type, int firstVector, double coefficient)
        {
            _type = type;
            _firstVector = firstVector;
            _secondVector = -1;
            _coefficient = coefficient;
        }

        public SimpleAction(SimpleActionType type, int firstVector, int secondVector, double coefficient)
        {
            _type = type;
            _firstVector = firstVector;
            _secondVector = secondVector;
            _coefficient = coefficient;
        }
    }
}
