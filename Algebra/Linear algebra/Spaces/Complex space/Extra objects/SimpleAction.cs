using Algebra.Fields_algebra.Fields;
using Algebra.Linear_algebra.Enums;

namespace Algebra.Linear_algebra.Spaces.Complex_space.Extra_objects
{
    public class SimpleAction
    {
        #region Private

        private SimpleActionType _type;

        private int _firstVector;

        private int _secondVector;

        private Complex _coefficient;

        #endregion

        public SimpleActionType Type { get => _type; }

        public int FirstVector { get => _firstVector; }

        public int SecondVector { get => _secondVector; }

        public Complex Coefficient { get => _coefficient; }

        public SimpleAction(SimpleActionType type, int firstVector, int secondVector)
        {
            _type = type;
            _firstVector = firstVector;
            _secondVector = secondVector;
            _coefficient = (Complex)0;
        }

        public SimpleAction(SimpleActionType type, int firstVector, Complex coefficient)
        {
            _type = type;
            _firstVector = firstVector;
            _secondVector = -1;
            _coefficient = coefficient.Clone() as Complex;
        }

        public SimpleAction(SimpleActionType type, int firstVector, int secondVector, Complex coefficient)
        {
            _type = type;
            _firstVector = firstVector;
            _secondVector = secondVector;
            _coefficient = coefficient.Clone() as Complex;
        }
    }
}
