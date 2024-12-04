using UnpakAsset.Common.Domain;

namespace UnpakAsset.Modules.AssignAsset.Domain.AssignAsset
{
    public sealed partial class AssignAsset
    {
        public sealed class AssignAssetBuilder
        {
            private readonly AssignAsset _asset;
            private Result? _result;
            private bool isSub = false;
            private List<string> data_target = new List<string>();
            private List<string> empty_target = new List<string>() { "nidn", "nip", "fakultas", "prodi", "unit" };

            public AssignAssetBuilder(AssignAsset asset)
            {
                _asset = asset;
            }

            private bool HasError => _result is not null && _result.IsFailure;

            public Result<AssignAsset> Build()
            {
                if (data_target.Count >2 || (isSub && data_target.Count > 2) )
                {
                    _result = Result.Failure<AssignAsset>(AssignAssetErrors.RejectMultiTargetAssign);
                }
                else if (data_target.Count > 0 && empty_target.Count == 0)
                {
                    _result = Result.Failure<AssignAsset>(AssignAssetErrors.TargetAssignNotFound);
                }
                else if (_asset.IsChange)
                {
                    _result = Result.Failure<AssignAsset>(AssignAssetErrors.TargetAssignNotInPosition);
                }

                return HasError ? Result.Failure<AssignAsset>(_result!.Error) : Result.Success(_asset);
            }

            public AssignAssetBuilder ChangeNidn(string? nidn)
            {
                if (HasError) return this;

                if (!string.IsNullOrEmpty(nidn))
                {
                    _asset.Nidn = nidn;
                    data_target.Add(nidn);
                    empty_target.Remove("nidn");
                }

                return this;
            }

            public AssignAssetBuilder ChangeNip(string? nip)
            {
                if (HasError) return this;

                if (!string.IsNullOrEmpty(nip))
                {
                    _asset.Nip = nip;
                    data_target.Add(nip);
                    empty_target.Remove("nip");
                }

                return this;
            }

            public AssignAssetBuilder ChangeFakultas(string? fakultas)
            {
                if (HasError) return this;

                if (!string.IsNullOrEmpty(fakultas))
                {
                    _asset.Fakultas = fakultas;
                    data_target.Add(fakultas);
                    empty_target.Remove("fakultas");
                }

                return this;
            }

            public AssignAssetBuilder ChangeProdi(string? prodi)
            {
                if (HasError) return this;

                if (!string.IsNullOrEmpty(prodi))
                {
                    _asset.Prodi = prodi;
                    data_target.Add(prodi);
                    isSub = true;
                    empty_target.Remove("prodi");
                }
                else
                {
                    isSub = false;
                }

                return this;
            }

            public AssignAssetBuilder ChangeUnit(string? unit)
            {
                if (HasError) return this;

                if (!string.IsNullOrEmpty(unit))
                {
                    _asset.Unit = unit;
                    data_target.Add(unit);
                    empty_target.Remove("unit");
                }

                return this;
            }

            public AssignAssetBuilder ChangeBarcode(string barcode)
            {
                if (HasError) return this;

                if (string.IsNullOrWhiteSpace(barcode))
                {
                    _result = Result.Failure<AssignAsset>(AssignAssetErrors.BarcodeNotFound);
                    return this;
                }

                _asset.Barcode = barcode;
                return this;
            }
        }
    }
}
