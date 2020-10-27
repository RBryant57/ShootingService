﻿using System;
using System.Collections.Generic;

namespace ShootingService.Models
{
    public partial class ShootingSessionView
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public string ShootingLocationViewName { get; set; }
        public string ShootingLocationViewShootingLocationName { get; set; }
        public string ShootingLocationViewState { get; set; }
        public string ShootingLocationViewLocation { get; set; }
        public string ShootingLocationViewNotes { get; set; }
        public int GunId { get; set; }
        public string GunViewSerialNumber { get; set; }
        public string GunViewName { get; set; }
        public string GunViewGunName { get; set; }
        public int GunViewCaliberId { get; set; }
        public string GunViewCaliberViewName { get; set; }
        public decimal GunViewCaliberViewDiameter { get; set; }
        public int GunViewCaliberViewDiameterUnitId { get; set; }
        public string GunViewCaliberViewDiameterUnitViewName { get; set; }
        public string GunViewCaliberViewDiameterUnitViewPlural { get; set; }
        public string GunViewCaliberViewDiameterUnitViewAbbreviation { get; set; }
        public int GunViewCaliberViewDiameterUnitViewUnitTypeId { get; set; }
        public string GunViewCaliberViewDiameterUnitViewUnitTypeName { get; set; }
        public string GunViewCaliberViewDiameterUnitViewUnitTypeNotes { get; set; }
        public string GunViewCaliberViewDiameterUnitViewNotes { get; set; }
        public decimal GunViewCaliberViewBrassLength { get; set; }
        public int GunViewCaliberViewBrassLengthUnitId { get; set; }
        public string GunViewCaliberViewBrassLengthUnitViewName { get; set; }
        public string GunViewCaliberViewBrassLengthUnitViewPlural { get; set; }
        public string GunViewCaliberViewBrassLengthUnitViewAbbreviation { get; set; }
        public int GunViewCaliberViewBrassLengthUnitViewUnitTypeId { get; set; }
        public string GunViewCaliberViewBrassLengthUnitViewUnitTypeName { get; set; }
        public string GunViewCaliberViewBrassLengthUnitViewUnitTypeNotes { get; set; }
        public string GunViewCaliberViewBrassLengthUnitViewNotes { get; set; }
        public int GunViewCaliberViewPrimerTypeId { get; set; }
        public string GunViewCaliberViewPrimerTypeName { get; set; }
        public string GunViewCaliberViewPrimerTypeAbbreviation { get; set; }
        public string GunViewCaliberViewPrimerTypeNotes { get; set; }
        public int GunViewCaliberViewSortOrder { get; set; }
        public string GunViewCaliberViewNotes { get; set; }
        public int GunViewManufacturerId { get; set; }
        public string GunViewManufacturerName { get; set; }
        public string GunViewManufacturerShortName { get; set; }
        public string GunViewManufacturerAddress { get; set; }
        public string GunViewManufacturerCity { get; set; }
        public string GunViewManufacturerState { get; set; }
        public string GunViewManufacturerZip { get; set; }
        public string GunViewManufacturerUrl { get; set; }
        public string GunViewManufacturerNotes { get; set; }
        public int GunViewSellerId { get; set; }
        public string GunViewSellerName { get; set; }
        public string GunViewSellerShortName { get; set; }
        public string GunViewSellerAddress { get; set; }
        public string GunViewSellerCity { get; set; }
        public string GunViewSellerState { get; set; }
        public string GunViewSellerZip { get; set; }
        public string GunViewSellerUrl { get; set; }
        public string GunViewSellerNotes { get; set; }
        public int? GunViewBuyerId { get; set; }
        public string GunViewBuyerName { get; set; }
        public string GunViewBuyerShortName { get; set; }
        public string GunViewBuyerAddress { get; set; }
        public string GunViewBuyerCity { get; set; }
        public string GunViewBuyerState { get; set; }
        public string GunViewBuyerZip { get; set; }
        public string GunViewBuyerUrl { get; set; }
        public string GunViewBuyerNotes { get; set; }
        public int GunViewCapacity { get; set; }
        public decimal GunViewBarrelLength { get; set; }
        public int GunViewBarrelLengthUnitId { get; set; }
        public string GunViewLengthUnitViewName { get; set; }
        public string GunViewLengthUnitViewPlural { get; set; }
        public string GunViewLengthUnitViewAbbrevation { get; set; }
        public int GunViewLengthUnitViewUnitTypeId { get; set; }
        public string GunViewLengthUnitViewUnitTypeName { get; set; }
        public string GunViewLengthUnitViewUnitTypeNotes { get; set; }
        public string GunViewLengthUnitViewNotes { get; set; }
        public int GunViewGunTypeId { get; set; }
        public string GunViewGunTypeName { get; set; }
        public string GunViewGunTypeNotes { get; set; }
        public decimal GunViewCost { get; set; }
        public DateTime GunViewAcquisitionDate { get; set; }
        public DateTime? GunViewRetireDate { get; set; }
        public string GunViewDetails { get; set; }
        public string GunViewNotes { get; set; }
        public int CartridgeId { get; set; }
        public string CartridgeViewName { get; set; }
        public string CartridgeViewCartridgeName { get; set; }
        public int CartridgeViewCartridgeLoadId { get; set; }
        public string CartridgeViewCartridgeLoadViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewCartridgeLoadName { get; set; }
        public int? CartridgeViewCartridgeLoadViewBulletId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewBulletName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewBulletFullName { get; set; }
        public int? CartridgeViewCartridgeLoadViewBulletViewBulletTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewBulletTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewBulletTypeAbbreviation { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewBulletTypeNotes { get; set; }
        public int? CartridgeViewCartridgeLoadViewBulletViewMaterialId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMaterialName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMaterialNotes { get; set; }
        public decimal? CartridgeViewCartridgeLoadViewBulletViewDiameter { get; set; }
        public int? CartridgeViewCartridgeLoadViewBulletViewDiameterUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewAbbreviation { get; set; }
        public int? CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewNotes { get; set; }
        public int? CartridgeViewCartridgeLoadViewBulletViewMass { get; set; }
        public int? CartridgeViewCartridgeLoadViewBulletViewMassUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMassUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMassUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMassUnitViewAbbreviation { get; set; }
        public int? CartridgeViewCartridgeLoadViewBulletViewMassUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMassUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMassUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMassUnitViewNotes { get; set; }
        public decimal? CartridgeViewCartridgeLoadViewBulletViewSectionalDensity { get; set; }
        public decimal? CartridgeViewCartridgeLoadViewBulletViewBallisticCoefficient { get; set; }
        public decimal? CartridgeViewCartridgeLoadViewBulletViewLength { get; set; }
        public int? CartridgeViewCartridgeLoadViewBulletViewLengthUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewAbbreviation { get; set; }
        public int? CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewNotes { get; set; }
        public int? CartridgeViewCartridgeLoadViewBulletViewManufacturerId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerAddress { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerCity { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerState { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerZip { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerUrl { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewNotes { get; set; }
        public int? CartridgeViewCartridgeLoadViewPowderId { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewPowderName { get; set; }
        public int? CartridgeViewCartridgeLoadViewPowderViewManufacturerId { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerName { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerAddress { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerCity { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerState { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerZip { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerUrl { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerNotes { get; set; }
        public int? CartridgeViewCartridgeLoadViewPowderViewPowderTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewPowderTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewPowderTypeNotes { get; set; }
        public int? CartridgeViewCartridgeLoadViewPowderViewPowderShapeId { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewPowderShapeName { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewPowderShapeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewNotes { get; set; }
        public decimal? CartridgeViewCartridgeLoadViewPowderWeight { get; set; }
        public int? CartridgeViewCartridgeLoadViewPowderWeightUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderWeightUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderWeightUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderWeightUnitViewAbbreviation { get; set; }
        public int? CartridgeViewCartridgeLoadViewPowderWeightUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderWeightUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderWeightUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderWeightUnitViewNotes { get; set; }
        public decimal? CartridgeViewCartridgeLoadViewCol { get; set; }
        public int? CartridgeViewCartridgeLoadViewColunitId { get; set; }
        public string CartridgeViewCartridgeLoadViewColunitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewColunitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewColunitViewAbbreviation { get; set; }
        public int? CartridgeViewCartridgeLoadViewColunitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewColunitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewColunitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewColunitViewNotes { get; set; }
        public int? CartridgeViewCartridgeLoadViewVelocity { get; set; }
        public int? CartridgeViewCartridgeLoadViewVelocityUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewVelocityUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewVelocityUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewVelocityUnitViewAbbreviation { get; set; }
        public int? CartridgeViewCartridgeLoadViewVelocityUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewVelocityUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewVelocityUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewVelocityUnitViewNotes { get; set; }
        public int? CartridgeViewCartridgeLoadViewPressure { get; set; }
        public int? CartridgeViewCartridgeLoadViewPressureUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewPressureUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewPressureUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewPressureUnitViewAbbreviation { get; set; }
        public int? CartridgeViewCartridgeLoadViewPressureUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewPressureUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewPressureUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewPressureUnitViewNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewNotes { get; set; }
        public int CartridgeViewBrassId { get; set; }
        public int? CartridgeViewBrassViewParentId { get; set; }
        public string CartridgeViewBrassViewName { get; set; }
        public string CartridgeViewBrassViewBrassName { get; set; }
        public string CartridgeViewBrassViewBrassFullName { get; set; }
        public string CartridgeViewBrassViewParentBrassFullName { get; set; }
        public int? CartridgeViewBrassViewMaterialId { get; set; }
        public string CartridgeViewBrassViewMaterialName { get; set; }
        public string CartridgeViewBrassViewMaterialNotes { get; set; }
        public int? CartridgeViewBrassViewManufacturerId { get; set; }
        public string CartridgeViewBrassViewManufacturerName { get; set; }
        public string CartridgeViewBrassViewManufacturerAddress { get; set; }
        public string CartridgeViewBrassViewManufacturerCity { get; set; }
        public string CartridgeViewBrassViewManufacturerState { get; set; }
        public string CartridgeViewBrassViewManufacturerZip { get; set; }
        public string CartridgeViewBrassViewManufacturerUrl { get; set; }
        public string CartridgeViewBrassViewManufacturerNotes { get; set; }
        public int? CartridgeViewBrassViewTimesFired { get; set; }
        public string CartridgeViewBrassViewNotes { get; set; }
        public int? CartridgeViewPrimerId { get; set; }
        public string CartridgeViewPrimerViewName { get; set; }
        public string CartridgeViewPrimerViewFullName { get; set; }
        public string CartridgeViewPrimerViewPrimerName { get; set; }
        public int? CartridgeViewPrimerViewPrimerTypeId { get; set; }
        public string CartridgeViewPrimerViewPrimerTypeName { get; set; }
        public string CartridgeViewPrimerViewPrimerTypeAbbreviation { get; set; }
        public string CartridgeViewPrimerViewPrimerTypeNotes { get; set; }
        public int? CartridgeViewPrimerViewManufacturerId { get; set; }
        public string CartridgeViewPrimerViewManufacturerName { get; set; }
        public string CartridgeViewPrimerViewManufacturerAddress { get; set; }
        public string CartridgeViewPrimerViewManufacturerCity { get; set; }
        public string CartridgeViewPrimerViewManufacturerState { get; set; }
        public string CartridgeViewPrimerViewManufacturerZip { get; set; }
        public string CartridgeViewPrimerViewManufacturerUrl { get; set; }
        public string CartridgeViewPrimerViewManufacturerNotes { get; set; }
        public string CartridgeViewPrimerViewNotes { get; set; }
        public int CartridgeViewManufacturerId { get; set; }
        public string CartridgeViewManufacturerName { get; set; }
        public string CartridgeViewManufacturerShortName { get; set; }
        public string CartridgeViewManufacturerAddress { get; set; }
        public string CartridgeViewManufacturerCity { get; set; }
        public string CartridgeViewManufacturerState { get; set; }
        public string CartridgeViewManufacturerZip { get; set; }
        public string CartridgeViewManufacturerUrl { get; set; }
        public string CartridgeViewManufacturerNotes { get; set; }
        public string CartridgeViewNotes { get; set; }
        public int Rounds { get; set; }
        public int? Retention { get; set; }
        public string Notes { get; set; }
    }
}
