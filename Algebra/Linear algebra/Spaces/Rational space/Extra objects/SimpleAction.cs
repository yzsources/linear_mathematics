using Algebra.Fields_algebra.Fields;
using Algebra.Linear_algebra.Enums;

namespace Algebra.Linear_algebra.Spaces.Rational_space.Extra_objects
{
    public class SimpleAction
    {
        #region Private

        private SimpleActionType _type;

        private int _firstVector;

        private int _secondVector;

        private Rational _coefficient;

        #endregion

        public SimpleActionType Type { get => _type; }

        public int FirstVector { get => _firstVector; }

        public int SecondVector { get => _secondVector; }

        public Rational Coefficient { get => _coefficient; }

        public SimpleAction(SimpleActionType type, int firstVector, int secondVector)
        {
            _type = type;
            _firstVector = firstVector;
            _secondVector = secondVector;
            _coefficient = (Rational)0;
        }

        public SimpleAction(SimpleActionType type, int firstVector, Rational coefficient)
        {
            _type = type;
            _firstVector = firstVector;
            _secondVector = -1;
            _coefficient = coefficient.Clone() as Rational;
        }

        public SimpleAction(SimpleActionType type, int firstVector, int secondVector, Rational coefficient)
        {
            _type = type;
            _firstVector = firstVector;
            _secondVector = secondVector;
            _coefficient = coefficient.Clone() as Rational;
        }
    }
}
