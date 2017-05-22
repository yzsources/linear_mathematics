namespace linear_mathematics.Algebra_objects
{
    public abstract class AdditiveElement
    {
        #region abstract
        protected abstract AdditiveElement Addition(AdditiveElement another);
        public abstract bool IfZero();
        public abstract AdditiveElement SumInversed { get; }
        #endregion
        #region non-abstract
        public static AdditiveElement operator + (AdditiveElement element1, AdditiveElement element2)
            => element1.Addition(element2);
        public static AdditiveElement operator - (AdditiveElement element1, AdditiveElement element2)
            => element1.Addition(element2.SumInversed);
        public static AdditiveElement operator - (AdditiveElement element)
            => element.SumInversed;
        #endregion
    }
}
