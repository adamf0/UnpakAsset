using UnpakAsset.Common.Domain;
using UnpakAsset.Modules.Tag.Domain.Group;

//using UnpakAsset.Modules.Asset.Domain.Abstractions;

namespace UnpakAsset.Modules.Tag.Domain.Group
{
    public sealed partial class Group
    {
        public sealed class GroupBuilder
        {
            private readonly Group _group;
            private Result? _result;

            public GroupBuilder(Group group)
            {
                _group = group;
            }

            private bool HasError => _result is not null && _result.IsFailure;

            public Result<Group> Build()
            {
                return HasError ? Result.Failure<Group>(_result!.Error) : Result.Success(_group);
            }

            public GroupBuilder ChangeNama(string nama)
            {
                if (HasError) return this;

                if (string.IsNullOrWhiteSpace(nama))
                {
                    _result = Result.Failure<Group>(GroupErrors.NamaNotFound);
                    return this;
                }

                _group.Nama = nama;
                return this;
            }
        }
    }
}

