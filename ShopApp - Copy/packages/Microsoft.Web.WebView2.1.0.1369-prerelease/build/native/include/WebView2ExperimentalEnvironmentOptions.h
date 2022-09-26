// Copyright (C) Microsoft Corporation. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

#ifndef __core_webview2_experimental_environment_options_h__
#define __core_webview2_experimental_environment_options_h__

#include <objbase.h>
#include <wrl/implements.h>

#include "WebView2EnvironmentOptions.h"
#include "webview2experimental.h"

template <typename allocate_fn_t,
          allocate_fn_t allocate_fn,
          typename deallocate_fn_t,
          deallocate_fn_t deallocate_fn>
class CoreWebView2CustomSchemeRegistrationBase
    : public Microsoft::WRL::RuntimeClass<
          Microsoft::WRL::RuntimeClassFlags<Microsoft::WRL::ClassicCom>,
          ICoreWebView2ExperimentalCustomSchemeRegistration> {
 public:
  CoreWebView2CustomSchemeRegistrationBase(LPCWSTR schemeName) {
    m_schemeName.Set(schemeName);
  }

  CoreWebView2CustomSchemeRegistrationBase(
      CoreWebView2CustomSchemeRegistrationBase&&) = default;
  ~CoreWebView2CustomSchemeRegistrationBase() { ReleaseAllowedOrigins(); }

  HRESULT STDMETHODCALLTYPE get_SchemeName(LPWSTR* schemeName) override {
    if (!schemeName)
      return E_POINTER;
    *schemeName = m_schemeName.Copy();
    if ((*schemeName == nullptr) && (m_schemeName.Get() != nullptr))
      return HRESULT_FROM_WIN32(GetLastError());
    return S_OK;
  }

  HRESULT STDMETHODCALLTYPE
  GetAllowedOrigins(UINT32* allowedOriginsCount,
                    LPWSTR** allowedOrigins) override {
    if (!allowedOrigins || !allowedOriginsCount) {
      return E_POINTER;
    }
    *allowedOriginsCount = 0;
    if (m_allowedOriginsCount == 0) {
      *allowedOrigins = nullptr;
      return S_OK;
    } else {
      *allowedOrigins = reinterpret_cast<LPWSTR*>(
          allocate_fn(m_allowedOriginsCount * sizeof(LPWSTR)));
      if (!(*allowedOrigins)) {
        return HRESULT_FROM_WIN32(GetLastError());
      }
      ZeroMemory(*allowedOrigins, m_allowedOriginsCount * sizeof(LPWSTR));
      for (UINT32 i = 0; i < m_allowedOriginsCount; i++) {
        (*allowedOrigins)[i] = m_allowedOrigins[i].Copy();
        if (!(*allowedOrigins)[i]) {
          HRESULT hr = HRESULT_FROM_WIN32(GetLastError());
          for (UINT32 j = 0; j < i; j++) {
            deallocate_fn((*allowedOrigins)[j]);
          }
          deallocate_fn(*allowedOrigins);
          return hr;
        }
      }
      *allowedOriginsCount = m_allowedOriginsCount;
      return S_OK;
    }
  }

  HRESULT STDMETHODCALLTYPE
  SetAllowedOrigins(UINT32 allowedOriginsCount,
                    LPCWSTR* allowedOrigins) override {
    ReleaseAllowedOrigins();
    if (allowedOriginsCount == 0) {
      return S_OK;
    } else {
      m_allowedOrigins = new AutoCoMemString[allowedOriginsCount];
      if (!m_allowedOrigins) {
        return HRESULT_FROM_WIN32(GetLastError());
      }
      for (UINT32 i = 0; i < allowedOriginsCount; i++) {
        m_allowedOrigins[i].Set(allowedOrigins[i]);
        if (!m_allowedOrigins[i].Get()) {
          HRESULT hr = HRESULT_FROM_WIN32(GetLastError());
          for (UINT32 j = 0; j < i; j++) {
            m_allowedOrigins[j].Release();
          }
          m_allowedOriginsCount = 0;
          delete[] (m_allowedOrigins);
          return hr;
        }
      }
      m_allowedOriginsCount = allowedOriginsCount;
      return S_OK;
    }
  }

 protected:
  class AutoCoMemString {
   public:
    AutoCoMemString() {}
    ~AutoCoMemString() { Release(); }
    void* operator new(size_t size) { return allocate_fn(size); }
    void operator delete(void* ptr) { deallocate_fn(ptr); }
    void* operator new[](size_t size) { return allocate_fn(size); }
    void operator delete[](void* ptr) { deallocate_fn(ptr); }
    void Release() {
      if (m_string) {
        deallocate_fn(m_string);
        m_string = nullptr;
      }
    }

    LPCWSTR Set(LPCWSTR str) {
      Release();
      if (str) {
        m_string = MakeCoMemString(str);
      }
      return m_string;
    }
    LPCWSTR Get() { return m_string; }
    LPWSTR Copy() {
      if (m_string)
        return MakeCoMemString(m_string);
      return nullptr;
    }

    LPWSTR MakeCoMemString(LPCWSTR source) {
      const size_t length = wcslen(source);
      const size_t bytes = (length + 1) * sizeof(*source);
      // Ensure we didn't overflow during our size calculation.
      if (bytes <= length) {
        return nullptr;
      }

      wchar_t* result = reinterpret_cast<wchar_t*>(allocate_fn(bytes));
      if (result)
        memcpy(result, source, bytes);

      return result;
    }

    LPWSTR m_string = nullptr;
  };

  void ReleaseAllowedOrigins() {
    if (m_allowedOrigins) {
      delete[] (m_allowedOrigins);
      m_allowedOrigins = nullptr;
    }
  }

  AutoCoMemString m_schemeName;
  COREWEBVIEW2ENVIRONMENTOPTIONS_BOOL_PROPERTY(TreatAsSecure);
  COREWEBVIEW2ENVIRONMENTOPTIONS_BOOL_PROPERTY(HasAuthorityComponent);
  AutoCoMemString* m_allowedOrigins = nullptr;
  unsigned int m_allowedOriginsCount = 0;
};

