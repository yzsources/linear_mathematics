namespace linear_mathematics.Algebra_objects
{
    public abstract class OrderedFieldElement : FieldElement
    {
        #region abstract
        public abstract bool BiggerThanZero();
        public abstract bool LesserThanZero();
        #endregion
        #region non-abstract
        public static bool operator > (OrderedFieldElement element1, OrderedFieldElement element2)
            => ((OrderedFieldElement)(element1 - element2)).BiggerThanZero();
        public static bool operator <(OrderedFieldElement element1, OrderedFieldElement element2)
            => ((OrderedFieldElement)(element1 - element2)).LesserThanZero();
        public static bool operator >=(OrderedFieldElement element1, OrderedFieldElement element2)
            => !((OrderedFieldElement)(element1 - element2)).LesserThanZero();
        public static bool operator <=(OrderedFieldElement element1, OrderedFieldElement element2)
            => !((OrderedFieldElement)(element1 - element2)).BiggerThanZero();
        public static OrderedFieldElement Max(OrderedFieldElement element1, OrderedFieldElement element2)
            => (element1 > element2) ? element1 : element2;
        public static OrderedFieldElement Min(OrderedFieldElement element1, OrderedFieldElement element2)
            => (element1 < element2) ? element1 : element2;
        public static OrderedFieldElement Abs(OrderedFieldElement element) 
            => Max(element, (OrderedFieldElement)(-(element))); 
        #endregion
    }
}
