/***************************************************************************************/
// ©Copyright 2016 HID Global Corporation/ASSA ABLOY AB. ALL RIGHTS RESERVED.
//
// For a list of applicable patents and patents pending, visit www.hidglobal.com/patents/
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN 
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//
/***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace ValleVerdeComun.Programacion.Huellas.Recursos
{
    public static class LumiSDKWrapper
    {


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void LumiPreviewCallbackDelegate(IntPtr pOutputImage,
                                                            int width,
                                                            int height,
                                                            int imgNum);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int LumiAcqStatusCallbackDelegate(LumiSDKWrapper.LUMI_ACQ_STATUS status);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int LumiPresenceDetectCallbackDelegate(IntPtr pImage,
                                                            int width,
                                                            int height,
                                                            uint status);

        ////////////////////////////////////////////////////////////////////////
        // LumiAPI functions (C API)
        ////////////////////////////////////////////////////////////////////////        
        public const string LUMI_API_DLL = "LumiAPI.dll";

        // LumiAPI.dll is loaded in the Main() function of the Program.cs for the 
        // CSharpExample.exe
        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiQueryNumberDevices(ref uint nNumDevices,  
                                                                StringBuilder strIPList);
  
        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiQueryDevice(uint deviceToQuery, 
                                                            ref LUMI_DEVICE dev);
        
        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiInit(uint hDevHandle,
                                                    ref uint hHandle);

        
        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiGetImageParams(uint hHandle,
                                                    ref uint nWidth,
                                                    ref uint nHeight,
                                                    ref uint nBPP,
                                                    ref uint nDPI);

        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiCapture(uint hHandle, 
                                                    byte[] pOutputImage,
                                                    ref int nSpoof,
                                                    LumiPreviewCallbackDelegate pCallbackFunc);

        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiCaptureEx(uint hHandle,
                                                    byte[] pOutputImage,
                                                    byte[] pTemplate,
                                                    ref uint nTemplateLength,
                                                    ref int nSpoof,
                                                    LumiPreviewCallbackDelegate pCallbackFunc);

        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiSetOption(uint hHandle,
                                                    LUMI_OPTIONS option,
                                                    IntPtr pArgument,
                                                    uint nArgumentSize);

        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus LumiSetDCOptions(uint hHandle,
											   string pFolderToSaveTo,
											   byte bOverwriteExistingFiles);//byte to make sure its a C++ bool

        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus LumiSaveLastCapture(uint hHandle,
												  string pUserIdentifier,
												  uint  nFinger,
												  uint  nInstance);

        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus LumiGetQualityMap(uint hHandle, byte[] pQualityMap);

        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus GetProcessingMode(uint hHandle, ref LUMI_PROCESSING_MODE processingMode);

        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus SetProcessingMode(uint hHandle, LUMI_PROCESSING_MODE processingMode);
											
        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus LumiDetectFinger(uint hHandle,
                                               ref LUMI_ACQ_STATUS nStatus, 
											   LumiAcqStatusCallbackDelegate func);

        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus LumiVerify(uint hHandle,
                                                    byte[] pInputTemplate,
                                                    uint nInputTemplateLength,
                                                    ref int nSpoof,
                                                    ref uint nScore);

        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiMatch(uint hHandle,
                                                    byte[] pProbeTemplate,
                                                    ref uint nProbeTemplateLength,
                                                    byte[] pGalleryTemplate,
                                                    ref uint nGalleryTemplateLength,
                                                    ref uint nMatchScore,
                                                    ref int nSpoofScore);

        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus LumiExtract(uint hHandle,
                                                    byte[] pImageBuffer,
                                                    uint nWidth,
                                                    uint nHeight,
                                                    uint nDPI,
                                                    byte[] pTemplate,
                                                    ref uint nTemplateLength);

        // LumiSetOption declared for the Presence Detection callback funtion.
        // A more generic declaration for LumiSetOption is in LumiSDKSetOption.cs.

        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiGetDeviceCaps(uint hHandle, ref LUMI_DEVICE_CAPS dCaps);

        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus LumiGetDeviceState(uint hHandle, ref LUMI_DEVICE_STATE dState);

        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus LumiSetLED(uint hHandle, LUMI_LED_CONTROL LED);

        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus LumiSnapShot(uint hHandle,
											         byte[] image,
											         int exposure,
											         int gain );
        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus LumiSetLiveMode(uint hHandle, uint mode, LumiPreviewCallbackDelegate pCallbackFunc);

        [DllImport(LUMI_API_DLL)]//new
        public static extern LumiStatus LumiGetVersionInfo (uint hHandle, ref LUMI_VERSION hVer);

        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiGetConfig(uint hHandle, ref LUMI_CONFIG config);

        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiSetConfig(uint hHandle, LUMI_CONFIG config);
       
        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiClose(uint hHandle);

        [DllImport(LUMI_API_DLL)]
        public static extern LumiStatus LumiExit();

        ///////////////////////////////////////////////////////////
        // Define needed LumiTypes (found in LumiTypes.h)
        ///////////////////////////////////////////////////////////
        /**********************************************/


        public enum LumiStatus
        {
            LUMI_STATUS_OK							= 0,			/* Operation completed successfully */
	        LUMI_STATUS_ERROR_DEVICE_OPEN			= 0x0001,		/* Could not find or open requested
													                biometric reader */
	        LUMI_STATUS_ERROR_DEVICE_CLOSE			= 0x0002,		/* Could not close biometric reader
													                or release allocated resources */
	        LUMI_STATUS_ERROR_CMD_NOT_SUPPORTED		= 0x0004,		/* This command is not supported on
													                current platform */
	        LUMI_STATUS_ERROR_COMM_LINK				= 0x0008,		/* General internal communication problem
													                prevented execution of command */
	        LUMI_STATUS_ERROR_PREPROCESSOR			= 0x0010,		/* Minimum thresholds for processing
													                quality were not achieved */
	        LUMI_STATUS_ERROR_CALIBRATION			= 0x0020,		/* Calibration cycle failed due to
													                inoperable hardware state */
	        LUMI_STATUS_ERROR_BUSY					= 0x0040,		/* Device is busy processing previous
													                command */
	        LUMI_STATUS_ERROR_INVALID_PARAMETER		= 0x0080,		/* Parameter or input is out of range */
	        LUMI_STATUS_ERROR_TIMEOUT				= 0x0100,		/* Event did not occur within programmed
													                time interval */
	        LUMI_STATUS_ERROR_INVALID_TEMPLATE		= 0x0200,		/* Supplied input template is invalid */
	        LUMI_STATUS_ERROR_MEMORY_ALLOCATION		= 0x0400,		/* Unable to allocate memory */
	        LUMI_STATUS_ERROR_INVALID_DEVICE_ID		= 0x0800,		/* Invalid device ID */
	        LUMI_STATUS_ERROR_INVALID_CONNECTION_ID	= 0x1000,		/* Invalid instance ID */
            LUMI_STATUS_ERROR_CONFIG_UNSUPPORTED    = 0x2000,		/* Current configuration or policy does not
																    support the function that was just called */
            LUMI_STATUS_UNSUPPORTED                 = 0x4000,		/* The function is not currently supported by the SDK*/
            LUMI_STATUS_INTERNAL_ERROR              = 0x8000,		/* An internal error occurred */
            LUMI_STATUS_INVALID_PARAMETER           = 0x8001,		/* Invalid parameter or non allocated buffer passed to function*/
            LUMI_STATUS_DEVICE_TIMEOUT              = 0x8002,		/* Biometric sensor is accessed by another process */
            LUMI_STATUS_INVALID_OPTION              = 0x8004,		/* Invalid option, invalid argument, or invalid
																    argument size passed to function LumiSetOption*/
            LUMI_STATUS_ERROR_MISSING_SPOOFTPL      = 0x8008,       /* Missing Spoof template from Composite image or ANSI
																    378 Template */
            LUMI_STATUS_CANCELLED_BY_USER           = 0x8010,		/* If the LumiPresenceDetectCallback returns -2, then
																    the SDK will return this status code during capture*/
            LUMI_STATUS_INVALID_FOLDER              = 0x8020,		/* Function LumiSetDCOptions returns this code if the folder
																    doesn't exist */
            LUMI_STATUS_DC_OPTIONS_NOT_SET          = 0x8040,		/* Function LumiSaveLastCapture returns this code if the
																    (Data Collection) option was not set OR set to a non
																    existing folder */            
            LUMI_STATUS_INCOMPATIBLE_FIRMWARE       = 0x8080,	    /* The firmware loaded on the sensor is not compatible with
															        this version of the SDK. */
            LUMI_STATUS_NO_DEVICE_FOUND             = 0x8100,		/* LumiInOpAPI returns this code if no device was found*/
            LUMI_STATUS_ERROR_READ_FILE             = 0x8200,		/* LumiInOpAPI returns this code if could not read from file*/
            LUMI_STATUS_ERROR_WRITE_FILE            = 0x8400,		/* LumiInOpAPI returns this code if could not write to file*/
            LUMI_STATUS_INVALID_FILE_FORMAT         = 0x8800,       /* Function LoadBitmapFromFile in LumiInOpAPI returns this 
															        code if invalid file format is passed. */
            LUMI_STATUS_ERROR_TIMEOUT_LATENT        = 0x9000,		/* Latent detection on sensor returned time out due to possible latent
															        or finger not moving between capture calls or PD cycles*/
            LUMI_STATUS_QUALITY_MAP_NOT_GENERATED   = 0x9010,		/* If LumiGetQualityMap is called before a LumiCapture, LumiCaptureEX or
															        LumiVerify is called, this code returned.  Also, this code is returned if 
															        a NULL buffer is passed into LumiGetQualityMap.*/
            LUMI_STATUS_THREAD_ERROR                = 0x9011,		/* More than one thread from same process attempting to enter SDK */
            LUMI_STATUS_ERROR_SENSOR_COMM_TIMEOUT   = 0x9012,		/* Serious communication error occured with the sensor.  The connection handle
															        to that sensor will be closed and no further functions can be called with
															        that connection handle.*/
            LUMI_STATUS_DEVICE_STATUS_ERROR = 0x9013,               /* LumiSetOption for the LUMI_OPTION_CHECK_SENSOR_HEALTH option will return
															        this error code if a sensor status error is present.*/
            LUMI_STATUS_ERROR_BAD_INSTALLATION = 0x9014,            /* If Lumidigm SDK files and folders are not in their proper relative paths or missing,
														            this error code will be returned.  If the plugin folder is missing, this error
														            code will be returned.  If the SPM folder is missing, this error is returned.
														            NOTE: This error code may be returned after the a call to the LumiQueryNumberDevices 
														            function or from other functions - depending on the situation.
														            NOTE: If the MercuryDvc.dll, SDvc.dll, or the VenusDvc.dll are removed from
														            the plugin folder, no error will be returned.  However, if you have a Lumidigm
														            sensor that requires one of these dlls, the LumiQueryNumberDevices function
														            will return 0 devices.
														            As of August 2011, the MercuryDvc.dll is required by the M300 and M301 sensors,
														            the SDvc.dll is required by the M31x and the V31x sensors, the VenusDvc.dll is
														            required by the V300 and V301 sensors.	
														            */
        }

        public enum LUMI_PROCESS_LOCATION
        {
	        LUMI_PROCESS_NONE = 0,
	        LUMI_PROCESS_SENSOR	= 1,
	        LUMI_PROCESS_PC	= 2
        }

        public enum TplInfo
        {
	        CONF_TPL_DEFAULT			= 0x0000,		/* Template type unknown */
	        CONF_TPL_NEC_3				= 0x0001,
	        CONF_TPL_NEC_4				= 0x0002,
	        CONF_TPL_ANSI378			= 0x0003,
	        END_TEMPLATES
        }
        /********************************************************/
        /*		Vid Stream	(used with LumiSetLiveMode 			*/
        /********************************************************/

        public const int LUMI_VID_OFF = 0;
        public const int LUMI_VID_ON = 1;


        public enum TransportInfo
        {
	        CONF_TRANS_DEFAULT	 = 0x0000,
	        CONF_TRANS_USB       = 0x0001,
	        CONF_TRANS_ETHERNET  = 0x0002,
	        CONF_TRANS_RS232	 = 0x0004,
	        CONF_TRANS_WYGEN     = 0x0008,
	        CONF_TRANS_END		 = 0xFFFF
        }

        public enum LUMI_PRES_DET_THRESH
        {
	        LUMI_PD_SENSITIVITY_LOW = 0,
	        LUMI_PD_SENSITIVITY_MEDIUM,
	        LUMI_PD_SENSITIVITY_HIGH
        } 
        
        public enum LUMI_PRES_DET_MODE
        {
            LUMI_PD_ON = 0,
            LUMI_PD_OFF = 1
        }   

        public enum LUMI_OPTIONS
        {
            LUMI_OPTION_SET_OVERRIDE_HEARTBEAT_DISPLAY = 0,
            LUMI_OPTION_SET_PRESENCE_DET_MODE = 1,
            LUMI_OPTION_SET_PRESENCE_DET_THRESH = 2,
            LUMI_OPTION_SET_ACQ_STATUS_CALLBACK = 3,
            LUMI_OPTION_SET_PRESENCE_DET_CALLBACK = 4,
            LUMI_OPTION_SET_PRESENCE_DET_COLOR = 5,
            LUMI_OPTION_RESET_DEVICE = 6,
            LUMI_OPTION_CHECK_SENSOR_HEALTH = 7
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct LUMI_DEVICE_CAPS
        {
            public byte bCaptureImage;          // Represents c++ bool
            public byte bExtract;               // Represents c++ bool
            public byte bMatch;                 // Represents c++ bool
            public byte bIdentify;              // Represents c++ bool
            public byte bSpoof;                 // Represents c++ bool
            public TplInfo eTemplate;			// Template Configuration
            public TransportInfo eTransInfo;	// Transport Configuration
            // Composite Image Size
            public uint m_nWidth;
            public uint m_nHeight;
            public uint m_nDPI;
            public uint m_nImageFormat;
            // Process Location
            public LUMI_PROCESS_LOCATION eProcessLocation;
        }
        
        public enum LUMI_DEVICE_FLAG
        {
	        DEVICE_STATE_UNKNOWN = 0,
	        DEVICE_STATE_OK,
	        DEVICE_STATE_BUSY,
	        DEVICE_STATE_ERROR
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LUMI_DEVICE_STATE
        {
            public LUMI_DEVICE_FLAG eFlag;
            public uint Device_Temp;
            public uint Trigger_Timeout;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LUMI_VERSION
        {
	        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string sdkVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string fwrVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string prcVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string tnsVersion;
        }
        public enum LUMI_SENSOR_TYPE
        {
            VENUS = 0,			/* Venus series sensors		*/
            M100 = 1,			/* Mercury M100 sensors		*/
            M300 = 2,			/* Mercury M300 sensors		*/
            M31X = 3,			/* M31X sensors		*/
            V31X = 4,			/* V31X sensors		*/
            V371 = 5,			/* V371 sensors		*/
            M32X = 8,			/* Mercury M32X sensors		*/
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LUMI_DEVICE
        {
            public uint hDevHandle;						            
            public LUMI_DEVICE_CAPS dCaps;                                
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]   
            public string strIdentifier;
            public LUMI_SENSOR_TYPE SensorType;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LUMI_CONFIG
        {
            public TplInfo eTemplateType;       
            public TransportInfo eTransInfo; 
            public uint nTriggerTimeout;
        }

        public enum LUMI_LED_CONTROL
        {
	        LUMI_JUPITER_LED_00 = 0,
	        LUMI_JUPITER_LED_01,
	        LUMI_JUPITER_LED_02,
	        LUMI_JUPITER_LED_03,
	        LUMI_JUPITER_LED_04,
	        LUMI_JUPITER_LED_05,
	        LUMI_JUPITER_LED_06,
	        LUMI_JUPITER_LED_07,
	        LUMI_JUPITER_LED_08,
	        LUMI_JUPITER_LED_09,
	        LUMI_JUPITER_LED_10,
	        LUMI_JUPITER_LED_11,
	        LUMI_VENUS_ALL_OFF = 1024,
	        LUMI_VENUS_GREEN_ON,
	        LUMI_VENUS_GREEN_OFF,
	        LUMI_VENUS_RED_ON,
	        LUMI_VENUS_RED_OFF,
	        LUMI_VENUS_GREEN_CYCLE_ON,
	        LUMI_VENUS_GREEN_CYCLE_OFF,
	        LUMI_VENUS_RED_CYCLE_ON,
	        LUMI_VENUS_RED_CYCLE_OFF
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LUMI_PROCESSING_MODE
        {
	      public byte bExtract;				/* Turn on or off minutia extraction (true = on, false = off)*/
          public byte bSpoof;				/* Turn on or off spoof	(true = on, false = off)			*/
          public byte bLatent;				/* Turn on or off latent detection (true = on, false = off)	*/
        }

        public enum LUMI_ACQ_STATUS
        {
	        LUMI_ACQ_DONE = 0,
	        LUMI_ACQ_PROCESSING_DONE,
	        LUMI_ACQ_BUSY,
	        LUMI_ACQ_TIMEOUT,
	        LUMI_ACQ_NO_FINGER_PRESENT,
	        LUMI_ACQ_MOVE_FINGER_UP,
	        LUMI_ACQ_MOVE_FINGER_DOWN,
	        LUMI_ACQ_MOVE_FINGER_LEFT,
	        LUMI_ACQ_MOVE_FINGER_RIGHT,
	        LUMI_ACQ_FINGER_POSITION_OK,
	        LUMI_ACQ_CANCELLED_BY_USER,
	        LUMI_ACQ_TIMEOUT_LATENT,
	        LUMI_ACQ_FINGER_PRESENT,
	        LUMI_ACQ_NOOP = 99,	
        }

       //typedef unsigned long LUMI_HANDLE;
    }
}
