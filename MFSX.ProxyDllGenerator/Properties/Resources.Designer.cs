﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MFSX.ProxyDllGenerator.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MFSX.ProxyDllGenerator.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to cmake_minimum_required(VERSION 3.15)
        ///project(#NAME# CXX)
        ///
        ///if (MSVC)
        ///    set(CMAKE_MSVC_RUNTIME_LIBRARY &quot;MultiThreaded&quot;)
        ///    set(CMAKE_CONFIGURATION_TYPES &quot;Release;RelWithDebInfo&quot; CACHE STRING &quot;&quot; FORCE)
        ///    set(CMAKE_CXX_FLAGS_RELEASE &quot;${CMAKE_CXX_FLAGS_RELEASE} /Os&quot;)
        ///    set(CMAKE_CXX_FLAGS_RELWITHDEBINFO &quot;${CMAKE_CXX_FLAGS_RELWITHDEBINFO} /Os&quot;)
        ///else()
        ///    message(FATAL_ERROR &quot;Non-MSVC compilers are not supported!&quot;)
        ///endif()
        ///
        ///add_library(#NAME# SHARED #NAME#.cpp #NAME#.def Logger.h)
        ///.
        /// </summary>
        internal static string CMakeLists {
            get {
                return ResourceManager.GetString("CMakeLists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #pragma once
        ///#if DEBUG
        ///#include &lt;stdio.h&gt;
        ///
        ///#define INITLOGGER(fileName) InitLogger(fileName)
        ///#define CLOSELOGGER() CloseLogger()
        ///#define LOG(fmt, ...) WriteLog(&quot;%X:%d:%s: &quot; ##fmt, GetCurrentThreadId(), __LINE__, __FUNCTION__, __VA_ARGS__)
        ///#define HEXDUMP(data, length) HexDump(data, length)
        ///
        ///HANDLE mutex = NULL;
        ///FILE* file = NULL;
        ///
        ///inline void InitLogger(const char* fileName)
        ///{
        ///	mutex = CreateMutex(NULL, false, NULL);
        ///
        ///	AllocConsole();
        ///
        ///	FILE* temp;
        ///	freopen_s(&amp;temp, &quot;CONIN$&quot;, &quot;r&quot;, stdin); [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Logger {
            get {
                return ResourceManager.GetString("Logger", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///Microsoft Visual Studio Solution File, Format Version 12.00
        ///# Visual Studio Version 17
        ///VisualStudioVersion = 17.7.34221.43
        ///MinimumVisualStudioVersion = 10.0.40219.1
        ///Project(&quot;{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}&quot;) = &quot;#NAME#&quot;, &quot;#NAME#\#NAME#.vcxproj&quot;, &quot;{3941E9F8-1337-4D69-8717-F74562ED5301}&quot;
        ///EndProject
        ///Global
        ///	GlobalSection(SolutionConfigurationPlatforms) = preSolution
        ///		Release|x86 = Release|x86
        ///		Release|x64 = Release|x64
        ///		RelWithDebInfo|x86 = RelWithDebInfo|x86
        ///		RelWithDebInfo|x64 = RelWit [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SlnFile {
            get {
                return ResourceManager.GetString("SlnFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #define DEBUG 1
        ///
        ///#include &lt;windows.h&gt;
        ///#include &lt;psapi.h&gt;
        ///#include &quot;Logger.h&quot;
        ///
        ///#define FUNC(i) ((void(*)())mProcs[i])()
        ///
        ///HINSTANCE mHinstDLL;
        ///uintptr_t mProcs[#COUNT#];
        ///
        ///const char* mImportNames[] = { #IMPORTS# };
        ///
        ///void MFSX();
        ///
        ///char* GetExePath()
        ///{
        ///	char buffer[MAX_PATH];
        ///	GetModuleFileName(NULL, buffer, MAX_PATH);
        ///
        ///	char* lastBackslash = strrchr(buffer, &apos;\\&apos;);
        ///	char* lastForwardSlash = strrchr(buffer, &apos;/&apos;);
        ///	if (lastBackslash || lastForwardSlash)
        ///	{
        ///		char* lastSeparator = lastBacks [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TemplateCpp {
            get {
                return ResourceManager.GetString("TemplateCpp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;Project DefaultTargets=&quot;Build&quot; xmlns=&quot;http://schemas.microsoft.com/developer/msbuild/2003&quot;&gt;
        ///  &lt;ItemGroup Label=&quot;ProjectConfigurations&quot;&gt;
        ///    &lt;ProjectConfiguration Include=&quot;Release|Win32&quot;&gt;
        ///      &lt;Configuration&gt;Release&lt;/Configuration&gt;
        ///      &lt;Platform&gt;Win32&lt;/Platform&gt;
        ///    &lt;/ProjectConfiguration&gt;
        ///    &lt;ProjectConfiguration Include=&quot;Release|x64&quot;&gt;
        ///      &lt;Configuration&gt;Release&lt;/Configuration&gt;
        ///      &lt;Platform&gt;x64&lt;/Platform&gt;
        ///    &lt;/ProjectConfiguration&gt;
        ///    &lt;ProjectCon [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string VcxprojFile {
            get {
                return ResourceManager.GetString("VcxprojFile", resourceCulture);
            }
        }
    }
}
