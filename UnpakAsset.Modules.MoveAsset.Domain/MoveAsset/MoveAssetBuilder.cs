using System;
using UnpakAsset.Common.Domain;

//using UnpakAsset.Modules.Asset.Domain.Abstractions;

namespace UnpakAsset.Modules.MoveAsset.Domain.MoveAsset
{
    public sealed partial class MoveAsset
    {
        public sealed class MoveAssetBuilder
        {
            private readonly MoveAsset _asset;
            private Result? _result;

            public MoveAssetBuilder(MoveAsset asset)
            {
                _asset = asset;
            }

            private bool HasError => _result is not null && _result.IsFailure;

            public Result<MoveAsset> Build()
            {
                if (string.IsNullOrWhiteSpace(_asset.Tipe))
                {
                    _result = Result.Failure<MoveAsset>(MoveAssetErrors.TypeNotFound(_asset.Tipe));
                }

                if (Array.IndexOf(new[] { TypeMove.Group.ToEnumString(), TypeMove.Location.ToEnumString(), TypeMove.Personal.ToEnumString() }, _asset.Tipe) < 0)
                {
                    _result = Result.Failure<MoveAsset>(MoveAssetErrors.TypeIvalid(_asset.Tipe));
                }

                if (_asset.Tiket != null)
                {
                    if (Array.IndexOf(new[] { TypeMove.Group.ToEnumString(), TypeMove.Location.ToEnumString() }, _asset.Tipe) < 0)
                    {
                        _result = Result.Failure<MoveAsset>(MoveAssetErrors.AvailableTypeOnTicket);
                    }

                    if (
                        (_asset.Grup == null || _asset.Grup.Length == 0) &&
                        (_asset.Lokasi == null || _asset.Lokasi.Length == 0)
                    )
                    {
                        _result = Result.Failure<MoveAsset>(MoveAssetErrors.GroupAndLocationNotFound);
                    }

                    if (
                        (_asset.Grup == null || _asset.Grup.Length > 0) &&
                        (_asset.Lokasi == null || _asset.Lokasi.Length > 0)
                    )
                    {
                        _result = Result.Failure<MoveAsset>(MoveAssetErrors.GroupAndLocationInvalidCategory);
                    }

                    if (
                        (_asset.GrupTarget == null || _asset.GrupTarget.Length == 0) &&
                        (_asset.LokasiTarget == null || _asset.LokasiTarget.Length == 0)
                    )
                    {
                        _result = Result.Failure<MoveAsset>(MoveAssetErrors.GroupAndLocationDestinationNotFound);
                    }

                    if (
                        (_asset.GrupTarget == null || _asset.GrupTarget.Length > 0) &&
                        (_asset.LokasiTarget == null || _asset.LokasiTarget.Length > 0)
                    )
                    {
                        _result = Result.Failure<MoveAsset>(MoveAssetErrors.GroupAndLocationDestinationInvalidCategory);
                    }
                }
                else if (_asset.Tipe == TypeMove.Personal.ToEnumString() && string.IsNullOrWhiteSpace(_asset.UserTarget))
                {
                    _result = Result.Failure<MoveAsset>(MoveAssetErrors.TargetUserNotFound);
                }

                if (string.IsNullOrWhiteSpace(_asset.PIC))
                {
                    _result = Result.Failure<MoveAsset>(MoveAssetErrors.PICNotFound);
                }

                if (string.IsNullOrWhiteSpace(_asset.Informasi))
                {
                    _result = Result.Failure<MoveAsset>(MoveAssetErrors.InformationNotFound);
                }

                return HasError ? Result.Failure<MoveAsset>(_result!.Error) : Result.Success(_asset);
            }

            public MoveAssetBuilder ChangeTicket(string? tiket)
            {
                if (HasError) return this;

                _asset.Tiket = tiket;
                return this;
            }

            public MoveAssetBuilder ChangeType(string tipe)
            {
                if (HasError) return this;

                _asset.Tipe = tipe;
                return this;
            }

            public MoveAssetBuilder ChangePIC(string pic)
            {
                if (HasError) return this;

                _asset.PIC = pic;
                return this;
            }

            public MoveAssetBuilder ChangeGroup(string? grup, string? type)
            {
                if (HasError) return this;

                if (type is null) {
                    _asset.Grup = grup;
                } else if (type is "target") {
                    _asset.GrupTarget = grup;
                }
                
                return this;
            }

            public MoveAssetBuilder ChangeSubGroup(string? sub_grup, string? type)
            {
                if (HasError) return this;

                if (type is null)
                {
                    _asset.SubGrup = sub_grup;
                }
                else if (type is "target")
                {
                    _asset.SubGrupTarget = sub_grup;
                }
                return this;
            }

            public MoveAssetBuilder ChangeLocation(string? lokasi, string? type)
            {
                if (HasError) return this;

                if (type is null)
                {
                    _asset.Lokasi = lokasi;
                }
                else if (type is "target")
                {
                    _asset.LokasiTarget = lokasi;
                }
                return this;
            }

            public MoveAssetBuilder ChangeUserTarget(string? user_target)
            {
                if (HasError) return this;

                _asset.UserTarget = user_target;
                
                return this;
            }

            public MoveAssetBuilder ChangeInformation(string informasi)
            {
                if (HasError) return this;

                _asset.Informasi = informasi;
                return this;
            }
        }
    }
}

