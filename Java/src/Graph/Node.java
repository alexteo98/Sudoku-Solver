package Graph;

import java.util.ArrayList;
import java.util.List;
import java.util.TreeSet;
import java.util.stream.IntStream;

public class Node {
    public boolean solved;
    public int value;
    int[] location = new int[2];
    private TreeSet<Integer> possibleValues;
    public List<Node> rowNeighbors, columnNeighbors, groupNeighbors;

    public Node(int x, int y){
        location[0] = x;
        location[1] = y;
        setup();
    }

    private void setup(){
        solved = false;
        value = 0;
        possibleValues = new TreeSet<>();
        IntStream.range(1,10).forEach(possibleValues::add);

        rowNeighbors = new ArrayList<>();
        columnNeighbors = new ArrayList<>();
        groupNeighbors = new ArrayList<>();
    }

    public void initValue(int val){
        value = val;
        possibleValues.clear();
        solved = true;
    }

    public void addRowNeighbor(Node n){
        if (n == this) return;
        rowNeighbors.add(n);
    }
    public void addColumnNeighbor(Node n){
        if (n == this) return;
        columnNeighbors.add(n);
    }
    public void addGroupNeighbor(Node n){
        if (n == this) return;
        groupNeighbors.add(n);
    }

    public TreeSet<Integer> getPossibleValues(){
        return this.possibleValues;
    }

    public void removePossible(int n){
        possibleValues.remove(n);
    }

    public boolean isSolved(){
        if (solved) return true;
        if (possibleValues.size() == 1){
            value = possibleValues.first();
            solved = true;
            //Propagate to neighbors
            propagateNeighbors(value);
            return true;
        }
        return false;
    }

    public void propagateNeighbors(int val){
        rowNeighbors.stream().forEach(x->x.removePossible(val));
        columnNeighbors.stream().forEach(x->x.removePossible(val));
        groupNeighbors.stream().forEach(x->x.removePossible(val));
    }

    @Override
    public boolean equals(Object o){
        if (!(o instanceof Node)) return false;
        Node n = (Node) o;
        return this.location.equals(n.location);
    }
}
