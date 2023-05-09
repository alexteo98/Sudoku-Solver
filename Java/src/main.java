import Sudoku.*;

import java.util.ArrayList;
import java.util.List;

import Sudoku.SampleSudokuManager;

public class main {
    public static void main (String args[]){



//        Sudoku s1 = new SampleSudokuManager().Sample2;
//        System.out.println(s1.printSudoku());
//        s1.solve();
//        System.out.println(s1.printSudoku());

        JsonSudokuParser parser = new JsonSudokuParser("C:\\Users\\alext\\source\\repos\\Sudoku-Solver\\Java\\src\\Sudoku\\JsonSampleSudoku1.json");
        parser.parse();
        Sudoku s = parser.sudoku;
        System.out.println(s.printSudoku());
        s.solve();
        System.out.println(s.printSudoku());

    }
}
