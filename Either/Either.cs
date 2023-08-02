namespace Either
{
    public record Either<TA, TB>
    {
        private sealed record A(TA Value) : Either<TA, TB>;

        private sealed record B(TB Value) : Either<TA, TB>;

        static public implicit operator Either<TA, TB>(TA value) =>
            new A(value);

        static public implicit operator Either<TA, TB>(TB value) =>
            new B(value);

        public T Match<T>(
            Func<TA, T> ifA,
            Func<TB, T> ifB) => this switch
            {
                A a => ifA(a.Value),
                B b => ifB(b.Value),
            };
    }
}
