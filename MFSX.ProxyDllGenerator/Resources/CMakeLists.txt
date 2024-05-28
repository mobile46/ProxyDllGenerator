cmake_minimum_required(VERSION 3.15)
project(#NAME# CXX)

if (MSVC)
    set(CMAKE_MSVC_RUNTIME_LIBRARY "MultiThreaded")
    set(CMAKE_CONFIGURATION_TYPES "Release;RelWithDebInfo" CACHE STRING "" FORCE)
    set(CMAKE_CXX_FLAGS_RELEASE "${CMAKE_CXX_FLAGS_RELEASE} /Os")
    set(CMAKE_CXX_FLAGS_RELWITHDEBINFO "${CMAKE_CXX_FLAGS_RELWITHDEBINFO} /Os")
else()
    message(FATAL_ERROR "Non-MSVC compilers are not supported!")
endif()

add_library(#NAME# SHARED #NAME#.cpp #NAME#.def Logger.h)
