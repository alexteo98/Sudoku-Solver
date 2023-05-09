package Sudoku;

import java.util.ArrayList;
import java.util.List;

class SampleSudokuBuilder {
    protected Sudoku sudoku = new Sudoku();
    protected List<int[]> initVals = new ArrayList<>();

    protected void addInitVal(int x, int y, int val) {
        initVals.add(new int[]{x, y, val});
    }

    public Sudoku build() {
        sudoku.initValues(initVals);
        return sudoku;
    }
}
