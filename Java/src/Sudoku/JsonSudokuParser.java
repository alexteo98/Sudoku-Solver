package Sudoku;

import Graph.Node;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;

import java.io.FileReader;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;


public class JsonSudokuParser {
    JSONParser parser = new JSONParser();
    String path = "";
    SampleSudokuBuilder builder = new SampleSudokuBuilder();
    public Sudoku sudoku;

    public JsonSudokuParser(String filePath){
        this.path = Path.of(filePath).toAbsolutePath().toString();
    }

    public void parse(){
        try{
            JSONObject jsonObject = (JSONObject) parser.parse(new FileReader(this.path));

            jsonObject.forEach((x, y) -> parseValues(x.toString(),y.toString()));

            sudoku = builder.build();
            int i =0;
        } catch (Exception e){
            int i =0;
        }
    }

    private void parseValues(String index, String value){
        int ix=-1, iy=-1, val=0;
        Node n;
        String[] s = index.split("\\.");
        if (s.length == 2){
            ix = Integer.valueOf(s[0]);
            iy = Integer.valueOf(s[1]);
            n = new Node(ix,iy);
            val = Integer.valueOf(value);
            if (val != 0) builder.addInitVal(ix,iy,val);
        }
    }
}
