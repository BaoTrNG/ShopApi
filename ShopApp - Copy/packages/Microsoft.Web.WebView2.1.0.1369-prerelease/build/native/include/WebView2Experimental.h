

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.xx.xxxx */
/* at a redacted point in time
 */
/* Compiler settings for ../../edge_embedded_browser/client/win/current/webview2experimental.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=AMD64 8.xx.xxxx 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif /* __RPCNDR_H_VERSION__ */


#ifndef __webview2experimental_h__
#define __webview2experimental_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

#ifndef DECLSPEC_XFGVIRT
#if _CONTROL_FLOW_GUARD_XFG
#define DECLSPEC_XFGVIRT(base, func) __declspec(xfg_virtual(base, func))
#else
#define DECLSPEC_XFGVIRT(base, func)
#endif
#endif

/* Forward Declarations */ 

#ifndef __ICoreWebView2Experimental5_FWD_DEFINED__
#define __ICoreWebView2Experimental5_FWD_DEFINED__
typedef interface ICoreWebView2Experimental5 ICoreWebView2Experimental5;

#endif 	/* __ICoreWebView2Experimental5_FWD_DEFINED__ */


#ifndef __ICoreWebView2Experimental16_FWD_DEFINED__
#define __ICoreWebView2Experimental16_FWD_DEFINED__
typedef interface ICoreWebView2Experimental16 ICoreWebView2Experimental16;

#endif 	/* __ICoreWebView2Experimental16_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalCompositionController4_FWD_DEFINED__
#define __ICoreWebView2ExperimentalCompositionController4_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalCompositionController4 ICoreWebView2ExperimentalCompositionController4;

#endif 	/* __ICoreWebView2ExperimentalCompositionController4_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalEnvironment3_FWD_DEFINED__
#define __ICoreWebView2ExperimentalEnvironment3_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalEnvironment3 ICoreWebView2ExperimentalEnvironment3;

#endif 	/* __ICoreWebView2ExperimentalEnvironment3_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalWebResourceRequestedEventArgs_FWD_DEFINED__
#define __ICoreWebView2ExperimentalWebResourceRequestedEventArgs_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalWebResourceRequestedEventArgs ICoreWebView2ExperimentalWebResourceRequestedEventArgs;

#endif 	/* __ICoreWebView2ExperimentalWebResourceRequestedEventArgs_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_FWD_DEFINED__
#define __ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler;

#endif 	/* __ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalUpdateRuntimeResult_FWD_DEFINED__
#define __ICoreWebView2ExperimentalUpdateRuntimeResult_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalUpdateRuntimeResult ICoreWebView2ExperimentalUpdateRuntimeResult;

#endif 	/* __ICoreWebView2ExperimentalUpdateRuntimeResult_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalCustomSchemeRegistration_FWD_DEFINED__
#define __ICoreWebView2ExperimentalCustomSchemeRegistration_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalCustomSchemeRegistration ICoreWebView2ExperimentalCustomSchemeRegistration;

#endif 	/* __ICoreWebView2ExperimentalCustomSchemeRegistration_FWD_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalEnvironmentOptions_FWD_DEFINED__
#define __ICoreWebView2ExperimentalEnvironmentOptions_FWD_DEFINED__
typedef interface ICoreWebView2ExperimentalEnvironmentOptions ICoreWebView2ExperimentalEnvironmentOptions;

#endif 	/* __ICoreWebView2ExperimentalEnvironmentOptions_FWD_DEFINED__ */


/* header files for imported files */
#include "webview2.h"

#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __WebView2Experimental_LIBRARY_DEFINED__
#define __WebView2Experimental_LIBRARY_DEFINED__

/* library WebView2Experimental */
/* [version][uuid] */ 









typedef /* [v1_enum] */ 
enum COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS
    {
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_NONE	= 0,
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_DOCUMENT	= 1,
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_SHARED_WORKER	= 2,
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_SERVICE_WORKER	= 4,
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_ALL	= 0xffffffff
    } 	COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS;

DEFINE_ENUM_FLAG_OPERATORS(COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS);
typedef struct COREWEBVIEW2_MATRIX_4X4
    {
    FLOAT _11;
    FLOAT _12;
    FLOAT _13;
    FLOAT _14;
    FLOAT _21;
    FLOAT _22;
    FLOAT _23;
    FLOAT _24;
    FLOAT _31;
    FLOAT _32;
    FLOAT _33;
    FLOAT _34;
    FLOAT _41;
    FLOAT _42;
    FLOAT _43;
    FLOAT _44;
    } 	COREWEBVIEW2_MATRIX_4X4;

