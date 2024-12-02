using UnpakAsset.Common.Domain;

//using UnpakAsset.Modules.Asset.Domain.Abstractions;

namespace UnpakAsset.Modules.Asset.Domain.Asset
{
    public sealed partial class Asset
    {
        public sealed class AssetBuilder
        {
            private readonly Asset _asset;
            private Result? _result;

            public AssetBuilder(Asset asset)
            {
                _asset = asset;
            }

            private bool HasError => _result is not null && _result.IsFailure;

            public Result<Asset> Build()
            {
                return HasError ? Result.Failure<Asset>(_result!.Error) : Result.Success(_asset);
            }

            public AssetBuilder ChangeNama(string nama)
            {
                if (HasError) return this;

                if (string.IsNullOrWhiteSpace(nama))
                {
                    _result = Result.Failure<Asset>(AssetErrors.NamaNotFound);
                    return this;
                }

                _asset.Nama = nama;
                return this;
            }

            public AssetBuilder ChangeTanggalTerdaftar(string tanggalTerdaftar)
            {
                if (HasError) return this;

                if (!DateTime.TryParse(tanggalTerdaftar, out var tanggal))
                {
                    _result = Result.Failure<Asset>(AssetErrors.TanggalTerdaftarInvalidDate);
                    return this;
                }

                _asset.TanggalTerdaftar = tanggal;
                return this;
            }

            public AssetBuilder ChangeKondisi(string kondisi)
            {
                if (HasError) return this;

                if (Array.IndexOf(new[] { KondisiAsset.Baru.ToEnumString(), KondisiAsset.Bekas.ToEnumString() }, kondisi) < 0)
                {
                    _result = Result.Failure<Asset>(AssetErrors.ConditionInvalidType(kondisi));
                    return this;
                }

                _asset.Kondisi = kondisi;
                return this;
            }

            public AssetBuilder ChangeKodeAsset(string kodeAsset)
            {
                if (HasError) return this;

                if (string.IsNullOrWhiteSpace(kodeAsset))
                {
                    _result = Result.Failure<Asset>(AssetErrors.KodeAsetNotFound);
                    return this;
                }

                _asset.KodeAsset = kodeAsset;
                return this;
            }

            public AssetBuilder ChangeGrup(string? grup)
            {
                if (!HasError) _asset.Grup = grup;
                return this;
            }

            public AssetBuilder ChangeSubGrup(string? subGrup)
            {
                if (!HasError) _asset.SubGrup = subGrup;
                return this;
            }

            public AssetBuilder ChangeLokasi(string? lokasi)
            {
                if (!HasError) _asset.Lokasi = lokasi;
                return this;
            }

            public AssetBuilder CheckGroupOrLocation()
            {
                if (_asset.Grup != null && _asset.Lokasi != null)
                {
                    _result = Result.Failure<Asset>(AssetErrors.GroupAndLocationInvalidCategory);
                    return this;
                }
                else if (_asset.Grup == null && _asset.Lokasi == null)
                {
                    _result = Result.Failure<Asset>(AssetErrors.GroupAndLocationNotFound);
                    return this;
                }
                return this;
            }

            public AssetBuilder ChangePO(string? po)
            {
                if (HasError) return this;

                if (string.IsNullOrWhiteSpace(po))
                {
                    _result = Result.Failure<Asset>(AssetErrors.PONotFound);
                    return this;
                }

                _asset.PO = po;
                return this;
            }

            public AssetBuilder ChangeHargaPerUnit(decimal hargaPerUnit)
            {
                if (HasError) return this;

                if (hargaPerUnit <= 0)
                {
                    _result = Result.Failure<Asset>(AssetErrors.HargaPerUnitInvalidNumber);
                    return this;
                }

                _asset.HargaPerUnit = hargaPerUnit;
                return this;
            }

            public AssetBuilder ChangeTotalUnit(int totalUnit)
            {
                if (HasError) return this;

                if (totalUnit < 0)
                {
                    _result = Result.Failure<Asset>(AssetErrors.TotalUnitInvalidNumber);
                    return this;
                }

                _asset.TotalUnit = totalUnit;
                return this;
            }
        }
    }
}

