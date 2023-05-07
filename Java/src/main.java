import Sudoku.Sudoku;

import java.util.ArrayList;
import java.util.List;

import Sudoku.SampleSudokuManager;

public class main {
    public static void main (String args[]){



        Sudoku s1 = new SampleSudokuManager().Sample2;
        System.out.println(s1.printSudoku());
        s1.solve();
        System.out.println(s1.printSudoku());

    }
}
