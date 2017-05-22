namespace linear_mathematics.Algebra_objects
{
    public abstract class RingElement: AdditiveElement
    {
        #region abstract
        protected abstract RingElement Multiplication(RingElement another);
        #endregion
        #region non-abstract
        public static RingElement operator *(RingElement element1, RingElement element2)
            => element1.Multiplication(element2);
        #endregion
    }
}
