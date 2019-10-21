#include "ScoreIO.h"

void ScoreIO::saveScore(int score) {
	outFile.open("score.txt");

	outFile << to_string(score);

	outFile.close();
}

void ScoreIO::clearFile() {
	outFile.open("score.txt");
	outFile.clear();
}

int ScoreIO::loadScore() {
	inFile.open("score.txt");
	string line;

	if (inFile.is_open()) {
		while (getline(inFile, line));

	}
	inFile.close();
	int x = stoi(line);
	return x;
}