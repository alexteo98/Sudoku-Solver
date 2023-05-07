package Sudoku;

import java.util.ArrayList;
import java.util.List;

public class SampleSudokuManager{
    public Sudoku Sample1 = new SampleSudoku1Builder().build();
    public Sudoku Sample2 = new SampleSudoku2Builder().build();
}

abstract class SampleSudokuBuilder{
    protected Sudoku sudoku = new Sudoku();
    protected List<int[]> initVals = new ArrayList<>();

    protected void addInitVal(int x,int y, int val){
        initVals.add(new int[]{x,y,val});
    }

    public Sudoku build() {
        sudoku.initValues(initVals);
        return sudoku;
    }
}

class SampleSudoku1Builder extends SampleSudokuBuilder{
    public SampleSudoku1Builder(){
        // Row 1
        addInitVal(0,2,5);
        addInitVal(0,3,2);
        addInitVal(0,5,8);
        addInitVal(0,7,1);
        // Row 2
        addInitVal(1,1,9);
        addInitVal(1,2,8);
        addInitVal(1,4,1);
        addInitVal(1,5,7);
        addInitVal(1,7,5);
        // Row 3
        addInitVal(2,0,7);
        addInitVal(2,2,4);
        addInitVal(2,4,6);
        addInitVal(2,8,9);
        // Row 4
        addInitVal(3,0,4);
        addInitVal(3,3,9);
        addInitVal(3,6,2);
        addInitVal(3,8,7);
        // Row 5
        addInitVal(4,0,1);
        addInitVal(4,8,6);
        // Row 6
        addInitVal(5,0,8);
        addInitVal(5,2,3);
        addInitVal(5,5,2);
        addInitVal(5,8,1);
        // Row 7
        addInitVal(6,0,3);
        addInitVal(6,4,2);
        addInitVal(6,6,4);
        addInitVal(6,8,5);
        // Row 8
        addInitVal(7,1,6);
        addInitVal(7,3,5);
        addInitVal(7,4,4);
        addInitVal(7,6,1);
        addInitVal(7,7,7);
        // Row 9
        addInitVal(8,1,4);
        addInitVal(8,3,7);
        addInitVal(8,5,9);
        addInitVal(8,6,3);
    }
}

class SampleSudoku2Builder extends SampleSudokuBuilder{
    public SampleSudoku2Builder(){
        // Row 1
        addInitVal(0,2,8);
        addInitVal(0,4,6);
        addInitVal(0,6,4);
        // Row 2
        addInitVal(1,0,7);
        addInitVal(1,3,9);
        addInitVal(1,5,2);
        // Row 3
        addInitVal(2,2,3);
        addInitVal(2,3,8);
        addInitVal(2,5,7);
        addInitVal(2,8,9);
        // Row 4
        addInitVal(3,0,5);
        addInitVal(3,2,7);
        addInitVal(3,5,6);
        // Row 5
        addInitVal(4,1,8);
        addInitVal(4,4,9);
        addInitVal(4,7,1);
        // Row 6
        addInitVal(5,3,1);
        addInitVal(5,6,5);
        addInitVal(5,8,2);
        // Row 7
        addInitVal(6,0,2);
        addInitVal(6,3,5);
        addInitVal(6,5,8);
        addInitVal(6,6,3);
        // Row 8
        addInitVal(7,3,6);
        addInitVal(7,5,9);
        addInitVal(7,8,5);
        // Row 9
        addInitVal(8,2,6);
        addInitVal(8,4,2);
        addInitVal(8,6,7);
    }
}