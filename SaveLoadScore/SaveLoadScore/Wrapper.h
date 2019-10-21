#pragma once
#include "PluginSettings.h"
#include "ScoreIO.h"

#ifdef __cplusplus
extern "C"
{
#endif

	PLUGIN_API int loadScore();
	PLUGIN_API void saveScore(int score);
	PLUGIN_API void clearFile();

#ifdef __cplusplus
}
#endif
