package Sudoku;

import Graph.Node;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.PriorityQueue;
import java.util.stream.IntStream;

public class Sudoku {
    Node[][] grid;
    PriorityQueue<Node> unsolvedNodes;

    Comparator<Node> nodePossibleValuesCmp = Comparator.comparingInt(o -> o.getPossibleValues().size());

    public Sudoku(){
        grid = new Node[9][9];
        unsolvedNodes = new PriorityQueue<>(nodePossibleValuesCmp);
        createNodes();
        linkColumns();
        linkGroups();
        linkRows();
    }

    public void initValues(List<int[]> values){
        for (int[] value: values) {
            Node n = grid[value[0]][value[1]];
            unsolvedNodes.remove(n);
            n.initValue(value[2]);
            n.propagateNeighbors(value[2]);
        }
    }

    public void createNodes(){
        for (int i=0;i<9;i++){
            for (int j=0;j<9;j++){
                Node n = new Node(i,j);
                grid[i][j] = n;
                unsolvedNodes.add(n);
            }
        }
    }

    public void linkRows(){
        for (int r=0;r<9;r++) {
            Node[] row = getRow(r);
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    row[i].addRowNeighbor(row[j]);
                }
            }
        }
    }

    public void linkColumns(){
        for (int c=0;c<9;c++) {
            Node[] columns = getColumn(c);
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    columns[i].addColumnNeighbor(columns[j]);
                }
            }
        }
    }

    public void linkGroups(){
        for (int g=0;g<9;g++) {
            Node[] columns = getGroup(g);
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    columns[i].addGroupNeighbor(columns[j]);
                }
            }
        }
    }

    public Node[] getRow(int rowIndex){
        Node[] row = new Node[9];
        for (int i = 0;i<9;i++){
            row[i] = grid[rowIndex][i];
        }
        return row;
    }

    public Node[] getColumn(int colIndex){
        Node[] column = new Node[9];
        for (int i = 0;i<9;i++){
            column[i] = grid[i][colIndex];
        }
        return column;
    }

    public Node[] getGroup(int grpIndex){
        Node[] group = new Node[9];

        int startRow = (grpIndex / 3) * 3;
        int startCol = (grpIndex % 3) * 3;

        int index = 0; // Index for the group array

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                group[index] = grid[startRow + i][startCol + j];
                index++;
            }
        }

        return group;
    }

    public void solve(){
        while (unsolvedNodes.size() != 0) {
            Node n = unsolvedNodes.remove();
            if (n.isSolved()) {
                n.propagateNeighbors(n.value);
                for (Node r : n.rowNeighbors) {
                    if (unsolvedNodes.contains(r)) {
                        unsolvedNodes.remove(r);
                        unsolvedNodes.add(r);
                    }
                }
                for (Node c : n.columnNeighbors) {
                    if (unsolvedNodes.contains(c)) {
                        unsolvedNodes.remove(c);
                        unsolvedNodes.add(c);
                    }
                }
                for (Node g : n.groupNeighbors) {
                    if (unsolvedNodes.contains(g)) {
                        unsolvedNodes.remove(g);
                        unsolvedNodes.add(g);
                    }
                }
            } else {
                unsolvedNodes.add(n);
            }
        }
    }


    public String printSudoku(){
        StringBuilder sb = new StringBuilder();

        for (int i=0;i<9;i++){
            for (int j = 0;j<9;j++){
                sb.append(grid[i][j].value);
                if (j%3==2) sb.append(" ");
            }
            sb.append("\n");
            if (i%3==2) sb.append(" ".repeat(11)).append("\n");
        }

        return sb.toString();
    }
}
