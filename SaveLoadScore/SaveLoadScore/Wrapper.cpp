#include "Wrapper.h"

ScoreIO io;

int loadScore() {
	return io.loadScore();
}

void clearFile() {
	return io.clearFile();
}

void saveScore(int score) {
	return io.saveScore(score);
}