using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.VirtualServer.Interop;

namespace VSPlus
{
	/// <summary>
	/// Define RPC_C_AUTHN_LEVEL_ constants
	/// </summary>
	public enum RpcAuthnLevel
	{
		Default = 0,
		None,
		Connect,
		Call,
		Pkt,
		PktIntegrity,
		PktPrivacy
	}

	/// <summary>
	/// Define RPC_C_IMP_LEVEL_ constants
	/// </summary>
	public enum RpcImpLevel
	{
		Default = 0,
		Anonymous,
		Identify,
		Impersonate,
		Delegate
	}

	/// <summary>
	/// Define EOAC_ constants
	/// </summary>
	public enum EoAuthnCap
	{
		None = 0x00
	}


	/// <summary>
	/// InitVS handles the special COM/DCOM startup code required by the Virtual
	/// Server security model.
	/// </summary>
	public class InitVS
	{
		// Create the call with PreserveSig:=FALSE so the COM InterOp layer 
		// will perform the error checking and throw an exception instead 
		// of returning an HRESULT.
		//
		[ DllImport( "Ole32.dll",
			  ExactSpelling=true,
			  EntryPoint="CoInitializeSecurity",
			  CallingConvention=CallingConvention.StdCall,
			  SetLastError=false,
			  PreserveSig=false) ]

		private static extern void CoInitializeSecurity(
			IntPtr pVoid,
			uint cAuthSvc,
			IntPtr asAuthSvc,
			IntPtr pReserved1,
			uint dwAuthnLevel,
			uint dwImpLevel,
			IntPtr pAuthList,
			uint dwCapabilities,
			IntPtr pReserved3 );
      
		/// <summary>
		/// Call CoInitializeSecurity with dwImpLevel set to Impersonate. Required by
		/// the Virtual Server COM Interface.  
		/// </summary>
		public InitVS()
		{
			CoInitializeSecurity(IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero,
				(uint)RpcAuthnLevel.None,
				(uint)RpcImpLevel.Impersonate,
				IntPtr.Zero, (uint)EoAuthnCap.None, IntPtr.Zero );
		}

		/// <summary>
		/// Get VMVirtualServerClass instance from a remote server using DCOM
		/// </summary>
		/// <param name="server">Remote server name</param>
		/// <returns>Remote Virtual Server object class with DCOM enabled</returns>
		public VMVirtualServerClass GetVMVirtualServerClass(string server)
		{

			VMVirtualServerClass GetVMVirtualServerClass_result;
			Type typeVSClass;
			Type typeDCOM;
			object objDCOM;

			typeVSClass = typeof(VMVirtualServerClass);
			typeDCOM = Type.GetTypeFromCLSID(typeVSClass.GUID, server, true);
			objDCOM = Activator.CreateInstance(typeDCOM);

			GetVMVirtualServerClass_result = 
				(VMVirtualServerClass) Marshal.CreateWrapperOfType(objDCOM, typeVSClass);
			return GetVMVirtualServerClass_result;
		}

		/// <summary>
		/// Get VMVirtualServerClass instance from local server using COM
		/// </summary>
		/// <returns>Local Virtual Server object class with COM enabled</returns>
		public VMVirtualServerClass GetVMVirtualServerClass()
		{
			VMVirtualServerClass GetVMVirtualServerClass_result;
			GetVMVirtualServerClass_result = new VMVirtualServerClass();
			return GetVMVirtualServerClass_result;
		}
	}
}
