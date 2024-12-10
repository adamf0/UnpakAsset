using UnpakAsset.Common.Domain;

//using UnpakAsset.Modules.Asset.Domain.Abstractions;

namespace UnpakAsset.Modules.DisposalAsset.Domain.DisposalAsset
{
    public sealed partial class DisposalAsset
    {
        public sealed class DisposalAssetBuilder
        {
            private readonly DisposalAsset _asset;
            private Result? _result;

            public DisposalAssetBuilder(DisposalAsset asset)
            {
                _asset = asset;
            }

            private bool HasError => _result is not null && _result.IsFailure;

            public Result<DisposalAsset> Build()
            {
                if (string.IsNullOrWhiteSpace(_asset.Tipe))
                {
                    _result = Result.Failure<DisposalAsset>(DisposalAssetErrors.TypeNotFound(_asset.Tipe));
                }

                if (Array.IndexOf(new[] { TypePhysical.Group.ToEnumString(), TypePhysical.Location.ToEnumString()}, _asset.Tipe) < 0)
                {
                    _result = Result.Failure<DisposalAsset>(DisposalAssetErrors.TypeIvalid(_asset.Tipe));
                }

                if (
                        (_asset.Grup == null || _asset.Grup.Length == 0) &&
                        (_asset.Lokasi == null || _asset.Lokasi.Length == 0)
                    )
                {
                    _result = Result.Failure<DisposalAsset>(DisposalAssetErrors.GroupAndLocationNotFound);
                }

                if (
                    (_asset.Grup?.Length > 0) &&
                    (_asset.Lokasi?.Length > 0)
                )
                {
                    _result = Result.Failure<DisposalAsset>(DisposalAssetErrors.GroupAndLocationInvalidCategory);
                }

                if (
                    _asset.Tipe == TypePhysical.Group.ToEnumString() &&
                    (_asset.Grup?.Length == 0)
                )
                {
                    _result = Result.Failure<DisposalAsset>(DisposalAssetErrors.GroupNotFound);
                }

                if (
                    _asset.Tipe == TypePhysical.Location.ToEnumString() &&
                    (_asset.Lokasi?.Length == 0)
                )
                {
                    _result = Result.Failure<DisposalAsset>(DisposalAssetErrors.LocationNotFound);
                }

                if (string.IsNullOrWhiteSpace(_asset.PIC))
                {
                    _result = Result.Failure<DisposalAsset>(DisposalAssetErrors.PICNotFound);
                }

                if (string.IsNullOrWhiteSpace(_asset.Informasi))
                {
                    _result = Result.Failure<DisposalAsset>(DisposalAssetErrors.InformationNotFound);
                }

                return HasError ? Result.Failure<DisposalAsset>(_result!.Error) : Result.Success(_asset);
            }

            public DisposalAssetBuilder ChangeTicket(string tiket)
            {
                if (HasError) return this;

                _asset.Tiket = tiket;
                return this;
            }

            public DisposalAssetBuilder ChangeType(string tipe)
            {
                if (HasError) return this;

                _asset.Tipe = tipe;
                return this;
            }

            public DisposalAssetBuilder ChangePIC(string pic)
            {
                if (HasError) return this;

                _asset.PIC = pic;
                return this;
            }

            public DisposalAssetBuilder ChangeGroup(string? grup, string? type)
            {
                if (HasError) return this;

                _asset.Grup = grup;

                return this;
            }

            public DisposalAssetBuilder ChangeSubGroup(string? sub_grup, string? type)
            {
                if (HasError) return this;

                _asset.SubGrup = sub_grup;

                return this;
            }

            public DisposalAssetBuilder ChangeLocation(string? lokasi, string? type)
            {
                if (HasError) return this;

                _asset.Lokasi = lokasi;

                return this;
            }

            public DisposalAssetBuilder ChangeInformation(string informasi)
            {
                if (HasError) return this;

                _asset.Informasi = informasi;
                return this;
            }
        }
    }
}

