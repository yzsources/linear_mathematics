namespace linear_mathematics.Test_objects
{
    public abstract class Abstract
    {
        protected abstract Abstract Add(Abstract another);

        public static Abstract operator + (Abstract first, Abstract second)
        {
            return first.Add(second);
        }
        public static Abstract Twice(Abstract element) => element + element;
    }
}
