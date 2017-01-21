using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent
{
    public class ObjectMemberAccessor<T, V> : MonadicValue<V>
    {
        private readonly MemberAccessor<T, V> _accessor;
        private readonly T _obj;

        public ObjectMemberAccessor(MemberAccessor<T, V> accessor, T obj) 
        {
            _accessor = accessor;
            _obj = obj;
        }

        public override V Value => _accessor.GetValue(_obj);

        public ObjectMemberAccessor<T, V> Apply(V value)
        {
            _accessor.SetValue(_obj, value);
            return this;
        }
    }

}