using UnpakAsset.Common.Domain;

//using UnpakAsset.Modules.Asset.Domain.Abstractions;

namespace UnpakAsset.Modules.PhysicalAsset.Domain.PhysicalAsset
{
    public sealed partial class PhysicalAsset
    {
        public sealed class PhysicalAssetBuilder
        {
            private readonly PhysicalAsset _asset;
            private Result? _result;

            public PhysicalAssetBuilder(PhysicalAsset asset)
            {
                _asset = asset;
            }

            private bool HasError => _result is not null && _result.IsFailure;

            public Result<PhysicalAsset> Build()
            {
                if (string.IsNullOrWhiteSpace(_asset.Tipe))
                {
                    _result = Result.Failure<PhysicalAsset>(PhysicalAssetErrors.TypeNotFound(_asset.Tipe));
                }

                if (string.IsNullOrWhiteSpace(_asset.Tipe))
                {
                    _result = Result.Failure<PhysicalAsset>(PhysicalAssetErrors.TypeNotFound(_asset.Tipe));
                }

                if (Array.IndexOf(new[] { TypePhysical.Group.ToEnumString(), TypePhysical.Location.ToEnumString()}, _asset.Tipe) < 0)
                {
                    _result = Result.Failure<PhysicalAsset>(PhysicalAssetErrors.TypeIvalid(_asset.Tipe));
                }

                if (
                        (_asset.Grup == null || _asset.Grup.Length == 0) &&
                        (_asset.Lokasi == null || _asset.Lokasi.Length == 0)
                    )
                {
                    _result = Result.Failure<PhysicalAsset>(PhysicalAssetErrors.GroupAndLocationNotFound);
                }

                if (
                    (_asset.Grup?.Length > 0) &&
                    (_asset.Lokasi?.Length > 0)
                )
                {
                    _result = Result.Failure<PhysicalAsset>(PhysicalAssetErrors.GroupAndLocationInvalidCategory);
                }

                if (
                    _asset.Tipe == TypePhysical.Group.ToEnumString() &&
                    (_asset.Grup?.Length == 0)
                )
                {
                    _result = Result.Failure<PhysicalAsset>(PhysicalAssetErrors.GroupNotFound);
                }

                if (
                    _asset.Tipe == TypePhysical.Location.ToEnumString() &&
                    (_asset.Lokasi?.Length == 0)
                )
                {
                    _result = Result.Failure<PhysicalAsset>(PhysicalAssetErrors.LocationNotFound);
                }

                if (string.IsNullOrWhiteSpace(_asset.PIC))
                {
                    _result = Result.Failure<PhysicalAsset>(PhysicalAssetErrors.PICNotFound);
                }

                if (string.IsNullOrWhiteSpace(_asset.Informasi))
                {
                    _result = Result.Failure<PhysicalAsset>(PhysicalAssetErrors.InformationNotFound);
                }

                return HasError ? Result.Failure<PhysicalAsset>(_result!.Error) : Result.Success(_asset);
            }

            public PhysicalAssetBuilder ChangeType(string tipe)
            {
                if (HasError) return this;

                _asset.Tipe = tipe;
                return this;
            }

            public PhysicalAssetBuilder ChangeTanggalMulai(string tanggal_mulai)
            {
                if (HasError) return this;

                DateTime _tanggal_mulai;
                try
                {
                    _tanggal_mulai = DateTime.Parse(tanggal_mulai);
                    _asset.TanggalMulai = _tanggal_mulai;
                }
                catch (Exception e)
                {
                    _result = Result.Failure<PhysicalAsset>(PhysicalAssetErrors.InvalidDate("tanggal mulai"));
                }

                return this;
            }

            public PhysicalAssetBuilder ChangeTanggalAkhir(string tanggal_akhir)
            {
                if (HasError) return this;

                DateTime _tanggal_akhir;
                try
                {
                    _tanggal_akhir = DateTime.Parse(tanggal_akhir);
                    _asset.TanggalAkhir = _tanggal_akhir;
                }
                catch (Exception e)
                {
                    _result = Result.Failure<PhysicalAsset>(PhysicalAssetErrors.InvalidDate("tanggal akhir"));
                }

                return this;
            }

            public PhysicalAssetBuilder ChangePIC(string pic)
            {
                if (HasError) return this;

                _asset.PIC = pic;
                return this;
            }

            public PhysicalAssetBuilder ChangeGroup(string? grup, string? type)
            {
                if (HasError) return this;

                _asset.Grup = grup;

                return this;
            }

            public PhysicalAssetBuilder ChangeSubGroup(string? sub_grup, string? type)
            {
                if (HasError) return this;

                _asset.SubGrup = sub_grup;

                return this;
            }

            public PhysicalAssetBuilder ChangeLocation(string? lokasi, string? type)
            {
                if (HasError) return this;

                _asset.Lokasi = lokasi;

                return this;
            }

            public PhysicalAssetBuilder ChangeInformation(string informasi)
            {
                if (HasError) return this;

                _asset.Informasi = informasi;
                return this;
            }
        }
    }
}

