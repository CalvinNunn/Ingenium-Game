#pragma once

#ifdef SaveLoadScore_EXPORTS
#define PLUGIN_API __declspec(dllexport)
#elif SaveLoadScore_IMPORTS
#define PLUGIN_API __declspec(dllimport)
#else
#define PLUGIN_API
#endif
