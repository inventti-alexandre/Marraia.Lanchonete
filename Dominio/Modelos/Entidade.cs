using Newtonsoft.Json;
using System;

namespace Dominio.Modelos
{
    public abstract class Entidade : IEquatable<Entidade>
    {
        /// <summary>
        /// Identificador da entidade
        /// </summary>
        [JsonProperty(Order = -2)] // Garante que será serializado primeiro
        public int Id { get; protected set; }

        public bool Equals(Entidade obj)
        {
            var compareTo = obj as Entidade;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entidade))
                return false;

            return Equals(obj as Entidade);
        }

        public static bool operator ==(Entidade a, Entidade b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entidade a, Entidade b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}
