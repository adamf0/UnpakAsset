using System.ComponentModel.DataAnnotations.Schema;
using UnpakAsset.Common.Domain;

//using UnpakAsset.Modules.Asset.Domain.Abstractions;

namespace UnpakAsset.Modules.Tag.Domain.Group
{
    public sealed partial class Group : Entity
    {
        private Group()
        {
        }

        [Column(TypeName = "VARCHAR(36)")]
        public Guid Id { get; private set; }
        [Column(TypeName = "VARCHAR(36)")]
        public string Nama { get; private set; } = null!;
        public static GroupBuilder Update(Group prev) => new GroupBuilder(prev);

        public static Result<Group> Create(
        string nama
        )
        {
            if (string.IsNullOrWhiteSpace(nama))
            {
                return Result.Failure<Group>(GroupErrors.NamaNotFound);
            }

            var group = new Group
            {
                Id = Guid.NewGuid(),
                Nama = nama,
            };

            group.Raise(new GroupCreatedDomainEvent(group.Id));

            return group;
        }
    }
}