typedef /* [v1_enum] */ 
enum COREWEBVIEW2_UPDATE_RUNTIME_STATUS
    {
        COREWEBVIEW2_UPDATE_RUNTIME_STATUS_LATEST_VERSION_INSTALLED	= 0,
        COREWEBVIEW2_UPDATE_RUNTIME_STATUS_UPDATE_ALREADY_RUNNING	= ( COREWEBVIEW2_UPDATE_RUNTIME_STATUS_LATEST_VERSION_INSTALLED + 1 ) ,
        COREWEBVIEW2_UPDATE_RUNTIME_STATUS_BLOCKED_BY_POLICY	= ( COREWEBVIEW2_UPDATE_RUNTIME_STATUS_UPDATE_ALREADY_RUNNING + 1 ) ,
        COREWEBVIEW2_UPDATE_RUNTIME_STATUS_FAILED	= ( COREWEBVIEW2_UPDATE_RUNTIME_STATUS_BLOCKED_BY_POLICY + 1 ) 
    } 	COREWEBVIEW2_UPDATE_RUNTIME_STATUS;

typedef /* [v1_enum] */ 
enum COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL
    {
        COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL_NORMAL	= 0,
        COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL_LOW	= ( COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL_NORMAL + 1 ) 
    } 	COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL;


EXTERN_C const IID LIBID_WebView2Experimental;

#ifndef __ICoreWebView2Experimental5_INTERFACE_DEFINED__
#define __ICoreWebView2Experimental5_INTERFACE_DEFINED__

