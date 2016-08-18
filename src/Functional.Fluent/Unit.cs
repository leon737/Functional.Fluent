namespace Functional.Fluent
{
    public struct Unit
    {
        public override bool Equals(object obj) => obj is Unit;
        
        public bool Equals(Unit other) => true;

        public static bool operator == (Unit lhs, Unit rhs) => true;

        public static bool operator !=(Unit lhs, Unit rhs) => false;

        public override int GetHashCode() => 0;
    }    
}