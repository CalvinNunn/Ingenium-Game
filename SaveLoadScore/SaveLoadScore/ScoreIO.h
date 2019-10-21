#pragma once

#include "PluginSettings.h"
#include <string>
#include <fstream>

using namespace std;

class PLUGIN_API ScoreIO {
public:
	void saveScore(int score);
	
	int loadScore();
	void clearFile();

private:
	ifstream inFile;
	ofstream outFile;
};