/* interface ICoreWebView2Experimental5 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2Experimental5 = {0xE05E04CA,0x7924,0x4C04,{0xA8,0x4C,0xA9,0x05,0x72,0xDB,0xA2,0x2A}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("E05E04CA-7924-4C04-A84C-A90572DBA22A")
    ICoreWebView2Experimental5 : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_MemoryUsageTargetLevel( 
            /* [retval][out] */ COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL *level) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_MemoryUsageTargetLevel( 
            /* [in] */ COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL level) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2Experimental5Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2Experimental5 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2Experimental5 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2Experimental5 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2Experimental5, get_MemoryUsageTargetLevel)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_MemoryUsageTargetLevel )( 
            ICoreWebView2Experimental5 * This,
            /* [retval][out] */ COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL *level);
        
        DECLSPEC_XFGVIRT(ICoreWebView2Experimental5, put_MemoryUsageTargetLevel)
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_MemoryUsageTargetLevel )( 
            ICoreWebView2Experimental5 * This,
            /* [in] */ COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL level);
        
        END_INTERFACE
    } ICoreWebView2Experimental5Vtbl;

    interface ICoreWebView2Experimental5
    {
        CONST_VTBL struct ICoreWebView2Experimental5Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2Experimental5_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2Experimental5_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2Experimental5_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2Experimental5_get_MemoryUsageTargetLevel(This,level)	\
    ( (This)->lpVtbl -> get_MemoryUsageTargetLevel(This,level) ) 

#define ICoreWebView2Experimental5_put_MemoryUsageTargetLevel(This,level)	\
    ( (This)->lpVtbl -> put_MemoryUsageTargetLevel(This,level) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2Experimental5_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2Experimental16_INTERFACE_DEFINED__
#define __ICoreWebView2Experimental16_INTERFACE_DEFINED__

/* interface ICoreWebView2Experimental16 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2Experimental16 = {0x679ddf3f,0x9044,0x486f,{0x84,0x58,0x16,0x65,0x3a,0x0e,0x16,0x03}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("679ddf3f-9044-486f-8458-16653a0e1603")
    ICoreWebView2Experimental16 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE AddWebResourceRequestedFilterWithRequestSourceKinds( 
            /* [in] */ const LPCWSTR uri,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE RemoveWebResourceRequestedFilterWithRequestSourceKinds( 
            /* [in] */ const LPCWSTR uri,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2Experimental16Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2Experimental16 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2Experimental16 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2Experimental16 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2Experimental16, AddWebResourceRequestedFilterWithRequestSourceKinds)
        HRESULT ( STDMETHODCALLTYPE *AddWebResourceRequestedFilterWithRequestSourceKinds )( 
            ICoreWebView2Experimental16 * This,
            /* [in] */ const LPCWSTR uri,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);
        
        DECLSPEC_XFGVIRT(ICoreWebView2Experimental16, RemoveWebResourceRequestedFilterWithRequestSourceKinds)
        HRESULT ( STDMETHODCALLTYPE *RemoveWebResourceRequestedFilterWithRequestSourceKinds )( 
            ICoreWebView2Experimental16 * This,
            /* [in] */ const LPCWSTR uri,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext,
            /* [in] */ const COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);
        
        END_INTERFACE
    } ICoreWebView2Experimental16Vtbl;

    interface ICoreWebView2Experimental16
    {
        CONST_VTBL struct ICoreWebView2Experimental16Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2Experimental16_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2Experimental16_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2Experimental16_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2Experimental16_AddWebResourceRequestedFilterWithRequestSourceKinds(This,uri,resourceContext,requestSourceKinds)	\
    ( (This)->lpVtbl -> AddWebResourceRequestedFilterWithRequestSourceKinds(This,uri,resourceContext,requestSourceKinds) ) 

#define ICoreWebView2Experimental16_RemoveWebResourceRequestedFilterWithRequestSourceKinds(This,uri,resourceContext,requestSourceKinds)	\
    ( (This)->lpVtbl -> RemoveWebResourceRequestedFilterWithRequestSourceKinds(This,uri,resourceContext,requestSourceKinds) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2Experimental16_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalCompositionController4_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalCompositionController4_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalCompositionController4 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalCompositionController4 = {0xe6041d7f,0x18ac,0x4654,{0xa0,0x4e,0x8b,0x3f,0x81,0x25,0x1c,0x33}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("e6041d7f-18ac-4654-a04e-8b3f81251c33")
    ICoreWebView2ExperimentalCompositionController4 : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_AutomationProvider( 
            /* [retval][out] */ IUnknown **provider) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateCoreWebView2PointerInfoFromPointerId( 
            /* [in] */ UINT pointerId,
            /* [in] */ HWND parentWindow,
            /* [in] */ struct COREWEBVIEW2_MATRIX_4X4 transform,
            /* [retval][out] */ ICoreWebView2PointerInfo **pointerInfo) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalCompositionController4Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalCompositionController4 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalCompositionController4 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalCompositionController4 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalCompositionController4, get_AutomationProvider)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_AutomationProvider )( 
            ICoreWebView2ExperimentalCompositionController4 * This,
            /* [retval][out] */ IUnknown **provider);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalCompositionController4, CreateCoreWebView2PointerInfoFromPointerId)
        HRESULT ( STDMETHODCALLTYPE *CreateCoreWebView2PointerInfoFromPointerId )( 
            ICoreWebView2ExperimentalCompositionController4 * This,
            /* [in] */ UINT pointerId,
            /* [in] */ HWND parentWindow,
            /* [in] */ struct COREWEBVIEW2_MATRIX_4X4 transform,
            /* [retval][out] */ ICoreWebView2PointerInfo **pointerInfo);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalCompositionController4Vtbl;

    interface ICoreWebView2ExperimentalCompositionController4
    {
        CONST_VTBL struct ICoreWebView2ExperimentalCompositionController4Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalCompositionController4_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalCompositionController4_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalCompositionController4_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalCompositionController4_get_AutomationProvider(This,provider)	\
    ( (This)->lpVtbl -> get_AutomationProvider(This,provider) ) 

#define ICoreWebView2ExperimentalCompositionController4_CreateCoreWebView2PointerInfoFromPointerId(This,pointerId,parentWindow,transform,pointerInfo)	\
    ( (This)->lpVtbl -> CreateCoreWebView2PointerInfoFromPointerId(This,pointerId,parentWindow,transform,pointerInfo) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalCompositionController4_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalEnvironment3_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalEnvironment3_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalEnvironment3 */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalEnvironment3 = {0x9A2BE885,0x7F0B,0x4B26,{0xB6,0xDD,0xC9,0x69,0xBA,0xA0,0x0B,0xF1}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9A2BE885-7F0B-4B26-B6DD-C969BAA00BF1")
    ICoreWebView2ExperimentalEnvironment3 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE UpdateRuntime( 
            /* [in] */ ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler *handler) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalEnvironment3Vtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalEnvironment3 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalEnvironment3 * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalEnvironment3 * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalEnvironment3, UpdateRuntime)
        HRESULT ( STDMETHODCALLTYPE *UpdateRuntime )( 
            ICoreWebView2ExperimentalEnvironment3 * This,
            /* [in] */ ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler *handler);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalEnvironment3Vtbl;

    interface ICoreWebView2ExperimentalEnvironment3
    {
        CONST_VTBL struct ICoreWebView2ExperimentalEnvironment3Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalEnvironment3_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalEnvironment3_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalEnvironment3_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalEnvironment3_UpdateRuntime(This,handler)	\
    ( (This)->lpVtbl -> UpdateRuntime(This,handler) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalEnvironment3_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalWebResourceRequestedEventArgs_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalWebResourceRequestedEventArgs_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalWebResourceRequestedEventArgs */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalWebResourceRequestedEventArgs = {0x8f3ec528,0x0596,0x4d51,{0x9f,0x9e,0x2d,0xa5,0x80,0xac,0x97,0x87}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("8f3ec528-0596-4d51-9f9e-2da580ac9787")
    ICoreWebView2ExperimentalWebResourceRequestedEventArgs : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_RequestedSourceKind( 
            /* [retval][out] */ COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS *requestedSourceKind) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalWebResourceRequestedEventArgsVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalWebResourceRequestedEventArgs * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalWebResourceRequestedEventArgs * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalWebResourceRequestedEventArgs * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalWebResourceRequestedEventArgs, get_RequestedSourceKind)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_RequestedSourceKind )( 
            ICoreWebView2ExperimentalWebResourceRequestedEventArgs * This,
            /* [retval][out] */ COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS *requestedSourceKind);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalWebResourceRequestedEventArgsVtbl;

    interface ICoreWebView2ExperimentalWebResourceRequestedEventArgs
    {
        CONST_VTBL struct ICoreWebView2ExperimentalWebResourceRequestedEventArgsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalWebResourceRequestedEventArgs_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalWebResourceRequestedEventArgs_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalWebResourceRequestedEventArgs_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalWebResourceRequestedEventArgs_get_RequestedSourceKind(This,requestedSourceKind)	\
    ( (This)->lpVtbl -> get_RequestedSourceKind(This,requestedSourceKind) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalWebResourceRequestedEventArgs_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler = {0xF1D2D722,0x3721,0x499C,{0x87,0xF5,0x4C,0x40,0x52,0x60,0x69,0x7A}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("F1D2D722-3721-499C-87F5-4C405260697A")
    ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Invoke( 
            /* [in] */ HRESULT errorCode,
            /* [in] */ ICoreWebView2ExperimentalUpdateRuntimeResult *result) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalUpdateRuntimeCompletedHandlerVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler, Invoke)
        HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler * This,
            /* [in] */ HRESULT errorCode,
            /* [in] */ ICoreWebView2ExperimentalUpdateRuntimeResult *result);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalUpdateRuntimeCompletedHandlerVtbl;

    interface ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler
    {
        CONST_VTBL struct ICoreWebView2ExperimentalUpdateRuntimeCompletedHandlerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_Invoke(This,errorCode,result)	\
    ( (This)->lpVtbl -> Invoke(This,errorCode,result) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalUpdateRuntimeCompletedHandler_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalUpdateRuntimeResult_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalUpdateRuntimeResult_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalUpdateRuntimeResult */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalUpdateRuntimeResult = {0xDD503E49,0xAB19,0x47C0,{0xB2,0xAD,0x6D,0xDD,0x09,0xCC,0x3E,0x3A}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("DD503E49-AB19-47C0-B2AD-6DDD09CC3E3A")
    ICoreWebView2ExperimentalUpdateRuntimeResult : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Status( 
            /* [retval][out] */ COREWEBVIEW2_UPDATE_RUNTIME_STATUS *status) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_ExtendedError( 
            /* [retval][out] */ HRESULT *error) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalUpdateRuntimeResultVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalUpdateRuntimeResult * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalUpdateRuntimeResult * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalUpdateRuntimeResult * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalUpdateRuntimeResult, get_Status)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Status )( 
            ICoreWebView2ExperimentalUpdateRuntimeResult * This,
            /* [retval][out] */ COREWEBVIEW2_UPDATE_RUNTIME_STATUS *status);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalUpdateRuntimeResult, get_ExtendedError)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_ExtendedError )( 
            ICoreWebView2ExperimentalUpdateRuntimeResult * This,
            /* [retval][out] */ HRESULT *error);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalUpdateRuntimeResultVtbl;

    interface ICoreWebView2ExperimentalUpdateRuntimeResult
    {
        CONST_VTBL struct ICoreWebView2ExperimentalUpdateRuntimeResultVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalUpdateRuntimeResult_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalUpdateRuntimeResult_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalUpdateRuntimeResult_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalUpdateRuntimeResult_get_Status(This,status)	\
    ( (This)->lpVtbl -> get_Status(This,status) ) 

#define ICoreWebView2ExperimentalUpdateRuntimeResult_get_ExtendedError(This,error)	\
    ( (This)->lpVtbl -> get_ExtendedError(This,error) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalUpdateRuntimeResult_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalCustomSchemeRegistration_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalCustomSchemeRegistration_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalCustomSchemeRegistration */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalCustomSchemeRegistration = {0xd60ac92c,0x37a6,0x4b26,{0xa3,0x9e,0x95,0xcf,0xe5,0x90,0x47,0xbb}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("d60ac92c-37a6-4b26-a39e-95cfe59047bb")
    ICoreWebView2ExperimentalCustomSchemeRegistration : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_SchemeName( 
            /* [retval][out] */ LPWSTR *schemeName) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_TreatAsSecure( 
            /* [retval][out] */ BOOL *treatAsSecure) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_TreatAsSecure( 
            /* [in] */ BOOL value) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetAllowedOrigins( 
            /* [out] */ UINT32 *allowedOriginsCount,
            /* [out] */ LPWSTR **allowedOrigins) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetAllowedOrigins( 
            /* [in] */ UINT32 allowedOriginsCount,
            /* [in] */ LPCWSTR *allowedOrigins) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_HasAuthorityComponent( 
            /* [retval][out] */ BOOL *hasAuthorityComponent) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_HasAuthorityComponent( 
            /* [in] */ BOOL hasAuthorityComponent) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalCustomSchemeRegistrationVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalCustomSchemeRegistration * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalCustomSchemeRegistration * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalCustomSchemeRegistration * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalCustomSchemeRegistration, get_SchemeName)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_SchemeName )( 
            ICoreWebView2ExperimentalCustomSchemeRegistration * This,
            /* [retval][out] */ LPWSTR *schemeName);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalCustomSchemeRegistration, get_TreatAsSecure)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_TreatAsSecure )( 
            ICoreWebView2ExperimentalCustomSchemeRegistration * This,
            /* [retval][out] */ BOOL *treatAsSecure);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalCustomSchemeRegistration, put_TreatAsSecure)
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_TreatAsSecure )( 
            ICoreWebView2ExperimentalCustomSchemeRegistration * This,
            /* [in] */ BOOL value);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalCustomSchemeRegistration, GetAllowedOrigins)
        HRESULT ( STDMETHODCALLTYPE *GetAllowedOrigins )( 
            ICoreWebView2ExperimentalCustomSchemeRegistration * This,
            /* [out] */ UINT32 *allowedOriginsCount,
            /* [out] */ LPWSTR **allowedOrigins);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalCustomSchemeRegistration, SetAllowedOrigins)
        HRESULT ( STDMETHODCALLTYPE *SetAllowedOrigins )( 
            ICoreWebView2ExperimentalCustomSchemeRegistration * This,
            /* [in] */ UINT32 allowedOriginsCount,
            /* [in] */ LPCWSTR *allowedOrigins);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalCustomSchemeRegistration, get_HasAuthorityComponent)
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_HasAuthorityComponent )( 
            ICoreWebView2ExperimentalCustomSchemeRegistration * This,
            /* [retval][out] */ BOOL *hasAuthorityComponent);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalCustomSchemeRegistration, put_HasAuthorityComponent)
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_HasAuthorityComponent )( 
            ICoreWebView2ExperimentalCustomSchemeRegistration * This,
            /* [in] */ BOOL hasAuthorityComponent);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalCustomSchemeRegistrationVtbl;

    interface ICoreWebView2ExperimentalCustomSchemeRegistration
    {
        CONST_VTBL struct ICoreWebView2ExperimentalCustomSchemeRegistrationVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalCustomSchemeRegistration_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalCustomSchemeRegistration_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalCustomSchemeRegistration_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalCustomSchemeRegistration_get_SchemeName(This,schemeName)	\
    ( (This)->lpVtbl -> get_SchemeName(This,schemeName) ) 

#define ICoreWebView2ExperimentalCustomSchemeRegistration_get_TreatAsSecure(This,treatAsSecure)	\
    ( (This)->lpVtbl -> get_TreatAsSecure(This,treatAsSecure) ) 

#define ICoreWebView2ExperimentalCustomSchemeRegistration_put_TreatAsSecure(This,value)	\
    ( (This)->lpVtbl -> put_TreatAsSecure(This,value) ) 

#define ICoreWebView2ExperimentalCustomSchemeRegistration_GetAllowedOrigins(This,allowedOriginsCount,allowedOrigins)	\
    ( (This)->lpVtbl -> GetAllowedOrigins(This,allowedOriginsCount,allowedOrigins) ) 

#define ICoreWebView2ExperimentalCustomSchemeRegistration_SetAllowedOrigins(This,allowedOriginsCount,allowedOrigins)	\
    ( (This)->lpVtbl -> SetAllowedOrigins(This,allowedOriginsCount,allowedOrigins) ) 

#define ICoreWebView2ExperimentalCustomSchemeRegistration_get_HasAuthorityComponent(This,hasAuthorityComponent)	\
    ( (This)->lpVtbl -> get_HasAuthorityComponent(This,hasAuthorityComponent) ) 

#define ICoreWebView2ExperimentalCustomSchemeRegistration_put_HasAuthorityComponent(This,hasAuthorityComponent)	\
    ( (This)->lpVtbl -> put_HasAuthorityComponent(This,hasAuthorityComponent) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalCustomSchemeRegistration_INTERFACE_DEFINED__ */


#ifndef __ICoreWebView2ExperimentalEnvironmentOptions_INTERFACE_DEFINED__
#define __ICoreWebView2ExperimentalEnvironmentOptions_INTERFACE_DEFINED__

/* interface ICoreWebView2ExperimentalEnvironmentOptions */
/* [unique][object][uuid] */ 


EXTERN_C __declspec(selectany) const IID IID_ICoreWebView2ExperimentalEnvironmentOptions = {0xac52d13f,0x0d38,0x475a,{0x9d,0xca,0x87,0x65,0x80,0xd6,0x79,0x3e}};

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("ac52d13f-0d38-475a-9dca-876580d6793e")
    ICoreWebView2ExperimentalEnvironmentOptions : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE GetCustomSchemeRegistrations( 
            /* [out] */ UINT32 *count,
            /* [out] */ ICoreWebView2ExperimentalCustomSchemeRegistration ***schemeRegistrations) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetCustomSchemeRegistrations( 
            /* [in] */ UINT32 count,
            /* [in] */ ICoreWebView2ExperimentalCustomSchemeRegistration **schemeRegistrations) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreWebView2ExperimentalEnvironmentOptionsVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICoreWebView2ExperimentalEnvironmentOptions * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICoreWebView2ExperimentalEnvironmentOptions * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICoreWebView2ExperimentalEnvironmentOptions * This);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalEnvironmentOptions, GetCustomSchemeRegistrations)
        HRESULT ( STDMETHODCALLTYPE *GetCustomSchemeRegistrations )( 
            ICoreWebView2ExperimentalEnvironmentOptions * This,
            /* [out] */ UINT32 *count,
            /* [out] */ ICoreWebView2ExperimentalCustomSchemeRegistration ***schemeRegistrations);
        
        DECLSPEC_XFGVIRT(ICoreWebView2ExperimentalEnvironmentOptions, SetCustomSchemeRegistrations)
        HRESULT ( STDMETHODCALLTYPE *SetCustomSchemeRegistrations )( 
            ICoreWebView2ExperimentalEnvironmentOptions * This,
            /* [in] */ UINT32 count,
            /* [in] */ ICoreWebView2ExperimentalCustomSchemeRegistration **schemeRegistrations);
        
        END_INTERFACE
    } ICoreWebView2ExperimentalEnvironmentOptionsVtbl;

    interface ICoreWebView2ExperimentalEnvironmentOptions
    {
        CONST_VTBL struct ICoreWebView2ExperimentalEnvironmentOptionsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICoreWebView2ExperimentalEnvironmentOptions_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICoreWebView2ExperimentalEnvironmentOptions_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICoreWebView2ExperimentalEnvironmentOptions_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICoreWebView2ExperimentalEnvironmentOptions_GetCustomSchemeRegistrations(This,count,schemeRegistrations)	\
    ( (This)->lpVtbl -> GetCustomSchemeRegistrations(This,count,schemeRegistrations) ) 

#define ICoreWebView2ExperimentalEnvironmentOptions_SetCustomSchemeRegistrations(This,count,schemeRegistrations)	\
    ( (This)->lpVtbl -> SetCustomSchemeRegistrations(This,count,schemeRegistrations) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICoreWebView2ExperimentalEnvironmentOptions_INTERFACE_DEFINED__ */

#endif /* __WebView2Experimental_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


