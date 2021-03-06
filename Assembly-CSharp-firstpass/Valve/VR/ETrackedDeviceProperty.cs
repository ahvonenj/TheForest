using System;

namespace Valve.VR
{
	public enum ETrackedDeviceProperty
	{
		Prop_TrackingSystemName_String = 1000,
		Prop_ModelNumber_String,
		Prop_SerialNumber_String,
		Prop_RenderModelName_String,
		Prop_WillDriftInYaw_Bool,
		Prop_ManufacturerName_String,
		Prop_TrackingFirmwareVersion_String,
		Prop_HardwareRevision_String,
		Prop_AllWirelessDongleDescriptions_String,
		Prop_ConnectedWirelessDongle_String,
		Prop_DeviceIsWireless_Bool,
		Prop_DeviceIsCharging_Bool,
		Prop_DeviceBatteryPercentage_Float,
		Prop_StatusDisplayTransform_Matrix34,
		Prop_Firmware_UpdateAvailable_Bool,
		Prop_Firmware_ManualUpdate_Bool,
		Prop_Firmware_ManualUpdateURL_String,
		Prop_HardwareRevision_Uint64,
		Prop_FirmwareVersion_Uint64,
		Prop_FPGAVersion_Uint64,
		Prop_VRCVersion_Uint64,
		Prop_RadioVersion_Uint64,
		Prop_DongleVersion_Uint64,
		Prop_BlockServerShutdown_Bool,
		Prop_CanUnifyCoordinateSystemWithHmd_Bool,
		Prop_ContainsProximitySensor_Bool,
		Prop_DeviceProvidesBatteryStatus_Bool,
		Prop_DeviceCanPowerOff_Bool,
		Prop_Firmware_ProgrammingTarget_String,
		Prop_DeviceClass_Int32,
		Prop_HasCamera_Bool,
		Prop_ReportsTimeSinceVSync_Bool = 2000,
		Prop_SecondsFromVsyncToPhotons_Float,
		Prop_DisplayFrequency_Float,
		Prop_UserIpdMeters_Float,
		Prop_CurrentUniverseId_Uint64,
		Prop_PreviousUniverseId_Uint64,
		Prop_DisplayFirmwareVersion_Uint64,
		Prop_IsOnDesktop_Bool,
		Prop_DisplayMCType_Int32,
		Prop_DisplayMCOffset_Float,
		Prop_DisplayMCScale_Float,
		Prop_EdidVendorID_Int32,
		Prop_DisplayMCImageLeft_String,
		Prop_DisplayMCImageRight_String,
		Prop_DisplayGCBlackClamp_Float,
		Prop_EdidProductID_Int32,
		Prop_CameraToHeadTransform_Matrix34,
		Prop_DisplayGCType_Int32,
		Prop_DisplayGCOffset_Float,
		Prop_DisplayGCScale_Float,
		Prop_DisplayGCPrescale_Float,
		Prop_DisplayGCImage_String,
		Prop_LensCenterLeftU_Float,
		Prop_LensCenterLeftV_Float,
		Prop_LensCenterRightU_Float,
		Prop_LensCenterRightV_Float,
		Prop_UserHeadToEyeDepthMeters_Float,
		Prop_CameraFirmwareVersion_Uint64,
		Prop_CameraFirmwareDescription_String,
		Prop_DisplayFPGAVersion_Uint64,
		Prop_DisplayBootloaderVersion_Uint64,
		Prop_DisplayHardwareVersion_Uint64,
		Prop_AudioFirmwareVersion_Uint64,
		Prop_AttachedDeviceId_String = 3000,
		Prop_SupportedButtons_Uint64,
		Prop_Axis0Type_Int32,
		Prop_Axis1Type_Int32,
		Prop_Axis2Type_Int32,
		Prop_Axis3Type_Int32,
		Prop_Axis4Type_Int32,
		Prop_FieldOfViewLeftDegrees_Float = 4000,
		Prop_FieldOfViewRightDegrees_Float,
		Prop_FieldOfViewTopDegrees_Float,
		Prop_FieldOfViewBottomDegrees_Float,
		Prop_TrackingRangeMinimumMeters_Float,
		Prop_TrackingRangeMaximumMeters_Float,
		Prop_ModeLabel_String,
		Prop_VendorSpecific_Reserved_Start = 10000,
		Prop_VendorSpecific_Reserved_End = 10999
	}
}
