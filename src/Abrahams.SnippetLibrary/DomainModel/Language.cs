using System;
using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.DomainModel
{
    public class Language : IEquatable<Language>
    { 
        public int Id { get; set; } = Constants.UnknownId;
        public string Name { get; set; } = string.Empty;
        public const int LanguageMaxLength = 30;

        public override bool Equals(object obj)
        {
            return Equals(obj as Language);
        }

        public bool Equals(Language other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public static bool operator ==(Language left, Language right)
        {
            return EqualityComparer<Language>.Default.Equals(left, right);
        }

        public static bool operator !=(Language left, Language right)
        {
            return !(left == right);
        }
    }
}
