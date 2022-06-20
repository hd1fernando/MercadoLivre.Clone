using FluentMigrator;
using System;

namespace MercadoLivre.Clone.Data.Migrations
{
    public class MercadoLivreMigrationAttribute : MigrationAttribute
    {
        public MercadoLivreMigrationAttribute(long version, string description) : base(version, description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));

            var versionLength = 14;
            if (version.ToString().Length != versionLength)
                throw new ArgumentException($"{nameof(version)} deve ter {versionLength} caracteres");
        }
    }
}