typedef CoreWebView2CustomSchemeRegistrationBase<decltype(&::CoTaskMemAlloc),
                                                 ::CoTaskMemAlloc,
                                                 decltype(&::CoTaskMemFree),
                                                 ::CoTaskMemFree>
    CoreWebView2CustomSchemeRegistration;

// This is a base COM class that implements IUnknown if there is no Experimental
// options, or ICoreWebView2ExperimentalEnvironmentOptions when there are
// Experimental options.
template <typename allocate_fn_t,
          allocate_fn_t allocate_fn,
          typename deallocate_fn_t,
          deallocate_fn_t deallocate_fn>
class CoreWebView2ExperimentalEnvironmentOptionsBase
    : public Microsoft::WRL::Implements<
          Microsoft::WRL::RuntimeClassFlags<Microsoft::WRL::ClassicCom>,
          ICoreWebView2ExperimentalEnvironmentOptions> {
 public:
  CoreWebView2ExperimentalEnvironmentOptionsBase() {}

  HRESULT STDMETHODCALLTYPE GetCustomSchemeRegistrations(
      UINT32* count,
      ICoreWebView2ExperimentalCustomSchemeRegistration*** schemeRegistrations)
      override {
    if (!count || !schemeRegistrations) {
      return E_POINTER;
    }
    *count = 0;
    if (m_customSchemeRegistrationsCount == 0) {
      *schemeRegistrations = nullptr;
      return S_OK;
    } else {
      *schemeRegistrations =
          reinterpret_cast<ICoreWebView2ExperimentalCustomSchemeRegistration**>(
              allocate_fn(
                  sizeof(ICoreWebView2ExperimentalCustomSchemeRegistration*) *
                  m_customSchemeRegistrationsCount));
      if (!*schemeRegistrations) {
        return HRESULT_FROM_WIN32(GetLastError());
      }
      for (UINT32 i = 0; i < m_customSchemeRegistrationsCount; i++) {
        (*schemeRegistrations)[i] = m_customSchemeRegistrations[i];
        (*schemeRegistrations)[i]->AddRef();
      }
      *count = m_customSchemeRegistrationsCount;
      return S_OK;
    }
  }

  HRESULT STDMETHODCALLTYPE SetCustomSchemeRegistrations(
      UINT32 count,
      ICoreWebView2ExperimentalCustomSchemeRegistration** schemeRegistrations)
      override {
    ReleaseCustomSchemeRegistrations();
    m_customSchemeRegistrations =
        reinterpret_cast<ICoreWebView2ExperimentalCustomSchemeRegistration**>(
            allocate_fn(
                sizeof(ICoreWebView2ExperimentalCustomSchemeRegistration*) *
                count));
    if (!m_customSchemeRegistrations) {
      return GetLastError();
    }
    for (UINT32 i = 0; i < count; i++) {
      m_customSchemeRegistrations[i] = schemeRegistrations[i];
      m_customSchemeRegistrations[i]->AddRef();
    }
    m_customSchemeRegistrationsCount = count;
    return S_OK;
  }

 protected:
  void ReleaseCustomSchemeRegistrations() {
    if (m_customSchemeRegistrations) {
      for (UINT32 i = 0; i < m_customSchemeRegistrationsCount; i++) {
        m_customSchemeRegistrations[i]->Release();
      }
      deallocate_fn(m_customSchemeRegistrations);
      m_customSchemeRegistrations = nullptr;
      m_customSchemeRegistrationsCount = 0;
    }
  }

  ~CoreWebView2ExperimentalEnvironmentOptionsBase() {
    ReleaseCustomSchemeRegistrations();
  };

 private:
  ICoreWebView2ExperimentalCustomSchemeRegistration**
      m_customSchemeRegistrations = nullptr;
  unsigned int m_customSchemeRegistrationsCount = 0;
};

template <typename allocate_fn_t,
          allocate_fn_t allocate_fn,
          typename deallocate_fn_t,
          deallocate_fn_t deallocate_fn>
class CoreWebView2ExperimentalEnvironmentOptionsClass
    : public Microsoft::WRL::RuntimeClass<
          Microsoft::WRL::RuntimeClassFlags<Microsoft::WRL::ClassicCom>,
          CoreWebView2EnvironmentOptionsBase<allocate_fn_t,
                                             allocate_fn,
                                             deallocate_fn_t,
                                             deallocate_fn>,
          CoreWebView2ExperimentalEnvironmentOptionsBase<allocate_fn_t,
                                                         allocate_fn,
                                                         deallocate_fn_t,
                                                         deallocate_fn>> {
 public:
  CoreWebView2ExperimentalEnvironmentOptionsClass() {}

 protected:
  ~CoreWebView2ExperimentalEnvironmentOptionsClass() override{};
};

typedef CoreWebView2ExperimentalEnvironmentOptionsClass<
    decltype(&::CoTaskMemAlloc),
    ::CoTaskMemAlloc,
    decltype(&::CoTaskMemFree),
    ::CoTaskMemFree>
    CoreWebView2ExperimentalEnvironmentOptions;

#endif  // __core_webview2_experimental_environment_options_h__
