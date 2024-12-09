using UnpakAsset.Common.Domain;

//using UnpakAsset.Modules.Asset.Domain.Abstractions;

namespace UnpakAsset.Modules.RepairAsset.Domain.RepairAsset
{
    public sealed partial class RepairAsset
    {
        public sealed class RepairAssetBuilder
        {
            private readonly RepairAsset _asset;
            private Result? _result;

            public RepairAssetBuilder(RepairAsset asset)
            {
                _asset = asset;
            }

            private bool HasError => _result is not null && _result.IsFailure;

            public Result<RepairAsset> Build()
            {
                if (string.IsNullOrWhiteSpace(_asset.Tipe))
                {
                    _result = Result.Failure<RepairAsset>(RepairAssetErrors.TypeNotFound(_asset.Tipe));
                }

                if (string.IsNullOrWhiteSpace(_asset.Tipe))
                {
                    _result = Result.Failure<RepairAsset>(RepairAssetErrors.TypeNotFound(_asset.Tipe));
                }

                if (Array.IndexOf(new[] { TypePhysical.Group.ToEnumString(), TypePhysical.Location.ToEnumString()}, _asset.Tipe) < 0)
                {
                    _result = Result.Failure<RepairAsset>(RepairAssetErrors.TypeIvalid(_asset.Tipe));
                }

                if (
                        (_asset.Grup == null || _asset.Grup.Length == 0) &&
                        (_asset.Lokasi == null || _asset.Lokasi.Length == 0)
                    )
                {
                    _result = Result.Failure<RepairAsset>(RepairAssetErrors.GroupAndLocationNotFound);
                }

                if (
                    (_asset.Grup?.Length > 0) &&
                    (_asset.Lokasi?.Length > 0)
                )
                {
                    _result = Result.Failure<RepairAsset>(RepairAssetErrors.GroupAndLocationInvalidCategory);
                }

                if (
                    _asset.Tipe == TypePhysical.Group.ToEnumString() &&
                    (_asset.Grup?.Length == 0)
                )
                {
                    _result = Result.Failure<RepairAsset>(RepairAssetErrors.GroupNotFound);
                }

                if (
                    _asset.Tipe == TypePhysical.Location.ToEnumString() &&
                    (_asset.Lokasi?.Length == 0)
                )
                {
                    _result = Result.Failure<RepairAsset>(RepairAssetErrors.LocationNotFound);
                }

                if (string.IsNullOrWhiteSpace(_asset.PIC))
                {
                    _result = Result.Failure<RepairAsset>(RepairAssetErrors.PICNotFound);
                }

                if (string.IsNullOrWhiteSpace(_asset.Informasi))
                {
                    _result = Result.Failure<RepairAsset>(RepairAssetErrors.InformationNotFound);
                }

                return HasError ? Result.Failure<RepairAsset>(_result!.Error) : Result.Success(_asset);
            }

            public RepairAssetBuilder ChangeType(string tipe)
            {
                if (HasError) return this;

                _asset.Tipe = tipe;
                return this;
            }

            public RepairAssetBuilder ChangePIC(string pic)
            {
                if (HasError) return this;

                _asset.PIC = pic;
                return this;
            }

            public RepairAssetBuilder ChangeGroup(string? grup, string? type)
            {
                if (HasError) return this;

                _asset.Grup = grup;

                return this;
            }

            public RepairAssetBuilder ChangeSubGroup(string? sub_grup, string? type)
            {
                if (HasError) return this;

                _asset.SubGrup = sub_grup;

                return this;
            }

            public RepairAssetBuilder ChangeLocation(string? lokasi, string? type)
            {
                if (HasError) return this;

                _asset.Lokasi = lokasi;

                return this;
            }

            public RepairAssetBuilder ChangeInformation(string informasi)
            {
                if (HasError) return this;

                _asset.Informasi = informasi;
                return this;
            }
        }
    }
}

