namespace Functional.Fluent.MonadicTypes
{
    public class TrackValue<T> : MonadicValue<T>
    {

        public bool HasChanges { get; protected set; }

        public TrackValue(T value)  : this (value, false) { }

        internal TrackValue(T value, bool hasChanges) : base(value)
        {
            HasChanges = hasChanges;
        }


    }
}